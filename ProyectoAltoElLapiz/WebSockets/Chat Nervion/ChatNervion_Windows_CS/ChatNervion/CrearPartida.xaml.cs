using AltoLapizService.DataObjects;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace ChatNervion
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CrearPartida : Page
    {
        public clsGrupo grupo { get; set; }
        public List<clsGrupo> grupos { get; set; }
        private IDisposable receiveMessageHandler { get; set; }

        public CrearPartida()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            grupo = (clsGrupo)e.Parameter;
            this.tblNombrePartida.Text = grupo.nombrePartida;
            this.tblNumeroRonda.Text = grupo.numeroRondas;
            this.tblPais.Text = grupo.pais;
            this.tblNumeroParticipantes.Text = grupo.numeroParticipantes;
            this.tblEstadoAbierto.Text = grupo.estadoAbierto;

            App myApp = (Application.Current as App);
            receiveMessageHandler = myApp.proxy.On<clsGrupo>("crearPartida", crearPartida);
        }

        private async void crearPartida(clsGrupo grupo)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                grupos.Add(grupo);
            });
        }


    }
}
