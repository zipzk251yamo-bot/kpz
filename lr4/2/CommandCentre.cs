using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Mediator
{
    class CommandCentre
    {
        private List<Runway> _runways = new List<Runway>();
        private List<Aircraft> _aircrafts = new List<Aircraft>();
        // Словник для відстеження: який літак на якій смузі зараз знаходиться
        private Dictionary<Aircraft, Runway> _aircraftRunways = new Dictionary<Aircraft, Runway>();

        public void RegisterRunway(Runway runway)
        {
            _runways.Add(runway);
        }

        public void RegisterAircraft(Aircraft aircraft)
        {
            _aircrafts.Add(aircraft);
        }

        // Центральний метод для обробки подій
        public void Notify(object sender, string ev)
        {
            if (sender is Aircraft aircraft)
            {
                if (ev == "Land")
                {
                    Console.WriteLine($"[Командний Центр]: Обробка запиту на посадку для {aircraft.Name}...");
                    // Шукаємо вільну смугу
                    var freeRunway = _runways.FirstOrDefault(r => !r.IsBusy);
                    
                    if (freeRunway != null)
                    {
                        Console.WriteLine($"[Командний Центр]: Знайдено вільну смугу. Дозвіл на посадку надано.");
                        freeRunway.SetBusyStatus(true);
                        _aircraftRunways[aircraft] = freeRunway;
                        Console.WriteLine($"[Командний Центр]: Літак {aircraft.Name} успішно сів на смугу {freeRunway.Id}.");
                    }
                    else
                    {
                        Console.WriteLine($"[Командний Центр]: Відмова! Усі смуги зайняті. {aircraft.Name} залишається в повітрі.");
                    }
                }
                else if (ev == "TakeOff")
                {
                    Console.WriteLine($"[Командний Центр]: Обробка запиту на зліт для {aircraft.Name}...");
                    if (_aircraftRunways.TryGetValue(aircraft, out Runway runway))
                    {
                        runway.SetBusyStatus(false);
                        _aircraftRunways.Remove(aircraft);
                        Console.WriteLine($"[Командний Центр]: Літак {aircraft.Name} успішно злетів. Смуга {runway.Id} звільнена.");
                    }
                    else
                    {
                        Console.WriteLine($"[Командний Центр]: Помилка! Літак {aircraft.Name} не знаходиться на жодній смузі.");
                    }
                }
            }
        }
    }
}