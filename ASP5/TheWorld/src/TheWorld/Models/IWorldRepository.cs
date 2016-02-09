using System.Collections.Generic;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
        void AddTrip(Trip newTrip);
        bool SaveAll();
        Trip GetTripByName(string tripName);

        void AddStop(string tripName, string name, Stop newStop);
        IEnumerable<Trip> GetUserTripsWithStops(string name);
        Trip GetTripByName(string tripName, string name);
    }
}