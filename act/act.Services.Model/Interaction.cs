using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace act.Services.Model
{
    public class Interaction
    {
        [Key()]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Relation Relation { get; set; }

        public virtual ICollection<Relation> Subjects { get; set; }
        public virtual ICollection<Relation> AsSubjects { get; set; }
    }
}