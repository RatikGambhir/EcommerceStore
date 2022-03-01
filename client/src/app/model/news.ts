export interface NFLNews {
	header: string;
	link: Link;
	articles: Article[];
}

export interface Link {
	language: string;
	rel: string[];
	href: string;
	text: string;
	shortText: string;
	isExternal: boolean;
	isPremium: boolean;
}

export interface Image {
	name: string;
	width: number;
	alt: string;
	caption: string;
	url: string;
	height: number;
	id: number;
	credit: string;
	type: string;
}

export interface Category {
	id: number;
	description: string;
	type: string;
	sportId: number;
	leagueId: number;

	uid: string;
	createDate: Date;
	teamId: number;

	athleteId: number;

	guid: string;
	topicId: number;
}

export interface Article {
	images: Image[];
	description: string;
	published: Date;
	type: string;
	premium: boolean;

	lastModified: Date;
	categories: Category[];
	headline: string;
	byline: string;
}
