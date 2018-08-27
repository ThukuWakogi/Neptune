using Neptune.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Neptune.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MaterialItemsPage : Page
    {
        MaterialCategory MaterialCategory = new MaterialCategory();

        public MaterialItemsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MaterialCategory = e.Parameter as MaterialCategory;
            base.OnNavigatedTo(e);
        }

        private void CustomerCommandBarAppButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is AppBarToggleButton)
            {
                if (MaterialsListView.SelectionMode == ListViewSelectionMode.Single)
                {
                    MaterialsListView.SelectionMode = ListViewSelectionMode.Multiple;
                    AddCustomerAppBarButton.IsEnabled = false;
                    DeleteCustomerAppBarButton.IsEnabled = true;
                }
                else if (MaterialsListView.SelectionMode == ListViewSelectionMode.Multiple)
                {
                    MaterialsListView.SelectionMode = ListViewSelectionMode.Single;
                    AddCustomerAppBarButton.IsEnabled = true;
                    DeleteCustomerAppBarButton.IsEnabled = false;
                }
            }
        }
    }
}
