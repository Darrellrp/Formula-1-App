﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_App.Models;

public abstract class Standing : Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int? Id { get; set; }
    public int RaceId { get; set; }
    public float Points { get; set; }
    public int Position { get; set; }
    public string PositionText { get; set; }
    public int Wins { get; set; }

    protected Standing(int? id, int raceId, float points, int position, string positionText, int wins)
    {
        this.Id = id;
        this.RaceId = raceId;
        this.Points = points;
        this.Position = position;
        this.PositionText = positionText;
        this.Wins = wins;
    }
}
