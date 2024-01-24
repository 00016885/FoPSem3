using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIUT.DAL
{
    internal class CourseManager
    {

        public void Create(Course c)
        {
            using var connection = new SQLiteConnection();
            try
            {
                var sql = $"INSERT INTO Course (Name) VALUES ('{c.Name}')";
                using var command = new SQLiteCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        public void Update(Course c)
        {
            using var connection = new SQLiteConnection();
            try
            {
                var sql = $"UPDATE Course SET (Name) VALUES ('{c.Name}' WHERE Id = {c.Id})";
                using var command = new SQLiteCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }



        public void Delete(int id)
        {
            using var connection = new SQLiteConnection();
            try
            {
                var sql = $"DELETE FROM Course WHERE Id = {id}";
                using var command = new SQLiteCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }



        public List<Course> GetAll()
        {
            using var connection = new SQLiteConnection();
            var result = new List<Course>();
            try
            {
                var sql = "SELECT Id, Name FROM Course";
                using var command = new SQLiteCommand(sql, connection);
                connection.Open();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var c = new Course
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Name = Convert.ToString(reader.GetValue(1))
                    };
                    result.Add(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

            return result;
        }

        public Course GetById(int id)
        {
            using var connection = new SQLiteConnection();
            try
            {
                var sql = $"SELECT Id, Name FROM Course WHERE Id = {id}";
                using var command = new SQLiteCommand(sql, connection);
                connection.Open();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var c = new Course
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Name = Convert.ToString(reader.GetValue(1))
                    };
                    return c;
                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

            return null;
        }





    }
}
