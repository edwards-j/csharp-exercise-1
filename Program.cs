using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;

namespace StudentExercises {
    class Program {
        static void Main (string[] args) {

            // Create 4, or more, exercises.
            // Exercise ChickenMonkey = new Exercise ("Chicken Monkey", "JavaScript");
            // Exercise CssSelectors = new Exercise ("Advanced CSS Selectors", "CSS");
            // Exercise ReactComponents = new Exercise ("React Components", "React");
            // Exercise YellowBrickRoad = new Exercise ("Yellow Brick Road", "HTML");

            Exercise ChickenMonkey = new Exercise () {
                Name = "Chicken Monkey",
                ExerciseLanguage = "JavaScript"
            };
            Exercise CssSelectors = new Exercise () {
                Name = "Advanced CSS Selectors",
                ExerciseLanguage = "CSS"
            };
            Exercise ReactComponents = new Exercise () {
                Name = "React Components",
                ExerciseLanguage = "React"
            };
            Exercise YellowBrickRoad = new Exercise () {
                Name = "Yellow Brick Road",
                ExerciseLanguage = "HTML"
            };

            // Create 3, or more, cohorts.
            Cohort C26 = new Cohort () { CohortName = "Day Cohort 26" };
            Cohort C27 = new Cohort () { CohortName = "Day Cohort 27" };
            Cohort C28 = new Cohort () { CohortName = "Day Cohort 28" };

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
                        StudentExerciseList = $"{exer.Name} in {exer.ExerciseLanguage}";
                        count++;
                    } else {
                        StudentExerciseList = $"{exer.Name} in {exer.ExerciseLanguage} and {StudentExerciseList}.";
                        count++;
                    }
                }

                Console.WriteLine ($"{StudentName} of {student.Cohort.CohortName} is working on {StudentExerciseList}");

            }

            // List exercises for the JavaScript language by using the Where() LINQ method.
            List<Exercise> JavaScriptExercises =
                (from js in exercises where js.ExerciseLanguage == "JavaScript"
                    select js).ToList ();

            Console.WriteLine ("----- JS Exercises -----");
            foreach (Exercise ex in JavaScriptExercises) {
                Console.WriteLine (ex.Name);
            }

            // List students in a particular cohort by using the Where() LINQ method.
            List<Student> C27Students =
                (from student in students where student.Cohort.CohortName == "Day Cohort 27"
                    select student).ToList ();

            Console.WriteLine ("----- Cohort 27 Students -----");
            foreach (Student stu in C27Students) {
                Console.WriteLine (stu.FirstName);
            }

            // List instructors in a particular cohort by using the Where() LINQ method.
            List<Instructor> C27Instructors =
                (from ins in instructors where ins.Cohort.CohortName == "Day Cohort 27"
                    select ins).ToList ();

            Console.WriteLine ("----- Cohort 27 Instructors -----");
            foreach (Instructor ins in C27Instructors) {
                Console.WriteLine (ins.FirstName);
            }

            // Sort the students by their last name.
            List<Student> StudentsByLastName =
                (from student in students orderby student.LastName select student).ToList ();

            Console.WriteLine ("----- Students By Last Name -----");
            foreach (Student stu in StudentsByLastName) {
                Console.WriteLine ($"{stu.FirstName} {stu.LastName}");
            }

            // Display any students that aren't working on any exercises 
            List<Student> StudentsWithNoWork =
                (from stu in students where stu.ExerciseCollection.Count == 0 select stu).ToList ();

            Console.WriteLine ("----- Students Not Working On Exercises -----");
            foreach (Student stu in StudentsWithNoWork) {
                Console.WriteLine ($"{stu.FirstName}");
            }

            // Which student is working on the most exercises? 
            List<Student> StudentWithMostWork =
                (from stu in students orderby stu.ExerciseCollection.Count descending select stu).ToList ();

            Console.WriteLine ("----- Student With Most Work -----");
            Console.WriteLine ($"{StudentWithMostWork.First().FirstName} is the student with the most exercises");

            // How many students in each cohort?
            Console.WriteLine ("----- How many students in each cohort? -----");
            foreach (Cohort cohort in cohorts) {
                Console.WriteLine ($"{cohort.CohortName} has {cohort.StudentCollection.Count} students in it");
            }

            SqliteConnection db = DatabaseInterface.Connection;

            // Query the database for all the Exercises.
            List<Exercise> AllEx = db.Query<Exercise> (@"SELECT * FROM Exercise").ToList ();
            Console.WriteLine ($"There are {AllEx.Count} exercises");

            // Find all the exercises in the database where the language is JavaScript.
            List<Exercise> JavaScriptEx =
                db.Query<Exercise> (@"SELECT  *
                                FROM Exercise e
                                WHERE e.ExerciseLanguage = 'JavaScript'
                                ").ToList ();

            Console.WriteLine ($"There are {JavaScriptEx.Count} JS exercises");

            // Insert a new exercise into the database.
            // db.Execute(@"
            // INSERT INTO exercise (name, ExerciseLanguage) VALUES ('Planets', 'C#');
            // ");

            // Find all instructors in the database. Include each instructor's cohort.
            Console.WriteLine ("-----All Instructors and their Cohorts-----");
            db.Query<Instructor, Cohort, Instructor> (@"
                                SELECT *
                                FROM instructor i
                                JOIN Cohort c ON c.Id = i.CohortId
                                ", (instructor, cohort) => {
                    instructor.Cohort = cohort;
                    return instructor;
                })
                .ToList ()
                .ForEach (ins => Console.WriteLine ($"{ins.FirstName} is the instructor for {ins.Cohort.CohortName}"));

            // Insert a new instructor into the database. Assign the instructor to an existing cohort.
            // db.Execute(@"
            // INSERT INTO instructor
            // (FirstName, LastName, SlackHandle, CohortId)
            // VALUES
            // ('Jenna', 'Solis', '@jenna', '2')
            // ");

            // Assign an existing exercise to an existing student.
            // db.Execute (@"
            //     INSERT INTO StudentExercise
            //     (ExerciseId, StudentId)
            //     VALUES
            //     (1, 4)
            //     ");

            // Find all the students in the database. 
            // Include each student's cohort AND each student's list of exercises.

           
        }
    }
}