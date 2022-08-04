using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intuit.Data
{
	public class Client
	{
		public int Id { get; set; }
		
		[Required]
		public string Nombre { get; set; }
		
		[Required]
		public string Apellido { get; set; }

		public DateTime Fecha_Nacimiento { get; set; }

		[Required]
		public string Cuit { get; set; }

		[Required]
		public string Celular { get; set; }

		[Required]
		public string Email { get; set; }

	}
}
