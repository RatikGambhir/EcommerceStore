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
				Let's talk about your favorites!
			</Typography>

			<Grid container spacing={3}>
				<Grid item xs={12} sm={12}>
					<AppTextInput control={control} name="favoritePart" label="What was your favorite part of the site?" />
				</Grid>
				<Grid item xs={12}>
					<AppTextInput control={control} name="leastFavoritePart" label="What was your least favorite part of the site (be honest!)" />
				</Grid>
			</Grid>
		</>
	);
}
