using Amoba;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmobaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameState gamestate = new GameState(4, 4);

        public MainWindow()
        {
            InitializeComponent();
        }
        private void BingoTablatKeszit()
        {
            string content = "O";

            AmobaGrid.Children.Clear();
            for (int i = 0; i < gamestate.Tabla.GetLength(0); i++)
            {
                for (int j = 0; j < gamestate.Tabla.GetLength(1); j++)
                {
                    var field = new Button() { Margin = new Thickness(0.5) };
                    field.Click += (sender, e) =>
                    {
                        content = (content == "O") ? "X" : "O";
                        field.FontSize = 20;
                        field.FontWeight = FontWeights.Bold;
                        field.Content = content;
                        field.IsEnabled = false;
                        gamestate.Tabla[Grid.GetRow((UIElement)sender), Grid.GetColumn((UIElement)sender)] = (string)field.Content;
                        if (gamestate.CheckGameOver(content))
                        {
                            string nyertes = (content == "X") ? Jatekos1.Text : Jatekos2.Text;
                            MessageBox.Show($"{nyertes} nyert!");
                            fajlNev.Text = gamestate.CreateGameState();
                        }
                    };
                    AmobaGrid.Children.Add(field);
                    Grid.SetRow(field, i);
                    Grid.SetColumn(field, j);
                    gamestate.Tabla[i, j] = "";
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < gamestate.Tabla.GetLength(0); i++)
            {
                var gridLength = new GridLength(40);
                AmobaGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = gridLength
                });
                AmobaGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = gridLength
                });
            }

            BingoTablatKeszit();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            if (fajlNev.Text != "" && Jatekos1.Text != "" && Jatekos2.Text != "")
            {
                string fajl = fajlNev.Text;
                gamestate.Jatekos1 = Jatekos1.Text;
                gamestate.Jatekos2 = Jatekos2.Text;

                gamestate.SaveGameState(gamestate, fajl);

                if (File.Exists(fajl))
                {
                    MessageBox.Show($"{fajl} mentése sikeres volt!");
                }
                else { MessageBox.Show($"{fajl} mentése sikertelen!"); }

                BingoTablatKeszit();
            }
            else { MessageBox.Show("A játék eredményéek mentéséhez, a szöveges mezőket ki kell tölteni!"); }
        }
    }
}