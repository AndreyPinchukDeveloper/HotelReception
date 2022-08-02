﻿using HotelManger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManger.Stores
{
    public class HotelStore
    {
        private readonly Hotel _hotel;
        private readonly List<Reservation> _reservations;
        private Lazy<Task> _initializeLazy;//we use lazy initialization to create an object only when 
                                                    //we first call it
        public IEnumerable<Reservation> Reservations => _reservations;
        public event Action<Reservation> ReservationMade;//Action return void, Func return value

        public HotelStore(Hotel hotel)
        {
            _hotel = hotel;
            _initializeLazy = new Lazy<Task>(Initialize);

            _reservations = new List<Reservation>();
        }

        public async Task Load()
        {
            try
            {
                await _initializeLazy.Value;
            }
            catch (Exception)
            {
                _initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }

            
        }

        public async Task MakeReservation(Reservation reservation)
        {
            await _hotel.MakeReservation(reservation);
            _reservations.Add(reservation);

            OnReservationMade(reservation);
        }

        /// <summary>
        /// Invoke method for Action delegate
        /// </summary>
        private void OnReservationMade(Reservation reservation)
        {
            ReservationMade?.Invoke(reservation);  
        }

        private async Task Initialize()
        {
            IEnumerable<Reservation> reservations = await _hotel.GetAllReservations();

            _reservations.Clear();
            _reservations.AddRange(reservations);
        }
    }
}
