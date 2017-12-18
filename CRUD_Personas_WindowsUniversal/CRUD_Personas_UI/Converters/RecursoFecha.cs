using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace CRUD_Personas_UI.Converters
{
    public class RecursoFecha : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            String fecha="";

            if (value != null)
            {
                DateTime fechaPasada = (DateTime)value; //DateTime.Parse(value.ToString());
                fecha = fechaPasada.ToString("dd /mm/ yyyy"); //concatenar bien
               
            }

            return fecha;           
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {

             throw new NotImplementedException();
        }
    }
}
