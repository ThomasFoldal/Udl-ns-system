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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace Udlåns_system
{
    /// <summary>
    /// Interaction logic for Udlån.xaml
    /// </summary>
    public partial class Udlån : Window
    {
        public int recept_ID;
        internal MySqlConnection con;

        public Udlån(int recept_id)
        {
            InitializeComponent();
            string con_string = "datasource=localhost;database=udlaans system;port=3306;username=root;password=";
            con = new MySqlConnection(con_string);
            con.Open();
            recept_ID = recept_id;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "tilfojUdlaan";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@recept_id", recept_ID);
            cmd.Parameters.AddWithValue("@enheds_id", Convert.ToInt32(enhed.Text));
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT * FROM udlaan WHERE recept_ID = " + recept_ID;
            cmd.CommandType = CommandType.Text;
            Data.ItemsSource = (cmd.ExecuteReader());
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            this.con.Close();
            this.Close();
        }
    }
}
