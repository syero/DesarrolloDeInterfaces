using PrimerEjercicioExamen.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerEjercicioExamen.Model
{
    class Imagenes: clsVMBase
    {
        public ObservableCollection<Imagen> imagenes() {

            ObservableCollection<Imagen> listaimagenes = new ObservableCollection<Imagen>();

            Imagen ImagenOriginal =new Imagen("ImagenOriginal", new Uri("ms-appx://_PrimerEjercicioExamen/Assets/imagenes/Diferencias.jpg", UriKind.Absolute));
            Imagen ImagenConDiferencias= new Imagen("ImagenConDiferencias", new Uri("ms-appx://_PrimerEjercicioExamen/Assets/imagenes/Diferencias2.jpg", UriKind.Absolute));

            listaimagenes.Add(ImagenOriginal);
            listaimagenes.Add(ImagenConDiferencias);

            return listaimagenes;
         }
}
}
