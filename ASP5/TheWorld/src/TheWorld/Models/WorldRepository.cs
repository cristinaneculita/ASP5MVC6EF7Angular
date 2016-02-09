﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;

namespace TheWorld.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;
        private ILogger<WorldRepository> _logger;

        public WorldRepository(WorldContext context, ILogger<WorldRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Trip> GetAllTrips()
        {
            try
            {
                return _context.Trips.OrderBy(t => t.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get trips from database", ex);
                return null;
            }
        }

        public IEnumerable<Trip> GetAllTripsWithStops()
        {
            return _context.Trips
                .Include(t=>t.Stops)
                .OrderBy(t => t.Name)
                .ToList();
        }

        public void AddTrip(Trip newTrip)
        {
            _context.Add(newTrip);
        }

        public bool SaveAll()
        {
           return _context.SaveChanges()>0;
        }

        public Trip GetTripByName(string tripName)
        {
            return _context.Trips
                .Include(t => t.Stops)
                .FirstOrDefault(t => t.Name == tripName);
        }

        public void AddStop(string tripName,string username,Stop newStop)
        {
            var theTrip = GetTripByName(tripName, username);
            newStop.Order = theTrip.Stops.Max(s => s.Order) + 1;
            theTrip.Stops.Add(newStop);
            _context.Stops.Add(newStop);
        }

        public IEnumerable<Trip> GetUserTripsWithStops(string name)
        {
            return _context.Trips
               .Include(t => t.Stops)
               .OrderBy(t => t.Name)
               .Where(t=>t.UserName==name)
               .ToList();
        }

        public Trip GetTripByName(string tripName, string name)
        {
            return _context.Trips
              .Include(t => t.Stops)
              .Where(t=>t.UserName==name)
              .FirstOrDefault(t => t.Name == tripName);
        }
    }
}
