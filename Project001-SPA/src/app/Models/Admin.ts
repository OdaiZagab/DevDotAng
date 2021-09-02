import { Hotel } from "./Hotel";
import { User } from "./User";

export interface Admin {
    id: number;
    userId: number;
    hotelId: number;
    user: User;
    hotel: Hotel;
}