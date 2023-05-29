using System.Windows;

namespace Tic_Tac_Toe_Game
{
    /// <summary>
    /// Логика взаимодействия для BotDifficultyMenu.xaml
    /// </summary>
    public partial class BotDifficultyMenuWindow : Window
    {
        public BotDifficultyMenuWindow()
        {
            InitializeComponent();
            Closing += BotDifficultyMenuWindow_Closing;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.OpenBotGameWindow(this, 1); //перехід на сторінку гри з ботом та передачею потрібного рівня складності
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationManager.OpenBotGameWindow(this, 2); //перехід на сторінку гри з ботом та передачею потрібного рівня складності
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationManager.OpenBotGameWindow(this, 3); //перехід на сторінку гри з ботом та передачею потрібного рівня складності
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationManager.OpenMenuWindow(this); //перехід на головну сторінку
        }

        private void BotDifficultyMenuWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

    }
}
