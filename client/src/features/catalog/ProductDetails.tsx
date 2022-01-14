import { Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import NotFound from "../../app/errors/NotFound";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { LoadingButton } from "@mui/lab";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { addBasketItemAsync, removeBasketItemAsync } from "../basket/basketSlice";
import { getProductsByIdAsync, productSelector } from "./catalogSlice";

export default function ProductDetails() {
	const { basket, status } = useAppSelector((state) => state.basket);
	const dispatch = useAppDispatch();
	const { id } = useParams<{ id: string }>();
	const products = useAppSelector((state) => productSelector.selectById(state, id));
	const [itemQuantity, setItemQuantity] = useState(0);
	const { status: productStatus } = useAppSelector((state) => state.catalog);

	const item = basket?.items.find((i) => i.productId === products?.id);

	useEffect(() => {
		if (item) setItemQuantity(item.quantity);
		if (!products) dispatch(getProductsByIdAsync(parseInt(id)));
	}, [id, item, dispatch, products]);

	function inputChange(event: any) {
		if (event.target.value >= 0) {
			setItemQuantity(parseInt(event.target.value));
		}
	}

	function handleUpdateCard() {
		if (!item || itemQuantity > item?.quantity) {
			const updatedQuantity = item ? itemQuantity - item.quantity : itemQuantity;
			dispatch(addBasketItemAsync({ productId: products?.id!, quantity: updatedQuantity }));
		} else {
			const updatedQuantity = item.quantity - itemQuantity;
			dispatch(removeBasketItemAsync({ productId: products?.id!, quantity: updatedQuantity }));
		}
	}

	if (productStatus.includes("pending")) return <LoadingComponent message="Loading Product details..." />;

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
							loading={status.includes("pending")}
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
