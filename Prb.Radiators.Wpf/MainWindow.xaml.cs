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

namespace Prb.Radiators.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private object panBottom;
        private object item;

        public MainWindow()
        {
            InitializeComponent();

            double lengthRoom = double.Parse(txtRoomLength.Text);
            double widthRoom = double.Parse(txtRoomWidth.Text);
            double heightRoom = double.Parse(txtRoomHeight.Text);


        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            panTop.IsEnabled = true;
            panBottom.IsEnabled = false;
            FillComboBoxes();
            ResetControls();
        }

        private void ResetControls()
        {

        }

        private void FillComboBoxes()
        {

        }



        private void BtnCalculateVolumeAndWatts_Click(object sender, RoutedEventArgs e)
        {
            double lengthRoom = double.Parse(txtRoomLength.Text);
            double widthRoom = double.Parse(txtRoomWidth.Text);
            double heightRoom = double.Parse(txtRoomHeight.Text);

            double volume = lengthRoom * widthRoom * heightRoom / 1000000;
            double watts = volume * 50;

            lblRoomValue.Content = $"{volume: n2}".ToString();  //Alles afronden naar 0.00
            lblRoomWatts.Content = watts.ToString();

            panTop.IsEnabled = false;
            panBottom.IsEnabled = true;
        }

        private void BtnCalculateRadiatorWatts_Click(object sender, RoutedEventArgs e)
        {
            double heightRadiator = double.Parse(cmbRadiatorHeight.SelectedValue.ToString());
            double width = double.Parse(cmbRadiatorWidth.SelectedValue.ToString());
            int panels = int.Parse(cmbRadiatorPanels.SelectedValue.ToString());

            double watts = heightRadiator * width * panels * 0.15;
            lblRadiatorWatts.Content = watts.ToString();
            btnAddRadiatorHeight.Visibility = Visibility.Visible;
        }

        private void CmbRadiatorHeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblRadiatorWatts.Content = "";
            btnAddRadiatorHeight.Visibility = Visibility.Collapsed;

        }

        private void CmbRadiatorWidth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblRadiatorWatts.Content = "";
            btnAddRadiatorHeight.Visibility = Visibility.Collapsed;
        }

        private void CmbRadiatorPanels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblRadiatorWatts.Content = "";
            btnAddRadiatorHeight.Visibility = Visibility.Collapsed;
        }

        private void btnAddRadiatorHeight_Click(object sender, RoutedEventArgs e)
        {
            double height = double.Parse(cmbRadiatorHeight.SelectedValue.ToString());
            double width = double.Parse(cmbRadiatorWidth.SelectedValue.ToString());
            int panels = int.Parse(cmbRadiatorPanels.SelectedValue.ToString());

            double watts = height * width * panels * 0.15;

            lstRadiators.Items.Add($"Radiator ({height} x {width} x {panels}) - {watts} W");

            double totalWatts = 0;
            foreach (string item in lstRadiators.Items) ;

            {
                string[] values = item.Split('-');
                totalWatts += double.Parse(values[1].Trim());
            }

            lblTotalWatts.Content = $"Total Watts: {totalWatts} W";
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetControls();
        }


    }   
       
        
}
