using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace paginaColegio1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

           // string CadenaConexion = "server=ipefnorteargentino.ddns.net; port=3306; username=nortesdw; password=nortesdw; database=nortesdw;";
            string CadenaConexion = "server =ipefnorteargentino.ddns.net; user id =nortesdw; password =nortesdw; port =3306; database =nortesdw;";
            MySqlConnection dbCon = new MySqlConnection(CadenaConexion);

            string query = "SELECT * FROM alumnos";
            MySqlCommand commandDatabase = new MySqlCommand(query, dbCon);

            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            dbCon.Open();

            // Ejecuta la consultas
            reader = commandDatabase.ExecuteReader();

            string v="";

            while (reader.Read())
            {
                
                    v = reader.GetString(3);
               
            }

           

            // Cerrar la conexión
            dbCon.Close();

            ViewData["alumno"] = v;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}