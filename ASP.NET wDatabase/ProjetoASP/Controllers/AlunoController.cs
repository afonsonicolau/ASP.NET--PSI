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
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult CriaAluno()
        {
            try
            {
                if (Session["Login"] == null) return RedirectToAction("Login", "Registo");

                return View();
            }
            catch (Exception ex)
            {
                return View("Erro", new HandleErrorInfo(ex, "Aluno",
                "CriaAluno"));

            }          
        }

        [HttpPost]
        public ActionResult CriaAluno(Aluno aluno)
        {
            try
            {
                if (Session["Login"] == null) return RedirectToAction("Login", "Registo");

                if (ModelState.IsValid)
                {
                    string ImagemNome = Path.GetFileNameWithoutExtension(aluno.Imagem.FileName);
                    string ImagemExt = Path.GetExtension(aluno.Imagem.FileName);
                    ImagemNome = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + ImagemNome.Trim() + ImagemExt;
                    aluno.ImgPath = @"\Content\Imagens\" + ImagemNome;
                    aluno.Imagem.SaveAs(ControllerContext.HttpContext.Server.MapPath(aluno.ImgPath));

                    ConexaoDB conn = new ConexaoDB("localhost", 3307, "root", "root", "formacao");

                    using (MySqlConnection conexao = conn.ObterConexao())
                    {
                        if (conexao != null)
                        {
                            string stm = "insert into alunos values(0, @primeiroNome, @ultimoNome, @morada, @genero, @dataNasc, @ano, @foto)";
                            using (MySqlCommand cmd = new MySqlCommand(stm, conexao))
                            {
                                cmd.Parameters.AddWithValue("@primeiroNome", aluno.PriNome);
                                cmd.Parameters.AddWithValue("@ultimoNome", aluno.UltNome);
                                cmd.Parameters.AddWithValue("@morada", aluno.Morada);
                                cmd.Parameters.AddWithValue("@genero", aluno.Genero.ToString());
                                cmd.Parameters.AddWithValue("@dataNasc", aluno.DataNasc);
                                cmd.Parameters.AddWithValue("@ano", aluno.AnoEscolaridade);
                                cmd.Parameters.AddWithValue("@foto", aluno.ImgPath);

                                int nRegistos = cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                return RedirectToAction("ListarAluno");
            }
            catch (Exception ex)
            {
                return View("Erro", new HandleErrorInfo(ex, "Aluno",
                "CriaAluno"));
            }
        }

        public ActionResult ListarAluno()
        {
            try
            {
                if (Session["Login"] == null) return RedirectToAction("Login", "Registo");

                ConexaoDB sConnection = new ConexaoDB("localhost", 3307, "root", "root", "formacao");

                // Save the regists to a list that will pass on to the view
                List<Aluno> lista = new List<Aluno>();

                using (MySqlConnection sqlConnection = sConnection.ObterConexao())
                {
                    if (sqlConnection != null)
                    {
                        using (MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM alunos", sqlConnection))
                        {
                            // Executes the Query and saves it to the MySqlDataReader object
                            using (MySqlDataReader sqlReader = sqlCommand.ExecuteReader())
                            {
                                while (sqlReader.Read())
                                {
                                    // Adds to the list
                                    lista.Add(new Aluno()
                                    {
                                        Naluno = sqlReader.GetInt32("idAlunos"),
                                        PriNome = sqlReader.GetString("nomeAlunos"),
                                        UltNome = sqlReader.GetString("ultimoNomeAlunos"),
                                        Morada = sqlReader.GetString("moradaAlunos"),
                                        Genero = sqlReader.GetString("generoAlunos") == "Masculino" ? Genero.Masculino : Genero.Feminino,
                                        DataNasc = sqlReader.GetDateTime("dataNascAlunos"),
                                        AnoEscolaridade = sqlReader.GetInt16("anoEscolaridadeAlunos"),
                                    });
                                }
                            }
                        }
                    }
                    return View(lista);
                }
            }
            catch (Exception ex)
            {
                return View("Erro", new HandleErrorInfo(ex, "Aluno",
                "ListarAluno"));
            }
        }

        public ActionResult DetalheAluno(int id)
        {
            try
            {
                if (Session["Login"] == null) return RedirectToAction("Login", "Registo");

                // Copy the "Listar Aluno" code
                ConexaoDB sConnection = new ConexaoDB("localhost", 3307, "root", "root", "formacao");

                // Creation of a variable "Aluno" type
                Aluno aluno = null;

                using (MySqlConnection sqlConnection = sConnection.ObterConexao())
                {
                    if (sqlConnection != null)
                    {
                        using (MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM alunos WHERE idAlunos=@idAlunos", sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@idAlunos", id);

                            // Executes the Query and saves it to the MySqlDataReader object
                            using (MySqlDataReader sqlReader = sqlCommand.ExecuteReader())
                            {
                                if (sqlReader.Read())
                                {
                                    // Adds to the list
                                    aluno = new Aluno()
                                    {
                                        Naluno = sqlReader.GetInt32("idAlunos"),
                                        PriNome = sqlReader.GetString("nomeAlunos"),
                                        UltNome = sqlReader.GetString("ultimoNomeAlunos"),
                                        Morada = sqlReader.GetString("moradaAlunos"),
                                        Genero = sqlReader.GetString("generoAlunos") == "Masculino" ? Genero.Masculino : Genero.Feminino,
                                        DataNasc = sqlReader.GetDateTime("dataNascAlunos"),
                                        AnoEscolaridade = sqlReader.GetInt16("anoEscolaridadeAlunos"),
                                        ImgPath = sqlReader.GetString("fotoAlunos"),
                                    };
                                    return View(aluno);
                                }
                            }
                        }
                    }
                }
                return RedirectToAction("ListarAluno");
            }
            catch (Exception ex)
            {
                return View("Erro", new HandleErrorInfo(ex, "Aluno",
                "DetalheAluno"));
            }         
        }

        [HttpPost]  
        public ActionResult EditarAluno(Aluno aluno)
        {
            try
            {
                if (Session["Login"] == null) return RedirectToAction("Login", "Registo");

                if (ModelState.IsValid)
                {
                    // Verifys if user changed the image
                    bool img = false;

                    if (aluno.Imagem != null)
                    {
                        // Uploads image
                        string ImagemNome = Path.GetFileNameWithoutExtension(aluno.Imagem.FileName);
                        string ImagemExt = Path.GetExtension(aluno.Imagem.FileName);

                        // Creates unique name for image
                        ImagemNome = DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + ImagemNome.Trim() + ImagemExt;

                        // Adds to "Content" folder
                        aluno.ImgPath = @"\Content\Imagens\" + ImagemNome;

                        // Saves image to drive
                        aluno.Imagem.SaveAs(ControllerContext.HttpContext.Server.MapPath(aluno.ImgPath));

                        img = true;

                    }

                    // Opens connection to database
                    ConexaoDB connection = new ConexaoDB("localhost", 3307, "root", "root", "formacao");

                    using (MySqlConnection sqlConnection = connection.ObterConexao())
                    {
                        if (sqlConnection != null)
                        {
                            string sFoto = (img) ? ",fotoAlunos=@foto" : ""; // If "img" = true it uploads the image
                            string stm = "UPDATE alunos SET nomeAlunos=@primeiroNome, ultimoNomeAlunos=@ultimoNome, moradaAlunos=@morada, generoAlunos=@genero, dataNascAlunos=@dataNasc, anoEscolaridadeAlunos=@ano" + sFoto + " WHERE idAlunos=@idAlunos";

                            using (MySqlCommand sqlCommand = new MySqlCommand(stm, sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@idAlunos", aluno.Naluno);
                                sqlCommand.Parameters.AddWithValue("@primeiroNome", aluno.PriNome);
                                sqlCommand.Parameters.AddWithValue("@ultimoNome", aluno.UltNome);
                                sqlCommand.Parameters.AddWithValue("@morada", aluno.Morada);
                                sqlCommand.Parameters.AddWithValue("@genero", aluno.Genero);
                                sqlCommand.Parameters.AddWithValue("@dataNasc", aluno.DataNasc);
                                sqlCommand.Parameters.AddWithValue("@ano", aluno.AnoEscolaridade);

                                if (img)
                                {
                                    sqlCommand.Parameters.AddWithValue("@foto", aluno.ImgPath);
                                }

                                int nRegistos = sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                return RedirectToAction("ListarAluno");
            }
            catch (Exception ex)
            {
                return View("Erro", new HandleErrorInfo(ex, "Aluno",
                "EditarAluno"));
            }            
        }
        public ActionResult EditarAluno(int? id)
        {
            try
            {
                if (Session["Login"] == null) return RedirectToAction("Login", "Registo");

                // Copy the "Listar Aluno" code
                ConexaoDB sConnection = new ConexaoDB("localhost", 3307, "root", "root", "formacao");

                // Creation of a variable "Aluno" type
                Aluno aluno = null;

                using (MySqlConnection sqlConnection = sConnection.ObterConexao())
                {
                    if (sqlConnection != null)
                    {
                        using (MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM alunos WHERE idAlunos=@idAlunos", sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@idAlunos", id);

                            // Executes the Query and saves it to the MySqlDataReader object
                            using (MySqlDataReader sqlReader = sqlCommand.ExecuteReader())
                            {
                                if (sqlReader.Read())
                                {
                                    // Adds to the list
                                    aluno = new Aluno()
                                    {
                                        Naluno = sqlReader.GetInt32("idAlunos"),
                                        PriNome = sqlReader.GetString("nomeAlunos"),
                                        UltNome = sqlReader.GetString("ultimoNomeAlunos"),
                                        Morada = sqlReader.GetString("moradaAlunos"),
                                        Genero = sqlReader.GetString("generoAlunos") == "Masculino" ? Genero.Masculino : Genero.Feminino,
                                        DataNasc = sqlReader.GetDateTime("dataNascAlunos"),
                                        AnoEscolaridade = sqlReader.GetInt16("anoEscolaridadeAlunos"),
                                        ImgPath = sqlReader.GetString("fotoAlunos"),
                                    };
                                    return View(aluno);
                                }
                            }
                        }
                    }
                }
                return RedirectToAction("ListarAluno");
            }
            catch (Exception ex)
            {
                return View("Erro", new HandleErrorInfo(ex, "Aluno",
                "EditarAluno"));
            }     
        }

        public ActionResult EliminarAluno(int? id)
        {
            try
            {
                if (Session["Login"] == null) return RedirectToAction("Login", "Registo");

                // Copy the "Listar Aluno" code
                ConexaoDB sConnection = new ConexaoDB("localhost", 3307, "root", "root", "formacao");

                // Creation of a variable "Aluno" type
                Aluno aluno = null;

                using (MySqlConnection sqlConnection = sConnection.ObterConexao())
                {
                    if (sqlConnection != null)
                    {
                        using (MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM alunos WHERE idAlunos=@idAlunos", sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@idAlunos", id);

                            // Executes the Query and saves it to the MySqlDataReader object
                            using (MySqlDataReader sqlReader = sqlCommand.ExecuteReader())
                            {
                                if (sqlReader.Read())
                                {
                                    // Adds to the list
                                    aluno = new Aluno()
                                    {
                                        Naluno = sqlReader.GetInt32("idAlunos"),
                                        PriNome = sqlReader.GetString("nomeAlunos"),
                                        UltNome = sqlReader.GetString("ultimoNomeAlunos"),
                                        Morada = sqlReader.GetString("moradaAlunos"),
                                        Genero = sqlReader.GetString("generoAlunos") == "Masculino" ? Genero.Masculino : Genero.Feminino,
                                        DataNasc = sqlReader.GetDateTime("dataNascAlunos"),
                                        AnoEscolaridade = sqlReader.GetInt16("anoEscolaridadeAlunos"),
                                        ImgPath = sqlReader.GetString("fotoAlunos"),
                                    };

                                    TempData["ImagePath"] = aluno.ImgPath;
                                    return View(aluno);
                                }
                            }
                        }
                    }
                }
                return RedirectToAction("ListarAluno");
            }
            catch (Exception ex)
            {
                return View("Erro", new HandleErrorInfo(ex, "Aluno",
                "EliminarAluno"));
            }           
        }

        [HttpPost, ActionName("EliminarAluno")]
        public ActionResult EliminaAlunoConfirmacao(int? id)
        {
            try
            {
                if (Session["Login"] == null) return RedirectToAction("Login", "Registo");

                ConexaoDB connection = new ConexaoDB("localhost", 3307, "root", "root", "formacao");

                using (MySqlConnection sqlConnection = connection.ObterConexao())
                {
                    if (sqlConnection != null)
                    {
                        string sDeleteQuery = "DELETE FROM alunos WHERE idAlunos=@idAlunos";

                        using (MySqlCommand sqlCommand = new MySqlCommand(sDeleteQuery, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@idAlunos", id);

                            int iNumeroRegistos = sqlCommand.ExecuteNonQuery();

                            if (iNumeroRegistos == 1)
                            {
                                // Deletes physical registry
                                new FileInfo(ControllerContext.HttpContext.Server.MapPath(TempData["ImagePath"].ToString())).Delete();
                            }
                        }
                    }
                }
                return RedirectToAction("ListarAluno");
            }
            catch (Exception ex)
            {
                return View("Erro", new HandleErrorInfo(ex, "Aluno",
                "EliminarAluno"));
            }           
        }
    }
}