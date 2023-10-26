using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEjemplo.Models;

namespace WebApiEjemplo.Services
{
	internal interface IProductService
	{
		public Task<List<Producto>> Obtener(); //metodo para obtener una lista//
	}
}
