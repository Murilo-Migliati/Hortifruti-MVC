using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HortifrutiMvc.Data;
using HortifrutiMvc.Models;
using HortifrutiMvc.DTOs;
using HortifrutiMvc.Services;

namespace HortifrutiMvc.Controllers
{
    public class ItensVendaController(ItensVendaService itensVendaService, ProdutoService produtoService, VendaService vendaService) : Controller
    {
        private readonly ItensVendaService _itensVendaService = itensVendaService;
        private readonly ProdutoService _produtoService = produtoService;
        private readonly VendaService _vendaService = vendaService;

        // GET: ItensVenda
        public async Task<IActionResult> Index()
        {
            var itensVenda = await _itensVendaService.GetAllAsync();
            return View(itensVenda);
        }

        // GET: ItensVenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensVenda = await _itensVendaService.GetByIdAsync(id.Value);
            if (itensVenda == null)
            {
                return NotFound();
            }

            return View(itensVenda);
        }

        // GET: ItensVenda/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ProdutoId"] = new SelectList(await _produtoService.GetAllAsync(), "Id", "Nome");
            ViewData["VendaId"] = new SelectList(await _vendaService.GetAllAsync(), "Id", "Id");
            return View();
        }

        // POST: ItensVenda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VendaId,ProdutoId,Quantidade,Preco")] ItensVendaDTO itensVendaDto)
        {
            if (ModelState.IsValid)
            {
                await _itensVendaService.AddAsync(itensVendaDto);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(await _produtoService.GetAllAsync(), "Id", "Nome", itensVendaDto.ProdutoId);
            ViewData["VendaId"] = new SelectList(await _vendaService.GetAllAsync(), "Id", "Id", itensVendaDto.VendaId);
            return View(itensVendaDto);
        }

        // GET: ItensVenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensVenda = await _itensVendaService.GetByIdAsync(id.Value);
            if (itensVenda == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(await _produtoService.GetAllAsync(), "Id", "Nome", itensVenda.ProdutoId);
            ViewData["VendaId"] = new SelectList(await _vendaService.GetAllAsync(), "Id", "Id", itensVenda.VendaId);
            return View(itensVenda);
        }

        // POST: ItensVenda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VendaId,ProdutoId,Quantidade,Preco")] ItensVendaDTO itensVendaDto)
        {
            if (id != itensVendaDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _itensVendaService.UpdateAsync(itensVendaDto);
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(await _produtoService.GetAllAsync(), "Id", "Nome", itensVendaDto.ProdutoId);
            ViewData["VendaId"] = new SelectList(await _vendaService.GetAllAsync(), "Id", "Id", itensVendaDto.VendaId);
            return View(itensVendaDto);
        }

        private async Task<bool> ItensVendaExists(int id)
        {
            return await _itensVendaService.ExistsAsync(id);
        }
    }
}
