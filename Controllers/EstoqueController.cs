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
   public class EstoqueController : Controller
    {
        private readonly EstoqueService _estoqueService;

        public EstoqueController(EstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        // GET: Estoque
        public async Task<IActionResult> Index()
        {
            var estoques = await _estoqueService.GetAllAsync();
            var estoqueViewModels = estoques.Select(e => new EstoqueViewModel
            {
                Id = e.Id,
                ProdutoId = e.ProdutoId,
                Quantidade = e.Quantidade,
                DataAtualizacao = e.DataAtualizacao
            }).ToList();

            return View(estoqueViewModels);
        }

        // GET: Estoque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _estoqueService.GetByIdAsync(id.Value);
            if (estoque == null)
            {
                return NotFound();
            }

            var viewModel = new EstoqueViewModel
            {
                Id = estoque.Id,
                ProdutoId = estoque.ProdutoId,
                Quantidade = estoque.Quantidade,
                DataAtualizacao = estoque.DataAtualizacao
            };

            return View(viewModel);
        }

        // GET: Estoque/Create
        public async Task<IActionResult> Create()
        {
            var produtos = await _estoqueService.GetProdutosAsync();
            ViewData["ProdutoId"] = new SelectList(produtos, "Id", "Nome");
            return View();
        }

        // POST: Estoque/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstoqueViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var estoqueDTO = new EstoqueDTO
                {
                    ProdutoId = viewModel.ProdutoId,
                    Quantidade = viewModel.Quantidade,
                    DataAtualizacao = viewModel.DataAtualizacao
                };

                await _estoqueService.AddAsync(estoqueDTO);
                return RedirectToAction(nameof(Index));
            }
            var produtos = await _estoqueService.GetProdutosAsync();
            ViewData["ProdutoId"] = new SelectList(produtos, "Id", "Nome", viewModel.ProdutoId);
            return View(viewModel);
        }

        // GET: Estoque/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _estoqueService.GetByIdAsync(id.Value);
            if (estoque == null)
            {
                return NotFound();
            }

            var viewModel = new EstoqueViewModel
            {
                Id = estoque.Id,
                ProdutoId = estoque.ProdutoId,
                Quantidade = estoque.Quantidade,
                DataAtualizacao = estoque.DataAtualizacao
            };

            var produtos = await _estoqueService.GetProdutosAsync();
            ViewData["ProdutoId"] = new SelectList(produtos, "Id", "Nome", viewModel.ProdutoId);
            return View(viewModel);
        }

        // POST: Estoque/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EstoqueViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var estoqueDTO = new EstoqueDTO
                {
                    Id = viewModel.Id,
                    ProdutoId = viewModel.ProdutoId,
                    Quantidade = viewModel.Quantidade,
                    DataAtualizacao = viewModel.DataAtualizacao
                };

                await _estoqueService.UpdateAsync(estoqueDTO);
                return RedirectToAction(nameof(Index));
            }
            var produtos = await _estoqueService.GetProdutosAsync();
            ViewData["ProdutoId"] = new SelectList(produtos, "Id", "Nome", viewModel.ProdutoId);
            return View(viewModel);
        }

        // GET: Estoque/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estoque = await _estoqueService.GetByIdAsync(id.Value);
            if (estoque == null)
            {
                return NotFound();
            }

            var viewModel = new EstoqueViewModel
            {
                Id = estoque.Id,
                ProdutoId = estoque.ProdutoId,
                Quantidade = estoque.Quantidade,
                DataAtualizacao = estoque.DataAtualizacao
            };

            return View(viewModel);
        }

        // POST: Estoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _estoqueService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EstoqueExists(int id)
        {
            return await _estoqueService.ExistsAsync(id);
        }
    }
}
