import ProductList from "../../features/catalog/ProductList";
import { useEffect } from "react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { getFiltersByType, getProductsAsync, productSelector } from "./catalogSlice";
import { Box, Grid, Pagination, Paper, Typography } from "@mui/material";
import ProductSearch from "./ProductSearch";
import RadioButtonFilter from "../../app/components/RadioButton";
import { setProductParams } from "./catalogSlice";
import CheckBoxButtons from "../../app/components/CheckBoxButtons";
import AppPagination from "../../app/components/Pagination";

const sortOptions = [
	{ value: "name", label: "Alphabetical" },
	{ value: "priceDesc", label: "Price - High to low" },
	{ value: "price", label: "Price - Low to High" },
];

export default function Catalog() {
	const products = useAppSelector(productSelector.selectAll);
	const { productsLoaded, status, filtersLoaded, types, productParams, metaData } = useAppSelector((state) => state.catalog);
	const dispatch = useAppDispatch();

	useEffect(() => {
		if (!productsLoaded) dispatch(getProductsAsync());
	}, [productsLoaded, dispatch]);

	useEffect(() => {
		if (!filtersLoaded) dispatch(getFiltersByType());
	}, [dispatch, filtersLoaded]);

	if (!filtersLoaded) return <LoadingComponent message="Loading Products..." />;

	return (
		<Grid container spacing={4}>
			<Grid item xs={3}>
				<Paper sx={{ mb: 2 }}>
					<ProductSearch />
				</Paper>
				<Paper sx={{ mb: 2, p: 2 }}>
					<RadioButtonFilter selectedValue={productParams.orderBy} options={sortOptions} onChange={(event) => dispatch(setProductParams({ orderBy: event.target.value }))} />
				</Paper>
				<Paper sx={{ mb: 2, p: 2 }}>
					<CheckBoxButtons
						items={types}
						checked={productParams.types}
						onChange={(items: string[]) =>
							dispatch(
								setProductParams({
									types: items,
								})
							)
						}
					/>
				</Paper>
			</Grid>

			<Grid item xs={9}>
				<ProductList products={products} />
			</Grid>
			<Grid item xs={3} />
			<Grid item xs={9}>
				{metaData && <AppPagination metaData={metaData} onPageChange={(page: number) => dispatch(setProductParams({ pageNumber: page }))} />}
			</Grid>
		</Grid>
	);
}
