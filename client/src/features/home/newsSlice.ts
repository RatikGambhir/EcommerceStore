import { NFLNews } from "../../app/model/news";
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import service from "../../app/api/service";

interface NewsState {
	news: NFLNews | null;
	newsLoading: string;
}

const initialState: NewsState = {
	news: null,
	newsLoading: "idle",
};

export const getNewsAsync = createAsyncThunk<NFLNews>("getNFLNewsAsync", async (_, thunkAPI) => {
	try {
		return service.News.getNews();
	} catch (error: any) {
		thunkAPI.rejectWithValue({ error: error.data });
	}
});

export const newsSlice = createSlice({
	name: "news",
	initialState,
	reducers: {},
	extraReducers: (builder) => {
		builder.addCase(getNewsAsync.pending, (state) => {
			console.log(state);
			state.newsLoading = "pendingNews";
		});
		builder.addCase(getNewsAsync.fulfilled, (state, action) => {
			state.news = action.payload;
			state.newsLoading = "idle";
		});
		builder.addCase(getNewsAsync.rejected, (state) => {
			state.newsLoading = "idle";
		});
	},
});
