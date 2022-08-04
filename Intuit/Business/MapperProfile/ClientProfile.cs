using AutoMapper;
using Intuit.Data;
using Intuit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intuit.Business.MapperProfile
{
	public class ClientProfile : Profile
	{
		public ClientProfile()
		{
			CreateMap<Client, ClientDTO>();
			CreateMap<ClientDTO, Client>();
		}
	}
}
