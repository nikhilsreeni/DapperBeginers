using System;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
namespace SampleConsole
{
    class Program 
    {
        static void Main(string[] args)
        {
           MyClass m=new MyClass();
           m.testMethod();

           Console.ReadLine();
        }
    }


    class  MyClass : RepositoryBase
    {
        public void testMethod()
        {

            using (SqlConnection connection = this.Connection)
            {
                const string query = "SELECT * FROM [user] WHERE [user].srno=11";
                Console.WriteLine(connection.Query<int>(query).FirstOrDefault() > 0 ? true : false);
            }
        }
    }


    public abstract partial class RepositoryBase
    {
        protected string ConnectiongString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            }
        }

        protected SqlConnection Connection
        {
            get
            {
                return new SqlConnection(this.ConnectiongString);
            }
        }
    }

}

