using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Cette classe est un Serializer, elle permet de déserializer un objet appelé, ou de charger le contenu d'un fichier dans un objet passé en
    /// paramètres. Elle contient uniquement deux méthodes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Serializer<T> : IData<T>
    {

        public string DefaultBackupFolder { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PhotoStockSave");
        /// <summary>
        /// Méthode permettant de sauvegarder n'importe quel élément appelé en paramètre,
        /// la méthode va générer un nom de fichier en fonction du type de l'objet appelé
        /// et créer un fichier avec l'extension .dat
        /// </summary>
        /// <param name="objCalled"></param>
        public void Saver(T objCalled)
        {
            string nomFichAEnregistre = "Save";
            nomFichAEnregistre += objCalled.GetType().Name;
            nomFichAEnregistre += ".dat";

            IFormatter formatter = new BinaryFormatter();
            if (Directory.Exists(DefaultBackupFolder))
            {
                using (FileStream stream = File.Create(Path.Combine(DefaultBackupFolder, nomFichAEnregistre)))
                {
                    formatter.Serialize(stream, objCalled);
                }
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(DefaultBackupFolder);
                using (FileStream stream = File.Create(Path.Combine(DefaultBackupFolder, nomFichAEnregistre)))
                {
                    formatter.Serialize(stream, objCalled);
                }
            }
        }

        /// <summary>
        /// Cette méthode permet de charger un fichier, qui porte le nom d'un objet passé en paramètre, le nom
        /// du fichier sera trouvé en récupérant le type du fichier et en rajoutant Save devant et .dat à la fin
        /// </summary>
        /// <param name="objCalled"></param>
        /// <returns>Retourne l'objet passé en paramètre puisqu'il est censé se charger avec le contenu d'un fichier lu</returns>
        public T Loader(T objCalled)
        {
            try
            {
                string nomFichAouvrir = "Save";
                nomFichAouvrir += objCalled.GetType().Name;
                nomFichAouvrir += ".dat";

                IFormatter formatter = new BinaryFormatter();
                using (FileStream stream = File.OpenRead(Path.Combine(DefaultBackupFolder, nomFichAouvrir)))
                {
                    objCalled = (T)formatter.Deserialize(stream);
                }
            }
            catch
            {
                objCalled = new Stub<T>().Loader(objCalled);
                Saver(objCalled);
            }
            return objCalled;
        }
    }
}
