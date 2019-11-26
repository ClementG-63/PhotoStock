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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationGraphique
{
    /// <summary>
    /// Logique d'interaction pour ImageUserControl.xaml
    /// </summary>
    public partial class ImageUserControl : UserControl
    {
        public Uri SourceLink
        {
            get => (Uri)GetValue(SourceProperty);
            set
            {
                SetValue(SourceProperty, value);
                Console.WriteLine(value);
            }
        }

        public static DependencyProperty SourceProperty = DependencyProperty.Register("SourceLink", typeof(Uri), typeof(ImageUserControl));

        public ImageUserControl()
        {
            InitializeComponent();
        }
    }
}
