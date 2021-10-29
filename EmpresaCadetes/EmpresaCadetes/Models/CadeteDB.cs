using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EmpresaCadetes;
namespace EmpresaCadetes.Models
{
    public class RepositorioCadetes
    {
        
        private readonly string connectionString;
        private readonly SQLiteConnection conexion;
        public RepositorioCadetes(string connectionString){
            this.connectionString = connectionString;
            conexion= new SQLiteConnection(connectionString);
        }
        public List<Cadete> getAll(){
            using (SQLiteConnection conexion= new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string SQLQuery =  "SELECT * FROM Cadetes WHERE Activo= 1;";
                SQLiteCommand command= new SQLiteCommand(SQLQuery,conexion);
                SQLDataReader dataReader= command.Execute();
                while(dataReader.NextResult()){
                        Cadete cadete= new Cadete(){
                              id  = Convert.ToInt32(dataReader["cadteId"])
                              nombre = Convert.ToString(dataReader["cadeteNombre"])

                        };

                }

            }
        }
    }
}