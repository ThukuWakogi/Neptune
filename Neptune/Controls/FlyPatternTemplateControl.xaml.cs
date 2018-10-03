using Neptune.Models;
using Neptune.Views;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Neptune.Controls
{
    public sealed partial class FlyPatternTemplateControl : UserControl
    {
        private FlyPattern FlyPattern { get => DataContext as FlyPattern; }
        //private string DisplayNumberOfFliesInPattern { get => $"{AppShell.Flies.Count(x => x.FlyPattern.Id == (DataContext as FlyPattern).Id)}"; } 

        public FlyPatternTemplateControl()
        {
            this.InitializeComponent();
            DataContextChanged += (s, e) => Bindings.Update();
        }
    }
}
