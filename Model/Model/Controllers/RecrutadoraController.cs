﻿using Model.Models;
using Model.Repositório;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Model.Controllers
{
    public class RecrutadoraController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            List<Alunos> alunos = new AlunosRepositorio().ObterTodos();
            ViewBag.Alunos = alunos;
            ViewBag.TituloPaginas = "Alunos";
            return View();
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            ViewBag.TituloPaginas = "Alunos - Cadastro";
            ViewBag.Aluno = new Alunos();
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Alunos aluno = new AlunosRepositorio().ObterPeloID(id);
            ViewBag.Aluno = aluno;
            ViewBag.TituloPaginas = "Alunos - Editar";
            return View();
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            bool apagado = new AlunosRepositorio().Excluir(id);
            ViewBag.TituloPagina = "Aluno - Apagar";
            return null;
        }

        [HttpPost]
        public ActionResult Store(Alunos aluno)
        {
            if (ModelState.IsValid)
            {
                
                int identificador = new AlunosRepositorio().Cadastrar(aluno);
                return RedirectToAction("Editar", new { id = identificador });

            }
            ViewBag.aluno = aluno;
            return View("Cadastro");
        }

        [HttpPost]
        public ActionResult Update(Alunos aluno)
        {
            bool alterado = new AlunosRepositorio().Alterar(aluno);
            return null;
        }

        
    }
}