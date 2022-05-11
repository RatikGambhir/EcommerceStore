import { Elements } from "@stripe/react-stripe-js"
import { loadStripe } from "@stripe/stripe-js"
import { useEffect, useState } from "react"
import service from "../../app/api/service"
import LoadingComponent from "../../app/layout/LoadingComponent"
import { useAppDispatch } from "../../app/store/configureStore"
import { setBasket } from "../basket/basketSlice"
import CheckoutPage from "./CheckoutPage"

const stripePromise = loadStripe('pk_test_51KpLsdLpJqBv3ErgC3XcsPk5ljLkNBeVBsSyqH11jg7Xhdw8LUfelpamdDjfbcmwaWVS0N6tYm03FNOQEelMpi2p00oaY56bKR')

export default function StripeWrapper() {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(true)

    useEffect(() => {
      service.Payments.sendPaymentIntent().then(basket => dispatch(setBasket(basket))).catch(error => console.log(error)).finally(() => setLoading(false))
    }, [dispatch])

    if(loading) return <LoadingComponent message="Loading Checkout Page..." />

  return (
    <Elements stripe={stripePromise}>
        <CheckoutPage />
    </Elements>
  )
}