using System;
using System.Collections.Generic;

namespace StudentExercises {
    public class Cohort {

        // The cohort 's name (Evening Cohort 6, Day Cohort 25, etc.)
        // The collection of students in the cohort.
        // The collection of instructors in the cohort.

        public string name {get; set;}
        public List<Student> StudentCollection = new List<Student> ();
        public List<Instructor> InstructorCollection = new List<Instructor> ();
    }

}