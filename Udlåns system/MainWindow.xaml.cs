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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace Udlåns_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindow main;
        MySqlConnection con;
        public MainWindow()
        {
            string con_string = "datasource=localhost;database=udlaans system;port=3306;username=root;password=";
            con = new MySqlConnection(con_string);
            MySqlCommand cmd = new MySqlCommand();
            InitializeComponent();
            main = this;
        }

        private void Udlån_Click(object sender, RoutedEventArgs e)
        {
            Recept ny_Recept = new Recept();
            ny_Recept.Show();
            main.IsEnabled = false;
        }

        private void Vis_Ud_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "visUdlaant";
            cmd.CommandType = CommandType.StoredProcedure;
            dataTable.ItemsSource = cmd.ExecuteReader();
            con.Close();
        }

        private void Overskrevende_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "visOverskraevetUdlaan";
            cmd.CommandType = CommandType.StoredProcedure;
            dataTable.ItemsSource = cmd.ExecuteReader();
            con.Close();
        }

        private void Tilgaengelige_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "visTilgaengeligeEnheder";
            cmd.CommandType = CommandType.StoredProcedure;
            dataTable.ItemsSource = cmd.ExecuteReader();
            con.Close();
        }

        private void Alle_Udlaan_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "visAlleUdlaan";
            cmd.CommandType = CommandType.StoredProcedure;
            dataTable.ItemsSource = cmd.ExecuteReader();
        }
    }
}
