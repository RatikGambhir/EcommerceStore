import { Alert, AlertTitle, ButtonGroup, Container, List, ListItem, ListItemText, Typography } from "@mui/material";
import { useState } from "react";
import service from "../../app/api/service";

export default function AboutPage() {
	const [validationErrors, setValidationErrors] = useState<string[]>([]);

	function getValidationError() {
		service.TestErrors.getValidationError()
			.then(() => console.log("should not see this"))
			.catch((error) => setValidationErrors(error));
	}

	return (
		<Container>
			<Typography gutterBottom variant="h2">
				{" "}
				Errors for testing purposes
			</Typography>
			<ButtonGroup fullWidth>
			</ButtonGroup>
			{validationErrors.length > 0 && (
				<Alert severity="error">
					<AlertTitle>Validation Errors</AlertTitle>
					<List>
						{validationErrors.map((error) => (
							<ListItem key={error}>
								<ListItemText>{error}</ListItemText>
							</ListItem>
						))}
					</List>
				</Alert>
			)}
		</Container>
	);
}
