import { TableContainer, Paper, Table, TableBody, TableRow, TableCell, Typography } from "@mui/material";
import { useState } from "react";
import { useStoreContext } from "../../app/context/StoreContext";
import { formateCurrency } from "../../app/util/util";

export default function BasketSummary() {
	const { basket } = useStoreContext();

	const subtotal = basket?.items.reduce((total, item) => (total += item.price * item.quantity), 0) ?? 0;
	const deliveryFee = subtotal > 10000 ? 0 : 500;

	return (
		<>
			<TableContainer component={Paper} variant={"outlined"}>
				<Table>
					<TableBody>
						<TableRow>
							<TableCell colSpan={2}>Subtotal</TableCell>
							<TableCell align="right"> {formateCurrency(subtotal)}</TableCell>
						</TableRow>
						<TableRow>
							<TableCell colSpan={2}>Delivery fee*</TableCell>
							<TableCell align="right">{formateCurrency(deliveryFee)}</TableCell>
						</TableRow>
						<TableRow>
							<TableCell colSpan={2}>Total</TableCell>
							<TableCell align="right">{formateCurrency(subtotal + deliveryFee)}</TableCell>
						</TableRow>
						<TableRow>
							<TableCell>
								<span style={{ fontStyle: "italic" }}>*Orders over $300 qualify for free delivery</span>
							</TableCell>
						</TableRow>
					</TableBody>
				</Table>
			</TableContainer>
		</>
	);
}
