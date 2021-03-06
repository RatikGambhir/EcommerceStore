import Avatar from "@mui/material/Avatar";
import TextField from "@mui/material/TextField";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { Link, useHistory } from "react-router-dom";
import { useForm } from "react-hook-form";
import { LoadingButton } from "@mui/lab";
import service from "../../app/api/service";
import { toast } from "react-toastify";

const theme = createTheme();

export default function Register() {
	const history = useHistory();

	const {
		setError,
		register,
		handleSubmit,
		formState: { isSubmitting, errors, isValid },
	} = useForm({
		mode: "all",
	});

	function handleSuccessfulRegistration() {
		history.push("/login");
		toast.success("Registration Successful!");
	}

	function handleApiErrors(errors: any) {
		if (errors) {
			errors.forEach((error: string) => {
				if (error.includes("Password")) {
					setError("password", { message: error });
				} else if (error.includes("Email")) {
					setError("email", { message: error });
				} else if (error.includes("Username")) {
					setError("username", { message: error });
				}
			});
		}
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
							Register
						</Typography>
						<Box
							component="form"
							noValidate
							onSubmit={handleSubmit((data) =>
								service.Account.register(data)
									.then(() => handleSuccessfulRegistration())
									.catch((error) => handleApiErrors(error))
							)}
							sx={{ mt: 1 }}
						>
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
								label="Email"
								{...register("email", {
									required: "Email is required",
								})}
								error={!!errors.email}
								helperText={errors?.email?.message}
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
									pattern: {
										value: /(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$/,
										message: "Need at least 6 characters, all including at least one upper case and unique character, and a number",
									},
								})}
								error={!!errors.password}
								helperText={errors?.password?.message}
							/>

							<LoadingButton disabled={!isValid} loading={isSubmitting} type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
								Register
							</LoadingButton>
							<Grid container>
								<Grid item xs>
									{/* <Link href="#" variant="body2">
										Forgot password?
									</Link> */}
								</Grid>
								<Grid item>
									<Link to="/login">{"Already have an account? Login"}</Link>
								</Grid>
							</Grid>
						</Box>
					</Box>
				</Grid>
			</Grid>
		</ThemeProvider>
	);
}
