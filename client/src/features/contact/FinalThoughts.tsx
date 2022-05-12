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
				Final thoughts
			</Typography>

			<Grid container spacing={3}>
				<Grid item xs={12} sm={12}>
					<AppTextInput control={control} name="anotherProject" label="Is there another project you would like to see?" />
				</Grid>
				<Grid item xs={12}>
					<AppTextInput control={control} name="finalThoughts" label="Any final thoughts?" />
				</Grid>
			</Grid>
		</>
	);
}
