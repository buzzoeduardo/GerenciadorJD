using GerenciadorSJD.Models;
using GerenciadorSJD.Service;
using GerenciadorSJD.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using GerenciadorSJD.Models.ViewModel;

namespace GerenciadorSJD.Controllers
{
    public class PoliciaisController : Controller
    {
        private readonly ServicePolicia _servicepolicia;
        private readonly ServiceProcesso _serviceprocesso;

        public PoliciaisController(ServicePolicia servicepolicia, ServiceProcesso serviceprocesso)
        {
            _servicepolicia = servicepolicia;
            _serviceprocesso = serviceprocesso;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _servicepolicia.RetornarTodos();
            return View(lista);
        }

        public async Task<IActionResult> BuscaSimples(string re)
        {
            var resultado = await _servicepolicia.PesquisarReNomeAsync(re);
            return View(resultado);
        }

        public async Task<IActionResult> Create()
        {           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Policia pm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _servicepolicia.InserirAsync(pm);
                    return RedirectToAction(nameof(Index));
                }

                catch (ExcNotFound e)
                {
                    return RedirectToAction(nameof(Error), new { mensagem = e.Message });
                }
            }
            return View(pm);            
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id não fornecido" });
            }
            var obj = await _servicepolicia.RetornarPolicialIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id inexistente" });
            }

            List<Processo> processo = await _serviceprocesso.RetornarTodosAsync();
            ModeloPolicial viewModelo = new ModeloPolicial { Policiais = obj, Processos = processo };
            return View(viewModelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Policia pm)
        {
            if (!ModelState.IsValid)
            {
                var processos = await _serviceprocesso.RetornarTodosAsync();
                var novaView = new ModeloPolicial { Policiais = pm, Processos = processos };
                return View(novaView);
            }
            if (id != pm.Id)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id não corresponde." });
            }
            try
            {
                await _servicepolicia.EditarAsync(pm);
                return RedirectToAction(nameof(Index));
            }
            catch (ExcNotFound e)
            {
                return RedirectToAction(nameof(Error), new { mensagem = e.Message });
            }
            catch (ExcBd e)
            {
                return RedirectToAction(nameof(Error), new { mensagem = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id não fornecido" });
            }

            var obj = await _servicepolicia.RetornarPolicialIdAsync(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Cadastro inexistente" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id não fornecido" });
            }

            var obj = await _servicepolicia.RetornarPolicialIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Cadastro inexistente" });
            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _servicepolicia.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ExcIntegridade e)
            {
                return RedirectToAction(nameof(Error), new { mensagem = e.Message });
            }
        }



        public IActionResult Error(string mensagem)
        {
            var modeloErro = new ErrorViewModel
            {
                Message = mensagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(modeloErro);
        }
               
    }
}
