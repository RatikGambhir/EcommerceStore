import { Button, Card, CardActions, CardContent, CardHeader, CardMedia, Link, Typography } from "@mui/material";
import { Article, NFLNews } from "../../app/model/news";
import { useAppSelector } from "../../app/store/configureStore";

interface Props {
	article: Article;
	
}

export default function ArticleCard({ article }: Props) {
	const { news } = useAppSelector((state) => state.news);
	const descriptionStyle = {
		display: "flex",
		alignContent: "center",
		alignItems: "center",
		justifyContent: "center",
	};

	return (
		<Card sx={{ height: 600, display: "inline-block" }}>
			<CardHeader
				title={article.headline}
				titleTypographyProps={{
					sx: { fontWeight: "bold", color: "primary.main" },
				}}
			/>
			<CardMedia sx={{ height: 200, backgroundSize: "contain", bgcolor: "primary.light", display: "block", margin: "auto"}} component="img" height="130" image={article.images[0].url} alt="green iguana" title={article.headline} />
			<CardContent>
				<Typography sx={descriptionStyle} variant="body2" color="text.secondary">
					{article.description}
				</Typography>
			</CardContent>
			<CardActions>
			<Button sx={{marginBottom: 10}} size="small" href={news?.link.href}>View more news</Button>
			</CardActions>
		</Card>
	);
}
