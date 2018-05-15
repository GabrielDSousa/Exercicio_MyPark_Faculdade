using MyPark.Model.DataBase;
using MyPark.Model.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPark.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult TipoVeiculo()
        {
            var tipoveiculos = DbFactory.Instance.TipoVeiculoRepository.FindAll();

            return View(tipoveiculos);
        }

        public ActionResult AddTipoVeiculo()
        {
            return View(new tipoveiculo());
        }

        public ActionResult Plano()
        {
            var planos = DbFactory.Instance.PlanoRepository.FindAll();

            return View(planos);
        }

        public ActionResult AddPlano()
        {
            return View(new plano());
        }

        public PartialViewResult GravarTipoVeiculo(tipoveiculo tipo)
        {
            DbFactory.Instance.TipoVeiculoRepository.SaveOrUpdate(tipo);

            var tipoveiculos = DbFactory.Instance.TipoVeiculoRepository.FindAll();

            return PartialView("_TabelaTipoVeiculo", tipoveiculos);
        }

        public PartialViewResult ExibirAddTipoVeiculo()
        {
            return PartialView("_AddTipoVeiculo", new tipoveiculo());
        }

        public PartialViewResult ExibirAddPlano()
        {
            return PartialView("_AddPlano", new plano());
        }

        public PartialViewResult GravarPlano(plano plano)
        {
            DbFactory.Instance.PlanoRepository.SaveOrUpdate(plano);

            var planos = DbFactory.Instance.PlanoRepository.FindAll();

            return PartialView("_TabelaPlano", planos);
        }

        public PartialViewResult ApagarPlano(Guid id)
        {
            DbFactory.Instance.PlanoRepository.FindFirstById(id);

            var planos = DbFactory.Instance.PlanoRepository.FindAll();

            return PartialView("_TabelaPlano", planos);
        }
    }
}