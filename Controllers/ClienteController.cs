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
    public class ClienteController(ClienteService clienteService) : Controller
    {
        private readonly ClienteService _clienteService = clienteService;

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.GetAllAsync();
            var clienteViewModels = clientes.Select(c => new ClienteViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Cpf = c.Cpf,
                DadosPessoaisId = c.DadosPessoaisId
            }).ToList();

            return View(clienteViewModels);
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.GetByIdAsync(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            var viewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DadosPessoaisId = cliente.DadosPessoaisId
            };

            return View(viewModel);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDTO = new ClienteDTO
                {
                    Nome = viewModel.Nome,
                    Cpf = viewModel.Cpf,
                    DadosPessoaisId = viewModel.DadosPessoaisId
                };

                await _clienteService.AddAsync(clienteDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.GetByIdAsync(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            var viewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DadosPessoaisId = cliente.DadosPessoaisId
            };

            return View(viewModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var clienteDTO = new ClienteDTO
                {
                    Id = viewModel.Id,
                    Nome = viewModel.Nome,
                    Cpf = viewModel.Cpf,
                    DadosPessoaisId = viewModel.DadosPessoaisId
                };

                await _clienteService.UpdateAsync(clienteDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteService.GetByIdAsync(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            var viewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DadosPessoaisId = cliente.DadosPessoaisId
            };

            return View(viewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clienteService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
