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
    /// Logique d'interaction pour LeaveConfirmWWDialog.xaml
    /// </summary>
    public partial class LeaveConfirmWWDialog : Window
    {
        public static bool Result { get; set; }//Valeur permettant de savoir si on séléctionné OUI ou NON dans le dialogue de confirmation

        public LeaveConfirmWWDialog()
        {
            InitializeComponent();
            Result = false;
        }

        // Fonction déclenchée par le bouton "Annuler" (Oui)
        public void Button_Click_Oui(object sender, RoutedEventArgs e)
        {
            SetResult(true); //Resultat à TRUE si la on confirme la fermeture
            this.Close();
        }

        //Setter du Resultat appelé lors de la séléction du bouton "oui" ou "non"
        private void SetResult(bool newR){
            Result = newR;
        }

        //Getter du Resultat de la demande de confirmation (Utilisé dans "AjoutFiltre.xaml"
        public static bool GetResult()
        {
            return Result;
        }

        // Fonction déclenchée par le bouton "Annuler" (Non)
        private void Button_Click_Non(object sender, RoutedEventArgs e)
        {
            SetResult(false);//Resultat à FALSE si la on annule la fermeture
            this.Close();
        }
    }
}
