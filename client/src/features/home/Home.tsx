import { useEffect } from "react";
import { Article } from "../../app/model/news";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import ArticleList from "./ArticleList";
import { getNewsAsync } from "./newsSlice";
import { Grid, Typography } from "@mui/material";

interface Props {
	articles: Article;
}

export default function HomePage({ articles }: Props) {
	const { news } = useAppSelector((state) => state.news);
	const dispatch = useAppDispatch();

	useEffect(() => {
		dispatch(getNewsAsync());
	}, [dispatch]);

	return (
		<>
			<Typography variant="h2" gutterBottom={true}>
				What's happening around the league?
			</Typography>
			<Grid container spacing={12} columnSpacing={{ sm: 2 }} marginBottom={20}>
				<Grid item>
					<ArticleList />
				</Grid>
			</Grid>
		</>
	);
}
