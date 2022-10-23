using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula_1_App.Models;

public abstract class Result : Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int? Id { get; set; }
    public int RaceId { get; set; }
    public int ConstructorId { get; set; }
    public float Points { get; set; }

    protected Result(int? id, int raceId, int constructorId, float points)
    {
        this.Id = id;
        this.RaceId = raceId;
        this.ConstructorId = constructorId;
        this.Points = points;
    }
}
