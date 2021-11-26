using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Tutorias.Models
{
    public class Tutor : ApplicationUser
    {
        [Key]public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z]+[a-zA-Z]*$")] [MaxLength(64)] public string Name { get; set; }
        [DataType(DataType.EmailAddress)][MaxLength(128)] public string Email { get; set; }
        [MaxLength(700)] public string Description { get; set; }
        [MaxLength(10)] public string? PhoneNumber { get; set; }
        [MaxLength(100)] public string? TwitterLink { get; set; }
        [MaxLength(100)] public string? FacebookLink { get; set; }
        [MaxLength(100)] public string? InstagramLink { get; set; }
        public float? AverageScore { get; set; }
        public ICollection<Tutorship>? Tutorships { get; set; }
        public ICollection<TutorCategory>? TutorCategories { get; set; }
        public ICollection<TutorSubject>? TutorSubjects { get; set; }
    }
}