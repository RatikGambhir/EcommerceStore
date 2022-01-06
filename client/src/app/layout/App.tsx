import { useState } from "react";
import Catalog from "../../features/catalog/Catalog";
import { Container, CssBaseline, ThemeProvider, createTheme } from "@mui/material";
import Header from "./header";
import { Route } from "react-router-dom";
import HomePage from "../../features/home/Home";
import ProductDetails from "../../features/catalog/ProductDetails";
import ContactPage from "../../features/contact/ContactPage";
import AboutPage from "../../features/about/AboutPage";

function App() {
	const [darkMode, setDarkMode] = useState(false);

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

	return (
		<ThemeProvider theme={theme}>
			<CssBaseline />
			<Header darkMode={darkMode} setDarkMode={changeTheme} />
			<Container>
				<Route exact path="/" component={HomePage} />
				<Route exact path="/catalog" component={Catalog} />
				<Route path="/catalog/:id" component={ProductDetails} />
				<Route path="/about" component={AboutPage} />
				<Route path="/contact" component={ContactPage} />
			</Container>
		</ThemeProvider>
	);
}

export default App;
