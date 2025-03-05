import React, { useEffect } from 'react';
import { Stack } from 'expo-router';
import { ThemeProvider } from '@/context/ThemeContext';
import Header from '@/components/Header';
import { ROUTES } from '@/constants/Routes';
import {QueryClient, QueryClientContext, QueryClientProvider} from '@tanstack/react-query';

const queryClient = new QueryClient();

export default function RootLayout() {
    useEffect(() => {
        // Check for auth tokens (this is a placeholder, replace with actual auth check)
        // Replace with actual token check logic

        //router.replace('/login' as LinkHrefType);
    }, []);

    return (
        <QueryClientContext.Provider value={queryClient}>
            <ThemeProvider>
                <Header />
                <Stack
                    screenOptions={{
                        headerShown: false,
                    }}
                >
                    <Stack.Screen name={ROUTES.INDEX} />
                    <Stack.Screen name={ROUTES.LOGIN} />
                    <Stack.Screen name={ROUTES.DEVICES} />
                </Stack>
            </ThemeProvider>
        </QueryClientContext.Provider>
    );
}