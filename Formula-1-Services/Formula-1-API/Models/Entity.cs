using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Formula_1_API.Models
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

