using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubicapp.Modelo;

namespace Ubicapp.Servicio
{
    public class ServicioProfesor
    {
        //private List<Profesor> lista = new List<Profesor>();

        public List<Profesor> ConsultarProfesor()
        {
            var lista = new List<Profesor>();
            lista.Add(new Profesor { /*Foto = "https://design.atlassian.com/images/personas/alana.jpg",*/ Nombre = "Alberto Jorge", Apellido = "Cepeda Alarcon"/*, Correo = "alberto.cepeda@hotmail.com"*/ });
            lista.Add(new Profesor { /*Foto = "http://www.luisan.net/diseno-grafico/imagenes-agencia-creativa/agencia-creativa-people.jpg",*/ Nombre = "Daniela Sofía", Apellido = "Aguilera Rios"/*, Correo = "daniela.rios@yahoo.com.mx"*/ });
            lista.Add(new Profesor { /*Foto = "http://static.batanga.com/sites/default/files/styles/full/public/curiosidades.batanga.com/files/Las-personas-con-ojos-azules-derivan-de-un-unico.jpg",*/ Nombre = "Javier", Apellido = "Saucedo López"/*, Correo = "javier.lopez@gmail.com"*/ });
            lista.Add(new Profesor { /*Foto = "http://bucket3.clanacion.com.ar/anexos/fotos/65/50-personas-inspiradoras-en-2014-1986565w618.jpg",*/ Nombre = "Julia", Apellido = "Alejandra Ortiz"/*, Correo = "julia.ortiz@hotmail.com"*/ });
            lista.Add(new Profesor { /*Foto = "http://www.manuelsilva.es/wp-content/uploads/IMG_6185b-copia.jpg",*/ Nombre = "Juan Mauricio", Apellido = "Ochoa Castillo"/*, Correo = "juanmauricio.ochoa@gmail.com"*/ });

            return lista;
        }

        /*public void AgregarProfesor(string urlfoto, string nombre, string apellido, string correo)
        {
            lista.Add(new Profesor { Foto = urlfoto, Nombre = nombre, Apellido = apellido, Correo = correo });
        }*/
    }
}
