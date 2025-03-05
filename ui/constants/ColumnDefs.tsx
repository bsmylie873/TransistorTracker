import {Device} from '@/interfaces/devices';
import {DEVICES_COLUMN_DEFINITION_IDS} from '@/constants/ColumnDefinitionIds/Devices';
import {ColumnDef} from '@tanstack/react-table';

const devicesColumnDefs: ColumnDef<Device>[] = [
    {
        id: DEVICES_COLUMN_DEFINITION_IDS.NAME?.toString(),
        accessorKey: 'name',
        size: 500,
        meta: {
            style: 'justify-center'
        },
        header: () => <span className='flex text-nowrap text-left'>Name</span>,
        enableGlobalFilter: true
    },
    {
        id: DEVICES_COLUMN_DEFINITION_IDS.AVATAR?.toString(),
        accessorKey: 'avatar',
        size: 100,
        meta: {
            style: 'justify-center'
        },
        header: () => <span className='flex text-nowrap text-left'>Avatar</span>,
        enableGlobalFilter: true
    },
    {
        id: DEVICES_COLUMN_DEFINITION_IDS.MODEL?.toString(),
        accessorKey: 'model',
        size: 200,
        meta: {
            style: 'justify-center'
        },
        header: () => <span className='flex text-nowrap text-left'>Model</span>,
        enableGlobalFilter: true
    },
    {
        id: DEVICES_COLUMN_DEFINITION_IDS.WATTAGE?.toString(),
        accessorKey: 'wattage',
        size: 100,
        meta: {
            style: 'justify-center'
        },
        header: () => <span className='flex text-nowrap text-left'>Wattage</span>,
        enableGlobalFilter: true
    },
    {
        id: DEVICES_COLUMN_DEFINITION_IDS.COLOUR?.toString(),
        accessorKey: 'colour',
        size: 100,
        meta: {
            style: 'justify-center'
        },
        header: () => <span className='flex text-nowrap text-left'>Colour</span>,
        enableGlobalFilter: true
    },
    {
        id: DEVICES_COLUMN_DEFINITION_IDS.WIRELESS?.toString(),
        accessorKey: 'wireless',
        size: 100,
        meta: {
            style: 'justify-center'
        },
        header: () => <span className='flex text-nowrap text-left'>Wireless</span>,
        enableGlobalFilter: true
    },
    {
        id: DEVICES_COLUMN_DEFINITION_IDS.RELEASE_DATE?.toString(),
        accessorKey: 'releaseDate',
        size: 150,
        meta: {
            style: 'justify-center'
        },
        header: () => <span className='flex text-nowrap text-left'>Release Date</span>,
        enableGlobalFilter: true
    },
];

export {
    devicesColumnDefs,
};