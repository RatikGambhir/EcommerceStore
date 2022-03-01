import { ComponentType } from "react";
import { Redirect, Route, RouteComponentProps, RouteProps } from "react-router-dom";
import { useAppSelector } from "../../app/store/configureStore";

interface Props extends RouteProps {
	component: ComponentType<RouteComponentProps<any>> | ComponentType<any>;
}

function PublicRoute({ component: Component, ...rest }: Props) {
	const { user } = useAppSelector((state) => state.account);

	return (
		<Route
			{...rest}
			render={(props) =>
				user ? (
					<Component {...props} />
				) : (
					<Redirect
						to={{
							pathname: "/home",
							state: { from: props.location },
						}}
					/>
				)
			}
		/>
	);
}
