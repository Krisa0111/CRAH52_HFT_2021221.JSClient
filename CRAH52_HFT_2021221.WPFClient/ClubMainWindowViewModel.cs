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
    public class ClubMainWindowViewModel: ObservableRecipient
    {
        public RestCollection<Clubs> Clubs { get; set; }
        private Clubs selectedClub;    

        public Clubs SelectedClub
        {
            get { return selectedClub; }
            set 
            {
                if (value!=null)
                {
                    selectedClub = new Clubs()
                    {
                        ClubName = value.ClubName,
                        ClubID = value.ClubID,
                        Capacity = value.Capacity,
                        President = value.President,
                        BaseTicketPrice = value.BaseTicketPrice,
                        Events = value.Events,
                        ShortDesc = value.ShortDesc
                    };
                    OnPropertyChanged();
                    (DeleteClubCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateClubCommand { get; set; }
        public ICommand DeleteClubCommand { get; set; }
        public ICommand UpdateClubCommand { get; set; }
        public ClubMainWindowViewModel()
        {
            Clubs = new RestCollection<Clubs>("http://localhost:30907/","clubs","hub");
            CreateClubCommand = new RelayCommand(() =>
            {
                Clubs.Add(new Clubs()
                {
                    ClubName = SelectedClub.ClubName,
                    ClubID = SelectedClub.ClubID,
                    Capacity= SelectedClub.Capacity,
                    President= SelectedClub.President,
                    ShortDesc= SelectedClub.ShortDesc,
                    BaseTicketPrice= SelectedClub.BaseTicketPrice,
                    Events= SelectedClub.Events
                }) ;
            });

            UpdateClubCommand = new RelayCommand(() =>
            {
                Clubs.Update(SelectedClub);
                OnPropertyChanged();
            });

            DeleteClubCommand = new RelayCommand(() =>
            {
                Clubs.Delete(SelectedClub.ClubID);
                OnPropertyChanged();
            },
            () => 
            {
                return SelectedClub != null;
            }
            );
            SelectedClub=new Clubs();
        }
    }
}
