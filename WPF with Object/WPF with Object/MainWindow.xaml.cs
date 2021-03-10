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
using ViewModel;

namespace WPFWithObject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ForceUserViewModel VM;

        public MainWindow()
        {
            InitializeComponent();
            VM = new ForceUserViewModel();
            DataContext = VM;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void bAddRank_Click(object sender, RoutedEventArgs e)
        {
            if (VM.Rank < 4)
            VM.Rank++;
            VM.UpdateRankName();
        }

        private void bDecreaseRank_Click(object sender, RoutedEventArgs e)
        {
            if (VM.Rank > 0)
                VM.Rank--;
            VM.UpdateRankName();
        }

        private void bName_Click(object sender, RoutedEventArgs e)
        {
            if (boxName.Text != VM.Name && !string.IsNullOrWhiteSpace(boxName.Text))
                VM.Name = boxName.Text;
        }

        private void bSpecies_Click(object sender, RoutedEventArgs e)
        {
            if (boxSpecies.Text != VM.Species && !string.IsNullOrWhiteSpace(boxSpecies.Text))
                VM.Species = boxSpecies.Text;
        }

        private void bChangeSides_Click(object sender, RoutedEventArgs e)
        {
            VM.ChangeSides();
        }

        private void bColor_Click(object sender, RoutedEventArgs e)
        {
            if (boxColor.Text != VM.LightsaberColor && !string.IsNullOrWhiteSpace(boxColor.Text))
                VM.LightsaberColor = boxColor.Text;
        }
    }
}
