using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tutorias.Models
{
    public class Subject
    {
        public enum Subjects
        {   

            //cambiar relación muchos a muchos con tutor
            [Display(Name = "Álgebra Lineal")] Algebra_Lineal,
            [Display(Name = "Física Mecánica")] Fisica_Mecanica,
            [Display(Name = "Ciencias Políticas")] Ciencias_Políticas,
            [Display(Name = "Cálculo Diferencial")] Calculo_Diferencial,
        }
        [Key]public int Name { get; set; }
    }
}