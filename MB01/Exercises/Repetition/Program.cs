using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace AdoNetRep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Filter-Criteria: ");
            string filterCriteria = Console.ReadLine();

            SqlConnection connection = new("Data Source=.;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False");

            SqlDataAdapter adapter = new();

            DataSet dataSet = new();

            adapter.SelectCommand = new SqlCommand($"SELECT * FROM Customers WHERE ContactName LIKE '%{filterCriteria}%' OR CompanyName LIKE '%{filterCriteria}%'", connection);

            adapter.Fill(dataSet, "Customers");

            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"{row["CustomerId"]}\t\t");
                    Console.Write($"{row["ContactName"]}\t\t");
                    Console.Write($"{row["CompanyName"]}\t\t");
                }
            }


        }
    }
}
