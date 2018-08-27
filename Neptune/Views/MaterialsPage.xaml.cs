using Neptune.Models;
using Neptune.PayLoads;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class MaterialsPage : Page
    {
        ObservableCollection<MaterialCategory> MaterialCategories = AppShell.MaterialCategories;
        public delegate void MaterialsPageEventHandler(object sender, RoutedEventArgs e);
        public static event MaterialsPageEventHandler OnNavigatedParentReady;

        public MaterialsPage()
        {
            this.InitializeComponent();
        }

        private void SelectMaterialCategoryAppBarToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is AppBarToggleButton)
            {
                if (MaterialCategoryGridView.SelectionMode == ListViewSelectionMode.Single)
                {
                    MaterialCategoryGridView.SelectionMode = ListViewSelectionMode.Multiple;
                    AddMaterialCategoryAppBarButton.Visibility = Visibility.Collapsed;
                    DeleteMaterialCategoryAppBarButton.Visibility = Visibility.Visible;
                }
                else if (MaterialCategoryGridView.SelectionMode == ListViewSelectionMode.Multiple)
                {
                    MaterialCategoryGridView.SelectionMode = ListViewSelectionMode.Single;
                    AddMaterialCategoryAppBarButton.Visibility = Visibility.Visible;
                    DeleteMaterialCategoryAppBarButton.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void MaterialCategoryGridView_ItemClick(object sender, ItemClickEventArgs e) => OnNavigatedParentReady?.Invoke(sender, e);
    }
}
