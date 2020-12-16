using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using System.IO;
using MySql.Data.MySqlClient;

namespace WebMVC.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult CriaAluno()
        {
            return View();
        }

        // Method POST
        [HttpPost]

        public ActionResult CriaAluno(aluno aluno)
        {
            // Verifys errors when form submits
            if(ModelState.IsValid)
            {
                // Image upload
                string sImagemNome = Path.GetFileNameWithoutExtension(aluno.imagem.FileName);
                string sImagemExt = Path.GetExtension(aluno.imagem.FileName);

                // Creates a unique name for the image, so it doesn't repeat
                sImagemNome = DateTime.Now.ToString("yyyyMMdHHmmss") + "-" + sImagemNome.Trim() + sImagemExt;

                // Adds images to "Content" folder / @ is used so that you don't have to put full path
                aluno.ImgPath = @"\Content\Imagens\" + sImagemNome;

                aluno.imagem.SaveAs(ControllerContext.HttpContext.Server.MapPath(aluno.ImgPath));
                // Opens connection to database
                conexaoDB sqlConnection = new conexaoDB("localhost", 3307, "formacao", "root", "root");

                using(MySqlConnection Connection = sqlConnection.obterConexao())
                {                 
                    if (Connection != null)
                    {
                        string sInsertQuery = "INSERT INTO alunos VALUES(0, @nomeAlunos, @ultimoNomeAlunos, @moradaAlunos, @generoAlunos, @dataNascAlunos, @anoEscolaridadeAlunos, @fotoAlunos)";

                        using (MySqlCommand sqlCommand = new MySqlCommand(sInsertQuery, Connection))
                        {
                            // Associate values to labels
                            sqlCommand.Parameters.AddWithValue("@nomeAlunos", aluno.PriNome);
                            sqlCommand.Parameters.AddWithValue("@ultimoNomeAlunos", aluno.UltNome);
                            sqlCommand.Parameters.AddWithValue("@moradaAlunos", aluno.Morada);
                            sqlCommand.Parameters.AddWithValue("@generoAlunos", aluno.Genero);
                            sqlCommand.Parameters.AddWithValue("@dataNascAlunos", aluno.DataNasc);
                            sqlCommand.Parameters.AddWithValue("@anoEscolaridadeAlunos", aluno.AnoEscolaridade);
                            sqlCommand.Parameters.AddWithValue("@fotoAlunos", aluno.ImgPath);

                            // Submit to database
                            int iNumRegistos = sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            return RedirectToAction("CriaAluno");
        }
    }
}