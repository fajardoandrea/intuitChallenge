using Intuit.Business.Contracts;
using Intuit.Domain;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intuit.Controllers
{
	[ApiController]
	[Route ("api/[controller]")]
	[SwaggerTag("Este controlador permite realizar operaciones CRUD de un cliente")]
	public class ClientController : Controller
	{
		private readonly IClientService _service;
		public ClientController(IClientService service)
		{
			_service = service;
		}

		[HttpGet]
		[Route ("getall")]
		public async Task<ActionResult> GetAll()
		{
			try
			{
				var list = new List<ClientDTO>();
				Task tarea1 = Task.Run(() => { list = _service.GetAll(); });
				await Task.WhenAll(tarea1);
				return Ok (list);
			}
			catch (Exception ex )
			{
				return BadRequest(ex.Message);
			}
		}
		
		[HttpPost]
		[Route("addnewclient")]
		public async Task<ActionResult> AddClient([FromBody] ClientDTO value)
		{
			try
			{
				Task tarea1 = Task.Run(() => { _service.AddNewClient(value); });
				await Task.WhenAll(tarea1);
				string mensaje = "Nuevo cliente creado";
				return Ok(mensaje);
			}
			catch (Exception  ex)
			{
				return BadRequest(ex.Message);
			}


		}
		
		[HttpGet]
		[Route ("getbyid/{id}")]
		public async Task<ActionResult<ClientDTO>> GetById(int id)
		{
			try
			{
				var result = new ClientDTO();
				Task tarea1 = Task.Run(() => {result =  _service.GetById(id); });
				await Task.WhenAll(tarea1);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		
		[HttpGet]
		[Route("searchbyname/{nombre}")]
		public async Task<ActionResult<string>> SearchByName(string nombre)
		{
			try
			{
				var result = new List<ClientDTO>();
				Task tarea1 = Task.Run(() => { ( result = _service.SearchByName(nombre)).ToString(); });
				await Task.WhenAll(tarea1);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		
		[HttpPost]
		[Route("update")]
		public async Task<ActionResult> UpdateClient([FromBody] ClientDTO client)
		{
			try
			{
				Task tarea1 = Task.Run(() => { _service.UpdateClient(client); });
				await Task.WhenAll(tarea1);
				string mensaje = "Informacion del cliente actualizada";
				return Ok(mensaje);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}
	}
}
