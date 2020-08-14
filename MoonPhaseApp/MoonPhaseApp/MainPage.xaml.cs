using System;
using System.ComponentModel;
using MoonPhaseApp.ViewModels;
using Xamarin.Forms;

namespace MoonPhaseApp
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            ((MainViewModel)this.BindingContext).CalculateMoonPhaseCommand.Execute(e.NewDate);
        }

        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var vm = ((MainViewModel)this.BindingContext);
            vm.CalculateMoonPhaseCommand.Execute(vm.SelectedDate);
        }
    }
}