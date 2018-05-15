using MyPark.Model.DataBase;
using MyPark.Model.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPark.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var users = DbFactory.Instance.UserRepository.FindAll();

            if(users.Count <= 0)
            {
                //Usuario deve ser salvo primeiro pois ele é o detendor da chave primária
                //var user = new User()
                //{
                //    Login = "admin",
                //    Senha = "admin",
                //};

                //user = DbFactory.Instance.UserRepository.Save(user);

                //Fazendo o relacionamento em cascata
                var operado = new operador()
                {
                    DtAdmissao = DateTime.Now,
                    Inativo = false,
                    Nome = "Administrador",
                    //salvado o usuário e o operador irá buscar o id do usuário pois foi programador par salvar em cascata
                    Usuario = new User()
                    {
                        Login = "admin",
                        Senha = "admin",
                    }
                };

                DbFactory.Instance.OperadorRepository.Save(operado);
            }

            var estadias = DbFactory.Instance.EstadiaRepository.FindAll();

            return View(estadias);
        }

        // GET: Nova Entrada
        public PartialViewResult NovaEntrada()
        {
            var tipos = DbFactory.Instance.TipoVeiculoRepository.FindAll();
            ViewBag.Tipos = new SelectList(tipos, "Id", "Titulo");
            return PartialView("_NovaEstadia", new estadia());
        }

        public PartialViewResult CriarEstadia(estadia estadia, Guid idTipoVeiculo)
        {
            var tipo = DbFactory.Instance.TipoVeiculoRepository.FindFirstById(idTipoVeiculo);
            estadia.DtEntrada = DateTime.Now;
            estadia.Veiculo.Tipo = tipo;

            DbFactory.Instance.EstadiaRepository.Save(estadia);

            var estadias = DbFactory.Instance.EstadiaRepository.FindAll();

            return PartialView("_TblEstadias", estadias);
        }
    }
}