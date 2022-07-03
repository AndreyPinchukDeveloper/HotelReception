﻿using ApplicationClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class ResrvationListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }
        public ResrvationListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            //TODO - use data from database
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 2), "Andre", DateTime.Now, DateTime.Now)));
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(2, 3), "Inessa", DateTime.Now, DateTime.Now)));
        }
    }
}
