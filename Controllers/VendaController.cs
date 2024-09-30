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
    public class VendaController(VendaService vendaService, ClienteService clienteService) : Controller
    {
        private readonly VendaService _vendaService = vendaService;
        private readonly ClienteService _clienteService = clienteService;

        // GET: Venda
        public async Task<IActionResult> Index()
        {
            var vendas = await _vendaService.GetAllAsync();
            return View(vendas);
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _vendaService.GetByIdAsync(id.Value);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Venda/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ClienteId"] = new SelectList(await _clienteService.GetAllAsync(), "Id", "Nome");
            return View();
        }

        // POST: Venda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,Data,Total")] VendaDTO vendaDto)
        {
            if (ModelState.IsValid)
            {
                await _vendaService.AddAsync(vendaDto);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(await _clienteService.GetAllAsync(), "Id", "Nome", vendaDto.ClienteId);
            return View(vendaDto);
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _vendaService.GetByIdAsync(id.Value);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(await _clienteService.GetAllAsync(), "Id", "Nome", venda.ClienteId);
            return View(venda);
        }

        // POST: Venda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,Data,Total")] VendaDTO vendaDto)
        {
            if (id != vendaDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vendaService.UpdateAsync(vendaDto);
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(await _clienteService.GetAllAsync(), "Id", "Nome", vendaDto.ClienteId);
            return View(vendaDto);
        }

        // GET: Venda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _vendaService.GetByIdAsync(id.Value);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vendaService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> VendaExists(int id)
        {
            return await _vendaService.ExistsAsync(id);
        }
    }
}
