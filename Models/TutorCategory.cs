using System;
using System.Collections.Generic;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace Tutorias.Models
{
    public class TutorCategory
    {
        public int ID { get; set; }
        public int TutorID {get;set;}
        public int CategoryID{get;set;}
    }
}