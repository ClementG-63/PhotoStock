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
    public partial class Ajouter : Window
    {
        private Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        public ObservableCollection<Filtre> FilterSelectedList { get; private set; }
        public ListeFiltre Liste1 { get; private set; }                                     //Propriété en lecture seul qui va chercher dans la liste de Filtre LFapp de App.xaml.cs de type ListeFiltre
        public GaleriePhoto Galerie1 { get; private set; }                                  //Propriété en lecture seul qui va chercher dans la Galerie de Photo LFapp de App.xaml.cs de type GaleriePhoto
        private string Filename { get; set; }
        

        public Ajouter()                                                                    // Constructeur de Ajouter, récupérant aucun paramètre
        {
            var RefApp = (Application.Current as App);
            InitializeComponent();
            FilterSelectedList = new ObservableCollection<Filtre>();                        // Création d'une collection observable de Filtre FilterSelectedList
            Liste1 = (Application.Current as App).ListeFiltreApp;                           // Liste1 récupère ListeFiltreApp dans App.xaml.cs
            Galerie1 = (Application.Current as App).GalerieEnsemble;                        // Galerie1 récupère GalerieEnsemble dans App.xaml.cs
            DataContext = this;                                                             // Définit le DataContext à this
        }

        private void Button_Click_Parcourir(object sender, RoutedEventArgs e)                //Construction du bouton permettant de Parcourir les dossier Windows
        {
            dlg.FileName = "Images";                                                         // Default file name
            dlg.DefaultExt = ".png";                                                         // Default file extension
            dlg.Filter = "Fichiers Images (*.jpeg,*.jpg)|*.png;*.jpg|All files (*.*)|*.*";   // Filter files by extension

            // Show open file dialog box
            bool? result = dlg.ShowDialog();                                                // Process open file dialog box results, bool? = nullable
            if (result == true)
            {
                // Open document
                Filename = dlg.FileName;                                             // récupération du chemin d'accès d'un fichier
                ContentImage.Width = 654;
                ContentImage.Source = new BitmapImage(new Uri(dlg.FileName));               //Donne la source de l'image à afficher, la source est le lien (Uri)[Chemin] du fichier séléctionné portant un certain nom(FileName)
            }
        }

        private void Button_Click_Leave(object sender, RoutedEventArgs e)                    // Evenement provoquer par le bouton "Annuler"
        {
            {
                if (sender is Button)                                                       // Si l'élément provoquant l'événement est un élement de type Bouton alors
                {
                    LeaveConfirmWWDialog leave1 = new LeaveConfirmWWDialog();               // Ouverture de la page demandant la confirmation pour quitter
                    leave1.ShowDialog();                                                    //Appelle la fenêtre de dialogue demandant la confirmation de l'annulation

                    if (LeaveConfirmWWDialog.GetResult() == true)                           //Est déclenchée si on confirme l'annulation de l'ajout
                    {
                        leave1.Close();                                                     //Fermeture de la fenêtre de confirmation
                        Close();                                                            //Fermeture de la fenêtre actuelle
                    }
                }
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)                                                                 //Bouton permettant de sauvegarder l'ajout
        {
            string Name = NomPhoto.Text;                                                                                                 //Définit Name au texte récupéré dans la textBox NomPhoto
            ObservableCollection<Filtre> FilterNameObsCollection = new ObservableCollection<Filtre>(TextBlockFilter.ItemsSource.Cast<Filtre>());
            string ArtisteName = Artiste.Text;                                                                                           //Définit ArtisteName au texte récupéré dans la textBox Artiste
            string EventName = Evenement.Text;                                                                                           //Définit EventName au texte récupéré dans la textBox Evenement
            string Explication = ExplicationBox.Text;                                                                                    //Définit Explication au texte récupéré dans la textBox ExplicationBox
            if (dlg.FileName == null)                                                                                                    //Si le chemin d'accès au fichier est null alors
            {
                MessageBoxResult result = MessageBox.Show("Vous n'avez pas séléctionné d'image.");                                       //Affiche un  message d'erreur si aucune image n'a été séléctionnée
            }
            else
            {
                if (FilterNameObsCollection.Count() != 0)                                                                                //Si aucun filtre n'a été ajoutée à la liste alors
                {
                    if (Filename != null)
                    {
                        Uri PhotoLink = new Uri(dlg.FileName);                                                                               //Création de PhotoLink de type Uri avec le Uri dlg.FileName (chemin du fichier)
                        Photo p1 = new Photo(Name, FilterNameObsCollection, ArtisteName, EventName, Explication, PhotoLink);                              //Création d'une photo p1 avec les éléments rentrés dans les textbox
                        Galerie1.AjouterPhotoGalerie(p1);                                                                                    //Ajout de la photo p1 dans la galerie Galerie1 

                        if (FilterNameObsCollection.Contains(Galerie1.FilterSelectedListeFiltreListView))                                    //Si la liste de filtre FilterNameObsCollection contient le fitlre séléctionné dans la List View de filtre
                        {                       
                            Galerie1.ObsCollectionPhotoPropertyFilterSelected.Add(p1);                                                                     //Ajout de la photo p1 dans la collection ObsCollectionPhotoProperty de Galerie1

                            Serializer<GaleriePhoto> serializer = new Serializer<GaleriePhoto>();
                            serializer.Saver(Galerie1);
                        }
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Aucune photo n'a été séléctionnée");
                    }
                }
                else                                                                                                                     //Sinon
                {
                    MessageBox.Show("Veuillez séléctionner un filtre dans la liste, et appuyer sur le bouton \"Ajouter\"");              //Affichage d'une boîte de message avec l'erreur
                }
            }
        }

        private void Button_Click_FilterSelectedAdd(object sender, RoutedEventArgs e)                                                    //Evenement déclenché à l'activation du bouton Ajouter pour ajouter les filtres
        {
            Filtre s1 = FilterSelectedComboBox.SelectedValue as Filtre;                                                                  //Récupération de la valeur de l'élément séléctionné et le cast en Filtre
            if (s1 != null)
            {
                FilterSelectedList.Add(s1);                                                                                              // Ajoute le filtre s1 à la liste de filtre séléctionnée pour la photo
            }
            else
            {
                MessageBox.Show("Séléctionnez un filtre");
            }
        }

        private void EventGotFocusTextBox_GotFocus(object sender, RoutedEventArgs e)                                                     // Evenement déclenché par le clique de la souris sur les textbox
        {
            TextBox t1 = sender as TextBox;                                                                                              //Récupère l'élément provoquant l'événement et le cast en TextBox
            t1.Text = "";                                                                                                                //Reinitialise les valeurs à l'interieur des text box
        }
    }
}
