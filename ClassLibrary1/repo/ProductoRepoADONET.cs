using ClassLibrary1.database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.repo
{
    public class ProductoRepoADONET
    {
        public static List<Producto> Listar()
        {
            // DAO -> ADO -> ADO.NET -> LINQ2SQL(MUERTO) -> ENTITY FRAMEWORK

            var resultado=new List<Producto>();
            var cs=ConfigurationManager.ConnectionStrings["conexionadonet"].ToString();

            // OCIConnection
            // MysqlConnection
            using(var con=new SqlConnection(cs))
            {
                var sql="select Id,Nombre from producto";
                var comando=new SqlCommand(sql,con);
                using(var lector=comando.ExecuteReader())
                {
                    while(lector.Read())
                    {
                        var prod=new Producto();
                        prod.Id=lector.GetInt32(0);
                        prod.Nombre=lector.GetString(1);
                        resultado.Add(prod);
                    }
                }
            }



            return resultado;
        }
    }
}
