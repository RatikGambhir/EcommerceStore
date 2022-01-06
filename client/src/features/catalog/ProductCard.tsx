import { Avatar, Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Product } from "../../app/model/product";

interface Props {
	product: Product;
}

export default function ProductCard({ product }: Props) {
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
				<Button size="small">Add To Cart</Button>
				<Button size="small">View</Button>
			</CardActions>
		</Card>
	);
}