using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;
using P2_2020CC605.Models;

namespace P2_2020CC605.Controllers
{
    public class casosreportadosController : Controller
    {
        private readonly covidDBContext _covidContext;

        public casosreportadosController(covidDBContext covidContext)
        {
            _covidContext = covidContext;
        }

        public IActionResult Index()
        {
            var listaDeDepartamentos = (from m in _covidContext.departamentos
                                        select m).ToList();
            ViewData["listaDeDepartamentos"] = new SelectList(listaDeDepartamentos, "id_departamento", "departamento");

           

            var listaDeGeneros = (from m in _covidContext.generos
                                        select m).ToList();
            ViewData["listaDeGeneros"] = new SelectList(listaDeGeneros, "id_genero", "genero");



            var listadoCasosreportados = (from e in _covidContext.casosreportados
                                          join m in _covidContext.departamentos on e.id_departamento equals m.id_departamento
                                          join t in _covidContext.generos on e.id_genero equals t.id_genero
                                          select new
                                          {
                                                id_departamento = e.id_departamento,
                                                departamento = m.departamento,
                                                id_genero = e.id_genero,
                                                genero = t.genero,
                                                confirmados = e.confirmados,
                                                recuperados = e.recuperados,
                                                fallecidos = e.fallecidos
                                          }).ToList();

            ViewData["listadoCasosreportados"] = listadoCasosreportados;

            return View();



            

        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("confirmados,recuperados,fallecidos,id_departamento,id_genero")] casosreportados casoNuevo)
        {
            try
            {
                _covidContext.casosreportados.Add(casoNuevo);
                _covidContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        } 


    }
}
