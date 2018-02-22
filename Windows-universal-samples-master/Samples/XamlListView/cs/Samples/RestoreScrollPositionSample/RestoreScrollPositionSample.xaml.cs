﻿using ListViewSample.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ListViewSample
{
    public sealed partial class RestoreScrollPositionSample : Page
    {
        // Global variables for page. Static persisted variables are used by ListViewPersistenceHelper
        // We need to save the item container height if the items have variable heights. If all items have a constant fixed height, you can manually 
        // set the height to the fixed value in ItemsListView_ContainerContentChanging
        private ObservableCollection<Item> _items;
        private static double _persistedItemContainerHeight = -1;
        private static string _persistedItemKey = "";
        private static string _persistedPosition = "";

        public RestoreScrollPositionSample()
        {
            this.InitializeComponent();
            // Page_Loaded calls the ListViewPersistenceHelper function to scroll to the last saved scroll position
            this.Loaded += Page_Loaded;
            _items = Item.GetItems(300);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(RestoreScrollPositionSample._persistedPosition))
            {
                // Here we kick off the async function to use the saved string _persistedPosition and the function GetItem to restore the scroll posistion
                await ListViewPersistenceHelper.SetRelativeScrollPositionAsync(this.ItemsListView, RestoreScrollPositionSample._persistedPosition, this.GetItem);
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            // Before we navigate away from the page, we want to generate a new _persistedPosition string. This string contains the key of the item at the top of the 
            // viewing window (generated by the function GetKey) and the offset of that item.
            RestoreScrollPositionSample._persistedPosition = ListViewPersistenceHelper.GetRelativeScrollPosition(this.ItemsListView, this.GetKey);
            base.OnNavigatingFrom(e);
        }

        private IAsyncOperation<object> GetItem(string key)
        {
            // This function takes a key that ListViewPersistenceHelper parsed out of the _persistedPosition string
            // It returns an item that corresponds to the given key
            // The implementation of this function is dependent on the data model you are using. Every item in your list should have
            // a unique key this function returns
            return Task.Run(() =>
            {
                if (_items.Count <= 0)
                {
                    return null;
                }
                else
                {
                    return (object)_items.FirstOrDefault(i => i.Id == key);
                }
            }).AsAsyncOperation();
        }

        private string GetKey(object item)
        {
            // This function takes in the item at the top of the viewport at the moment of navigating away from the page, and returns
            // a key corresponding to that item. the implementation of this function is dependent on the data model you are using. In this 
            // function we also save the fully rendered _persistedItemContainerHeight. You do not need to do this if all of your items have 
            // the same fixed height. Finally, we save the key into a variable so it can be used outside of ListViewPersistenceHelper functions
            var singleItem = item as Item;
            if (singleItem != null)
            {
                _persistedItemContainerHeight = (ItemsListView.ContainerFromItem(item) as ListViewItem).ActualHeight;
                _persistedItemKey = singleItem.Id;
                return _persistedItemKey;
            }
            else
            {
                return string.Empty;
            }
        }

        private void ItemsListView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            // This function manually sets the height of the item ListViewPersistenceHelper is attempting to scroll to. We need to set the height
            // because if the item is not fully rendered at the time of scrolling, it can return an incorrect height and cause ListViewPersistenceHelper 
            // to overscroll. 
            var singleItem = args.Item as Item;

            if (singleItem != null && singleItem.Id == _persistedItemKey)
            {
                if (!args.InRecycleQueue)
                {
                    // Here we set the container's height equal to the fully rendered container height we had saved before navigating away. If all the items in 
                    // your list have the same fixed height, you can replace this variable with a hardcoded height value. 
                    args.ItemContainer.Height = _persistedItemContainerHeight;
                }
                else
                {
                    // Containers in a list are recycled when they are scrolled out of view. However, if those containers have their Height property set and the content
                    // changes, that set Height is still applied. This creates an incorect UI if the items in your list are supposed to be of variable height. 
                    // If all the items in your list have the same fixed height, you do not have to do this. 
                    args.ItemContainer.ClearValue(HeightProperty);
                }
            }
        }

        private void ItemsListView_ItemClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Page2));
        }

        private void ShowSliptView(object sender, RoutedEventArgs e)
        {
            // Clearing the cache
            int cacheSize = ((Frame)Parent).CacheSize;
            ((Frame)Parent).CacheSize = 0;
            ((Frame)Parent).CacheSize = cacheSize;

            MySamplesPane.SamplesSplitView.IsPaneOpen = !MySamplesPane.SamplesSplitView.IsPaneOpen;
        }
    }
}