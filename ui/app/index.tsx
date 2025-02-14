import React from 'react';
import { Text, View, Image, TouchableOpacity } from 'react-native';
import { useThemeColor } from '@/hooks/useThemeColor';
import { useTheme } from '@/context/ThemeContext';
import { Colors } from '@/constants/Colors';
import Icon from 'react-native-vector-icons/FontAwesome';

export default function Index() {
    const { theme, toggleTheme } = useTheme();
    const backgroundColor = useThemeColor({ light: Colors.light.background, dark: Colors.dark.background }, 'background');
    const textColor = useThemeColor({ light: Colors.light.text, dark: Colors.dark.text }, 'text');

    return (
        <View
            style={{
                flex: 1,
                justifyContent: 'center',
                alignItems: 'center',
                backgroundColor: backgroundColor,
            }}
        >
            <Image
                source={require('../assets/images/transistortrackerlogo.png')}
                style={{ width: 200, height: 200 }}
            />
            <Text style={{ fontWeight: 'bold', fontSize: 24, color: textColor }}>
                Transistor Tracker
            </Text>
            <TouchableOpacity onPress={toggleTheme} style={{ marginTop: 20 }}>
                <Icon
                    name={theme === 'light' ? 'moon-o' : 'sun-o'}
                    size={30}
                    color={textColor}
                />
            </TouchableOpacity>
        </View>
    );
}