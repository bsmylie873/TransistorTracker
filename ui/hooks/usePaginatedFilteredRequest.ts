import { useInfiniteQuery } from '@tanstack/react-query';
import {PAGINATION_CONFIG} from "@/constants/PaginationConfig";

interface fnprops {
    pageNumber: number;
    pageSize: number;
    sortBy: string | undefined;
    sortDirection: string | undefined;
    search: string | undefined;
}

interface props<T> {
    fn: ({ sortBy, sortDirection, search }: fnprops) => Promise<T>;
    key: string;
    sortBy: string | undefined;
    sortDirection: string | undefined;
    search: string | undefined;
    pageSize?: number;
    refetchInterval: number | false;
    refetchOnWindowFocus?: boolean | 'always';
}

const usePaginatedFilteredRequest = <T>({
                                            fn,
                                            key,
                                            sortBy,
                                            sortDirection,
                                            search,
                                            pageSize = PAGINATION_CONFIG.PAGE_SIZE,
                                            refetchInterval = false,
                                            refetchOnWindowFocus = 'always'
                                        }: props<T>) =>
    useInfiniteQuery({
        queryKey: [key, { sortBy: sortBy, sortDirection: sortDirection, search: search }],
        queryFn: ({ pageParam = 1 }) => fn({ pageNumber: pageParam, pageSize: pageSize, sortBy, sortDirection, search }),
        initialPageParam: PAGINATION_CONFIG.INITIAL_PAGE,
        getNextPageParam: (_lastGroup, groups) => groups.length + PAGINATION_CONFIG.INITIAL_PAGE,
        refetchOnWindowFocus: refetchOnWindowFocus,
        refetchInterval: refetchInterval
    });

export { usePaginatedFilteredRequest };
