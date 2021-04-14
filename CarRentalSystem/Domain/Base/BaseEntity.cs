using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalSystem.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        protected BaseEntity(int id)
        {
            Id = id;
        }
    }
}
