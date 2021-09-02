import { Floor } from "./Floor";
import { Room } from "./Room";
import { RoomType } from "./RoomType";

export interface Hotel {
    id: number;
    name: string;
    phone: string;
    location: string;
    rooms: Room[];
    floors: Floor[];
    roomTypes: RoomType[];
}