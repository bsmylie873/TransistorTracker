import { SortingState } from '@tanstack/react-table';

export const parseAccessorKey = (key: string) => {
    if (key?.includes('.')) {
        return key.split('.').pop();
    } else {
        return key;
    }
};

export const defaultSortingState: SortingState = [{ id: '1', desc: false }];