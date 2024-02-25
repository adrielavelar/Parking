using Parking.Domain.Enums;

namespace Parking.Data.Entities
{
    public class Record
    {
        public Guid Id { get; set; }
        public DateTime In { get; set; }
        public DateTime? Out { get; set; }
        public int Quantity { get; set; }
        public TypeEnum Type { get; set; }
        public bool Active { get; set; }
    }
}
