import axios, { AxiosError, AxiosResponse } from "axios";
import { request } from "http";
import { toast } from "react-toastify";
import { history } from "../..";
import { PaginationResponse } from "../model/pagination";
import { store } from "../store/configureStore";

axios.defaults.baseURL = "http://localhost:5000/api/";
axios.defaults.withCredentials = true;
const responseBody = (response: AxiosResponse) => response.data;

axios.interceptors.request.use((config: any) => {
	const token = store.getState().account.user?.token;
	if (token) config.headers.Authorization = `Bearer ${token}`;
	return config;
});

axios.interceptors.response.use(
	(response) => {
		console.log(response);
		const pagination = response.headers["pagination"];
		response.headers["Access-Control-Allow-Origin"] = "*";
		if (pagination) {
			response.data = new PaginationResponse(response.data, JSON.parse(pagination));
			console.log(response);
			return response;
		}
		return response;
	},
	(error: AxiosError) => {
		const { data, status } = error.response!;
		switch (status) {
			case 400:
				if (data.errors) {
					const modelStateErrors: string[] = [];
					for (const key in data.errors) {
						if (data.errors[key]) {
							modelStateErrors.push(data.errors[key]);
						}
					}
					throw modelStateErrors.flat();
				}
				toast.error(data.title);
				break;
			case 401:
				toast.error(data.title);
				break;
			case 500:
				history.push({
					pathname: "/server-error",
					state: { error: data },
				});
				break;
			default:
				break;
		}
		console.log("caught by interceptor");
		return Promise.reject(error.response);
	}
);

const requests = {
	get: (url: string, params?: URLSearchParams) => axios.get(url, { params }).then(responseBody),
	post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
	put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
	delete: (url: string) => axios.delete(url).then(responseBody),
};

const Catalog = {
	list: (params: URLSearchParams) => requests.get("products", params),
	details: (id: number) => requests.get(`products/${id}`),
	filters: () => requests.get("products/filter"),
};

const TestErrors = {
	get400Error: () => requests.get("Error/bad-request"),
	get401Error: () => requests.get("Error/unauthorized"),
	get404Error: () => requests.get("Error/not-found"),
	get500Error: () => requests.get("Error/server-error"),
	getValidationError: () => requests.get("Error/validation-error"),
};

const Basket = {
	getBasket: () => requests.get("basket"),
	addItem: (productId: number, quanity = 1) => requests.post(`basket?productId=${productId}&quantity=${quanity}`, {}),
	removeItem: (productId: number, quanity = 1) => requests.delete(`basket?productId=${productId}&quantity=${quanity}`),
};

const Account = {
	login: (values: any) => requests.post("account/login", values),
	register: (values: any) => requests.post("account/register", values),
	currentUser: () => requests.get("account/currentUser"),
};

const News = {
	getNews: () => requests.get("News"),
};

const Feedback = {
	submitFeedback: (values: any) => requests.post("Feedback", values),
};

const service = {
	Catalog,
	TestErrors,
	Basket,
	Account,
	News,
	Feedback,
};

export default service;
