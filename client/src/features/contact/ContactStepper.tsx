import { Box, Button, Paper, Step, StepLabel, Stepper, Typography } from "@mui/material";
import { useState } from "react";
import { FieldValues, FormProvider, useForm } from "react-hook-form";
import PostiveNegative from "./PositiveNegative";
import FavoritePart from "./FavoritePart";
import FinalThoughts from "./FinalThoughts";
import NameEntry from "./NameEntry";

import { yupResolver } from "@hookform/resolvers/yup";
import service from "../../app/api/service";
//import { validationSchema } from "./checkoutValidation";

const steps = ["Tell me how I did", "What's your favorite?", "Anything else?", "Let's connect!"];

function getStepContent(step: number) {
	switch (step) {
		case 0:
			return <PostiveNegative />;
		case 1:
			return <FavoritePart />;
		case 2:
			return <FinalThoughts />;
		case 3:
			return <NameEntry />;
		default:
			throw new Error("Unknown step");
	}
}

export default function CheckoutPage() {
	const [activeStep, setActiveStep] = useState(0);

	//	const currentValidationSchema = validationSchema[activeStep];

	const methods = useForm({
		mode: "all",
		//	resolver: yupResolver(currentValidationSchema),
	});

	async function submitFeedback(data: FieldValues) {
		await service.Feedback.submitFeedback(data).then(() => setActiveStep(activeStep + 1)).catch((error) => console.log('didnt work', error));
	
	}
	const handleNext = async (data: FieldValues) => {
		if (activeStep === steps.length - 1) {
			await submitFeedback(data);
		} else {
			setActiveStep(activeStep + 1);
		}
	};

	const handleBack = () => {
		setActiveStep(activeStep - 1);
	};

	return (
		<FormProvider {...methods}>
			<Paper variant="outlined" sx={{ my: { xs: 3, md: 6 }, p: { xs: 2, md: 3 } }}>
				<Typography component="h1" variant="h4" align="center">
					Ratik needs your feedback to become a better software engineer! Please consider filling out the following questions
				</Typography>
				<Stepper activeStep={activeStep} sx={{ pt: 3, pb: 5 }}>
					{steps.map((label) => (
						<Step key={label}>
							<StepLabel>{label}</StepLabel>
						</Step>
					))}
				</Stepper>
				<>
					{activeStep === steps.length ? (
						<>
							<Typography variant="h5" gutterBottom>
								Thank you for submitting your feedback!
							</Typography>
							<Typography variant="subtitle1">I appreciate you taking the time to submit your feedback.</Typography>
						</>
					) : (
						<form onSubmit={methods.handleSubmit(handleNext)}>
							{getStepContent(activeStep)}
							<Box sx={{ display: "flex", justifyContent: "flex-end" }}>
								{activeStep !== 0 && (
									<Button onClick={handleBack} sx={{ mt: 3, ml: 1 }}>
										Back
									</Button>
								)}
								<Button disabled={!methods.formState.isValid} variant="contained" type="submit" sx={{ mt: 3, ml: 1 }}>
									{activeStep === steps.length - 1 ? "Submit Feedback" : "Next"}
								</Button>
							</Box>
						</form>
					)}
				</>
			</Paper>
		</FormProvider>
	);
}
