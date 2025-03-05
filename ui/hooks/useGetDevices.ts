import axiosInstance from "@/integration/instance";
import {ROUTES} from "@/constants/Routes";
import {usePaginatedFilteredRequest} from "@/hooks/usePaginatedFilteredRequest";
import {PaginatedDevicesResponse} from "@/interfaces/devices";
import {QueryKeys} from "@/constants/QueryKeys";

const getDevices = async ({
                              pageSize,
                              pageNumber,
                              sortBy,
                              sortDirection,
                              search
                          }: {
    pageSize: number;
    pageNumber: number;
    sortBy?: string;
    sortDirection?: string | undefined;
    search?: string;
}): Promise<PaginatedDevicesResponse> => {
    const {data} = await axiosInstance.get(ROUTES.DEVICES, {
        params: {
            ...(pageSize && {pageSize}),
            ...(pageNumber && {pageNumber}),
            ...(sortBy && {sortBy}),
            ...(sortDirection && {sortDirection}),
            ...(search && {search})
        },
        paramsSerializer: {indexes: null}
    });
    return data;
};

const useGetDevices = ({
                           sortBy,
                           sortDirection,
                           search
                       }: {
    sortBy: string;
    sortDirection: string;
    search: string;
}) => usePaginatedFilteredRequest({
    fn: getDevices,
    key: QueryKeys.DEVICES,
    sortBy,
    sortDirection,
    search,
    refetchInterval: false
});

export {useGetDevices};
