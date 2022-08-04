using Intuit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intuit.Business.Contracts
{
	public interface IClientService
	{
		public List<ClientDTO> GetAll();

		ClientDTO GetById(int Id);

		List<ClientDTO> SearchByName(string Nombre);

		bool AddNewClient(ClientDTO client);
		void UpdateClient(ClientDTO client);
	}
}
