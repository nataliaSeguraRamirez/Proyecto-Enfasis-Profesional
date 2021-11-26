using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorias.Models
{
    public class Tutorship
    {
        public int ID{ get; set; }
        public int StudentID { get; set; }
        public int TutorID { get; set; }
        public float? Score { get; set; }
        public Boolean Sent {get;set;} = false;
        public string? Description {get;set;} = "No se dieron comentarios";
    }
}