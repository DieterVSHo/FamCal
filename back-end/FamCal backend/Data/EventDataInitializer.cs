using Microsoft.AspNetCore.Identity;
using FamCal_backend.Models;
using System;
using System.Collections.Generic;

namespace FamCal_backend.Data
{
    // to rename to famcaldatainit
    public class EventDataInitializer
    {
        private readonly FamCalContext _dbContext;

        public EventDataInitializer(FamCalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                var events = new List<Event>
                {
                    new Event { Title = "afspraak tandarts", StartDate = new DateTime(2020,08,20,08,30,0), EndDate = new DateTime(2020,08,20,09,30,0)}
                };
                events.ForEach(e => _dbContext.Events.Add(e));
                _dbContext.SaveChanges();
            };
            }

    }
}