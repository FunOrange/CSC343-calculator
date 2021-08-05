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

namespace CSC343_calculator.Views
{
    /// <summary>
    /// Interaction logic for TopView.xaml
    /// </summary>
    public partial class TopView : Window
    {
        public TopView()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClosureTarget1.Text = "";
            ClosureTarget2.Text = "";
            ClosureTarget3.Text = "";
            ClosureTarget4.Text = "";
            WithoutFD.Text = "";
        }
    }
}
