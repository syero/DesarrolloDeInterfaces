using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _18_CRUD_Personas_UWP_UI.Converters
{
    class dateTimeToStringConverter:IValueConverter
    {
        //Viene de la base de datos, Como cuando seleccionamos una persona de la lista
        //De fecha a string
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = (DateTime)value;
            return date.ToShortDateString();
        }

        //De String a fecha
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string strValue = value as string;
            //DateTime resultDateTime= DateTime.Now;

            DateTime myDate = DateTime.Parse(value.ToString());


            //if (value.GetType() == typeof(String)) {
              //  String[] sfecha = ((String)value).Split("/");
              //  resultDateTime = new DateTime(int.Parse(sfecha[0]), int.Parse(sfecha[1]), int.Parse(sfecha[2]));
            //}
            return myDate;
        }
    }
}
