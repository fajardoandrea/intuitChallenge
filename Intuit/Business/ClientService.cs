using AutoMapper;
using Intuit.Business.Contracts;
using Intuit.Data;
using Intuit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Intuit.Business
{
	public class ClientService : IClientService
	{
		private readonly DBConnection _context;
		private readonly IMapper _mapper;

		public ClientService(DBConnection context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		
		/// <summary>
		/// Agrega un nuevo cliente a la base de datos
		/// </summary>
		/// <param name="client"></param>
		/// <returns>La entidad creada</returns>
		public bool AddNewClient(ClientDTO client)
		{
			Client entity = _mapper.Map<ClientDTO, Client>(client);
			_context.Client.Add(entity);
			_context.SaveChanges();
			var createdEntity = entity;
			return true;
		}

		/// <summary>
		/// Devuelve todos los datos de la tabla Cliente
		/// </summary>
		/// <returns></returns>
		public List<ClientDTO> GetAll()
		{
			var EntityList = _context.Client.ToList();
			var ClientList = new List<ClientDTO>();

			foreach (var item in EntityList)
			{
				var client = _mapper.Map<Client, ClientDTO>(item);
				ClientList.Add(client);
			}
			return ClientList;

		}

		/// <summary>
		/// Devuelve un unico resultado producto de la busqueda por ID
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public ClientDTO GetById(int Id)
		{
			var client = _context.Client.FirstOrDefault(c => c.Id == Convert.ToInt32(Id));
			var result = _mapper.Map<Client, ClientDTO>(client);
			return result;

		}

		/// <summary>
		/// Regresa todos los datos con coincidencias en la busqueda de nombres 
		/// </summary>
		/// <param name="Nombre"></param>
		/// <returns></returns>
		public List<ClientDTO> SearchByName(string Nombre)
		{
			var client = _context.Client.Where(x => x.Nombre.ToLower().Contains(Nombre.ToLower())).ToList();
			var result = _mapper.Map<List<Client>, List<ClientDTO>>(client);
			return result;

		}

		/// <summary>
		/// Permite reescribir la informacion de un cliente que ya existe en la base de datos 
		/// </summary>
		/// <param name="client"></param>
		public void UpdateClient(ClientDTO client)
		{
			var entity = _mapper.Map<ClientDTO, Client>(client);
			_context.Client.Update(entity);
			_context.SaveChanges();
		}
	}
}
