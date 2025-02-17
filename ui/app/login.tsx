import React from 'react';
import {View, Text, TextInput, StatusBar, Image} from 'react-native';
import { Link } from 'expo-router';
import { useThemeColor } from '@/hooks/useThemeColor';
import { useTheme } from '@/context/ThemeContext';
import { Colors } from '@/constants/Colors';
import { ROUTES } from "@/constants/Routes";
import { LinkHrefType } from "@/constants/Types";

export default function Login() {
    const { theme } = useTheme();
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
            <StatusBar backgroundColor={backgroundColor} barStyle={theme === 'light' ? 'dark-content' : 'light-content'} />
            <Image
                source={require('../assets/images/transistortrackerlogo.png')}
                style={{ width: 150, height: 150, marginBottom: 20, marginTop: -75 }}
            />
            <Text style={{ fontWeight: 'bold', fontSize: 24, color: textColor, marginBottom: 20 }}>
                Transistor Tracker
            </Text>
            <TextInput
                placeholder="Username"
                placeholderTextColor={textColor}
                style={{ height: 40, borderColor: textColor, borderWidth: 1, marginBottom: 20, width: '80%', paddingHorizontal: 10, color: textColor }}
            />
            <TextInput
                placeholder="Password"
                placeholderTextColor={textColor}
                secureTextEntry
                style={{ height: 40, borderColor: textColor, borderWidth: 1, marginBottom: 20, width: '80%', paddingHorizontal: 10, color: textColor }}
            />
            <Link href={{ pathname: ROUTES.INDEX as LinkHrefType }} style={{ color: textColor, fontSize: 18 }}>
                Login
            </Link>
        </View>
    );
}