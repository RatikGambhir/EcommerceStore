import { useState, useEffect } from "react";
import Catalog from "../../features/catalog/Catalog";
import { Container, CssBaseline, ThemeProvider, createTheme } from "@mui/material";
import Header from "./header";
import { Route, Switch } from "react-router-dom";
import HomePage from "../../features/home/Home";
import ProductDetails from "../../features/catalog/ProductDetails";
import ContactPage from "../../features/contact/ContactPage";
import AboutPage from "../../features/about/AboutPage";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ServerError from "../../app/errors/ServerError";
import NotFound from "../../app/errors/NotFound";
import BasketPage from "../../features/basket/BasketPage";
import { useStoreContext } from "../context/StoreContext";
import { getCookie } from "../util/util";
import service from "../api/service";
import LoadingComponent from "./LoadingComponent";
import Checkout from "../../features/checkout/Checkout";

function App() {
	const { setBasket } = useStoreContext();
	const [loading, setLoading] = useState(true);
	const [darkMode, setDarkMode] = useState(false);

	useEffect(() => {
		const buyerId = getCookie("buyerId");
		if (buyerId) {
			service.Basket.getBasket()
				.then((basket) => setBasket(basket))
				.catch((error) => console.log(error))
				.finally(() => setLoading(false));
		} else {
			setLoading(false);
		}
	}, [setBasket]);

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
					<Route path="/contact" component={ContactPage} />
					<Route path="/server-error" component={ServerError} />
					<Route path="/basket" component={BasketPage} />
					<Route path="/checkout" component={Checkout} />
					<Route component={NotFound} />
				</Switch>
			</Container>
		</ThemeProvider>
	);
}

export default App;
