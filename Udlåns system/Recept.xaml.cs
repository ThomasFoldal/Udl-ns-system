using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Udlåns_system
{
    /// <summary>
    /// Interaction logic for Recept.xaml
    /// </summary>
    public partial class Recept : Window
    {
        Recept recept_ref;
        public Recept()
        {
            InitializeComponent();
            recept_ref = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string con_string = "datasource=localhost;database=udlaans system;port=3306;username=root;password=";
            MySqlConnection con = new MySqlConnection(con_string);
            con.Open();
            MySqlDataAdapter dtb = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            string input_bruger = in_bruger.Text;
            int Input_bruger = Convert.ToInt32(input_bruger);
            string input_udlaan = in_udlaan.Text;
            string input_aflevering = in_aflevering.Text;
            cmd.CommandText = "lavRecept";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@elev", Input_bruger);
            cmd.Parameters.AddWithValue("@udlaansdato", input_udlaan);
            cmd.Parameters.AddWithValue("@afleveringsdato", input_aflevering);
            cmd.ExecuteNonQuery();

            cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "findReceptID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bruger", Input_bruger);
            cmd.Parameters.AddWithValue("@udlaansdato", input_udlaan);
            cmd.Parameters.AddWithValue("@aflevering", input_aflevering);
            cmd.Parameters.Add("@recept", MySqlDbType.Int32);
            cmd.Parameters["@recept"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int recept_ID = Convert.ToInt32(cmd.Parameters["@recept"].Value);
            Udlån udlaan_form = new Udlån(recept_ID);
            udlaan_form.Show();
            recept_ref.Close();
        }
    }
}
