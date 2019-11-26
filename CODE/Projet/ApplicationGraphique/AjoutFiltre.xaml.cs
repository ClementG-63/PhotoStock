using Data;
using Galerie;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour AjoutFiltre.xaml
    /// </summary>
    public partial class AjoutFiltre : Window
    {
        public ListeFiltre Lf1 => (Application.Current as App).ListeFiltreApp;

        public AjoutFiltre()
        {
            InitializeComponent();
        }

        //Méthode déclenchée par le bouton "Annuler"
        private void Button_Click_Annuler(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                LeaveConfirmWWDialog leave1 = new LeaveConfirmWWDialog();
                leave1.ShowDialog();//Appelle la fenêtre de dialogue demandant la confirmation de l'annulation

                if (LeaveConfirmWWDialog.GetResult() == true)
                {//Est déclenchée si on confirme l'annulation de l'ajout
                    leave1.Close();
                    Close();
                }
            }
        }

        //Méthode déclenchée par le bouton de validation d'ajout de filtre
        private void Button_Click_Valider(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                this.Close();
                string ContenuTextBox = textbox1.Text;//Le nom du nouveau filtre est le contenu de la textbox1

                Filtre f1 = new Filtre(ContenuTextBox);
                Lf1.AjouterFiltre(f1);//Ajout du nouveau filtre par la méthode AjouterFiltre de ListeFiltre

                Serializer<ListeFiltre> serializer = new Serializer<ListeFiltre>();
                serializer.Saver(Lf1);

                var refApp = (Application.Current as App);
            }
        }
        private void EventGotFocusTextBox_GotFocus(object sender, RoutedEventArgs e)                                                     // Evenement déclenché par le clique de la souris sur les textbox
        {
            TextBox t1 = sender as TextBox;                                                                                              //Récupère l'élément provoquant l'événement et le cast en TextBox
            t1.Text = "";                                                                                                                //Reinitialise les valeurs à l'interieur des text box
        }
    }
}
