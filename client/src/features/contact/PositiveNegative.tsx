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
				How was the overall experience?
			</Typography>

			<Grid container spacing={3}>
				<Grid item xs={12} sm={12}>
					<AppTextInput control={control} name="fullName" label="What did I do well?" />
				</Grid>
				<Grid item xs={12}>
					<AppTextInput control={control} name="address1" label="What could have I done better?" />
				</Grid>
			</Grid>
		</>
	);
}
