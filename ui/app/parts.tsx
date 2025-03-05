import React, {useContext, useEffect, useState} from 'react';
import {View, Text, FlatList, Image} from 'react-native';
import {useGetParts} from '@/hooks/useGetParts';
import {Part} from '@/interfaces/parts';
import {defaultSortingState, parseAccessorKey} from '@/utils/datagrid';
import {partsColumnDefs} from '@/constants/ColumnDefs';
import {SortingState} from '@tanstack/react-table';
import styles from '@/constants/DatagridStyles';
import {useThemeColor} from '@/hooks/useThemeColor';
import {Colors} from '@/constants/Colors';
import {QueryClientContext} from '@/context/QueryClientContext';

const Parts = () => {
    const queryClient = useContext(QueryClientContext);
    const [parts, setParts] = useState<Part[]>([]);
    const [sorting, setSorting] = useState<SortingState>(defaultSortingState);

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

    const {data, fetchNextPage, isFetching, isLoading, status, refetch, error} = useGetParts({
        //@ts-expect-error TS doesnt think accessorKey is a valid prop
        sortBy: parseAccessorKey(partsColumnDefs.find((columnDef) => columnDef.id === sorting[0]?.id)?.accessorKey),
        sortDirection: sorting[0]?.desc ? 'desc' : 'asc',
    });

    useEffect(() => {
        if (data) {
            setParts(data.pages.flatMap(page => page.data));
        }
    }, [data]);

    if (isLoading) {
        return <Text style={{color: textColor}}>Loading...</Text>;
    }

    if (error) {
        return <Text style={{color: textColor}}>Error loading parts</Text>;
    }

    return (
        <View style={[styles.container, {backgroundColor}]}>
            <Text style={[styles.title, {color: textColor}]}>Parts</Text>
            <FlatList
                data={parts}
                keyExtractor={(item) => item.name}
                onEndReached={() => fetchNextPage()}
                onEndReachedThreshold={0.5}
                ListFooterComponent={() => isFetching ? <Text>Loading more...</Text> : null}
                ListEmptyComponent={() => !isLoading && (
                    <Text style={styles.title}>No parts found</Text>
                )}
                renderItem={({item}) => (
                    <View style={[styles.row, {borderBottomColor: borderColor}]}>
                        <Text style={[styles.cell, {color: textColor}]}>{item.name}</Text>
                        <View style={styles.cell}>
                            {item.avatar ? (
                                <Image source={{uri: item.avatar}} style={{width: 40, height: 40, borderRadius: 20}}/>
                            ) : (<View style={{width: 40, height: 40}}/>)}
                        </View>
                        <Text style={[styles.cell, {color: textColor}]}>{item.description}</Text>
                        <Text style={[styles.cell, {color: textColor}]}>{item.wattage}</Text>
                        <Text style={[styles.cell, {color: textColor}]}>{item.colour}</Text>
                        <Text style={[styles.cell, {color: textColor}]}>{item.releaseDate?.toString()}</Text>
                    </View>
                )}
                ListHeaderComponent={() => (
                    <View style={[styles.header, {borderBottomColor: borderColor}]}>
                        <Text style={[styles.headerCell, {color: textColor}]}>Name</Text>
                        <Text style={[styles.headerCell, {color: textColor}]}>Avatar</Text>
                        <Text style={[styles.headerCell, {color: textColor}]}>Description</Text>
                        <Text style={[styles.headerCell, {color: textColor}]}>Wattage</Text>
                        <Text style={[styles.headerCell, {color: textColor}]}>Colour</Text>
                        <Text style={[styles.headerCell, {color: textColor}]}>Release Date</Text>
                    </View>
                )}
            />
        </View>
    );
};

export default Parts;