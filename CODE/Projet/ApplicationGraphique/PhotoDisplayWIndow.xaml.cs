using Galerie;
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

namespace ApplicationGraphique
{
    /// <summary>
    /// Logique d'interaction pour PhotoDisplayWIndow.xaml
    /// </summary>
    public partial class PhotoDisplayWIndow : Window
    {
        public Photo PH1 { get; private set; }
        public PhotoDisplayWIndow(Photo p1)
        {
            InitializeComponent();
            DataContext = this;
            PH1 = p1;
        }

        private void Button_ClickCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
