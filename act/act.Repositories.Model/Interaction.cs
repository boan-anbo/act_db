using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace act.Services.Model
{
    public class Interaction
    {
        [Key()]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public Relation Relation { get; set; }

        public virtual ICollection<Relation> Subjects { get; set; }
        public virtual ICollection<Relation> AsSubjects { get; set; }
    }
}