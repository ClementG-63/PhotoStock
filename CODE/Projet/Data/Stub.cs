using Galerie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Cette classe permet de charger les données brutes dans l'application lors de l'instanciation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stub<T> : IData<T>
    {
        /// <summary>
        /// Cette méthode est vide puisque elle ne peut pas effectuer de sauvegarde en mémoire (in)
        /// </summary>
        /// <param name="objCalled"></param>
        public void Saver(T objCalled)
        {

        }

        /// <summary>
        /// Cette méthode permet de charger les différents élements en fonction du type de l'objet qui est donné en paramètre
        /// la méthode détecte automatiquement le type de l'objet
        /// </summary>
        /// <param name="objCalled"></param>
        /// <returns> Elle retourne le l'objet passé en paramètre avec les éléments chargés</returns>
        public T Loader(T objCalled)
        {
            if (objCalled is ListeFiltre)
            {
                Filtre nb = new Filtre("Noir & Blanc");
                Filtre couleur = new Filtre("Couleur");
                Filtre bfbf = new Filtre("Binic Folk Blues Festival");
                Filtre art = new Filtre("Art Rocks");

                (objCalled as ListeFiltre).AjouterFiltre(nb);
                (objCalled as ListeFiltre).AjouterFiltre(couleur);
                (objCalled as ListeFiltre).AjouterFiltre(bfbf);
                (objCalled as ListeFiltre).AjouterFiltre(art);


            }
            if (objCalled is GaleriePhoto)
            {
                Filtre nb = new Filtre("Noir & Blanc");
                Filtre couleur = new Filtre("Couleur");
                Filtre bfbf = new Filtre("Binic Folk Blues Festival");
                Filtre art = new Filtre("Art Rocks");

                ObservableCollection<Filtre> lf1test = new ObservableCollection<Filtre>()
                {
                   new Filtre("Noir & Blanc"),
                };

                ObservableCollection<Filtre> lf2test = new ObservableCollection<Filtre>()
                {
                    new Filtre("Couleur")
                };
                Photo p1 = new Photo("Test1", lf1test, "Guyon Clément", "Folk Blues", "", new Uri("Ressources/IMG_6443.JPG", UriKind.Relative));
                Photo p2 = new Photo("Test2", lf2test, "Guyon Clément", "Folk Blues", "", new Uri("Ressources/IMG_6707.JPG", UriKind.Relative));
                Photo p3 = new Photo("Test3", lf1test, "Guyon Clément", "Folk Blues", "", new Uri("Ressources/IMG_6601.JPG", UriKind.Relative));

                (objCalled as GaleriePhoto).AjouterPhotoGalerie(p1);
                (objCalled as GaleriePhoto).AjouterPhotoGalerie(p2);
                (objCalled as GaleriePhoto).AjouterPhotoGalerie(p3);
            } else
            {
                return objCalled;
            }

            return objCalled;
        }
    }
}
