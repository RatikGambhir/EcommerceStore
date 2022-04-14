import { useState, useEffect, useCallback } from "react";
import Catalog from "../../features/catalog/Catalog";
import { Container, CssBaseline, ThemeProvider, createTheme } from "@mui/material";
import Header from "./header";
import { Route, Switch } from "react-router-dom";
import HomePage from "../../features/home/Home";
import ProductDetails from "../../features/catalog/ProductDetails";
import FeedBackPage from "../../features/contact/ContactPage";
import AboutPage from "../../features/about/AboutPage";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ServerError from "../../app/errors/ServerError";
import NotFound from "../../app/errors/NotFound";
import BasketPage from "../../features/basket/BasketPage";
import LoadingComponent from "./LoadingComponent";
import Checkout from "../../features/checkout/Checkout";
import { useAppDispatch } from "../store/configureStore";
import { getUserBasketAsync } from "../../features/basket/basketSlice";
import Login from "../../features/account/Login";
import Register from "../../features/account/Register";
import { getCurrentUser } from "../../features/account/accountSlice";
import Orders from "../../features/orders/Order";
import OrderDetails from "../../features/orders/OrderDetails";

function App() {
	const dispatch = useAppDispatch();
	const [loading, setLoading] = useState(true);
	const [darkMode, setDarkMode] = useState(false);

	const initApp = useCallback(async () => {
		try {
			await dispatch(getCurrentUser());
			await dispatch(getUserBasketAsync());
		} catch (error: any) {
			console.log(error);
		}
	}, [dispatch]);

	useEffect(() => {
		initApp().then(() => setLoading(false));
	}, [initApp]);

	const paletteType = darkMode ? "dark" : "light";

	const theme = createTheme({
		palette: {
			mode: paletteType,
			background: {
				default: paletteType === "light" ? "#eaeaea" : "#121212",
			},
		},
	});

	function changeTheme() {
		setDarkMode(!darkMode);
	}

	if (loading) return <LoadingComponent message="Initializing App" />;

	return (
		<ThemeProvider theme={theme}>
			<ToastContainer position="bottom-right" hideProgressBar />
			<CssBaseline />
			<Header darkMode={darkMode} setDarkMode={changeTheme} />
			<Container>
				<Switch>
					<Route exact path="/" component={HomePage} />
					<Route exact path="/catalog" component={Catalog} />
					<Route path="/catalog/:id" component={ProductDetails} />
					<Route path="/about" component={AboutPage} />
					<Route path="/feedback" component={FeedBackPage} />
					<Route path="/server-error" component={ServerError} />
					<Route path="/basket" component={BasketPage} />
					<Route path="/checkout" component={Checkout} />
					<Route path="/orders" component={Orders} />
					<Route path="/orderdetails/:id" component={OrderDetails} />
					<Route path="/login" component={Login} />
					<Route path="/register" component={Register} />
					<Route component={NotFound} />
				</Switch>
			</Container>
		</ThemeProvider>
	);
}

export default App;
