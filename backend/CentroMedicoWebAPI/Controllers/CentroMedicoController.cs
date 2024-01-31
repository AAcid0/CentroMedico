using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentroMedicoWebAPI.Models;


namespace CentroMedicoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroMedicoController : ControllerBase
    {
        private readonly CentroMedicoContext _dbContext;

        public CentroMedicoController(CentroMedicoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("pacientes")]
        public async Task<IActionResult> ListarPacientes()
        {
            var listaPacientes = await _dbContext.Pacientes.ToListAsync();

            return Ok(listaPacientes);
        }

        [HttpGet]
        [Route("paciente/{id}")]
        public async Task<IActionResult> ObtenerPaciente(int id)
        {
            var pacienteTarget = await _dbContext.Pacientes.FindAsync(id);

            if (pacienteTarget == null)
                return BadRequest("No existe el paciente indicado.");

            return Ok(pacienteTarget);
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearPaciente([FromBody] Paciente paciente)
        {
            await _dbContext.AddAsync(paciente);
            await _dbContext.SaveChangesAsync();

            return Ok(paciente);
        }

        [HttpPut]
        [Route("actualizar")]
        public async Task<IActionResult> ActualizarPaciente([FromBody] Paciente paciente)
        {
            var pacienteTarget = await _dbContext.Pacientes.FindAsync(paciente.PacienteId);

            if (pacienteTarget == null)
                return BadRequest("No existe el paciente indicado.");

            pacienteTarget.Nombres = paciente.Nombres;
            pacienteTarget.Apellidos = paciente.Apellidos;
            pacienteTarget.TipoDocumento = paciente.TipoDocumento;
            pacienteTarget.NumeroDocumento = paciente.NumeroDocumento;
            pacienteTarget.FechaNacimiento = paciente.FechaNacimiento;
            pacienteTarget.CiudadResidencia = paciente.CiudadResidencia;

            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<IActionResult> EliminarPaciente(int id)
        {
            var pacienteTarget = await _dbContext.Pacientes.FindAsync(id);

            if(pacienteTarget == null)
                return BadRequest("No existe el paciente indicado.");

            _dbContext.Pacientes.Remove(pacienteTarget);
            await _dbContext.SaveChangesAsync();

            return Ok();
      
        }
    }
}
