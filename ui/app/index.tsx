import React from 'react';
import { Text, View } from 'react-native';
import { useThemeColor } from '@/hooks/useThemeColor';
import { Colors } from '@/constants/Colors';
import MaterialIcons from 'react-native-vector-icons/MaterialIcons';
import { Link } from 'expo-router';
import { ROUTES } from '@/constants/Routes';
import { LinkHrefType } from '@/constants/Types';
import { Octicons } from "@expo/vector-icons";
import { useNavigation } from '@react-navigation/native';

export default function Index() {
    const backgroundColor = useThemeColor({ light: Colors.light.background, dark: Colors.dark.background }, 'background');
    const textColor = useThemeColor({ light: Colors.light.text, dark: Colors.dark.text }, 'text');

    return (
        <View
            style={{
                flex: 1,
                justifyContent: 'center',
                alignItems: 'center',
                backgroundColor: backgroundColor,
                paddingVertical: 20,
            }}
        >
            <View style={{ flexDirection: 'column', alignItems: 'center' }}>
                <Link href={{ pathname: ROUTES.DEVICES as LinkHrefType }} style={{ marginVertical: 20, alignItems: 'center' }}>
                    <MaterialIcons name="devices-other" size={60} color={textColor} />
                    <Text style={{ color: textColor, textAlign: 'center', marginTop: 10 }}>Devices</Text>
                </Link>
                <Link href={{ pathname: ROUTES.PARTS as LinkHrefType }} style={{ marginVertical: 20, alignItems: 'center' }}>
                    <Octicons name="cpu" size={60} color={textColor} />
                    <Text style={{ color: textColor, textAlign: 'center', marginTop: 10 }}>Parts</Text>
                </Link>
                <Link href={{ pathname: ROUTES.LOCATIONS as LinkHrefType }} style={{ marginVertical: 20, alignItems: 'center' }}>
                    <MaterialIcons name="location-on" size={60} color={textColor} />
                    <Text style={{ color: textColor, textAlign: 'center', marginTop: 10 }}>Locations</Text>
                </Link>
            </View>
        </View>
    );
}