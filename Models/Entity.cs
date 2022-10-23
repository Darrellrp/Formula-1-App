﻿using System;
namespace Formula_1_App.Models
{
    public abstract class Entity: IEntity
    {
        public abstract int? Id { get; set; }

        public Entity() { }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }

            return Equals((Entity)obj);
        }

        private bool Equals(Entity entity)
        {
            return entity.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

