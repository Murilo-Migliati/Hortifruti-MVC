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
    public class FornecedorController(FornecedorService fornecedorService) : Controller
    {
        private readonly FornecedorService _fornecedorService = fornecedorService;

        // GET: Fornecedor
        public async Task<IActionResult> Index()
        {
            var fornecedores = await _fornecedorService.GetAllAsync();
            var fornecedorViewModels = fornecedores.Select(f => new FornecedorViewModel
            {
                Id = f.Id,
                Nome = f.Nome,
                Cnpj = f.Cnpj,
                DadosPessoaisId = f.DadosPessoaisId
            }).ToList();

            return View(fornecedorViewModels);
        }

        // GET: Fornecedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _fornecedorService.GetByIdAsync(id.Value);
            if (fornecedor == null)
            {
                return NotFound();
            }

            var viewModel = new FornecedorViewModel
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Cnpj = fornecedor.Cnpj,
                DadosPessoaisId = fornecedor.DadosPessoaisId
            };

            return View(viewModel);
        }

        // GET: Fornecedor/Create
        public async Task<IActionResult> Create()
        {
            var dadosPessoais = await _fornecedorService.GetDadosPessoaisAsync();
            ViewData["DadosPessoaisId"] = new SelectList(dadosPessoais, "Id", "Nome");
            return View();
        }

        // POST: Fornecedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var fornecedorDTO = new FornecedorDTO
                {
                    Nome = viewModel.Nome,
                    Cnpj = viewModel.Cnpj,
                    DadosPessoaisId = viewModel.DadosPessoaisId
                };

                await _fornecedorService.AddAsync(fornecedorDTO);
                return RedirectToAction(nameof(Index));
            }
            var dadosPessoais = await _fornecedorService.GetDadosPessoaisAsync();
            ViewData["DadosPessoaisId"] = new SelectList(dadosPessoais, "Id", "Nome", viewModel.DadosPessoaisId);
            return View(viewModel);
        }

        // GET: Fornecedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _fornecedorService.GetByIdAsync(id.Value);
            if (fornecedor == null)
            {
                return NotFound();
            }

            var viewModel = new FornecedorViewModel
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Cnpj = fornecedor.Cnpj,
                DadosPessoaisId = fornecedor.DadosPessoaisId
            };

            var dadosPessoais = await _fornecedorService.GetDadosPessoaisAsync();
            ViewData["DadosPessoaisId"] = new SelectList(dadosPessoais, "Id", "Nome", viewModel.DadosPessoaisId);
            return View(viewModel);
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FornecedorViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var fornecedorDTO = new FornecedorDTO
                {
                    Id = viewModel.Id,
                    Nome = viewModel.Nome,
                    Cnpj = viewModel.Cnpj,
                    DadosPessoaisId = viewModel.DadosPessoaisId
                };

                await _fornecedorService.UpdateAsync(fornecedorDTO);
                return RedirectToAction(nameof(Index));
            }
            var dadosPessoais = await _fornecedorService.GetDadosPessoaisAsync();
            ViewData["DadosPessoaisId"] = new SelectList(dadosPessoais, "Id", "Nome", viewModel.DadosPessoaisId);
            return View(viewModel);
        }

        // GET: Fornecedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _fornecedorService.GetByIdAsync(id.Value);
            if (fornecedor == null)
            {
                return NotFound();
            }

            var viewModel = new FornecedorViewModel
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Cnpj = fornecedor.Cnpj,
                DadosPessoaisId = fornecedor.DadosPessoaisId
            };

            return View(viewModel);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _fornecedorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FornecedorExists(int id)
        {
            return await _fornecedorService.ExistsAsync(id);
        }
    }
}
