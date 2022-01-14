import { Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Product } from "../../app/model/product";
import service from "../../app/api/service";
import NotFound from "../../app/errors/NotFound";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { LoadingButton } from "@mui/lab";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { removeItem, setBasket } from "../basket/basketSlice";

export default function ProductDetails() {
	const { basket } = useAppSelector((state) => state.basket);
	const dispatch = useAppDispatch();
	const { id } = useParams<{ id: string }>();
	const [products, setProducts] = useState<Product | null>(null);
	const [loading, setLoading] = useState(true);
	const [itemQuantity, setItemQuantity] = useState(0);
	const [submitting, setSubmitting] = useState(false);

	const item = basket?.items.find((i) => i.productId === products?.id);

	useEffect(() => {
		if (item) setItemQuantity(item.quantity);
		service.Catalog.details(parseInt(id))
			.then((response) => setProducts(response))
			.catch((error) => console.log(error))
			.finally(() => setLoading(false));
	}, [id, item]);

	function inputChange(event: any) {
		if (event.target.value >= 0) {
			setItemQuantity(parseInt(event.target.value));
		}
	}

	function handleUpdateCard() {
		setSubmitting(true);
		if (!item || itemQuantity > item?.quantity) {
			const updatedQuantity = item ? itemQuantity - item.quantity : itemQuantity;
			service.Basket.addItem(products?.id!, updatedQuantity)
				.then((basket) => dispatch(setBasket(basket)))
				.catch((error) => console.log(error))
				.finally(() => setSubmitting(false));
		} else {
			const updatedQuantity = item.quantity - itemQuantity;
			service.Basket.removeItem(products?.id!, updatedQuantity)
				.then(() => dispatch(removeItem({ productId: products?.id!, quantity: updatedQuantity })))
				.catch((error) => console.log(error))
				.finally(() => setSubmitting(false));
		}
	}

	if (loading) return <LoadingComponent message="Loading Product details..." />;

	if (!products) return <NotFound />;

	return (
		<Grid container spacing={6}>
			<Grid item xs={6}>
				<img src={products.picture} alt={products.name} style={{ width: "100%" }} />
			</Grid>
			<Grid item xs={6}>
				<Typography variant="h3">{products.name}</Typography>
				<Divider sx={{ mb: 2 }} />
				<Typography variant="h4" color="secondary">
					${(products.price / 100).toFixed(2)}
				</Typography>
				<TableContainer>
					<Table>
						<TableBody>
							<TableRow>
								<TableCell>Name</TableCell>
								<TableCell>{products.name}</TableCell>
							</TableRow>
							<TableRow>
								<TableCell>Description</TableCell>
								<TableCell>{products.description}</TableCell>
							</TableRow>
							<TableRow>
								<TableCell>Type</TableCell>
								<TableCell>{products.type}</TableCell>
							</TableRow>
							<TableRow>
								<TableCell>Brand</TableCell>
								<TableCell>{products.brand}</TableCell>
							</TableRow>
							<TableRow>
								<TableCell>Quanity in stock</TableCell>
								<TableCell>{products.quantityInStock}</TableCell>
							</TableRow>
						</TableBody>
					</Table>
				</TableContainer>
				<Grid container spacing={2}>
					<Grid item xs={6}>
						<TextField variant="outlined" type="number" label="Quantity in Cart" fullWidth value={itemQuantity} onChange={inputChange} />
					</Grid>
					<Grid item xs={6}>
						<LoadingButton
							disabled={item?.quantity === itemQuantity || (!item && itemQuantity === 0)}
							onClick={handleUpdateCard}
							loading={submitting}
							sx={{ height: "55px" }}
							color="primary"
							size="large"
							variant="contained"
							fullWidth
						>
							{item ? "Update Quantity" : "Add To Cart"}
						</LoadingButton>
					</Grid>
				</Grid>
			</Grid>
		</Grid>
	);
}
