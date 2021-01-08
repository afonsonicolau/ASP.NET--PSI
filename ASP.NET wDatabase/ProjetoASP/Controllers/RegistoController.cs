using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoASP.Models;
using System.IO;
using MySql.Data.MySqlClient;

namespace ProjetoASP.Controllers
{
    public class RegistoController : Controller
    {
        // GET: Registo
        public ActionResult Registo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registo(Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                ConexaoDB connection = new ConexaoDB("localhost", 3307, "root", "root", "formacao");

                using (MySqlConnection sqlConnection = connection.ObterConexao())
                {
                    if(sqlConnection != null)
                    {
                        string sInsertQuery = "INSERT INTO utilizadores VALUES(0, @email, MD5(@password))"; // MD5 encryption on password

                        using (MySqlCommand sqlCommand = new MySqlCommand(sInsertQuery, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@email", utilizador.sEmail);
                            sqlCommand.Parameters.AddWithValue("@password", utilizador.sPassword);

                            int iNumeroRegistos = sqlCommand.ExecuteNonQuery();

                            // If successful
                            if(iNumeroRegistos == 1)
                            {
                                return RedirectToAction("Login");
                            }

                        }
                    }
                }
            }
            return RedirectToAction("Registo");
        }

        public ActionResult Login(Utilizador utilizador)
        {
            if (ModelState.IsValid)
            {
                ConexaoDB connection = new ConexaoDB("localhost", 3307, "root", "root", "formacao");

                using (MySqlConnection sqlConnection = connection.ObterConexao())
                {
                    if (sqlConnection != null)
                    {
                        string sSelectQuery = "SELECT * FROM utilizadores WHERE emailUtilizadores=@email AND passwordUtilizadores=MD5(@password)"; // MD5 encryption on password

                        using (MySqlCommand sqlCommand = new MySqlCommand(sSelectQuery, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@email", utilizador.sEmail);
                            sqlCommand.Parameters.AddWithValue("@password", utilizador.sPassword);

                            using (MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                            {
                                // Verifys if theres data return, meaning, if user already exists
                                if(sqlDataReader.Read())
                                {
                                    // Saves login information
                                    Session["login"] = 1;
                                    Session["email"] = utilizador.sEmail;

                                    return RedirectToAction("ListarAluno", "Aluno");
                                }
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            // If on an active session
            if(Session["login"] != null)
            {
                Session.Abandon();
            }
            return RedirectToAction("Login");
        }
    }
}