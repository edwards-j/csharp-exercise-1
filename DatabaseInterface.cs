using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using Microsoft.Data.Sqlite;

namespace StudentExercises {
    public class DatabaseInterface {
        public static SqliteConnection Connection {
            get {
                string _connectionString = $"Data Source=./StudentExercises.db";
                return new SqliteConnection (_connectionString);
            }
        }
    }
}