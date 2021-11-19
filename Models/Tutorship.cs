using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorias.Models
{
    public class Tutorship
    {
        public int TutorshipID{ get; set; }
        public int StudentID { get; set; }
        public int TutorID { get; set; }
        public float Score { get; set; }
        public string Description {get;set;} = "No se dieron comentarios";
    }
}