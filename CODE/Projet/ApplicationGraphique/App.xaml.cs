using Data;
using Galerie;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows;

namespace ApplicationGraphique
{
    public partial class App : Application
    {
        public ListeFiltre ListeFiltreApp { get; private set; }                             //Création et instanciation d'une propriété ListeFiltre, la seule liste de filtre utilisée et commune à toutes les fenêtres
        public GaleriePhoto GalerieEnsemble { get; private set; }                           //Création d'une propriété GaleriePhoto

        public App()
        {
            ListeFiltreApp = new ListeFiltre();
            GalerieEnsemble = new GaleriePhoto();

            /* A mettre en commentaire pour un chargement par fichier et à décommenter pour un chargement par stub*/
            /**/ //ListeFiltreApp = new Stub<ListeFiltre>().Loader(ListeFiltreApp);
            /**/ //GalerieEnsemble = new Stub<GaleriePhoto>().Loader(GalerieEnsemble);
            /* A mettre en paranthèse pour un chargement avec le stub*/
            /* A mettre en commentaire pour un chargement par fichier et à decommenter pour un chargement par stub*/

            /* A mettre en commentaire pour un chargement avec le stub et à décommenter pour un chargement par fichier*/
            /**/ Serializer<ListeFiltre> readerFilterList = new Serializer<ListeFiltre>();
            /**/ ListeFiltreApp = readerFilterList.Loader(ListeFiltreApp);

           /**/ Serializer<GaleriePhoto> readerGalerie = new Serializer<GaleriePhoto>();
           /**/ GalerieEnsemble = readerGalerie.Loader(GalerieEnsemble);
           /* A mettre en paranthèse pour un chargement avec le stub*/

        }
    }
}
