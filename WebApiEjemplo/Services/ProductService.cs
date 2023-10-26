using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiEjemplo.Models;

namespace WebApiEjemplo.Services
{
	internal class ProductService : IProductService
	{
		const string URL = "https://api.escuelajs.co/api/v1/products?offset=0&limit=10"; //Url de la api//
		public async Task<List<Producto>> Obtener()
		{
			var httpClient = new HttpClient(); // Se crea una instancia de HttpClient para realizar solicitudes de HTTP//
			var response = await httpClient.GetAsync(URL); // se realiza una solicitud GET a la url de la api//

			if (response.IsSuccessStatusCode) // Se verifica si la respuesta de la solicitud es exitosa//
			{
				var content = await response.Content.ReadAsStringAsync(); //Se lee el contenido de la respuesta como una cadena//
				var producto = JsonSerializer.Deserialize<List<Producto>>(content); //Se realiza la respuesta Json en una lista de objetos de producto//
				return producto; //Se devuelve la lista de productos//
			}
			return null; //Si la respuesta no es exitosa, se devuelve null//
		}
	}
}
