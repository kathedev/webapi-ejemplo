using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEjemplo.Models;


namespace WebApiEjemplo.Services
{
    public interface ICategoriasService
    {
        Task<List<Categoria>> ObtenerCategorias();
        Task<bool> Eliminar(int categoriaId);
        Task<Categoria> CrearCategoria(Categoria nuevaCategoria);
        Task<bool> ActualizarCategoria(int id, string newname);
    }

}
