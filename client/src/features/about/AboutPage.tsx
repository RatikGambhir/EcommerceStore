import { Alert, AlertTitle, Button, ButtonGroup, Container, List, ListItem, ListItemText, Typography } from "@mui/material";
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
				<Button variant="contained" onClick={() => service.TestErrors.get400Error().catch((error) => console.log(error))}>
					Test 400 error
				</Button>
				<Button variant="contained" onClick={() => service.TestErrors.get401Error().catch((error) => console.log(error))}>
					Test 401 error
				</Button>
				<Button variant="contained" onClick={() => service.TestErrors.get404Error().catch((error) => console.log(error))}>
					Test 404 error
				</Button>
				<Button variant="contained" onClick={() => service.TestErrors.get500Error().catch((error) => console.log(error))}>
					Test 500 error
				</Button>
				<Button variant="contained" onClick={getValidationError}>
					Test Validation error
				</Button>
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
