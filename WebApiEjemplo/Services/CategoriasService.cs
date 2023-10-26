using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using WebApiEjemplo.Models;
using System.Xml.Linq;

namespace WebApiEjemplo.Services
{
    public class CategoriasService : ICategoriasService
    {
        private const string URL = "https://api.escuelajs.co/api/v1/categories";

        public async Task<List<Categoria>> ObtenerCategorias()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(URL);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categorias = JsonSerializer.Deserialize<List<Categoria>>(content);
                return categorias;
            }
            return null;
        }

        public async Task<bool> Eliminar(int categoriaId)
        {
            var httpClient = new HttpClient();
            var deleteUrl = $"{URL}/{categoriaId}";

            var response = await httpClient.DeleteAsync(deleteUrl);

            return response.IsSuccessStatusCode;
        }
        public async Task<Categoria> CrearCategoria(Categoria nuevaCategoria)
        {
            var httpClient = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(nuevaCategoria), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(URL, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var categoriaCreada = JsonSerializer.Deserialize<Categoria>(responseContent);
                return categoriaCreada;
            }
            return null;
        }
        public async Task<bool> ActualizarCategoria(int id, string newname)
        {

            var httpClient = new HttpClient();
            var content = new StringContent($"{{\"name\": \"{newname}\"}}", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync($"https://api.escuelajs.co/api/v1/categories/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                await Application.Current.MainPage.DisplayAlert("Exitoso", "La categoria de actualizo", "Aceptar");
                return true;
            }
            else
            {
                string conttent = await response.Content.ReadAsStringAsync();
                await Application.Current.MainPage.DisplayAlert("Error", "Detalles del error: " + conttent, "Aceptar");
            }

            return false;

            //{

            //    var httpClient = new HttpClient();
            //    var putUrl = $"{URL}/{categoria.id}";

            //    var categoriaJson = JsonSerializer.Serialize(categoria);
            //    var content = new StringContent(categoriaJson, Encoding.UTF8, "application/json");

            //    var response = await httpClient.PutAsync(putUrl, content);

            //    return response.IsSuccessStatusCode;
            //}

        }
   

    }
}

