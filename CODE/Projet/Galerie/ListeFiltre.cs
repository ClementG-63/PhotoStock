
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Galerie
{
    /// <summary>
    /// Cette classe définit une ListeFiltre, elle contient deux méthodes, une méthode DeleteFiltre et une méthode AjouterFiltre,
    /// elle est utilisée dans App, stockant tous les filtres d'une application
    /// </summary>
    [Serializable()]
    public class ListeFiltre
    { 
        /// <summary>
        /// Déclaration de la collection contenant les filtres de la listefiltre
        /// </summary>
        public ObservableCollection<Filtre> OCollectionFiltres { get; private set; }      
        
        /// <summary>
        /// Concstructeur de ListreFiltre qui instancie une observable collection de Filtres
        /// </summary>
        public ListeFiltre()                                                              
        {
            OCollectionFiltres = new ObservableCollection<Filtre>();       
        }

        /// <summary>
        /// Méthode permettant d'ajouter un filtre appelé en paramètre dans la ListeFiltre (ObservableCollection). Si cette liste contient déjà 
        /// ce filtre alors l'ajout n'est pas effectué et une fenêtre contenant un message d'erreur apparaît
        /// </summary>
        /// <param name="f1"></param>
        public void AjouterFiltre(Filtre f1)                              
        {
            if (!OCollectionFiltres.Contains(f1))                                                    
            {
                OCollectionFiltres.Add(f1);                                    
            } else                                                                        
            {
                MessageBox.Show("Ce filtre existe déjà");                    
            }
        }

        /// <summary>
        /// Cette méthode permet de supprimer un filtre - passé en paramètre - de la liste uniquement si la liste contient de même filtre.
        /// </summary>
        /// <param name="f1"></param>
        public void DeleteFiltre(Filtre f1)                                                        
        {
            if (OCollectionFiltres.Contains(f1))                                               
            {                                                                                
                OCollectionFiltres.Remove(f1);                                     
            }
        }
    }
}
