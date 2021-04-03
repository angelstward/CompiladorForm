using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompiladorForm.Transversal
{
    public class Cache
    {
        private Dictionary<int, Linea> Lineas = new Dictionary<int, Linea>();
        private static readonly Cache INSTANCIA = new Cache();

        private Cache()
        {
        }

        public static Cache ObtenerCache()
        {
            return INSTANCIA;
        }
        public void Limpiar()
        {
            Lineas.Clear();
        }
        public void AgregarLineas(string Contenido)
        {
            if(Contenido != null)
            {
                Limpiar();
                string[] response = Contenido.Split(Environment.NewLine);
                for(int i =1; i<= response.Count(); i++)
                {
                    var linea = Linea.Crear(i, AsignarLineaAgregar(response[i - 1]));
                    Lineas.Add(i, linea);                    
                }
                var lineaFin = Linea.Crear(response.Count() + 1, "@EOF@");
                Lineas.Add(response.Count() + 1,lineaFin);
            }
        }

        private string AsignarLineaAgregar(string response)
        {
            if ("".Equals(response))
            {
                return "@JL@";
            }
            return response;
        }
        public Linea ObtenerLinea(int NumeroLinea)
        {
            Linea LineaRetorno = Linea.Crear(Lineas.Count() + 1, "@EOF@");

            if (Lineas.ContainsKey(NumeroLinea))
            {
                LineaRetorno = Lineas[NumeroLinea];
            }
            return LineaRetorno;
        }

    }
}
