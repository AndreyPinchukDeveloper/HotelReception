﻿using HotelManger.Models;

namespace HotelManger.ViewModels
{
    /// <summary>
    /// This view model glue the model and the view
    /// </summary>
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservation;
        /// <summary>
        /// We use this ViewModel instead of directly binding with Resrvation model
        /// becase we wouldn't be able to change roomID to a string
        /// </summary>
        public string RoomID => _reservation.RoomID?.ToString();
        public string UserName => _reservation.UserName;
        public string StartDate => _reservation.StartTime.ToString("d");
        public string EndDate => _reservation.EndTime.ToString("d");
        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}
