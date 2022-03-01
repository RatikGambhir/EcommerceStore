import { createAsyncThunk, createSlice, isAnyOf } from "@reduxjs/toolkit";
import { act } from "react-dom/test-utils";
import thunk from "redux-thunk";
import service from "../../app/api/service";
import { Basket } from "../../app/model/basket";
import { toast } from "react-toastify";
import { getCookie } from "../../app/util/util";

interface BasketState {
	basket: Basket | null;
	status: string;
}

const initialState: BasketState = {
	basket: null,
	status: "idle",
};

export const getUserBasketAsync = createAsyncThunk<Basket>(
	"basket/getUserBaksetAsync",
	async (_, thunkAPI) => {
		try {
			return service.Basket.getBasket();
		} catch (error: any) {
			return thunkAPI.rejectWithValue({ error: error.data });
		}
	},
	{
		condition: () => {
			if (!getCookie("buyerId")) return false;
		},
	}
);

export const addBasketItemAsync = createAsyncThunk<Basket, { productId: number; quantity?: number }>("basket/addBasketItemAsync", async ({ productId, quantity }, thunkAPI) => {
	try {
		toast.success("Item added to cart!", { position: toast.POSITION.TOP_LEFT, autoClose: 6000 });
		return await service.Basket.addItem(productId, quantity);
	} catch (error: any) {
		return thunkAPI.rejectWithValue({ error: error.data });
	}
});

export const removeBasketItemAsync = createAsyncThunk<void, { productId: number; quantity?: number; name?: string }>("basket/removeBasketItemAsync", async ({ productId, quantity }, thunkAPI) => {
	try {
		toast.success("Item removed from cart!", { position: toast.POSITION.TOP_LEFT, autoClose: 6000 });
		await service.Basket.removeItem(productId, quantity);
	} catch (error: any) {
		return thunkAPI.rejectWithValue({ error: error.data });
	}
});

export const basketSlice = createSlice({
	name: "basket",
	initialState,
	reducers: {
		setBasket: (state, action) => {
			state.basket = action.payload;
		},
		clearBasket: (state) => {
			state.basket = null;
		},
	},
	extraReducers: (builder) => {
		builder.addCase(addBasketItemAsync.pending, (state, action) => {
			console.log(action);
			state.status = "pendingAddItem" + action.meta.arg.productId;
		});

		builder.addCase(removeBasketItemAsync.pending, (state, action) => {
			state.status = "pendingRemoveItem" + action.meta.arg.productId + action.meta.arg.name;
		});
		builder.addCase(removeBasketItemAsync.fulfilled, (state, action) => {
			const { productId, quantity } = action.meta.arg;
			const itemIndex = state.basket?.items.findIndex((i) => i.productId == productId);
			if (itemIndex === -1 || itemIndex === undefined) return;
			state.basket!.items[itemIndex].quantity -= quantity!;
			if (state.basket!.items[itemIndex].quantity === 0) state.basket!.items.splice(itemIndex, 1);
			state.status = "idle";
		});
		builder.addCase(removeBasketItemAsync.rejected, (state, action) => {
			console.log(action);
			state.status = "idle";
		});
		builder.addMatcher(isAnyOf(addBasketItemAsync.fulfilled, getUserBasketAsync.fulfilled), (state, action) => {
			state.basket = action.payload;
			state.status = "idle";
		});
		builder.addMatcher(isAnyOf(addBasketItemAsync.rejected, getUserBasketAsync.rejected), (state, action) => {
			console.log(action.payload);
			state.status = "idle";
		});
		// builder.addCase(removeBasketItemAsync.pending, (state, action) => {
		// 	state.status = "pendingDeleteItem" + action.meta.arg.productId;
		// });
	},
});

export const { setBasket, clearBasket } = basketSlice.actions;
