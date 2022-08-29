using System.ComponentModel.DataAnnotations;

namespace act.Services.Model
{
    public class Relation
    {
        [Key()]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        
        public virtual Interaction Subject { get; set; }
        public int SubjectId { get; set; }
        public virtual Interaction Object { get; set; }
        public int ObjectId { get; set; }
    }
}
