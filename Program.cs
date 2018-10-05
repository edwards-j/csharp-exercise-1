using System;
using System.Collections.Generic;

namespace StudentExercises {
    class Program {
        static void Main (string[] args) {

            // Create 4, or more, exercises.
            Exercise Ex1 = new Exercise ("Chicken Monkey", "JavaScript");
            Exercise Ex2 = new Exercise ("Advanced CSS Selectors", "CSS");
            Exercise Ex3 = new Exercise ("React Components", "React");
            Exercise Ex4 = new Exercise ("Yellow Brick Road", "HTML");

            // Create 3, or more, cohorts.
            Cohort C26 = new Cohort ();
            Cohort C27 = new Cohort ();
            Cohort C28 = new Cohort ();

            // Create 4, or more, students and assign them to one of the cohorts.
            Student Jonathan = new Student ();
            Jonathan.FirstName = "Jonathan";
            Jonathan.LastName = "Edwards";
            Jonathan.SlackHandle = "@Jonathan";
            Jonathan.Cohort = "Day Cohort 27";
            C27.StudentCollection.Add (Jonathan);

            Student Alejandro = new Student ();
            Alejandro.FirstName = "Alejandro";
            Alejandro.LastName = "Font";
            Alejandro.SlackHandle = "@Alejandro";
            Alejandro.Cohort = "Day Cohort 28";
            C28.StudentCollection.Add (Alejandro);

            Student Madi = new Student ();
            Madi.FirstName = "Madi";
            Madi.LastName = "Peper";
            Madi.SlackHandle = "@Madi";
            Madi.Cohort = "Day Cohort 27";
            C27.StudentCollection.Add (Madi);

            Student Streator = new Student ();
            Streator.FirstName = "Streator";
            Streator.LastName = "Ward";
            Streator.SlackHandle = "@Streator";
            Streator.Cohort = "Day Cohort 26";
            C26.StudentCollection.Add (Streator);

            // Create 3, or more, instructors and assign them to one of the cohorts.
            Instructor Steve = new Instructor ();
            C27.InstructorCollection.Add (Steve);

            Instructor Meg = new Instructor ();
            C26.InstructorCollection.Add (Meg);

            Instructor Kimmy = new Instructor ();
            C28.InstructorCollection.Add (Kimmy);

            // Have each instructor assign 2 exercises to each of the students.
            Steve.AssignExercise (Jonathan, Ex1);
            Steve.AssignExercise (Jonathan, Ex4);

            Steve.AssignExercise (Madi, Ex2);
            Steve.AssignExercise (Madi, Ex3);

            Meg.AssignExercise (Streator, Ex1);
            Meg.AssignExercise (Streator, Ex2);

            Kimmy.AssignExercise (Alejandro, Ex3);
            Kimmy.AssignExercise (Alejandro, Ex4);

            // Create a list of students. Add all of the student instances to it.
            List<Student> students = new List<Student> ();
            students.Add (Jonathan);
            students.Add (Alejandro);
            students.Add (Madi);
            students.Add (Streator);

            // Create a list of exercises.Add all of the exercise instances to it.
            List<Exercise> exercises = new List<Exercise> ();
            exercises.Add (Ex1);
            exercises.Add (Ex2);
            exercises.Add (Ex3);
            exercises.Add (Ex4);

            // foreach (Student student in students) {
            //     Console.Write($"{student.FirstName} is working on {student.ExerciseCollection[0].Name} and {student.ExerciseCollection[1].Name}. ");
            // }

            foreach (Student student in students) {
                string StudentName = student.FirstName;
                string StudentExerciseList = "";
                int count = 0;

                foreach (Exercise exer in student.ExerciseCollection) {
                    if (count == 0) {
                        StudentExerciseList = $"{exer.Name}";
                        count++;
                    } else {
                        StudentExerciseList = $"{exer.Name} and {StudentExerciseList}.";
                        count++;
                    }
                }

                Console.WriteLine ($"{StudentName} is working on {StudentExerciseList}");
            }
        }
    }
}