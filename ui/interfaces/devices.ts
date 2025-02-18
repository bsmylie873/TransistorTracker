export interface Device {
    id: string;
    name: string;
    description: string;
    createdBy: string;
    avatar?: string;
    model: string;
    wattage?: number;
    colour?: string;
    wireless?: boolean;
    releaseDate?: Date;
}

export interface PaginatedDevicesResponse {
    data: Device[];
    totalCount: number;
}