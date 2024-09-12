using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            ConeccionBD datos = new ConeccionBD();
            try
            {
                datos.setearconsulta("Select Codigo, Nombre, A.Descripcion as Detalle, M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl From ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I where A.IdMarca = M.Id AND A.IdCategoria = C.Id AND A.Id = I.IdArticulo");
                datos.ejecutarlectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Detalle"];
                    aux.marca = new Marca();
                    aux.marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.categoria = new Categoria();
                    aux.categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.imagenurl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarconexion();
            }

        }

        public List<Articulo> buscarpormarca(string marca)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista1 = negocio.listar();
            List<Articulo> lista2 = new List<Articulo>();
            foreach (Articulo art in lista1)
            {
                if (art.marca.Descripcion == marca)
                {
                    lista2.Add(art);
                }
            }
            return lista2;
        }

        public List<Articulo> buscarporcategoria(string cat)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista1 = negocio.listar();
            List<Articulo> lista2 = new List<Articulo>();
            foreach (Articulo art in lista1)
            {
                if (art.categoria.Descripcion == cat)
                {
                    lista2.Add(art);
                }
            }
            return lista2;
        }
    }
}
