using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises {
    class Program {
        static void Main (string[] args) {

            // Create 4, or more, exercises.
            Exercise ChickenMonkey = new Exercise ("Chicken Monkey", "JavaScript");
            Exercise CssSelectors = new Exercise ("Advanced CSS Selectors", "CSS");
            Exercise ReactComponents = new Exercise ("React Components", "React");
            Exercise YellowBrickRoad = new Exercise ("Yellow Brick Road", "HTML");

            // Create 3, or more, cohorts.
            Cohort C26 = new Cohort () { name = "Day Cohort 26" };
            Cohort C27 = new Cohort () { name = "Day Cohort 27" };
            Cohort C28 = new Cohort () { name = "Day Cohort 28" };

            // Create 4, or more, students and assign them to one of the cohorts.
            Student Jonathan = new Student () {
                FirstName = "Jonathan",
                LastName = "Edwards",
                SlackHandle = "@Jonathan",
                Cohort = C27
            };
            C27.StudentCollection.Add (Jonathan);

            Student Alejandro = new Student () {
                FirstName = "Alejandro",
                LastName = "Font",
                SlackHandle = "@Alejandro",
                Cohort = C28
            };
            C28.StudentCollection.Add (Alejandro);

            Student Madi = new Student () {
                FirstName = "Madi",
                LastName = "Peper",
                SlackHandle = "@Madi",
                Cohort = C27
            };
            C27.StudentCollection.Add (Madi);

            Student Streator = new Student () {
                FirstName = "Streator",
                LastName = "Ward",
                SlackHandle = "@Streator",
                Cohort = C26
            };
            C26.StudentCollection.Add (Streator);

            Student Ricky = new Student () {
                FirstName = "Ricky",
                LastName = "Bruner",
                SlackHandle = "@ricky",
                Cohort = C26
            };
            C26.StudentCollection.Add (Ricky);

            // Create 3, or more, instructors and assign them to one of the cohorts.
            Instructor Steve = new Instructor () {
                FirstName = "Steve",
                LastName = "Brownlee",
                SlackHandle = "@coach",
                Cohort = C27
            };
            C27.InstructorCollection.Add (Steve);

            Instructor Meg = new Instructor () {
                FirstName = "Meg",
                LastName = "Ducharme",
                SlackHandle = "@meg",
                Cohort = C26
            };;
            C26.InstructorCollection.Add (Meg);

            Instructor Kimmy = new Instructor () {
                FirstName = "Kimmy",
                LastName = "Bird",
                SlackHandle = "@kimmy",
                Cohort = C28
            };;
            C28.InstructorCollection.Add (Kimmy);

            // Have each instructor assign 2 exercises to each of the students.
            Steve.AssignExercise (Jonathan, ChickenMonkey);
            Steve.AssignExercise (Jonathan, CssSelectors);
            Steve.AssignExercise (Jonathan, ReactComponents);

            Steve.AssignExercise (Madi, CssSelectors);
            Steve.AssignExercise (Madi, ReactComponents);

            Meg.AssignExercise (Streator, ChickenMonkey);
            Meg.AssignExercise (Streator, CssSelectors);

            Kimmy.AssignExercise (Alejandro, ReactComponents);
            Kimmy.AssignExercise (Alejandro, YellowBrickRoad);

            // Create a list of students. Add all of the student instances to it.
            List<Student> students = new List<Student> () {
                Jonathan,
                Alejandro,
                Madi,
                Streator,
                Ricky
            };

            // Create a list of exercises.Add all of the exercise instances to it.
            List<Exercise> exercises = new List<Exercise> () {
                ChickenMonkey,
                CssSelectors,
                ReactComponents,
                YellowBrickRoad
            };

            // Create a list of instructors. Add all of the instructor instances to it.
            List<Instructor> instructors = new List<Instructor> () {
                Steve,
                Meg,
                Kimmy,
            };

            // Create a list of cohorts. Add all of the cohort instances to it.
            List<Cohort> cohorts = new List<Cohort> () {
                C26,
                C27,
                C28
            };

            foreach (Student student in students) {
                string StudentName = student.FirstName;
                string StudentExerciseList = "";
                int count = 0;

                foreach (Exercise exer in student.ExerciseCollection) {
                    if (count == 0) {
                        StudentExerciseList = $"{exer.Name} in {exer.Language}";
                        count++;
                    } else {
                        StudentExerciseList = $"{exer.Name} in {exer.Language} and {StudentExerciseList}.";
                        count++;
                    }
                }

                Console.WriteLine ($"{StudentName} of {student.Cohort.name} is working on {StudentExerciseList}");

            }

            // List exercises for the JavaScript language by using the Where() LINQ method.
            List<Exercise> JavaScriptExercises =
                (from js in exercises where js.Language == "JavaScript"
                    select js).ToList ();

            Console.WriteLine ("----- JS Exercises -----");
            foreach (Exercise ex in JavaScriptExercises) {
                Console.WriteLine (ex.Name);
            }

            // List students in a particular cohort by using the Where() LINQ method.
            List<Student> C27Students =
                (from student in students where student.Cohort.name == "Day Cohort 27"
                    select student).ToList ();

            Console.WriteLine ("----- Cohort 27 Students -----");
            foreach (Student stu in C27Students) {
                Console.WriteLine (stu.FirstName);
            }

            // List instructors in a particular cohort by using the Where() LINQ method.
            List<Instructor> C27Instructors =
                (from ins in instructors where ins.Cohort.name == "Day Cohort 27"
                    select ins).ToList ();

            Console.WriteLine ("----- Cohort 27 Instructors -----");
            foreach (Instructor ins in C27Instructors) {
                Console.WriteLine (ins.FirstName);
            }

            // Sort the students by their last name.
            List<Student> StudentsByLastName =
                (from student in students
                orderby student.LastName
                select student).ToList();

            Console.WriteLine ("----- Students By Last Name -----");
            foreach (Student stu in StudentsByLastName) {
                Console.WriteLine ($"{stu.FirstName} {stu.LastName}");
            }

            // Display any students that aren't working on any exercises 
            // (Make sure one of your student instances don't have any exercises.
            // Create a new student if you need to.)

            List<Student> StudentsWithNoWork = 
            (from stu in students
            where stu.ExerciseCollection.Count == 0
            select stu).ToList();

            Console.WriteLine ("----- Students Not Working On Exercises -----");
            foreach (Student stu in StudentsWithNoWork) {
                Console.WriteLine ($"{stu.FirstName}");
            }

            // Which student is working on the most exercises? 
            // Make sure one of your students has more exercises than the others.
            List<Student> StudentWithMostWork =
            (from stu in students
            where stu.ExerciseCollection.Count > 2
            select stu).ToList();

             Console.WriteLine ("----- Student With Most Work -----");
             foreach (Student stu in StudentWithMostWork) {
                Console.WriteLine ($"{stu.FirstName}");
            }

            // How many students in each cohort?
            Console.WriteLine ("----- How many students in each cohort? -----");
            foreach (Cohort cohort in cohorts) {
                Console.WriteLine ($"{cohort.name} has {cohort.StudentCollection.Count} students in it");
            }
        }
    }
}