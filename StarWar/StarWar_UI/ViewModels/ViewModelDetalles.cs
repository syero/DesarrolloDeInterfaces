using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace StarWar_UI.ViewModels
{
    public class ViewModelDetalles
    {



        /// <summary>
        /// este metodo sirve para convertir un array de bytes en una imagen
        /// </summary>
        /// <returns></returns>
        //public async Task<BitmapImage> convertirUnArrayDeBytsAUnaImagenAsync()
        //{
        //    using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
        //    {
        //        using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
        //        {
        //            writer.WriteBytes(this.imagenBinaria);
        //            await writer.StoreAsync();
        //        }
        //        imagen = new BitmapImage();
        //        await imagen.SetSourceAsync(stream);
        //        return imagen;
        //    }
        //}
    }
}
