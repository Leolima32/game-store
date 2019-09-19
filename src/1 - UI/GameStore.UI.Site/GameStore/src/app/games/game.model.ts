import { Genre } from "../genres/genre.model";
import { Company } from "../companies/company.model";
import { Platform } from "../platforms/platform.model";

export interface Game {
    id: string;
    name: string;
    description: string;
    shortDescription: string;
    releaseDate: string;
    price: number;
    rating: number;
    imagePath: string;
    imageRelativePath: string;
    coverImagePath: string;
    coverImageRelativePath: string;
    genres: Genre[];
    developers: Company[];
    publishers: Company[];
    platforms: Platform[];
}
