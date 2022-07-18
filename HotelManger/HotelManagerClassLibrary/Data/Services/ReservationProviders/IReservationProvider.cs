﻿using HotelManagerClassLibrary.Models;

namespace HotelManagerClassLibrary.Data.Services.ReservationProviders
{
    public interface IReservationProvider
    {
        Task<IEnumerable<Reservation>> GetAllReservations();//Класс Task представляет собой одну операцию,
                                                            //которая не возвращает значение и обычно выполняется асинхронно.
                                                            //Task объекты являются одним из центральных компонентов асинхронного шаблона на основе задач

        //IEnumerable — это базовый интерфейс для всех неуниверсальных коллекций, которые можно перечислить
    }
}
