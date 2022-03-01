import { Grid } from "@mui/material";
import { useAppSelector } from "../../app/store/configureStore";
import ProductCardSkeleton from "../catalog/ProductSkeleton";
import ArticleCard from "./ArticleCard";

export default function ProductList() {
	const { news, newsLoading } = useAppSelector((state) => state.news);
	return (
		<Grid container spacing={4}>
			{news?.articles.map((newsItem) => (
				<Grid item key={newsItem.description} xs={4}>
					{newsLoading === "pendingNews" ? <ProductCardSkeleton /> : <ArticleCard article={newsItem} />}
				</Grid>
			))}
		</Grid>
	);
}
