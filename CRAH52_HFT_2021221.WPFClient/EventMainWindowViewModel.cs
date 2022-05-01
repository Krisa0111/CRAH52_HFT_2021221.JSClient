using CRAH52_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CRAH52_HFT_2021221.WPFClient
{
    public class EventMainWindowViewModel :ObservableRecipient
    {
        public RestCollection<Events> Events { get; set; }
        private ObservableCollection<Guests> selectedEventGuests;
        public ObservableCollection<Guests> SelectedEventGuests 
        { 
            get
            {
                return selectedEventGuests;
                
            }
            set
            {
                
                if (value == null)
                {
                    selectedEventGuests = new ObservableCollection<Guests>();
                }
                else
                {
                    selectedEventGuests = new ObservableCollection<Guests>(value);
                }
                OnPropertyChanged();
            }
        }
        private Events selectedEvent;

        public Events SelectedEvent
        {
            get { return selectedEvent; }
            set 
            {
                if (value !=null)
                {
                    selectedEvent = new Events()
                    {
                        EventName = value.EventName,
                        EventID = value.EventID,
                        EventShortDesc = value.EventShortDesc,
                        Date = value.Date,
                        Clubs = value.Clubs,
                        ClubID = value.ClubID,
                        Guests = value.Guests

                    };
                    OnPropertyChanged();
                    Generate(selectedEvent);
                    (DeleteEventCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private void Generate(Events value)
        {
            if (value.Guests!=null)
            {
                SelectedEventGuests = new ObservableCollection<Guests>(value.Guests);
            }
            
        }

        public ICommand CreateEventCommand { get; set; }
        public ICommand DeleteEventCommand { get; set; }
        public ICommand UpdateEventCommand { get; set; }
        public EventMainWindowViewModel()
        {
            Events = new RestCollection<Events>("http://localhost:30907/", "events","hub");
            CreateEventCommand = new RelayCommand(() =>
            {
                Events.Add(new Events()
                {
                    EventID = SelectedEvent.EventID,
                    EventName = SelectedEvent.EventName,
                    EventShortDesc = SelectedEvent.EventShortDesc,
                    ClubID = null,
                    Clubs = SelectedEvent.Clubs,
                    Date = SelectedEvent.Date,
                    Guests = null
                });
            }
            );
            UpdateEventCommand = new RelayCommand(() =>
            {
                Events.Update(SelectedEvent);
            });
            DeleteEventCommand = new RelayCommand(() =>
            {
                Events.Delete(SelectedEvent.EventID);
            },
            () =>
            {
                return SelectedEvent != null;
            });
            SelectedEvent = new Events();
            


        }
    }
}
