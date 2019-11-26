using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Galerie
{
    /// <summary>
    /// Classe définissant Filtre. Cette classe est utilisée dans beaucoup d'autres classes, comme ListeFiltre, mais aussi Photo.
    /// </summary>
    [Serializable()]
    public class Filtre : IEquatable<Filtre>                   
    {
        /// <summary>
        /// Correspond au nom du filtre
        /// </summary>
        public string NomFiltre { get; private set; }           

        /// <summary>
        /// Constructeur de filtre prenant un string en paramètre
        /// </summary>
        /// <param name="nFiltre"></param>
        public Filtre(string nFiltre)                           
        {
            if(nFiltre != null)
            {
                NomFiltre = nFiltre;
            } else
            {
                MessageBox.Show("");
            }
        }

        /// <summary>
        /// Méthode equals retournant le résultat de la méthode equals définit plus bas
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Filtre);
        }

        /// <summary>
        /// Méthode équals
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Filtre other)
        {
            return other != null &&
                   NomFiltre == other.NomFiltre;
        }

        /// <summary>
        /// Méthode HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 1480048321 + EqualityComparer<string>.Default.GetHashCode(NomFiltre);
        }
    }

}
