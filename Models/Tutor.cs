using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tutorias.Models
{
    public class Tutor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email {get;set;}
        [MaxLength(80)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public float? AverageScore { get; set; }
        public ICollection<Tutorship>? Tutorships { get; set; }
        public ICollection<TutorCategory>? TutorCategories { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
    }
}