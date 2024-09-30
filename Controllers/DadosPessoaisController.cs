using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HortifrutiMvc.Data;
using HortifrutiMvc.Models;
using HortifrutiMvc.ViewModels;
using HortifrutiMvc.DTOs;
using HortifrutiMvc.Services;

namespace HortifrutiMvc.Controllers
{
    public class DadosPessoaisController : Controller
    {
        private readonly DadosPessoaisService _dadosPessoaisService;

        public DadosPessoaisController(DadosPessoaisService dadosPessoaisService)
        {
            _dadosPessoaisService = dadosPessoaisService;
        }

        // GET: DadosPessoais
        public async Task<IActionResult> Index()
        {
            var dadosPessoais = await _dadosPessoaisService.GetAllAsync();
            var dadosPessoaisViewModels = dadosPessoais.Select(dp => new DadosPessoaisViewModel
            {
                Id = dp.Id,
                Email = dp.Email,
                Telefone = dp.Telefone,
                Endereco = dp.Endereco
            }).ToList();

            return View(dadosPessoaisViewModels);
        }

        // GET: DadosPessoais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _dadosPessoaisService.GetByIdAsync(id.Value);
            if (dadosPessoais == null)
            {
                return NotFound();
            }

            var viewModel = new DadosPessoaisViewModel
            {
                Id = dadosPessoais.Id,
                Email = dadosPessoais.Email,
                Telefone = dadosPessoais.Telefone,
                Endereco = dadosPessoais.Endereco
            };

            return View(viewModel);
        }

        // GET: DadosPessoais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DadosPessoais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DadosPessoaisViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dadosPessoaisDTO = new DadosPessoaisDTO
                {
                    Email = viewModel.Email,
                    Telefone = viewModel.Telefone,
                    Endereco = viewModel.Endereco
                };

                await _dadosPessoaisService.AddAsync(dadosPessoaisDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: DadosPessoais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _dadosPessoaisService.GetByIdAsync(id.Value);
            if (dadosPessoais == null)
            {
                return NotFound();
            }

            var viewModel = new DadosPessoaisViewModel
            {
                Id = dadosPessoais.Id,
                Email = dadosPessoais.Email,
                Telefone = dadosPessoais.Telefone,
                Endereco = dadosPessoais.Endereco
            };

            return View(viewModel);
        }

        // POST: DadosPessoais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DadosPessoaisViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dadosPessoaisDTO = new DadosPessoaisDTO
                {
                    Id = viewModel.Id,
                    Email = viewModel.Email,
                    Telefone = viewModel.Telefone,
                    Endereco = viewModel.Endereco
                };

                await _dadosPessoaisService.UpdateAsync(dadosPessoaisDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: DadosPessoais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _dadosPessoaisService.GetByIdAsync(id.Value);
            if (dadosPessoais == null)
            {
                return NotFound();
            }

            var viewModel = new DadosPessoaisViewModel
            {
                Id = dadosPessoais.Id,
                Email = dadosPessoais.Email,
                Telefone = dadosPessoais.Telefone,
                Endereco = dadosPessoais.Endereco
            };

            return View(viewModel);
        }

        // POST: DadosPessoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _dadosPessoaisService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DadosPessoaisExists(int id)
        {
            return _dadosPessoaisService.GetByIdAsync(id) != null;
        }
    }
}

