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
                //int NumeroLinea = (Lineas.Count()==0)?1:Lineas.Keys().Max
            }

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
