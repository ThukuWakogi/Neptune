using Neptune.Models;
using Neptune.Views;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Neptune.ContentDialogs
{
    public sealed partial class EditPositionContentDialog : ContentDialog
    {
        Position position = new Position();
        public delegate void UpdatePositionsEventHandler(Worker updatingWorker, Position positionToUpdate, decimal salary);
        public static event UpdatePositionsEventHandler OnPositionUpdated;

        public EditPositionContentDialog(Position incomingPosition)
        {
            this.InitializeComponent();
            position = incomingPosition;
            EditPositionSalaryContentDialog.Title = $"Edit {position.PositionName.ToLower()} salary";
            PositionSalaryDetailTextBlock.Text = $"Former salary: {position.Salary}/-";
            PositionSalaryTextBox.IsEnabled = SavePositionUpdateTextBox.IsEnabled = (position.Id != 7);
        }

        private async void SavePositionUpdateTextBox_ClickAsync(object sender, RoutedEventArgs e)
        {
            EditPositionProgressRing.IsActive = true;

            if (await NeptuneDatabase.UpdatePositionRecordAsync(AppShell.Workers.First(x => x.Id == AppShell._loggedInUserId), position, Convert.ToDecimal(PositionSalaryTextBox.Text)))
            {
                AppShell.Positions.First(x => x.Id == position.Id).Salary = position.Salary = Convert.ToDecimal(PositionSalaryTextBox.Text);
                OnPositionUpdated?.Invoke(AppShell.Workers.First(x => x.Id == AppShell._loggedInUserId), position, Convert.ToDecimal(PositionSalaryTextBox.Text));
                EditPositionSalaryContentDialog.Hide();
            }

            EditPositionProgressRing.IsActive = false;
        }

        private void PositionSalaryTextBox_TextChanged(object sender, TextChangedEventArgs e) => SavePositionUpdateTextBox.IsEnabled = !string.IsNullOrWhiteSpace(PositionSalaryTextBox.Text);

        private void CancelPositionUpdateTextBox_Click(object sender, RoutedEventArgs e) => EditPositionSalaryContentDialog.Hide();
    }
}
