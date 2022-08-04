using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intuit.Domain
{
	public class ClientDTO
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "El Apellido es obligatorio")]
		public string Apellido { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
		public DateTime Fecha_Nacimiento { get; set; }

		[Required(ErrorMessage = "El Cuit es obligatorio")]
		[MinLength(10)]
		[MaxLength(11)]
		public string Cuit { get; set; }

		[Required(ErrorMessage = "El Celular es obligatorio")]
		public string Celular { get; set; }

		[Required(ErrorMessage = "El Email es obligatorio")]
		[DataType(DataType.EmailAddress)]
		[MaxLength(50)]
		[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Ingrese un email valido")]
		public string Email { get; set; }
	}
}
