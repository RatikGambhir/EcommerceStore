import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import { Product } from "../../app/model/product";
import service from "../../app/api/service";
import { RootState } from "../../app/store/configureStore";

const productsAdapter = createEntityAdapter<Product>();

export const getProductsAsync = createAsyncThunk<Product[]>("catalog/getProductsAsync", async (_, thunkAPI) => {
	try {
		return await service.Catalog.list();
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

export const catalogSlice = createSlice({
	name: "catalog",
	initialState: productsAdapter.getInitialState({
		productsLoaded: false,
		status: "idle",
	}),
	reducers: {},
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
	},
});

export const productSelector = productsAdapter.getSelectors((state: RootState) => state.catalog);
