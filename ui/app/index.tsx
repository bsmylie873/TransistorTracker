import React from 'react';
import { Text, View, Image, TouchableOpacity } from 'react-native';
import { useThemeColor } from '@/hooks/useThemeColor';
import { useTheme } from '@/context/ThemeContext';
import { Colors } from '@/constants/Colors';
import Icon from 'react-native-vector-icons/FontAwesome';
import MaterialIcons from 'react-native-vector-icons/MaterialIcons';
import { Link } from 'expo-router';
import { ROUTES } from '@/constants/Routes';
import { LinkHrefType } from '@/constants/Types';
import { Octicons } from "@expo/vector-icons";

export default function Index() {
    const { theme, toggleTheme } = useTheme();
    const backgroundColor = useThemeColor({ light: Colors.light.background, dark: Colors.dark.background }, 'background');
    const textColor = useThemeColor({ light: Colors.light.text, dark: Colors.dark.text }, 'text');

    return (
        <View
            style={{
                flex: 1,
                justifyContent: 'space-between',
                alignItems: 'center',
                backgroundColor: backgroundColor,
                paddingVertical: 20,
            }}
        >
            <View style={{ alignItems: 'center' }}>
                <Image
                    source={require('../assets/images/transistortrackerlogo.png')}
                    style={{ width: 200, height: 200 }}
                />
                <Text style={{ fontWeight: 'bold', fontSize: 24, color: textColor }}>
                    Transistor Tracker
                </Text>
                <View style={{ flexDirection: 'column', marginTop: 20 }}>
                    <Link href={{ pathname: ROUTES.DEVICES as LinkHrefType }} style={{ marginVertical: 10, flexDirection: 'row', alignItems: 'center' }}>
                        <MaterialIcons name="devices-other" size={40} color={textColor} />
                        <Text style={{ color: textColor, marginLeft: 10, fontSize: 20 }}>Devices</Text>
                    </Link>
                    <Link href={{ pathname: ROUTES.PARTS as LinkHrefType }} style={{ marginVertical: 10, flexDirection: 'row', alignItems: 'center' }}>
                        <Octicons name="cpu" size={40} color={textColor} />
                        <Text style={{ color: textColor, marginLeft: 10, fontSize: 20 }}>Parts</Text>
                    </Link>
                    <Link href={{ pathname: ROUTES.LOCATIONS as LinkHrefType }} style={{ marginVertical: 10, flexDirection: 'row', alignItems: 'center' }}>
                        <MaterialIcons name="location-on" size={40} color={textColor} />
                        <Text style={{ color: textColor, marginLeft: 10, fontSize: 20 }}>Locations</Text>
                    </Link>
                </View>
            </View>
            <View style={{ flexDirection: 'row', marginTop: 20 }}>
                <TouchableOpacity
                    onPress={toggleTheme}
                    style={{ marginHorizontal: 10 }}
                    accessibilityRole="button"
                    accessibilityLabel={`Switch to ${theme === 'light' ? 'dark' : 'light'} mode`}
                    accessibilityHint={`Changes app theme to ${theme === 'light' ? 'dark' : 'light'} mode`}
                >
                    <Icon
                        name={theme === 'light' ? 'moon-o' : 'sun-o'}
                        size={40}
                        color={textColor}
                    />
                </TouchableOpacity>
                <TouchableOpacity
                    onPress={() => console.log('License and Readme')}
                    style={{ marginHorizontal: 10 }}
                    accessibilityRole="button"
                    accessibilityLabel="View License and Readme"
                    accessibilityHint="Opens the License and Readme"
                >
                    <MaterialIcons
                        name="description"
                        size={40}
                        color={textColor}
                    />
                </TouchableOpacity>
            </View>
        </View>
    );
}