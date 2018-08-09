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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Neptune.Controls
{
    public sealed partial class WorkerControl : UserControl
    {
        public Worker Worker { get { return DataContext as Worker; } }

        public WorkerControl()
        {
            this.InitializeComponent();
            DataContextChanged += (s, e) => Bindings.Update();
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e) => WorkerTemplateGrid.Width = (sender as WorkerControl).ActualWidth;
    }
}
