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
    public class ProdutoController(ProdutoService produtoService) : Controller
    {
        private readonly ProdutoService _produtoService = produtoService;

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.GetAllAsync();
            var produtoViewModels = produtos.Select(p => new ProdutoViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                FornecedorId = p.FornecedorId
            }).ToList();

            return View(produtoViewModels);
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.GetByIdAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                FornecedorId = produto.FornecedorId
            };

            return View(viewModel);
        }

        // GET: Produto/Create
        public async Task<IActionResult> Create()
        {
            var fornecedores = await _produtoService.GetFornecedoresAsync();
            ViewData["FornecedorId"] = new SelectList(fornecedores, "Id", "Nome");
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var produtoDTO = new ProdutoDTO
                {
                    Nome = viewModel.Nome,
                    Preco = viewModel.Preco,
                    FornecedorId = viewModel.FornecedorId
                };

                await _produtoService.AddAsync(produtoDTO);
                return RedirectToAction(nameof(Index));
            }
            var fornecedores = await _produtoService.GetFornecedoresAsync();
            ViewData["FornecedorId"] = new SelectList(fornecedores, "Id", "Nome", viewModel.FornecedorId);
            return View(viewModel);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.GetByIdAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                FornecedorId = produto.FornecedorId
            };

            var fornecedores = await _produtoService.GetFornecedoresAsync();
            ViewData["FornecedorId"] = new SelectList(fornecedores, "Id", "Nome", viewModel.FornecedorId);
            return View(viewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var produtoDTO = new ProdutoDTO
                {
                    Id = viewModel.Id,
                    Nome = viewModel.Nome,
                    Preco = viewModel.Preco,
                    FornecedorId = viewModel.FornecedorId
                };

                await _produtoService.UpdateAsync(produtoDTO);
                return RedirectToAction(nameof(Index));
            }
            var fornecedores = await _produtoService.GetFornecedoresAsync();
            ViewData["FornecedorId"] = new SelectList(fornecedores, "Id", "Nome", viewModel.FornecedorId);
            return View(viewModel);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.GetByIdAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            var viewModel = new ProdutoViewModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                FornecedorId = produto.FornecedorId
            };

            return View(viewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produtoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProdutoExists(int id)
        {
            return await _produtoService.ExistsAsync(id);
        }
    }
}
