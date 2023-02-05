using Dapper;
using Microsoft.AspNetCore.Mvc;
using dapperMVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace projetoMVC.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IConfiguration _config;
        public PessoaController(IConfiguration config)
        {
            _config = config;

        }
        public IActionResult Index()
        {
            IDbConnection conn;

            try
            {
                string selecaoQuery = "select * from pessoa";
                conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                conn.Open();
                IEnumerable<Pessoas> listaPessoas = conn.Query<Pessoas>(selecaoQuery).ToList();
                return View(listaPessoas);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                IDbConnection conn;

                try
                {
                    string insercaoQuery = "insert into pessoa (nome_pessoa, telefone_pessoa, cpf_pessoa) values (@nome_pessoa, @telefone_pessoa, @cpf_pessoa)";
                    conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                    conn.Open();
                    conn.Execute(insercaoQuery, pessoas);
                    conn.Close();
                    return RedirectToAction(nameof(Index));
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return View(pessoas);
        }

        [HttpGet]

        public IActionResult Edit(int id_pessoa)
        {
            IDbConnection conn;

            try
            {
                string selecaoQuery = "select * from pessoa where id_pessoa = @id_pessoa";
                conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                conn.Open();
                Pessoas pessoas = conn.Query<Pessoas>(selecaoQuery, new { id_pessoa = id_pessoa }).FirstOrDefault();
                conn.Close();

                return View(pessoas);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public IActionResult Edit(int id_pessoa, Pessoas pessoas)
        {
            if (id_pessoa != pessoas.id_pessoa)
                return NotFound();

            if (ModelState.IsValid)
            {
                IDbConnection conn;

                try
                {
                    string atualizarQuery = "update pessoa set nome_pessoa = @nome_pessoa,telefone_pessoa = @telefone_pessoa, cpf_pessoa = @cpf_pessoa where id_pessoa = @id_pessoa";
                    conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                    conn.Open();
                    conn.Execute(atualizarQuery, pessoas);
                    conn.Close();
                    return RedirectToAction(nameof(Index));
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return View(pessoas);
        }

        [HttpPost]

        public IActionResult Delete(int id_pessoa)
        {
                IDbConnection conn;

                try
                {
                    string excluirQuery = "delete from pessoa where id_pessoa = @id_pessoa";
                    conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                    conn.Open();
                    conn.Execute(excluirQuery, new { id_pessoa  = id_pessoa });
                    conn.Close();
                    return RedirectToAction(nameof(Index));
                }

                catch (Exception ex)
                {
                    throw ex;
                }
        }
    }
}
