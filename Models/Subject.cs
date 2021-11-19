using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tutorias.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CategoryName{get;set;}
    }
}