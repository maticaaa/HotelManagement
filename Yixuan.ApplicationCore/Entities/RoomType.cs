using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        public string? RTDesc { get; set; }
        public decimal? Rent { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public override bool Equals(object obj)
        {
            if(typeof(RoomType).IsInstanceOfType(obj))
            {
                return this.Id == ((RoomType)obj).Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
