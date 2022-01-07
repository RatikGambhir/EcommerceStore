import { Product } from "../../app/model/product";
import ProductList from "../../features/catalog/ProductList";
import { useState, useEffect } from "react";
import service from "../../app/api/service";

export default function Catalog() {
	const [products, setProducts] = useState<Product[]>([]);

	useEffect(() => {
		service.Catalog.list().then((products) => setProducts(products));
	}, []);

	return (
		<>
			<ProductList products={products} />
		</>
	);
}
