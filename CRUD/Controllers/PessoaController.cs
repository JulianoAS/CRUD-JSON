using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exemplos.Models;
using Layers.DTO;
using Layers.BLL;


namespace Exemplos.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoas
        public ActionResult Index()
        {


            return View(LisPessoas());
        }


        public ActionResult Incluir()
        {

            return View();

        }

        [HttpPost]
        public JsonResult Incluir(PessoaModel model)
        {


            PessoaBll bo = new PessoaBll();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                if (bo.CpfValidar(model.CPF))
                {
                    model.Id = bo.Incluir(new Pessoa()
                    {

                        Nome = model.Nome,
                        Sobrenome = model.Sobrenome,
                        CPF = model.CPF,
                        RG = model.RG,
                        CEP = model.CEP,
                        Cidade = model.Cidade,
                        Estado = model.Estado,
                        Logradouro = model.Logradouro,
                        Email = model.Email,
                        Telefone = model.Telefone,
                        Celular = model.Celular

                    });
                    return Json("Cadastro efetudado com Sucesso.");
                }

                else
                {
                    Response.StatusCode = 400;
                    return Json("Cadastro não efetuado, cpf inválido.");
                }


            }
        }


        [HttpPost]
        public JsonResult Deletar(long id)
        {
            PessoaBll bo = new PessoaBll();
            bo.Deletar(id);
            return Json("Sucesso ao excluir o registro.");
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            PessoaBll bo = new PessoaBll();
            PessoaModel model = null;
            Pessoa pessoa = bo.LerPessoa(id);

            if (pessoa != null)
            {
                model = new PessoaModel()
                {
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    CPF = pessoa.CPF,
                    RG = pessoa.RG,
                    CEP = pessoa.CEP,
                    Logradouro = pessoa.Logradouro,
                    Cidade = pessoa.Cidade,
                    Estado = pessoa.Estado,
                    Celular = pessoa.Celular,
                    Telefone = pessoa.Telefone,
                    Email = pessoa.Email

                };
            }
            return View(model);
        }



        [HttpPost]
        public JsonResult Alterar(PessoaModel model)
        {

            PessoaBll bo = new PessoaBll();

            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {

                bo.Atualizar(new Pessoa()
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Sobrenome = model.Sobrenome,
                    CPF = model.CPF,
                    RG = model.RG,
                    CEP = model.CEP,
                    Cidade = model.Cidade,
                    Estado = model.Estado,
                    Logradouro = model.Logradouro,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    Celular = model.Celular
                });

                return Json("Cadastro atualizado com Sucesso.");
            }

        }

        public List<PessoaModel> LisPessoas()
        {

            PessoaBll bo = new PessoaBll();

            List<PessoaModel> ListPessoas = new List<PessoaModel>();

            foreach (var item in bo.ListPessoa())
            {

                ListPessoas.Add(new PessoaModel()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Sobrenome = item.Sobrenome,
                    CPF = item.CPF,
                    RG = item.RG,
                    CEP = item.CEP,
                    Cidade = item.Cidade,
                    Estado = item.Estado,
                    Logradouro = item.Logradouro,
                    Email = item.Email,
                    Telefone = item.Telefone,
                    Celular = item.Celular
                });


            }

            return ListPessoas;


        }

    }
}















