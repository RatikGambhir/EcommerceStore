import { Button, Container, Divider, Link, Paper, Typography } from "@mui/material";
import { useHistory } from "react-router-dom";

export default function NotFound() {
	const history = useHistory();

	return (
		<Container component={Paper} sx={{ height: 400 }}>
			<Typography gutterBottom variant="h3">
				Oops! We could not find what you are looking for. Please Try again!
			</Typography>
			<Divider />
			<Button onClick={() => history.push("/")} fullWidth>
				Go back to Home page
			</Button>
		</Container>
	);
}
