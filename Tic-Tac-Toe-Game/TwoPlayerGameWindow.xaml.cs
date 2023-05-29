using System.Windows;
using System.Windows.Controls;

namespace Tic_Tac_Toe_Game
{
    /// <summary>
    /// Логика взаимодействия для TwoPlayerWindow.xaml
    /// </summary>
    public partial class TwoPlayerGameWindow : Window
    {
        public string[,] map = new string[3, 3]; //двомірний масив для поля
        public bool isXTurn = true; // змінна для перевірки гравця який зараз ходить
        public bool isXFirst = true; // змінна для перевірки гравця який ходить першим
        public int Xscore = 0; // рахунок першого гравця
        public int Oscore = 0; // рахунок другого гравця
        public TwoPlayerGameWindow()
        {
            InitializeComponent();
            this.Closing += TwoPlayerWindow_Closing;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content is null) // перевірка чи поле зайняте
            {
                string XO = "";
                if (isXTurn)
                {
                    XO = "X";
                    isXTurn = false;
                }
                else
                {
                    XO = "O";
                    isXTurn = true;
                }
                switch (button.Name) // перевірка яке поле було натиснуто та зміна потрібного поля в масиві
                {
                    case "button1":
                        map[0, 0] = XO;
                        break;
                    case "button2":
                        map[0, 1] = XO;
                        break;
                    case "button3":
                        map[0, 2] = XO;
                        break;
                    case "button4":
                        map[1, 0] = XO;
                        break;
                    case "button5":
                        map[1, 1] = XO;
                        break;
                    case "button6":
                        map[1, 2] = XO;
                        break;
                    case "button7":
                        map[2, 0] = XO;
                        break;
                    case "button8":
                        map[2, 1] = XO;
                        break;
                    case "button9":
                        map[2, 2] = XO;
                        break;

                }
                button.Content = XO;
                WinCheck(); // перевірка чи є переможець
            }
        }

        public void WinCheck()
        {
            // далі прописана логіка для перевірки всі варіантів коли один з гравців перемагає 
            for (int y = 0; y < 3; y++)
            {
                if (map[y, 0] == "X" && map[y, 1] == "X" && map[y, 2] == "X")
                {
                    winner.Content = "X wins";
                    winner.Visibility = Visibility.Visible;
                    Xscore++;
                    EndGame();
                    break;
                }
                if (map[y, 0] == "O" && map[y, 1] == "O" && map[y, 2] == "O")
                {
                    winner.Content = "O wins";
                    winner.Visibility = Visibility.Visible;
                    Oscore++;
                    EndGame();
                    break;
                }
            }
            for (int x = 0; x < 3; x++)
            {
                if (map[0, x] == "X" && map[1, x] == "X" && map[2, x] == "X")
                {
                    winner.Content = "X wins";
                    winner.Visibility = Visibility.Visible;
                    Xscore++;
                    EndGame();
                    break;
                }
                if (map[0, x] == "O" && map[1, x] == "O" && map[2, x] == "O")
                {
                    winner.Content = "O wins";
                    winner.Visibility = Visibility.Visible;
                    Oscore++;
                    EndGame();
                    break;
                }
            }
            if (map[0, 0] == "X" && map[1, 1] == "X" && map[2, 2] == "X")
            {
                winner.Content = "X wins";
                winner.Visibility = Visibility.Visible;
                Xscore++;
                EndGame();
            }
            else if (map[2, 0] == "X" && map[1, 1] == "X" && map[0, 2] == "X")
            {
                winner.Content = "X wins";
                winner.Visibility = Visibility.Visible;
                Xscore++;
                EndGame();
            }
            else if (map[0, 0] == "O" && map[1, 1] == "O" && map[2, 2] == "O")
            {
                winner.Content = "O wins";
                winner.Visibility = Visibility.Visible;
                Oscore++;
                EndGame();
            }
            else if (map[2, 0] == "O" && map[1, 1] == "O" && map[0, 2] == "O")
            {
                winner.Content = "O wins";
                winner.Visibility = Visibility.Visible;
                Oscore++;
                EndGame();
            }
            if (winner.Visibility is Visibility.Hidden)
            {
                int buttonsFilled = 0;
                foreach (var m in map)
                {
                    if (!string.IsNullOrEmpty(m))
                    {
                        buttonsFilled++;
                    }
                }
                if (buttonsFilled == 9)
                {
                    winner.Content = "Draw!";
                    winner.Visibility = Visibility.Visible;
                    EndGame();
                }
            }
        }

        public void EndGame()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
            score.Content = Xscore + ":" + Oscore; //оновлення рахунку
            restartButton.Visibility = Visibility.Visible;
        }
        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            for (int y = 0; y < 3; y++) //очищення поля
            {
                for (int x = 0; x < 3; x++)
                {
                    map[y, x] = "";
                }
            }
            button1.Content = null;
            button2.Content = null;
            button3.Content = null;
            button4.Content = null;
            button5.Content = null;
            button6.Content = null;
            button7.Content = null;
            button8.Content = null;
            button9.Content = null;
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled = true;
            button9.IsEnabled = true;
            if (isXFirst)
                isXFirst = false;
            else
                isXFirst = true;
            winner.Visibility = Visibility.Hidden;
            restartButton.Visibility = Visibility.Hidden;
        }

        private void toMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.OpenMenuWindow(this); //перехід на головну сторінку
        }
        private void TwoPlayerWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
