using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MoonPhaseApp.Annotations;
using MoonPhaseApp.Services;
using Xamarin.Forms;

namespace MoonPhaseApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _emoji;
        private Earth.Hemispheres _hemisphere;
        private string _name;
        private DateTime _selectedDate;
        private string _display;

        public Command<DateTime> CalculateMoonPhaseCommand { get; set; }
        
        
        public MainViewModel()
        {
            SelectedDate = DateTime.UtcNow;
            SetMoonPhaseResult(Moon.Calculate(SelectedDate, Hemisphere));
            CalculateMoonPhaseCommand = new Command<DateTime>(CalculateMoonPhase);
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime MinimumDateTime => Moon.MinimumDateTime;

        private void CalculateMoonPhase (DateTime dateTime)
        {
            var result = Moon.Calculate(dateTime, Hemisphere);
            SetMoonPhaseResult(result);
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public Earth.Hemispheres Hemisphere
        {
            get => _hemisphere;
            set
            {
                _hemisphere = value;
                OnPropertyChanged();
            }
        }

        public List<Earth.Hemispheres> Hemispheres
        {
            get
            {
                var list = new List<Earth.Hemispheres>();
                foreach (var value in Enum.GetValues(typeof(Earth.Hemispheres)))
                {
                    list.Add((Earth.Hemispheres) value);
                }

                return list;
            }
        }
        public string Emoji
        {
            get => _emoji;
            set
            {
                _emoji = value;
                OnPropertyChanged();
            }
        }

        public string Display
        {
            get => _display;
            set
            {
                _display = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void SetMoonPhaseResult(Moon.PhaseResult result)
        {
            Emoji = result.Emoji;
            Hemisphere = result.Hemisphere;
            Name = result.Name;
            Display = result.ToString();
        }
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}