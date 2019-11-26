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
    /// Logique d'interaction pour ImageUserControlADMIN.xaml
    /// </summary>
    public partial class ImageUserControlADMIN : UserControl
    {
        public Uri SourcePhotoAdmin
        {
            get => (Uri)GetValue(SourcePhotoAdminProperty);
            set
            {
                SetValue(SourcePhotoAdminProperty, value);
            }
        }

        public static DependencyProperty SourcePhotoAdminProperty = DependencyProperty.Register("SourcePhotoAdmin", typeof(Uri), typeof(ImageUserControlADMIN));
        public ImageUserControlADMIN()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler ClickOnRedCross;

        private void Button_Click_RedCrossForDeletePicUserControl(object sender, RoutedEventArgs e)
        {
            ClickOnRedCross?.Invoke(sender, new RoutedEventArgs()); // On verifie si Click est null, si il ne l'est pas, on effectue Click == Délégué
        }
    }
}
