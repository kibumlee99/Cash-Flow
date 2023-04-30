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

namespace Cash_Flow
{
    /// <summary>
    /// Interaction logic for howto.xaml
    /// </summary>
    public partial class howto : Window
    {
        public howto()
        {
            InitializeComponent();
            this.Title = "How to Play";
        }

        private void professionButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Add(new specifics());
        }
    }
}
