import ProductList from "../../features/catalog/ProductList";
import { useEffect } from "react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { getProductsAsync, productSelector } from "./catalogSlice";

export default function Catalog() {
	const products = useAppSelector(productSelector.selectAll);
	const { productsLoaded, status } = useAppSelector((state) => state.catalog);
	const dispatch = useAppDispatch();

	useEffect(() => {
		if (!productsLoaded) dispatch(getProductsAsync());
	}, [productsLoaded, dispatch]);

	if (status.includes("pending")) return <LoadingComponent message="Loading Products..." />;

	return (
		<>
			<ProductList products={products} />
		</>
	);
}
