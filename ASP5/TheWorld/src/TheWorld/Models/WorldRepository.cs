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

        public void AddStop(string tripName,Stop newStop)
        {
            var theTrip = GetTripByName(tripName);
            newStop.Order = theTrip.Stops.Max(s => s.Order) + 1;
            _context.Stops.Add(newStop);
        }
    }
}
