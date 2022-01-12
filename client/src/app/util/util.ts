export function getCookie(key: string) {
	const cookie = document.cookie.match("(^|;)\\s*" + key + "\\s*=\\s*([^;]+)");
	return cookie ? cookie.pop() : "";
}

export function formateCurrency(amount: number) {
	return "$" + (amount / 100).toFixed(2);
}
