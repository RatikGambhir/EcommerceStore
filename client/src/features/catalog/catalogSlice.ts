import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import { Product, ProductParams } from "../../app/model/product";
import service from "../../app/api/service";
import { RootState } from "../../app/store/configureStore";
import { MetaData } from "../../app/model/pagination";

interface CatalogState {
	productsLoaded: boolean;
	filtersLoaded: boolean;
	status: string;
	brands: string[];
	types: string[];
	productParams: ProductParams;
	metaData: MetaData | null;
}

const productsAdapter = createEntityAdapter<Product>();

function getAxiosparams(productParams: ProductParams) {
	const params = new URLSearchParams();
	params.append("pageNumber", productParams.pageNumber.toString());
	params.append("pageSize", productParams.pageSize.toString());
	params.append("orderBy", productParams.orderBy.toString());

	if (productParams.searchTerm) params.append("searchName", productParams.searchTerm);
	if (productParams.brands) params.append("brands", productParams.brands.toString());
	if (productParams.types) params.append("types", productParams.types.toString());

	return params;
}

export const getProductsAsync = createAsyncThunk<Product[], void, { state: RootState }>("catalog/getProductsAsync", async (_, thunkAPI) => {
	try {
		const params = getAxiosparams(thunkAPI.getState().catalog.productParams);
		const response = await service.Catalog.list(params);
		thunkAPI.dispatch(setMetaData(response.metaData));
		return response.items;
	} catch (error: any) {
		return thunkAPI.rejectWithValue({ error: error.data });
	}
});

export const getProductsByIdAsync = createAsyncThunk<Product, number>("catalog/getProductsByIdAsync", async (productId, thunkAPI) => {
	try {
		return await service.Catalog.details(productId);
	} catch (error: any) {
		return thunkAPI.rejectWithValue({ error: error.data });
	}
});

export const getFiltersByType = createAsyncThunk("catalog/getFiltersByType", async (_, thunkAPI) => {
	try {
		return service.Catalog.filters();
	} catch (error: any) {
		return thunkAPI.rejectWithValue({ error: error.data });
	}
});

function initParams() {
	return {
		pageNumber: 1,
		pageSize: 6,
		orderBy: "name",
	};
}

export const catalogSlice = createSlice({
	name: "catalog",
	initialState: productsAdapter.getInitialState<CatalogState>({
		productsLoaded: false,
		filtersLoaded: false,
		status: "idle",
		brands: [],
		types: [],
		productParams: initParams(),
		metaData: null,
	}),
	reducers: {
		setProductParams: (state, action) => {
			state.productsLoaded = false;
			state.productParams = { ...state.productParams, ...action.payload };
		},
		setMetaData: (state, action) => {
			state.metaData = action.payload;
		},
		resetProductParams: (state) => {
			state.productParams = initParams();
		},
	},
	extraReducers: (builder) => {
		builder.addCase(getProductsAsync.pending, (state) => {
			state.status = "pendingGetProducts";
		});
		builder.addCase(getProductsAsync.fulfilled, (state, action) => {
			productsAdapter.setAll(state, action.payload);
			state.status = "idle";
			state.productsLoaded = true;
		});
		builder.addCase(getProductsAsync.rejected, (state) => {
			state.status = "idle";
		});
		builder.addCase(getProductsByIdAsync.pending, (state) => {
			state.status = "pendingGetProductById";
		});
		builder.addCase(getProductsByIdAsync.fulfilled, (state, action) => {
			productsAdapter.upsertOne(state, action.payload);
			state.status = "idle";
		});
		builder.addCase(getProductsByIdAsync.rejected, (state, action) => {
			console.log(action);
			state.status = "idle";
		});
		builder.addCase(getFiltersByType.pending, (state) => {
			state.status = "pendingGetFilters";
		});
		builder.addCase(getFiltersByType.fulfilled, (state, action) => {
			state.brands = action.payload.brands;
			state.types = action.payload.types;
			state.filtersLoaded = true;
		});
		builder.addCase(getFiltersByType.rejected, (state, action) => {
			state.status = "idle";
			console.log(action.payload);
		});
	},
});

export const productSelector = productsAdapter.getSelectors((state: RootState) => state.catalog);

export const { setProductParams, resetProductParams, setMetaData } = catalogSlice.actions;
