import Avatar from "@mui/material/Avatar";
import TextField from "@mui/material/TextField";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { Link, useHistory } from "react-router-dom";
import { FieldValues, useForm } from "react-hook-form";
import { LoadingButton } from "@mui/lab";
import { useAppDispatch } from "../../app/store/configureStore";
import { signInUser } from "./accountSlice";

const theme = createTheme();

export default function Login() {
	const history = useHistory();
	const dispatch = useAppDispatch();

	const {
		register,
		handleSubmit,
		formState: { isSubmitting, errors, isValid },
	} = useForm({
		mode: "all",
	});

	async function submitForm(data: FieldValues) {
		try {
			await dispatch(signInUser(data));
			history.push("/");
		} catch (error) {
			console.log(error);
		}

		//	console.log(response);
		// if ((response.type = "account/signInUser/rejected")) return;
		// if ((response.type = "account/signInUser/fulfilled")) history.push("/");
	}

	return (
		<ThemeProvider theme={theme}>
			<Grid container component={Paper} sx={{ height: "100vh" }}>
				<Grid
					item
					xs={false}
					sm={4}
					md={7}
					sx={{
						backgroundImage: "url(https://source.unsplash.com/random)",
						backgroundRepeat: "no-repeat",
						backgroundColor: (t) => (t.palette.mode === "light" ? t.palette.grey[50] : t.palette.grey[900]),
						backgroundSize: "cover",
						backgroundPosition: "center",
					}}
				/>
				<Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
					<Box
						sx={{
							my: 8,
							mx: 4,
							display: "flex",
							flexDirection: "column",
							alignItems: "center",
						}}
					>
						<Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
							<LockOutlinedIcon />
						</Avatar>
						<Typography component="h1" variant="h5">
							Sign in
						</Typography>
						<Box component="form" noValidate onSubmit={handleSubmit(submitForm)} sx={{ mt: 1 }}>
							<TextField
								margin="normal"
								fullWidth
								label="Username"
								autoFocus
								{...register("username", {
									required: "Username is required",
								})}
								error={!!errors.username}
								helperText={errors?.username?.message}
							/>

							<TextField
								margin="normal"
								fullWidth
								label="Password"
								type="password"
								id="password"
								autoComplete="current-password"
								{...register("password", {
									required: "Password is required",
								})}
								error={!!errors.password}
								helperText={errors?.password?.message}
							/>
							<LoadingButton disabled={!isValid} loading={isSubmitting} type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
								Sign In
							</LoadingButton>
							<Grid container>
								<Grid item xs>
									{/* <Link href="#" variant="body2">
										Forgot password?
									</Link> */}
								</Grid>
								<Grid item>
									<Link to="/register">{"Don't have an account? Sign Up"}</Link>
								</Grid>
							</Grid>
						</Box>
					</Box>
				</Grid>
			</Grid>
		</ThemeProvider>
	);
}
