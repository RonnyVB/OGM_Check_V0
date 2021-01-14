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
using System.Windows.Forms;


namespace OGM_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtGMededeling_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtGMededeling.Text.Length == 12)
            {
                if (MededelingCheck(txtGMededeling.Text) == true)
                {
                    //MessageBox.Show("Correct");
                    txtGMededeling.Background = Brushes.LightGreen;
                }
                else
                {
                    txtGMededeling.Background = Brushes.Red;
                }
            }
            else
            {
                txtGMededeling.Background = Brushes.White;
            }
        }

        private bool MededelingCheck(string Mededeling)
        {
            int Check, CommaLoc;
            double Werkgetal, Deling, Afronding, ControleGetal;
            if (txtGMededeling.Text.Length == 12)
            {
                Check = int.Parse(Mededeling.ToString().Substring(10, 2));
                Werkgetal = double.Parse(Mededeling.ToString().Substring(0, 10));
                Deling = Werkgetal / 97;
                CommaLoc = Deling.ToString().IndexOf(',');
                Afronding = double.Parse(Deling.ToString().Substring(0, CommaLoc));
                if (Deling == Afronding)
                {
                    ControleGetal = 97;
                }
                else
                {
                    ControleGetal = Werkgetal - (Afronding * 97);
                }
                if (ControleGetal == Check)
                {
                    return true;
                }
            }
            return false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "Check gestructureerde mededeling";
            txtGMededeling.Focus();
            
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(txtGMededeling.Text.Replace("/",""));
        }
    }
}
