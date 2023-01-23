using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Development_Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            /*
             * CHANGE DATASOURCE TO LOCAL DB
             */

            builder.DataSource = "DESKTOP-SQ77T5G\\SQLEXPRESS";

            builder.IntegratedSecurity = true;
            builder.TrustServerCertificate = true;
            string sqlConnectionString = builder.ConnectionString;

            DirectoryInfo currentDir = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString());

            string[] fileArray = Directory.GetFiles(currentDir + @"\SqlScripts\");


            foreach (string file in fileArray)
            {
                try
                {
                    string script = File.ReadAllText(file);

                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand(script, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in file: " + file);
                    Console.WriteLine(e);
                }

            }
        }
    }
}