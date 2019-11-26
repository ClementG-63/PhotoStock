using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Galerie
{
    /// <summary>
    /// Cette classe est une des classes les plus importante. Elle contient la liste de toutes les photos de l'application. Mais également la liste des
    /// photos ayant pour filtre un des filtres séléctionné.
    /// </summary>
    [Serializable()]
    public class GaleriePhoto
    {
        /// <summary>
        /// Déclare une collection de photos CollectionObservablePhotoGalerieFilterSelected qui contient toutes les photos de l'applications
        /// Déclare une collection ObsCollectionPhotoProperty, qui elle, contient une liste de photo correspondant au filtre séléctionné
        /// </summary>
        public ObservableCollection<Photo> CollectionObservablePhotoGalerie { get; private set; }                             
        private Filtre selectedFilter;                                                                                  

        public ObservableCollection<Photo> ObsCollectionPhotoPropertyFilterSelected { get; private set; }                             

        /// <summary>
        /// Propriété calculé FilterSelectedListeFiltreListView. Elle retourne le filtre séléctionné dans le getter, et le setter permet d'attribuer à l'appelant la valeur
        /// value, et en parallèle, l'actualisation est effectuée via la méthode UpdateList() déclaré plus bas
        /// </summary>
        public Filtre FilterSelectedListeFiltreListView                                                                 
        {
            get { return selectedFilter; }                                                                              
            set{ selectedFilter = value; UpdateList(); }                                                                
        }

        /// <summary>
        /// Constructeur de GaleriePhoto, qui instancie une propriété de type observable collection de Photo, et une autre liste contenant la liste
        /// des photos contenant un filtre séléctionné.
        /// Le nomp de la galerie est également initialisé
        /// </summary>
        /// <param name="nomG"></param>
        public GaleriePhoto()                                                                                
        {
            ObsCollectionPhotoPropertyFilterSelected = new ObservableCollection<Photo>();                                             
            CollectionObservablePhotoGalerie = new ObservableCollection<Photo>();                                 
        }

        /// <summary>
        /// Cette méthode permet d'ajouter une photo donnée en paramètre, dans la Galerie
        /// </summary>
        /// <param name="p1"></param>
        public void AjouterPhotoGalerie(Photo p1)                                                                       
        {
            if (!CollectionObservablePhotoGalerie.Contains(p1))                                           
            {
                CollectionObservablePhotoGalerie.Add(p1);                                                 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        public void DeletePhotoGalerie(Photo p1)                                                                        
        {
            if (CollectionObservablePhotoGalerie.Where(p => p.Nom == p1.Nom).Count() > 0)                 
            {
                CollectionObservablePhotoGalerie.Remove(p1);                                             
                UpdateList();                                                                                           
            }
            else
            {
                MessageBox.Show("La galerie ne contient pas cette image");                                              
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateList()                                                                                                                                
        {
            var collection = CollectionObservablePhotoGalerie.Where(x => x.NfiltreReadOnly.Contains(FilterSelectedListeFiltreListView));           
            ObsCollectionPhotoPropertyFilterSelected.Clear();                                                                                                                 

            foreach (var item in collection)                                                                                                                    
            {
                if (!ObsCollectionPhotoPropertyFilterSelected.Contains(item))                                                        
                    ObsCollectionPhotoPropertyFilterSelected.Add(item);                                                              
            }
        }
    }

}



