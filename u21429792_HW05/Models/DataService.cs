using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



namespace u21429792_HW05.Models
{
    public class DataService
    {

        private static DataService instance;
        public String connectionString = "Data Source=JENALLE\\SQLEXPRESS01;Initial Catalog=Library;Integrated Security=True";

       public static DataService getInstance()
        {
            if (instance == null)
            {
                instance = new DataService();
            }
            return instance;
        }

        public void setConnectionString(String someConnStr)
        {
            connectionString = someConnStr;
        }

        public List<Books> GetAllBooksDetails()
        {
            List<Books> books = new List<Books>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM books ", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Books book = new Books
                            (
                                bID : Convert.ToInt32(reader["bookId"]),
                                aID : Convert.ToInt32(reader["authorId"]),
                                tID : Convert.ToInt32(reader["typeId"]),
                                bTitle : Convert.ToString(reader["name"]),
                                bPageCount : Convert.ToInt32(reader["pagecount"]),
                                bPoint : Convert.ToInt32(reader["point"])
                            );
                            books.Add(book);
                        }
                    }
                }
                con.Close();
            }
            return books;
        }

        public List<Authors> GetAllAuthorsDetails()
        {
            List<Authors> authors = new List<Authors>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM authors ", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Authors author = new Authors
                            {
                                AID = Convert.ToInt32(reader["authorId"]),
                                AName = Convert.ToString(reader["name"]),
                                ASurname = Convert.ToString(reader["surname"]),
                            };
                            authors.Add(author);
                        }
                    }
                }
                con.Close();
            }
            return authors;
        }

        public List<Types> GetAllTypesDetails()
        {
            List<Types> types = new List<Types>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM types ", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Types type = new Types
                            {
                                TID = Convert.ToInt32(reader["typeId"]),
                                TName = Convert.ToString(reader["name"]),                                
                            };
                           types.Add(type);
                        }
                    }
                }
                con.Close();
            }
            return types;
        }

        public List<Borrows> GetAllBorrowDetails()
        {
            List<Borrows> borrows = new List<Borrows>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM borrows ", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Borrows borrow = new Borrows
                            {
                                BOID = Convert.ToInt32(reader["borrowId"]),
                                BID = Convert.ToInt32(reader["bookId"]),
                                SID = Convert.ToInt32(reader["studentId"]),
                                TakenDate = Convert.ToDateTime(reader["takenDate"]),
                                ReturnDate = Convert.ToDateTime(reader["broughtDate"]),
                            };
                            borrows.Add(borrow);
                        }
                    }
                }
                con.Close();
            }
            return borrows;
        }

        public List<Students> GetAllStudentsDetails()
        {
            List<Students> students = new List<Students>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM students", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Students student = new Students
                            {
                                SID = Convert.ToInt32(reader["studentId"]),
                                SName = Convert.ToString(reader["name"]),
                                SSurname = Convert.ToString(reader["surname"]),
                                SDOB = Convert.ToDateTime(reader["birthdate"]),
                                SGender = Convert.ToString(reader["gender"]),
                                SClass = Convert.ToString(reader["class"]),
                                SPoint = Convert.ToInt32(reader["point"])
                            };
                            students.Add(student);
                        }
                    }
                }
                con.Close();
            }
            return students;
        }
    }
}