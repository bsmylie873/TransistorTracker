import { useTheme } from '@/context/ThemeContext';

  export const useThemeColor = (colors: { light: string; dark: string }, colorName: string) => {
    const { theme } = useTheme();
    return colors[theme];
  };