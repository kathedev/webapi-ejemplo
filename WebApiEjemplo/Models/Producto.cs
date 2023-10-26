using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEjemplo.Models
{
    internal class Producto
    {
        public int id { get; set; } // Identificador del producto//
        public string title { get; set; } //Nombre del producto //
        public int price { get; set; } //Precio del producto//
        public string description { get; set; } //Descripción del producto//
        public List<string> images { get; set; } //Lista de las imagenes del producto//
        public DateTime creationAt { get; set; } //Fecha y hora de la creación del producto//
        public DateTime updatedAt { get; set; } //Actualización del producto//
        public Category category { get; set; } //Categoria a la que pertenece el producto//
    }
    public class Category
    {
        public int id { get; set; } //Identificador de la categoria //
        public string name { get; set; } //Nombre de la categoria//
        public string image { get; set; } //Imagen de la categoria//
        public DateTime creationAt { get; set; } //Fecha y hora de la creación de la categoria//
        public DateTime updatedAt { get; set; } //Fecha y hora de la actualización de la categoria//
    }
}
