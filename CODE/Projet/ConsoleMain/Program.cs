using Data;
using Galerie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Filtre nb = new Filtre("Noir & Blanc");
            Filtre couleur = new Filtre("Couleur");
            Filtre bfbf = new Filtre("Binic Folk Blues Festival");
            Filtre art = new Filtre("Art Rocks");

            var ar = nb.NomFiltre;
            Console.WriteLine(ar);

            //Création correcte d'une ListeFiltre
            ListeFiltre lf1 = new ListeFiltre();
            //Ajout correct de filtre dans lf1
            lf1.AjouterFiltre(nb);
            lf1.AjouterFiltre(couleur);
            lf1.AjouterFiltre(bfbf);
            lf1.AjouterFiltre(art);

            lf1.DeleteFiltre(art);
            var collecfiltre = lf1.OCollectionFiltres;
            Console.WriteLine(collecfiltre);

            GaleriePhoto ga1 = new GaleriePhoto();

            ObservableCollection<Filtre> obslf = new ObservableCollection<Filtre>();
            Photo p1 = new Photo("", obslf, "", "", "", new Uri("Ressources/IMG_6443.JPG", UriKind.Relative));
            Photo p2 = new Photo("", obslf, "", "", "", new Uri("Ressources/IMG_6707.JPG", UriKind.Relative));


            ga1.AjouterPhotoGalerie(p1);
            ga1.AjouterPhotoGalerie(p2);
            ga1.DeletePhotoGalerie(p2);

            GaleriePhoto gastub = new GaleriePhoto();
            Stub<GaleriePhoto> stub = new Stub<GaleriePhoto>();
            stub.Loader(gastub);



            int count = ga1.CollectionObservablePhotoGalerie.Count();
            Console.WriteLine(count);

            /* Ce code permet d'obtenir le type d'un objet, et de le transformer en 
             nom fichier pour sauvegarder */
            object nomFichAEnregistre = "Save";
            nomFichAEnregistre += ga1.GetType().Name;
            nomFichAEnregistre += ".bin";

            Console.WriteLine(nomFichAEnregistre);

            Serializer<GaleriePhoto> serializer = new Serializer<GaleriePhoto>();
            serializer.Saver(ga1);

            /* code essayé pour comprendre pourquoi ma serialization ne fonctionnait pas, la lecture du fichier donnait des listes vides*/
            ListeFiltre lftest = new ListeFiltre();
            lftest.AjouterFiltre(nb);
            lftest.AjouterFiltre(couleur);
            Console.WriteLine("Avant serialisation :" + lftest.OCollectionFiltres.Count());

            Serializer<ListeFiltre> testserializer = new Serializer<ListeFiltre>();

            Console.WriteLine(lftest.GetType().Name);
            nomFichAEnregistre = "Save";
            nomFichAEnregistre += lftest.GetType().Name;
            nomFichAEnregistre += ".bin";
            Console.WriteLine(nomFichAEnregistre);

            testserializer.Saver(lftest);
            testserializer.Loader(lftest);
            Console.WriteLine("Après serialisation :" + lftest.OCollectionFiltres.Count());

            var aa = Directory.GetCurrentDirectory();
            Console.WriteLine(aa);

            Console.ReadLine();
        }
    }
}
