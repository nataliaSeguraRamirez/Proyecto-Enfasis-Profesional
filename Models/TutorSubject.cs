using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorias.Models
{
    public class TutorSubject
    {
        public int ID{ get; set; }
        public int StudentID { get; set; }
        public int TutorID { get; set; }
    }
}