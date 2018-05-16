using ChatNervion;
using ChatNervion.DataModel;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ChatNervion_Windows_CS
{
    public sealed partial class MainPage : Page
    {
        private MobileServiceCollection<TodoItem, TodoItem> items;
#if OFFLINE_SYNC_ENABLED
        private IMobileServiceSyncTable<TodoItem> todoTable = App.MobileService.GetSyncTable<TodoItem>(); // offline sync
#else
        //private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();
#endif

        public MainPage()
        {
            this.InitializeComponent();
            // this.DataContext = (Application.Current as App).ChatVM;
        }

        /// <summary>
        /// Handle the parameters from chatroom page.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null && !e.Parameter.Equals(string.Empty))
            {
                Group info = (Group)e.Parameter;
                tbxGroup.Text = info.nombreGrupo;
                tbxName.Text = info.Nick;
            }
        }

        async private void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri((sender as HyperlinkButton).Tag.ToString()));
        }

        private async void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            btnJoin.IsEnabled = false;
            tbxError.Text = string.Empty;
            string groupName = tbxGroup.Text.Trim();
            string userName = tbxName.Text.Trim();
            if (groupName.Length == 0 || userName.Length == 0)
            {
                tbxError.Text = "Group & user name can't be empty.";
                btnJoin.IsEnabled = true;
                return;
            }
            //Connect to hub
            App myApp = (Application.Current as App);
            if (myApp.conn.State != ConnectionState.Connected)
            {
                try
                {
                    await myApp.conn.Start();
                }
                catch
                {
                    tbxError.Text = $"Can't connect to server {myApp.conn.Url}";
                    btnJoin.IsEnabled = true;
                    return;
                }
            }
            //join to group
            if (myApp.conn.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
            {
                await myApp.proxy.Invoke("JoinGroup", groupName);
                Group info = new Group();
                info.nombreGrupo = groupName;
                info.Nick = userName;
                Frame.Navigate(typeof(ChatRoom), info);
            }
            else
            {
                tbxError.Text = $"Can't connect to server {myApp.conn.Url}";
            }
            btnJoin.IsEnabled = true;
        }

        //private void send_Click(object sender, RoutedEventArgs e)
        //{
        //    (Application.Current as App).Broadcast(new ChatMessage { Username = name.Text, Message = text.Text });
        //}


    }
}
