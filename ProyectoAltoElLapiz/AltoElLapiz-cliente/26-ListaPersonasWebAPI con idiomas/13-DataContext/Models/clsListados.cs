using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace _13_DataContext.Models
{
    public class clsListados
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<clsPersona> listadoPersonas()
        {
            ObservableCollection  <clsPersona> listaPersonas = new ObservableCollection<clsPersona>();
            //listaPersonas= getPersonas().Result;
            
            //listaPersonas.Add(new clsPersona(1, "Fernando", "Galiana", new DateTime(1973, 6, 2), "Calle", "656454544"));
            //listaPersonas.Add(new clsPersona(1, "Irene", "Galiana", new DateTime(2010, 6, 2), "Calle", "656454544"));
            //listaPersonas.Add(new clsPersona(1, "Elena", "Galiana", new DateTime(2011, 6, 2), "Calle", "656454544"));
            //listaPersonas.Add(new clsPersona(1, "Manue", "Marquez", new DateTime(1973, 6, 2), "Calle", "656454544"));
            //listaPersonas.Add(new clsPersona(1, "Irene", "Galiana", new DateTime(2010, 6, 2), "Calle", "656454544"));
            //listaPersonas.Add(new clsPersona(1, "Elena", "Galiana", new DateTime(2011, 6, 2), "Calle", "656454544"));
            //listaPersonas.Add(new clsPersona(1, "Manue", "Marquez", new DateTime(1973, 6, 2), "Calle", "656454544"));
            //listaPersonas.Add(new clsPersona(1, "Irene", "Galiana", new DateTime(2010, 6, 2), "Calle", "656454544"));
            //listaPersonas.Add(new clsPersona(1, "Elena", "Galiana", new DateTime(2011, 6, 2), "Calle", "656454544"));
                    
           
            return listaPersonas;
        }

        public async Task<ObservableCollection<clsPersona>> getPersonas()
      
        {
            Uri miUrl = new Uri("http://webapipersonas.azurewebsites.net/api/personas");

            //Usamos un filtro para que la lista sea la más reciente y no la que tenga en la caché
            HttpBaseProtocolFilter filtro = new HttpBaseProtocolFilter();
            filtro.CacheControl.ReadBehavior = Windows.Web.Http.Filters.HttpCacheReadBehavior.MostRecent;
            filtro.CacheControl.WriteBehavior = Windows.Web.Http.Filters.HttpCacheWriteBehavior.NoCache;

            //Instanciamos el cliente Http con el filtro
            HttpClient mihttpClient = new HttpClient(filtro);
            
            ObservableCollection<clsPersona> listadoPersonas = new ObservableCollection<clsPersona>();

            try
            {
                string respuesta = await mihttpClient.GetStringAsync(miUrl);

                mihttpClient.Dispose();
                //JsoonConvert necesita using Newtonsoft.Json;
                //Es el paquete Nuget de Newtonsoft
                listadoPersonas = JsonConvert.DeserializeObject<ObservableCollection<clsPersona>>(respuesta);
              

            }
            catch (Exception ex)
            {
                throw ex;
               
            }
            return listadoPersonas;

        }
    }

}
