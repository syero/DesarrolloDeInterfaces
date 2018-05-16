using AltoLapizService.DataObjects;
using ChatNervion.DataModel;
using ChatNervion_Windows_CS;
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
    public sealed partial class ChatRoom : Page
    {
        private clsMensajeChat mensaje { get; set; }

        private IDisposable receiveMessageHandler { get; set; }

        public ChatRoom()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        /// <summary>
        /// get user name and group name from the mainpage
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            mensaje = (clsMensajeChat)e.Parameter;
            //dynamic info = e.Parameter;
            //groupName = info.groupName;
            //userName = info.userName;
            this.tblGroupName.Text = mensaje.nombreGrupo;
            this.tblUserName.Text = mensaje.nick;
            App myApp = (Application.Current as App);
            receiveMessageHandler = myApp.proxy.On<string,string>("receivemessage", ReceiveMessage);
        }

        private async void ReceiveMessage(string nick, string message)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                this.lvwMessages.Items.Add($"{nick}: {message}");
            });
        }

        async private void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }

        /// <summary>
        /// leave group and remove receive message handler
        /// navigate to mainpage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App myApp = (Application.Current as App);
            if (myApp.conn.State == ConnectionState.Connected)
            {
                await myApp.proxy.Invoke("LeaveGroup", mensaje.nombreGrupo);
                receiveMessageHandler.Dispose();
            }
            Frame.Navigate(typeof(MainPage), new { groupName = mensaje.nombreGrupo, userName = mensaje.nick });
        }

        /// <summary>
        /// Invoke SendToGroup method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            tblError.Text = string.Empty;
            App myApp = (Application.Current as App);
            if (myApp.conn.State != ConnectionState.Connected)
            {
                tblError.Text = "Disconnected!";
                return;
            }

            mensaje.mensaje = this.tbxMessage.Text.Trim();
            if (mensaje.mensaje.Length > 0)
            {
                myApp.proxy.Invoke("SendToGroup", mensaje);
            }
            this.tbxMessage.Text = string.Empty;
        }

    }
}

