using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Tic_Tac_Toe_Game
{
    /// <summary>
    /// Логика взаимодействия для BotGameWindow.xaml
    /// </summary>
    public partial class BotGameWindow : Window
    {
        private readonly int difficulty; // змінна яка виміряє складність
        public string[,] map = new string[3, 3]; //двумірний масив поля
        public bool isXTurn = true; //зміна для перевірки хто ходить
        public bool isXFirst = true; //зміна для перевірки того хто ходить перший
        public int Xscore = 0; // зміна очків гравця
        public int Oscore = 0; //зміна очків бота
        public BotGameWindow(int difficulty)
        {
            InitializeComponent();
            this.difficulty = difficulty; //збереження складності
            this.Closing += BotGameWindow_Closing;
        }

        private void BotGameWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void PlayerTurn(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Content is null)
            {
                switch (button.Name) //збереження в масиві натиснутої кнопки
                {
                    case "button1":
                        map[0, 0] = "X";
                        break;
                    case "button2":
                        map[0, 1] = "X";
                        break;
                    case "button3":
                        map[0, 2] = "X";
                        break;
                    case "button4":
                        map[1, 0] = "X";
                        break;
                    case "button5":
                        map[1, 1] = "X";
                        break;
                    case "button6":
                        map[1, 2] = "X";
                        break;
                    case "button7":
                        map[2, 0] = "X";
                        break;
                    case "button8":
                        map[2, 1] = "X";
                        break;
                    case "button9":
                        map[2, 2] = "X";
                        break;

                }
                button.Content = "X";
                WinCheck(); //перевірка чи є переможець
                if (button1.IsEnabled is true) //перевірка чи гра завершена
                {
                    BotTurn(); //хід бота
                    WinCheck(); //перевірка чи є переможець
                }
            }
        }

        private void BotTurn()
        {
            // Принцип роботи бота: кожна складність має своє число і
            // при множенні цього числа можна отримати шанс при якому бот зробить вірний хід.
            // якщо шанс спрацьвав то бот аналізує поле та робить вірний хід
            // якщо шанс не спрацбвав то бот зробить випадковий хід
            Random rnd = new Random();
            if (rnd.Next(1, 100) <= difficulty * 25)
            {
                if (string.IsNullOrEmpty(map[1, 1]))
                {
                    map[1, 1] = "O";
                    button5.Content = "O";
                    return;
                }
                if (map[1, 1] == "X")
                {
                    if (map[0, 0] == "X")
                    {
                        if (string.IsNullOrEmpty(map[2, 2]))
                        {
                            map[2, 2] = "O";
                            button9.Content = "O";
                            return;
                        }
                    }
                    if (map[0, 2] == "X")
                    {
                        if (string.IsNullOrEmpty(map[2, 0]))
                        {
                            map[2, 0] = "O";
                            button7.Content = "O";
                            return;
                        }
                    }
                    if (map[2, 0] == "X")
                    {
                        if (string.IsNullOrEmpty(map[0, 2]))
                        {
                            map[0, 2] = "O";
                            button3.Content = "O";
                            return;
                        }
                    }
                    if (map[2, 2] == "X")
                    {
                        if (string.IsNullOrEmpty(map[0, 0]))
                        {
                            map[0, 0] = "O";
                            button1.Content = "O";
                            return;
                        }
                    }
                    if (map[1, 0] == "X")
                    {
                        if (string.IsNullOrEmpty(map[1, 2]))
                        {
                            map[1, 2] = "O";
                            button6.Content = "O";
                            return;
                        }
                    }
                    if (map[1, 2] == "X")
                    {
                        if (string.IsNullOrEmpty(map[1, 0]))
                        {
                            map[1, 0] = "O";
                            button4.Content = "O";
                            return;
                        }
                    }
                    if (map[0, 1] == "X")
                    {
                        if (string.IsNullOrEmpty(map[2, 1]))
                        {
                            map[2, 1] = "O";
                            button8.Content = "O";
                            return;
                        }
                    }
                    if (map[2, 1] == "X")
                    {
                        if (string.IsNullOrEmpty(map[0, 1]))
                        {
                            map[0, 1] = "O";
                            button2.Content = "O";
                            return;
                        }
                    }
                }
                if (map[0, 0] == "X" && map[0, 2] == "X")
                {
                    if (string.IsNullOrEmpty(map[0, 1]))
                    {
                        map[0, 1] = "O";
                        button2.Content = "O";
                        return;
                    }
                }
                if (map[2, 0] == "X" && map[2, 2] == "X")
                {
                    if (string.IsNullOrEmpty(map[2, 1]))
                    {
                        map[2, 1] = "O";
                        button8.Content = "O";
                        return;
                    }
                }
                if (map[0, 0] == "X" && map[2, 0] == "X")
                {
                    if (string.IsNullOrEmpty(map[1, 0]))
                    {
                        map[1, 0] = "O";
                        button4.Content = "O";
                        return;
                    }
                }
                if (map[0, 2] == "X" && map[2, 2] == "X")
                {
                    if (string.IsNullOrEmpty(map[1, 2]))
                    {
                        map[1, 2] = "O";
                        button6.Content = "O";
                        return;
                    }
                }

            }
            List<int[]> p = new List<int[]>();
            for (int g = 0; g < 3; g++)
            {
                for (int f = 0; f < 3; f++)
                {
                    if (string.IsNullOrEmpty(map[g, f]))
                    {
                        int[] n = { g, f };
                        p.Add(n);
                    }
                }
            }
            int r = rnd.Next(0, p.Count);
            int y = p[r][0];
            int x = p[r][1];
            map[y, x] = "O";
            if (y == 0 && x == 0)
            {
                button1.Content = "O";
            }
            else if (y == 0 && x == 1)
            {
                button2.Content = "O";
            }
            else if (y == 0 && x == 2)
            {
                button3.Content = "O";
            }
            else if (y == 1 && x == 0)
            {
                button4.Content = "O";
            }
            else if (y == 1 && x == 1)
            {
                button5.Content = "O";
            }
            else if (y == 1 && x == 2)
            {
                button6.Content = "O";
            }
            else if (y == 2 && x == 0)
            {
                button7.Content = "O";
            }
            else if (y == 2 && x == 1)
            {
                button8.Content = "O";
            }
            else if (y == 2 && x == 2)
            {
                button9.Content = "O";
            }
        }

        public void WinCheck()
        {
            //перевірка всіх можливих варіантів де може бути переможець
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
                int c = 0;
                foreach (var m in map)
                {
                    if (!string.IsNullOrEmpty(m))
                    {
                        c++;
                    }
                }
                if (c == 9)
                {
                    winner.Content = "Draw";
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
            score.Content = Xscore + ":" + Oscore; //оновлення рахунуу
            restartButton.Visibility = Visibility.Visible;
        }
        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            for (int y = 0; y < 3; y++) //очищення масиву поля
            {
                for (int x = 0; x < 3; x++)
                {
                    map[y, x] = "";
                }
            }
            // очищення поля
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
            NavigationManager.OpenMenuWindow(this); //перехід на головне меню
        }
    }
}
