import React, {useEffect, useState} from 'react';
import {View, Text, FlatList, Image, Button} from 'react-native';
import {Link, useNavigation} from '@react-navigation/native';
import {useGetDevices} from '@/hooks/useGetDevices';
import {Device} from '@/interfaces/devices';
import {defaultSortingState, parseAccessorKey} from '@/utils/datagrid';
import {devicesColumnDefs} from '@/constants/ColumnDefs';
import {SortingState} from '@tanstack/react-table';
import styles from '@/constants/DatagridStyles';
import {QueryClient, QueryClientProvider} from '@tanstack/react-query';

const queryClient = new QueryClient();

const Devices = () => {
    const [devices, setDevices] = useState<Device[]>([]);
    const [sorting, setSorting] = useState<SortingState>(defaultSortingState);
    const [search, setSearch] = useState<string | undefined>('');
    const navigation = useNavigation();

    const {data, fetchNextPage, isFetching, isLoading, status, refetch, error} = useGetDevices({
        //@ts-expect-error TS doesnt think accessorKey is a valid prop
        sortBy: parseAccessorKey(devicesColumnDefs.find((columnDef) => columnDef.id === sorting[0]?.id)?.accessorKey),
        sortDirection: sorting[0]?.desc ? 'desc' : 'asc',
        search: search?.trim()?.toLowerCase() || ''
    });

    useEffect(() => {
        if (data) {
            setDevices(data.pages.flatMap(page => page.data));
        }
    }, [data]);

    if (isLoading) {
        return <Text>Loading...</Text>;
    }

    if (error) {
        return <Text>Error loading devices</Text>;
    }

    return (
        <QueryClientProvider client={queryClient}>
            <View style={styles.container}>
                <Text style={styles.title}>Devices</Text>
                <FlatList
                    data={devices}
                    keyExtractor={(item) => item.id}
                    renderItem={({item}) => (
                        <View style={styles.row}>
                            <Text style={styles.cell}>{item.name}</Text>
                            {item.avatar && <Image source={{uri: item.avatar}} style={styles.cell}/>}
                            <Text style={styles.cell}>{item.model}</Text>
                            <Text style={styles.cell}>{item.wattage}</Text>
                            <Text style={styles.cell}>{item.colour}</Text>
                            <Text style={styles.cell}>{item.wireless ? 'Yes' : 'No'}</Text>
                            <Text style={styles.cell}>{item.releaseDate?.toString()}</Text>
                        </View>
                    )}
                    ListHeaderComponent={() => (
                        <View style={styles.header}>
                            <Text style={styles.headerCell}>Name</Text>
                            <Text style={styles.headerCell}>Avatar</Text>
                            <Text style={styles.headerCell}>Model</Text>
                            <Text style={styles.headerCell}>Wattage</Text>
                            <Text style={styles.headerCell}>Colour</Text>
                            <Text style={styles.headerCell}>Wireless</Text>
                            <Text style={styles.headerCell}>Release Date</Text>
                        </View>
                    )}
                />
            </View>
        </QueryClientProvider>
    );
};

export default Devices;