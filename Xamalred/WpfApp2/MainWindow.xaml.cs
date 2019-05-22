using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
using System.IO;
using System.Windows.Markup;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnView_XamalClick (object sender,RoutedEventArgs e)
        {
            File.WriteAllText("YourXaml.xaml",txtDataXaml.Text);
            Window MyWindow=null;
            try
            {
                using (Stream sr = File.Open("YourXaml.xaml", FileMode.Open))
                {
                    MyWindow=(Window)XamlReader.Load(sr); 
                    MyWindow.ShowDialog();
                    MyWindow.Close();
                    MyWindow=null;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Window_Loaded(object sender,EventArgs e)
        {
            if(File.Exists("YourXaml.xaml"))
            {
                txtDataXaml.Text=File.ReadAllText("YourXaml.xaml");
            }
            else
                txtDataXaml.Text=
                    "<Window xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n"
                     +"xmlns: x =\"http://schemas.microsoft.com/winfx/2006/xaml \"\n"
                     +" Height = \"450\" Width =\"1041\" WindowStartupLocation = \"CenterScreen\">\n" 
                     +"<StackPanel>\n"
                     +"</StackPanel>\n"
                     +"</Window>";
        }
        private void Window_Closed(object sender,EventArgs e)
        {
            File.WriteAllText("YourXaml.xaml",txtDataXaml.Text);
            Application.Current.Shutdown();
        }
    }
}
