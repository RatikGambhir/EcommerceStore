import axios, { Axios, AxiosError, AxiosResponse } from "axios";

axios.defaults.baseURL = "http://localhost:5000/api/";

const responseBody = (response: AxiosResponse) => response.data;

axios.interceptors.response.use(
	(response) => {
		return response;
	},
	(error: AxiosError) => {
		console.log("caught by interceptor");
		return Promise.reject(error.response);
	}
);

const requests = {
	get: (url: string) => axios.get(url).then(responseBody),
	post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
	put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
	delete: (url: string) => axios.delete(url).then(responseBody),
};

const Catalog = {
	list: () => requests.get("products"),
	details: (id: number) => requests.get(`products/${id}`),
};

const TestErrors = {
	get400Error: () => requests.get("Error/bad-request"),
	get401Error: () => requests.get("Error/unauthorized"),
	get404Error: () => requests.get("Error/not-found"),
	get500Error: () => requests.get("Error/server-error"),
	getValidationError: () => requests.get("Error/validation-error"),
};

const service = {
	Catalog,
	TestErrors,
};

export default service;
