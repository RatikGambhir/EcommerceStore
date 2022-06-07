import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, Box, IconButton, List, ListItem, Switch, Toolbar, Typography } from "@mui/material";
import { NavLink, Link } from "react-router-dom";
import { useAppSelector } from "../store/configureStore";
import SignedInMenu from "../layout/SignedInMenu";

interface Props {
	darkMode: boolean;
	setDarkMode: () => void;
}

const midLinks = [
	{ title: "shop", path: "/catalog" },
	{ title: "feedback", path: "/feedback" },
];

const rightLinks = [
	{ title: "login", path: "/login" },
	{ title: "register", path: "/register" },
];

const navStyles = {
	color: "inherit",
	textDecoration: "none",
	typography: "h6",
	"&:hover": {
		color: "grey.500",
	},
	"&.active": {
		color: "text.secondary",
	},
};

export default function Header({ darkMode, setDarkMode }: Props) {
	const { basket } = useAppSelector((state) => state.basket);
	const { user } = useAppSelector((state) => state.account);
	const itemCount = basket?.items.reduce((sum, item) => (sum += item.quantity), 0);

	return (
		<AppBar position="static" sx={{ mb: 4 }}>
			<Toolbar sx={{ display: "flex", justifyContent: "space-between", alignItems: "center", color: "secondary" }}>
				<Box display="flex" alignItems="center">
					<img src="/download.png" style={{ height: "50px", backgroundColor: "inherit", padding: "5px", backgroundImage: "none", alignContent: "left" }} alt="National Football League"></img>
					<Typography variant="h6" component={NavLink} exact to="/" sx={navStyles}>
						NFL STORE
					</Typography>
					<Switch checked={darkMode} onChange={setDarkMode} />
				</Box>
				<List sx={{ display: "flex" }}>
					{midLinks.map(({ title, path }) => (
						<ListItem component={NavLink} to={path} key={path} sx={navStyles}>
							{title.toUpperCase()}
						</ListItem>
					))}
				</List>
				<Box display="flex" alignItems="center">
					<IconButton component={Link} to="/basket" size="large" sx={{ color: "inherit" }}>
						<Badge badgeContent={itemCount} color="secondary">
							<ShoppingCart />
						</Badge>
					</IconButton>
					{user ? (
						<SignedInMenu />
					) : (
						<List sx={{ display: "flex" }}>
							{rightLinks.map(({ title, path }) => (
								<ListItem component={NavLink} to={path} key={path} sx={navStyles}>
									{title.toUpperCase()}
								</ListItem>
							))}
						</List>
					)}
				</Box>
			</Toolbar>
		</AppBar>
	);
}
