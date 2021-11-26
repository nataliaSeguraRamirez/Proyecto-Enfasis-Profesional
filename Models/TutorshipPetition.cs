using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tutorias.Models
{
    public class TutorshipPetition
    {
        public int ID{ get; set; }
        public int StudentID { get; set; }
        public int TutorID { get; set; }
        public DateTime CreatedAt {get;set;}
        public string State { get; set; } = "Pendiente";
        public string? Message {get;set;} = "Sin mensaje.";
    }
}