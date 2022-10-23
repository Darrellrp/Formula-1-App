using System;
namespace Formula_1_App.Models
{
    public abstract class Entity: IEntity
    {
        public abstract int? Id { get; set; }

        public Entity() { }

        public override bool Equals(object obj) => this.Equals((Entity)obj);

        public bool Equals(Entity entity)
        {
            if (entity == null)
            {
                return false;
            }

            return entity.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

