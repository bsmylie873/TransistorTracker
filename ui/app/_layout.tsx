import React, { useEffect } from 'react';
import { Stack, useRouter } from 'expo-router';
import { ThemeProvider } from '@/context/ThemeContext';
import {LinkHrefType} from "@/constants/Types";
import Header from '@/components/Header';

export default function RootLayout() {
    const router = useRouter();

    useEffect(() => {
        // Check for auth tokens (this is a placeholder, replace with actual auth check)
         // Replace with actual token check logic

        router.replace('/login' as LinkHrefType);
    }, []);

    return (
        <ThemeProvider>
            <Header />
            <Stack
                screenOptions={{
                    headerShown: false,
                }}
            >
                <Stack.Screen name="index" />
                <Stack.Screen name="login" />
            </Stack>
        </ThemeProvider>
    );
}