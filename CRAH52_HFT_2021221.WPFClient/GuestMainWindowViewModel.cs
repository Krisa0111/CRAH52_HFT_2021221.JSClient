using CRAH52_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRAH52_HFT_2021221.WPFClient
{
    public class GuestMainWindowViewModel :ObservableRecipient
    {
        public RestCollection<Guests> Guests { get; set; }

        private Guests selectedGuest;

        public Guests SelectedGuest
        {
            get { return selectedGuest; }
            set
            {
                if (value != null)
                {
                    selectedGuest = new Guests()
                    {
                        Name = value.Name,
                        GuestID = value.GuestID,
                        BirthYear = value.BirthYear,
                        Email = value.Email,
                        Event = value.Event,
                        EventID = value.EventID
                    };
                    OnPropertyChanged();
                    (DeleteGuestCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateGuestCommand { get; set; }
        public ICommand DeleteGuestCommand { get; set; }
        public ICommand UpdateGuestCommand { get; set; }
        public GuestMainWindowViewModel()
        {
            Guests = new RestCollection<Guests>("http://localhost:30907/", "guests","hub");
            CreateGuestCommand = new RelayCommand(() =>
            {
                Guests.Add(new Guests()
                {
                    Name = SelectedGuest.Name,
                    GuestID = SelectedGuest.GuestID,
                    Email = SelectedGuest.Email,
                    BirthYear = SelectedGuest.BirthYear,
                    Event = SelectedGuest.Event,
                    EventID = SelectedGuest.EventID
                });
            });
            UpdateGuestCommand = new RelayCommand(() =>
            {
                Guests.Update(SelectedGuest);
            });
            DeleteGuestCommand = new RelayCommand(() =>
            {
                Guests.Delete(SelectedGuest.GuestID);
            });
            SelectedGuest = new Guests();
        }
    }
}
