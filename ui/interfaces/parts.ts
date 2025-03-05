export interface Part {
    id: string;
    name: string;
    avatar?: string;
    description?: string;
    wattage?: number;
    colour?: string;
    releaseDate?: Date;
    deviceId?: number;
    userId?: number;
    locationId?: number;
    categoryId?: number;
    conditionId?: number;
    statusId?: number;
}

export interface PaginatedPartsResponse {
    data: Part[];
    totalCount: number;
}