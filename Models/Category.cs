using System;
using System.Collections.Generic;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace Tutorias.Models
{
    public class Category
    {
        public int ID { get; set; }
        public ICollection<TutorCategory> TutorCategories {get;set;}
        public enum Categories
        {
            [Display(Name = "Ciencias Sociales")] Ciencias_Sociales,
            [Display(Name = "Ciencias Naturales")] Ciencias_Naturales,
            [Display(Name = "Ciencias Exactas")] Ciencias_Exactas,
        }
    }
}