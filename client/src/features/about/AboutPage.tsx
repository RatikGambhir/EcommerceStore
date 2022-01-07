import { Button, ButtonGroup, Container, Typography } from "@mui/material";
import service from "../../app/api/service";

export default function AboutPage() {
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
				<Button variant="contained" onClick={() => service.TestErrors.getValidationError().catch((error) => console.log(error))}>
					Test Validation error
				</Button>
			</ButtonGroup>
		</Container>
	);
}
