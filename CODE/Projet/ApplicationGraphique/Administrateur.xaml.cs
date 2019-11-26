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
    /// <summary>
    /// Logique d'interaction pour Administrateur.xaml
    /// </summary>
    public partial class Administrateur : Window
    {
        public ListeFiltre Liste1 { get; private set; }//Propriété en lecture seul qui va chercher dans LFapp de App.xaml.cs
        public GaleriePhoto Gal1 { get; private set; }
        public bool SaveStat { get; private set; }


        public Administrateur()
        {
            InitializeComponent();
            DataContext = this;
            Liste1 = (Application.Current as App).ListeFiltreApp;
            Gal1 = (Application.Current as App).GalerieEnsemble;
            Gal1.FilterSelectedListeFiltreListView = Liste1.OCollectionFiltres.FirstOrDefault();
        }

        private void AjouterFiltre_Click(object sender, RoutedEventArgs e)//bouton pour ajouter une photo
        {
            AjoutFiltre filtre = new AjoutFiltre();
            Serializer<ListeFiltre> serializer = new Serializer<ListeFiltre>();
            serializer.Saver(Liste1);
            filtre.ShowDialog();
        }

        private void SupprimerFiltre_Click(object sender, RoutedEventArgs e)//bouton pour supprimer un filtre
        {
            var selected = ListeFiltreListView.SelectedItem as Filtre;
            Liste1.DeleteFiltre(selected);

            Serializer<ListeFiltre> serializer = new Serializer<ListeFiltre>();
            serializer.Saver(Liste1);
        }

        private void Button_Click_User(object sender, RoutedEventArgs e)//Bouton pour repasser en mode simple Utilisateur
        {
            Accueil_Photos acc1 = new Accueil_Photos();
            acc1.Show();
            Close();
        }

        private void Button_Click_AjouterPhoto(object sender, RoutedEventArgs e)//Bouton pour ajouter une photo
        {
            Ajouter addphoto = new Ajouter();
            Serializer<GaleriePhoto> serializer = new Serializer<GaleriePhoto>();
            serializer.Saver(Gal1);
            addphoto.ShowDialog();
        }

        private void Button_Click_RedCrossForDeletePic(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var deletePhoto = button.DataContext as Photo;
            Gal1.DeletePhotoGalerie(deletePhoto);

            Serializer<GaleriePhoto> serializer = new Serializer<GaleriePhoto>();
            serializer.Saver(Gal1);
        }

        private void ListView_MouseDoubleClickOnPhoto(object sender, MouseButtonEventArgs e)
        {
            Photo p1 = PhotoListView.SelectedItem as Photo;

            PhotoDisplayWIndow pDW1 = new PhotoDisplayWIndow(p1);
            pDW1.ShowDialog();
        }


    }
}
