import { createSlice } from "@reduxjs/toolkit";

export interface CounterState {
	data: number;
	title: string;
}

const initialState: CounterState = {
	data: 42,
	title: "Ratik is cooler than all of you!!!!",
};

export const counterSlice = createSlice({
	name: "count",
	initialState,
	reducers: {
		increment: (state, action) => {
			state.data += action.payload;
		},
		decrement: (state, action) => {
			state.data -= action.payload;
		},
	},
});

export const { increment, decrement } = counterSlice.actions;
