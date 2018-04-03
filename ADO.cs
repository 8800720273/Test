using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    class Program
    {
        static SqlConnection con = null;
        public static void Connecting()
        {

            try
            {


                string constring = @"Data Source=DESKTOP-8R9D1AL\SQLEXPRESS;Initial Catalog=BizruntimeAsTrainee;Integrated Security=True;User id=sa;password=1234";
                con = new SqlConnection(constring);

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public static void Inner()
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("select e1.Username,e1.FirstName,e1.LastName,e2.DepartmentName from Employee e1 inner join Departments e2 on e1.DepartID=e2.id", con);
                SqlDataReader sdr = cm.ExecuteReader();
                Console.WriteLine("\nInner");
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i) + "\t");
                }
                Console.WriteLine("\n===============================================================");
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr[i] + "\t");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("===============================================================");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }

        }

        public static void Self()
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("SELECT e1.Username,e1.FirstName,e1.LastName from Employee e1 inner join Employee e2 on e1.id=e2.DepartID", con);
                SqlDataReader sdr = cm.ExecuteReader();
                Console.WriteLine("\nSelf");
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i) + "\t");
                }
                Console.WriteLine("\n===============================================================");
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr[i] + "\t");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("===============================================================");

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        public static void OuterLeft()
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Employee e1 LEFT OUTER JOIN Departments e2 ON e1.DepartID = e2.id ", con);
                SqlDataReader sdr = cm.ExecuteReader();
                Console.WriteLine("\nLeftOuter");
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i) + "\t");
                }
                Console.WriteLine("\n===============================================================");
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr[i] + "\t");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("===============================================================");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        public static void OuterRight()
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Employee e1 RIGHT OUTER JOIN Departments e2 ON e1.DepartID = e2.id", con);
                SqlDataReader sdr = cm.ExecuteReader();
                Console.WriteLine("\nRightOuter");
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i) + "\t");
                }
                Console.WriteLine("\n===============================================================");
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr[i] + "\t");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("===============================================================");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        public static void OuterFull()
        {
            try
            {
                con.Open();
                SqlCommand cm = new SqlCommand("SELECT * FROM Employee e1 FULL OUTER JOIN Departments e2 ON e1.DepartID = e2.id ", con);
                SqlDataReader sdr = cm.ExecuteReader();
                Console.WriteLine("\nFulllOuter");
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    Console.Write(sdr.GetName(i) + "\t");
                }
                Console.WriteLine("\n===============================================================");
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        Console.Write(sdr[i] + "\t");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("===============================================================");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }


        static void Main(string[] args)
        {
            Connecting();
            Inner();
            Self();
            OuterLeft();
            OuterRight();
            OuterFull();

            Console.ReadKey();
        }
    }
}


