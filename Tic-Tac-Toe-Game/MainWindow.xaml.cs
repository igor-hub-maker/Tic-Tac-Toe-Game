using System.Windows;

namespace Tic_Tac_Toe_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            NavigationManager.InitializeMenu(this); //ініціалізація навігації
            InitializeComponent();
            this.Closing += MainWindow_Closing;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.OpenTwoPlayresWindow(this); // відкриття вікна для гри на двох
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationManager.OpenBotDifficultyMenuWindow(this); // перехід на вибір складності при грі з ботом
        }
    }
}
