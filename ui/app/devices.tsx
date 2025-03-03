import React, {useEffect, useState} from 'react';
import {View, Text, FlatList, Image} from 'react-native';
import {useGetDevices} from '@/hooks/useGetDevices';
import {Device} from '@/interfaces/devices';
import {defaultSortingState, parseAccessorKey} from '@/utils/datagrid';
import {devicesColumnDefs} from '@/constants/ColumnDefs';
import {SortingState} from '@tanstack/react-table';
import styles from '@/constants/DatagridStyles';
import {QueryClient, QueryClientProvider} from '@tanstack/react-query';
import {useThemeColor} from '@/hooks/useThemeColor';
import {Colors} from '@/constants/Colors';

const queryClient = new QueryClient();

const Devices = () => {
    const [devices, setDevices] = useState<Device[]>([]);
    const [sorting, setSorting] = useState<SortingState>(defaultSortingState);
    const [search, setSearch] = useState<string | undefined>('');

    // Use theme colors
    const backgroundColor = useThemeColor({
        light: Colors.light.background,
        dark: Colors.dark.background
    }, 'background');
    const textColor = useThemeColor({
        light: Colors.light.text,
        dark: Colors.dark.text
    }, 'text');
    const borderColor = useThemeColor({
        light: Colors.light.tint,
        dark: Colors.dark.tint
    }, 'border');

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
        return <Text style={{color: textColor}}>Loading...</Text>;
    }

    if (error) {
        return <Text style={{color: textColor}}>Error loading devices</Text>;
    }

    return (
        <QueryClientProvider client={queryClient}>
            <View style={[styles.container, {backgroundColor}]}>
                <Text style={[styles.title, {color: textColor}]}>Devices</Text>
                <FlatList
                    data={devices}
                    keyExtractor={(item) => item.id}
                    renderItem={({item}) => (
                        <View style={[styles.row, {borderBottomColor: borderColor}]}>
                            <Text style={[styles.cell, {color: textColor}]}>{item.name}</Text>
                            {item.avatar && <Image source={{uri: item.avatar}} style={styles.cell}/>}
                            <Text style={[styles.cell, {color: textColor}]}>{item.model}</Text>
                            <Text style={[styles.cell, {color: textColor}]}>{item.wattage}</Text>
                            <Text style={[styles.cell, {color: textColor}]}>{item.colour}</Text>
                            <Text style={[styles.cell, {color: textColor}]}>{item.wireless ? 'Yes' : 'No'}</Text>
                            <Text style={[styles.cell, {color: textColor}]}>{item.releaseDate?.toString()}</Text>
                        </View>
                    )}
                    ListHeaderComponent={() => (
                        <View style={[styles.header, {borderBottomColor: borderColor}]}>
                            <Text style={[styles.headerCell, {color: textColor}]}>Name</Text>
                            <Text style={[styles.headerCell, {color: textColor}]}>Avatar</Text>
                            <Text style={[styles.headerCell, {color: textColor}]}>Model</Text>
                            <Text style={[styles.headerCell, {color: textColor}]}>Wattage</Text>
                            <Text style={[styles.headerCell, {color: textColor}]}>Colour</Text>
                            <Text style={[styles.headerCell, {color: textColor}]}>Wireless</Text>
                            <Text style={[styles.headerCell, {color: textColor}]}>Release Date</Text>
                        </View>
                    )}
                />
            </View>
        </QueryClientProvider>
    );
};

export default Devices;