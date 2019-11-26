using Data;
using Galerie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    public partial class Accueil_Photos : Window
    {
        public ListeFiltre Liste1 { get; private set; }//Propriété en lecture seul qui va chercher dans LFapp de App.xaml.cs
        public GaleriePhoto Gal1 { get; private set; }

        public Accueil_Photos()
        {
            InitializeComponent();
            DataContext = this;
            Liste1 = (Application.Current as App).ListeFiltreApp;
            Gal1 = (Application.Current as App).GalerieEnsemble;

            Gal1.FilterSelectedListeFiltreListView = Liste1.OCollectionFiltres.FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Administrateur photoAdmin = new Administrateur();
            photoAdmin.Show();
            Close();
        }
        private void Button_ClickSaveList(object sender, RoutedEventArgs e)
        {
            Serializer<ListeFiltre> serializer = new Serializer<ListeFiltre>();
            serializer.Saver(Liste1);

            var refApp = (Application.Current as App);

            MessageBox.Show("Liste de Filtres sauvegardé, enjoy !");
        }

        private void ListView_MouseDoubleClickOnPhoto(object sender, MouseButtonEventArgs e)
        {
            Photo p1 = ListViewPhotos.SelectedItem as Photo;

            PhotoDisplayWIndow pDW1 = new PhotoDisplayWIndow(p1);
            pDW1.ShowDialog();
        }
    }
}
