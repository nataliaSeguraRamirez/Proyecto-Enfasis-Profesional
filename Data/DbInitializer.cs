using Tutorias.Models;
using System;
using System.Linq;

namespace Tutorias.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TutorshipContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]{
                new Student{Name="Camilo", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ac consectetur neque, id porttitor lacus. Pellentesque dolor erat, efficitur a urna sed, mattis maximus tortor. "},
                new Student{Name="Daniel", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ac consectetur neque, id porttitor lacus. Pellentesque dolor erat, efficitur a urna sed, mattis maximus tortor. "},
                new Student{Name="Pamela", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ac consectetur neque, id porttitor lacus. Pellentesque dolor erat, efficitur a urna sed, mattis maximus tortor. "}
            };

            foreach(Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var tutors = new Tutor[]{
                new Tutor{Name="Natalia", AverageScore=3.5f},
                new Tutor{Name="Andrés", AverageScore=2.1f},
                new Tutor{Name="Andrea", AverageScore=5f}
            };

            foreach(Tutor t in tutors)
            {
                context.Tutors.Add(t);
            }
            context.SaveChanges();

            var tutorships = new Tutorship[]
            {
                new Tutorship{StudentID=1, TutorID = 1},
                new Tutorship{StudentID=2, TutorID = 3},
                new Tutorship{StudentID=3, TutorID = 2}
            };

            foreach(Tutorship t in tutorships)
            {
                context.Tutorships.Add(t);
            }
            context.SaveChanges();
        }
    }
}