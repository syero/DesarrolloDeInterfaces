/*
 * To add Offline Sync Support:
 *  1) Add the NuGet package Microsoft.Azure.Mobile.Client.SQLiteStore (and dependencies) to all client projects
 *  2) Uncomment the #define OFFLINE_SYNC_ENABLED
 *
 * For more information, see: http://go.microsoft.com/fwlink/?LinkId=717898
 */
//#define OFFLINE_SYNC_ENABLED

using ChatNervion.DataObjects;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

#if OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;  // offline sync
using Microsoft.WindowsAzure.MobileServices.Sync;         // offline sync
#endif

namespace ChatNervion
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
            this.DataContext = (Application.Current as App).ChatVM;
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).Broadcast(new ChatMessage { Username = name.Text, Message = text.Text });
        }
    }
}
