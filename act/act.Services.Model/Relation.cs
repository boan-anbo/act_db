using System.ComponentModel.DataAnnotations;

namespace act.Services.Model
{
    public class Relation
    {
        [Key()]
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        
        public virtual Interaction Subject { get; set; }
        public int SubjectId { get; set; }
        public virtual Interaction Object { get; set; }
        public int ObjectId { get; set; }
    }
}
