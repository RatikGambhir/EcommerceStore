import { Product } from "../../app/model/product";
import ProductList from "../../features/catalog/ProductList";
import { useState, useEffect } from "react";
import service from "../../app/api/service";
import LoadingComponent from "../../app/layout/LoadingComponent";

export default function Catalog() {
	const [products, setProducts] = useState<Product[]>([]);
	const [loading, setLoading] = useState(true);

	useEffect(() => {
		service.Catalog.list()
			.then((products) => setProducts(products))
			.catch((error) => console.log(error))
			.finally(() => setLoading(false));
	}, []);

	if (loading) return <LoadingComponent message="Loading Products..." />;

	return (
		<>
			<ProductList products={products} />
		</>
	);
}
