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
    public class FuncionarioController(FuncionarioService funcionarioService) : Controller
    {
        private readonly FuncionarioService _funcionarioService = funcionarioService;

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            var funcionarios = await _funcionarioService.GetAllAsync();
            return View(funcionarios);
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _funcionarioService.GetByIdAsync(id.Value);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public async Task<IActionResult> Create()
        {
            var dadosPessoais = await _funcionarioService.GetAllDadosPessoaisAsync();
            ViewData["DadosPessoaisId"] = new SelectList(dadosPessoais, "Id", "Id");
            return View();
        }

        // POST: Funcionario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cargo,DadosPessoaisId")] FuncionarioDTO funcionarioDto)
        {
            if (ModelState.IsValid)
            {
                await _funcionarioService.AddAsync(funcionarioDto);
                return RedirectToAction(nameof(Index));
            }
            var dadosPessoais = await _funcionarioService.GetAllDadosPessoaisAsync();
            ViewData["DadosPessoaisId"] = new SelectList(dadosPessoais, "Id", "Id", funcionarioDto.DadosPessoaisId);
            return View(funcionarioDto);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _funcionarioService.GetByIdAsync(id.Value);
            if (funcionario == null)
            {
                return NotFound();
            }
            var dadosPessoais = await _funcionarioService.GetAllDadosPessoaisAsync();
            ViewData["DadosPessoaisId"] = new SelectList(dadosPessoais, "Id", "Id", funcionario.DadosPessoaisId);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cargo,DadosPessoaisId")] FuncionarioDTO funcionarioDto)
        {
            if (id != funcionarioDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _funcionarioService.UpdateAsync(funcionarioDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FuncionarioExists(funcionarioDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var dadosPessoais = await _funcionarioService.GetAllDadosPessoaisAsync();
            ViewData["DadosPessoaisId"] = new SelectList(dadosPessoais, "Id", "Id", funcionarioDto.DadosPessoaisId);
            return View(funcionarioDto);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _funcionarioService.GetByIdAsync(id.Value);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _funcionarioService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> FuncionarioExists(int id)
        {
            return await _funcionarioService.GetByIdAsync(id) != null;
        }
    }
}
