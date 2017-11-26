using System;
using System.Collections.Generic;
using System.Linq;
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

namespace game_model_remake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IGame myLevel;
        public MainWindow()
        {
            // # = wall
            // f = floor
            // b = block
            // o = objective
            string level = "#####fo##fb##ff##ff##ff#####";
            int rowWidth = 4;
            int playerX = 1;
            int playerY = 1;
            myLevel = new Level(1, rowWidth, playerX, playerY, level);
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            myLevel.MovePlayer(Direction.LEFT);
            movesUpdate();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            myLevel.MovePlayer(Direction.RIGHT);
            movesUpdate();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            myLevel.MovePlayer(Direction.UP);
            movesUpdate();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            myLevel.MovePlayer(Direction.DOWN);
            movesUpdate();
        }

        private void movesUpdate()
        {
            label.Content = "Total Moves: " + myLevel.GetMoveCount();
        }
    }
}
