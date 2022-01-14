import { LoadingButton } from "@mui/lab";
import { Avatar, Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { useState } from "react";
import { Link } from "react-router-dom";
import service from "../../app/api/service";
import { Product } from "../../app/model/product";
import { useAppDispatch } from "../../app/store/configureStore";
import { setBasket } from "../basket/basketSlice";

interface Props {
	product: Product;
}

export default function ProductCard({ product }: Props) {
	const [loading, setLoading] = useState(false);
	const dispatch = useAppDispatch();

	function AddItemToCart(productId: number) {
		setLoading(true);
		service.Basket.addItem(productId)
			.then((basket) => dispatch(setBasket(basket)))
			.catch((error) => console.log(error))
			.finally(() => setLoading(false));
	}

	return (
		<Card>
			<CardHeader
				avatar={<Avatar sx={{ bgcolor: "secondary.main" }}>{product.name.charAt(0).toUpperCase()}</Avatar>}
				title={product.name}
				titleTypographyProps={{
					sx: { fontWeight: "bold", color: "primary.main" },
				}}
			/>
			<CardMedia sx={{ height: 200, backgroundSize: "contain", bgcolor: "primary.light" }} component="img" height="140" image={product.picture} alt="green iguana" title={product.name} />
			<CardContent>
				<Typography gutterBottom variant="h5" color="secondary" sx={{ color: "green" }}>
					${(product.price / 100).toFixed(2)}
				</Typography>
				<Typography variant="body2" color="text.secondary">
					{product.brand} / {product.type}
				</Typography>
			</CardContent>
			<CardActions>
				<LoadingButton loading={loading} onClick={() => AddItemToCart(product.id)} size="small">
					Add To Cart
				</LoadingButton>
				<Button component={Link} to={`/catalog/${product.id}`} size="small">
					View
				</Button>
			</CardActions>
		</Card>
	);
}
