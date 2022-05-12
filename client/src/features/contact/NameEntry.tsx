import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import { useFormContext } from "react-hook-form";
import AppTextInput from "../../app/components/AppTextInput";
import AppCheckBox from "../../app/components/AppCheckBox";

export default function AddressForm() {
	const { control } = useFormContext();
	return (
		<>
			<Typography variant="h6" gutterBottom>
				Would you like to put your name? <span><Typography variant="subtitle1">
				(Optional)
						</Typography></span>
			</Typography>

			<Grid container spacing={3}>
				<Grid item xs={12} sm={12}>
					<AppTextInput control={control} name="fullName" label="First Name" />
				</Grid>
				<Grid item xs={12}>
					<AppTextInput control={control} name="linkedIn" label="Let's connect on LinkedIn!" />
				</Grid>
			</Grid>
		</>
	);
}
