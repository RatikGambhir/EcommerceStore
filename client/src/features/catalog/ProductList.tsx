import { Grid } from "@mui/material";
import { Product } from "../../app/model/product";
import ProductCard from "../../features/catalog/ProductCard";
import { useAppSelector } from "../../app/store/configureStore";
import ProductCardSkeleton from "./ProductSkeleton";

interface Props {
	products: Product[];
}

export default function ProductList({ products }: Props) {
	const { productsLoaded } = useAppSelector((state) => state.catalog);
	return (
		<Grid container spacing={4}>
			{products.map((product) => (
				<Grid item xs={4} key={product.id}>
					{!productsLoaded ? <ProductCardSkeleton /> : <ProductCard product={product} />}
				</Grid>
			))}
		</Grid>
	);
}
