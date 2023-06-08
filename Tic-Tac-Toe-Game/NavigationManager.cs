using System;
using System.Windows;

namespace Tic_Tac_Toe_Game
{
    public static class NavigationManager
    {
        public static MainWindow MenuWindow = new MainWindow() { Visibility = Visibility.Hidden }; //створення змінної головної сторінки
        public static BotDifficultyMenuWindow BotDifficultyMenuWindow = new BotDifficultyMenuWindow() { Visibility = Visibility.Hidden }; //створення змінної сторінки вибору складності с ботом
        public static BotGameWindow BotGameWindow = new BotGameWindow(1) { Visibility = Visibility.Hidden }; //створення змінної сторінки гри з ботом
        public static TwoPlayerGameWindow TwoPlayresGameWindow = new TwoPlayerGameWindow() { Visibility = Visibility.Hidden }; //створення змінної сторінки гри на двох

        public static void InitializeMenu(object sender)
        {
            MenuWindow = (MainWindow)sender; //ініціалізація головної сторінки для запобігання створення двох таких
        }

        public static void OpenMenuWindow(object sender)
        {
            var window = (Window)sender;
            window.Visibility = Visibility.Hidden; //прихованя сторінки, яка визвала перехід
            MenuWindow.Visibility = Visibility.Visible; //показ головної сторінки
        }
        public static void OpenTwoPlayresWindow(object sender)
        {
            var window = (Window)sender;
            window.Visibility = Visibility.Hidden; //прихованя сторінки, яка визвала перехід
            TwoPlayresGameWindow = new TwoPlayerGameWindow(); // оновлення сторінки для гри на двох
            GC.Collect();
            TwoPlayresGameWindow.Visibility = Visibility.Visible; //показ сторінки для гри на двох
        }
        public static void OpenBotGameWindow(object sender, int difficulty)
        {
            var window = (Window)sender;
            window.Visibility = Visibility.Hidden; //прихованя сторінки, яка визвала перехід
            BotGameWindow = new BotGameWindow(difficulty); //оновлення сторінки для гри з ботом
            GC.Collect();
            BotGameWindow.Visibility = Visibility.Visible; //показ сторінки для гри з ботом
        }

        public static void OpenBotDifficultyMenuWindow(object sender)
        {
            var window = (Window)sender;
            window.Visibility = Visibility.Hidden; //прихованя сторінки, яка визвала перехід
            BotDifficultyMenuWindow.Visibility = Visibility.Visible; //показ сторінки для вибору складності 
        }
    }
}
