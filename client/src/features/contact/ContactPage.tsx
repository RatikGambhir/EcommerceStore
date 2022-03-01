import Avatar from "@mui/material/Avatar";
import TextField from "@mui/material/TextField";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import AssignmentIcon from "@mui/icons-material/Assignment";
import Typography from "@mui/material/Typography";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { Link, useHistory } from "react-router-dom";
import { useForm } from "react-hook-form";
import { LoadingButton } from "@mui/lab";
import service from "../../app/api/service";
import { toast } from "react-toastify";
import { green } from "@mui/material/colors";

const theme = createTheme();

export default function FeedBackPage() {
	const history = useHistory();

	const {
		register,
		handleSubmit,
		formState: { isSubmitting, isValid },
	} = useForm({
		mode: "all",
	});

	function sendFeedback(data: any) {
		console.log(data);
		service.Feedback.submitFeedback(data)
			.then(() => handleSuccessfulRegistration())
			.catch((error) => handleApiErrors(error));
	}

	function handleSuccessfulRegistration() {
		history.push("/");
		toast.success("Thank you for your feedback!");
	}

	function handleApiErrors(error: any) {
		toast.error(error.message);
	}

	return (
		<ThemeProvider theme={theme}>
			<Grid container component={Paper} sx={{ height: "100vh" }}>
				<Grid item component={Paper} square>
					<Box
						sx={{
							my: 8,
							mx: 4,
							display: "flex",
							flexDirection: "column",
							alignItems: "center",
						}}
					>
						<Avatar sx={{ bgcolor: green[500] }}>
							<AssignmentIcon />
						</Avatar>
						<Typography component="h1" variant="h5">
							I need your feedback, the good and the bad. Feel free to submit anonomysly or by name!
						</Typography>
						<Box component="form" noValidate onSubmit={handleSubmit(sendFeedback)} sx={{ mt: 1 }}>
							<TextField margin="normal" label="First and Last name" autoFocus fullWidth {...register("name")} sx={{ display: "flex", marginRight: "100px", alignContent: "center" }} />
							<TextField margin="normal" label="Favorite part of the site" fullWidth {...register("favoritepart")} sx={{ marginRight: "100px", display: "flex" }} />
							<TextField margin="normal" label="Least Favorite part of the site" fullWidth {...register("leastfavoritepart")} />
							<TextField margin="normal" label="What did we do well?" fullWidth multiline rows={4} {...register("whatdidwedowell")} />
							<TextField margin="normal" label="What could we work on?" fullWidth multiline rows={4} {...register("whatwedidnotdowell")} />
							<TextField margin="normal" label="Is there another project you would like to see?" fullWidth {...register("anotherproject")} />
							<TextField margin="normal" label="Any other thoughts?" multiline rows={4} fullWidth {...register("finalthoughts")} />

							<LoadingButton disabled={!isValid} loading={isSubmitting} type="submit" variant="contained" sx={{ mt: 3, mb: 2 }}>
								Send Feedback
							</LoadingButton>
							<Grid container>
								<Grid item>
									<Link to="/">{"Changed your mind? That's ok! You can go home here"}</Link>
								</Grid>
							</Grid>
							<Typography variant="h6">Note: Your Feedback will automatically be sent anonomysly unless you put your name in the field above!</Typography>
						</Box>
					</Box>
				</Grid>
			</Grid>
		</ThemeProvider>
	);
}
