using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_DataContext.ViewModels
{
    public class StringFormatter : Windows.UI.Xaml.Data.IValueConverter
    {
        // Convertimos el valor a String con el formato de fecha desado
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string fecha = "";
            if (value != null)
            {
                DateTime dt = DateTime.Parse(value.ToString());
                fecha = dt.ToString("dd/MM/yyyy");
            }
            return fecha;


        }

        // Conversion al revés. Cuando queremos guardar
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTime fecha = new DateTime();
           
            if (value != null)
            {
                fecha = System.Convert.ToDateTime(value);
               
            }
            return fecha;
        }
    }
}
