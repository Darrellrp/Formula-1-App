﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_API.Models
{
    public class DriverStanding : Standing, IIdentifier
    {       
        public int DriverId { get; set; }

        public DriverStanding() {}

        public DriverStanding(int? id, int driverId, int raceId, float points, int position, string positionText, int wins)
            : base(id, raceId, points, position, positionText, wins)
        {
            this.DriverId = driverId;
        }
    }
}
