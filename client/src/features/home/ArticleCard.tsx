import { Card, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Article } from "../../app/model/news";

interface Props {
	article: Article;
}

export default function ArticleCard({ article }: Props) {
	const descriptionStyle = {
		alignContent: "center",
		alignItems: "center",
	};

	return (
		<Card sx={{ height: 600 }}>
			<CardHeader
				title={article.headline}
				titleTypographyProps={{
					sx: { fontWeight: "bold", color: "primary.main" },
				}}
			/>
			<CardMedia sx={{ height: 250, backgroundSize: "contain", bgcolor: "primary.light" }} component="img" height="130" image={article.images[0].url} alt="green iguana" title={article.headline} />
			<CardContent>
				<Typography sx={descriptionStyle} variant="body2" color="text.secondary">
					{article.description}
				</Typography>
			</CardContent>
			{/* <CardActions>
				<Link to={link.} size="small">
					Go to Article
				</Link>
			</CardActions> */}
		</Card>
	);
}
