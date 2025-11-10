using System.Data;
using System.Data.OleDb;

public class DumpDB
{

    public static void Main(string[] args)
    {

        args = ["Contact"];

        if (args.Length == 0)
        {

            Console.WriteLine("no args provided");
            return;
        }

        DataSet dataSet = new();

        OleDbConnection connection = new($"Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=playground;");
        OleDbDataAdapter adapter = new();

        foreach (var tableName in args)
        {
            adapter.SelectCommand = new OleDbCommand($"SELECT * FROM {tableName}", connection);
            adapter.Fill(dataSet, tableName);
        }
        connection.Close();

        foreach (DataTable table in dataSet.Tables)
        {
            Console.WriteLine(table.TableName);
            foreach (DataColumn col in table.Columns)
            {
                Console.Write($"{col.ColumnName}\t");
            }
            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (var obj in row.ItemArray)
                {
                    Console.Write($"{obj}\t");
                }
                Console.WriteLine();
            }
        }


    }

}
