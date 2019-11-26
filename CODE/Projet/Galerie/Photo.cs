using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Galerie
{
    /// <summary>
    /// Classe Photo définit une photo. Cette classe ne contient pas de méthode, uniquement un constructeur.
    /// </summary>
    [Serializable()] 
    public class Photo
    {
        /// <summary>
        /// NfiltreReadOnly encapsule Nfiltre afin d'éviter toute manipulation malveillante de la liste, la liste de filtre NfiltreReadOnly est donc en lecture seule
        /// Chacunes des propriétés et chacun des attributs permet de détailler cette photo : nom, Artiste, Evenement, Explication et le chemin d'accès de la photo
        /// </summary>
        private readonly ObservableCollection<Filtre> Nfiltre;                                                            
        public ReadOnlyObservableCollection<Filtre> NfiltreReadOnly => new ReadOnlyObservableCollection<Filtre>(Nfiltre); 

        public string Nom { get; private set; }                       
        public string Artiste { get; private set; }                                                                 
        public string Evenement { get; private set; }                                             
        public string Explication { get; private set; }                                                                                   
        public Uri Link { get; private set; }



        /// <summary>
        /// Constructeur de photo définit par 4 propriétés de type string donnant une description à une photo, et un Uri, donnant le chemin d'accès d'une image et une 
        /// liste de filtres
        /// </summary>
        /// 
        /// <param name="Nom"> Correspond au nom d'une Photo</param>
        /// <param name="nFiltre">Correspond à une liste de filtre que peut avoir une photo</param>
        /// <param name="artiste">Correspond au nom de l'artiste qui a réalisé la photo</param>
        /// <param name="evenement">Correspond au nom de l'événement dans lequel a été réalisé la photo</param>
        /// <param name="explication">Correspond aux explications de la photo</param>
        /// <param name="LienPhoto">Correspond au lien / chemin d'accés d'une photo</param>
        public Photo(string Nom, ObservableCollection<Filtre> nFiltre, string artiste, string evenement, string explication, Uri LienPhoto)
        {
            this.Nom = Nom;
            Nfiltre = nFiltre;
            Artiste = artiste;
            Evenement = evenement;
            Explication = explication;
            Link = LienPhoto;
        }
    }
}
