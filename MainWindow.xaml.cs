using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tictactoe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] map = new string[9] {"N", "N", "N", "N", "N", "N", "N", "N", "N"};
        Turns turn = Turns.X;
        string status = "Begin";
        bool isFirstClick = false;
        bool isFinish = false;

        TextBlock lb_turn, lb_status;

        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            lb_turn = (TextBlock) this.FindName("Label_Turn");
            lb_status = (TextBlock) this.FindName("Label_Status");
            reloadBoard();
        }

        private void reloadBoard()
        {
            lb_turn.Text = turn.ToString();
            lb_status.Text = status;
        }

        private void gameFinish(Turns winner)
        {
            isFinish = true;

            if(winner != Turns.P)
            {
                status = winner.ToString() + " Won";
                reloadBoard();
            } else
            {
                status = "Tied";
                reloadBoard();
            }
        }

        private Turns isWin()
        {
            Turns winner = Turns.N;

            if(map[0] == map[1] && map[1] == map[2] && map[0] != "N")
            {
                if (map[0] == "O") { winner = Turns.O; } else { winner = Turns.X; }
            }
            else if(map[3] == map[4] && map[4] == map[5] && map[3] != "N")
            {
                if (map[3] == "O") { winner = Turns.O; } else { winner = Turns.X; }
            }
            else if (map[6] == map[7] && map[7] == map[8] && map[6] != "N")
            {
                if (map[6] == "O") { winner = Turns.O; } else { winner = Turns.X; }
            }
            else if (map[0] == map[3] && map[3] == map[6] && map[0] != "N")
            {
                if (map[0] == "O") { winner = Turns.O; } else { winner = Turns.X; }
            }
            else if (map[1] == map[4] && map[4] == map[7] && map[1] != "N")
            {
                if (map[1] == "O") { winner = Turns.O; } else { winner = Turns.X; }
            }
            else if (map[2] == map[5] && map[5] == map[8] && map[2] != "N")
            {
                if (map[2] == "O") { winner = Turns.O; } else { winner = Turns.X; }
            }
            else if (map[0] == map[4] && map[4] == map[8] && map[0] != "N")
            {
                if (map[0] == "O") { winner = Turns.O; } else { winner = Turns.X; }
            }
            else if (map[2] == map[4] && map[4] == map[6] && map[2] != "N")
            {
                if (map[2] == "O") { winner = Turns.O; } else { winner = Turns.X; }
            }

            int i = 0;
            int rs = 0;
            foreach(string item in map)
            {
                if(item != "N")
                {
                    rs++;
                }

                i++;
            }
            if(rs == 9)
            {
                winner = Turns.P;
            }

            return winner;
        }

        private void blockClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if(!isFirstClick)
            {
                isFirstClick = true;
                status = "Gaming";
                reloadBoard();
            }

            if((string) btn.Content != "X" && (string) btn.Content != "O" && !isFinish)
            {
                map[int.Parse(btn.Name.Replace("Btn_", "")) - 1] = turn.ToString();
                btn.Content = turn.ToString();

                if (turn == Turns.X)
                {
                    turn = Turns.O;
                }
                else
                {
                    turn = Turns.X;
                }

                Turns winner = isWin();

                if(winner != Turns.N)
                {
                    gameFinish(winner);
                }

                reloadBoard();
            }
        }
    }

    public enum Turns {X, O, N, P}
}
