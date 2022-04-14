import { Box, Button, Paper, Step, StepLabel, Stepper, Typography } from "@mui/material";
import { useState } from "react";
import { FieldValues, FormProvider, useForm } from "react-hook-form";
import PostiveNegative from "./PositiveNegative";
import FavoritePart from "./FavoritePart";
import FinalThoughts from "./FinalThoughts";
import NameEntry from "./NameEntry";

import { yupResolver } from "@hookform/resolvers/yup";
//import { validationSchema } from "./checkoutValidation";

const steps = ["Shipping address", "Review your order", "Payment details"];

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

	const handleNext = (data: FieldValues) => {
		if (activeStep === 0) {
			console.log(data);
		}
		setActiveStep(activeStep + 1);
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
								Thank you for submitting your feedback! .
							</Typography>
							<Typography variant="subtitle1">Your order number is #2001539. We have emailed your order confirmation, and will send you an update when your order has shipped.</Typography>
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