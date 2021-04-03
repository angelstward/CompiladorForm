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
                string[] response = Contenido.Split("\r");
                int i = 1;
                for (int pos=1; pos<= response.Count();pos++)
                {
                    string[] contenidoAgregar = AsignarLineaAgregar(response[pos - 1]);
                    foreach(string l in contenidoAgregar)
                    {
                        string stringAgregar = l;
                        if (l.Equals(""))
                        {
                            stringAgregar = "@JL@";
                        }
                        var linea = Linea.Crear(i, stringAgregar);
                        Lineas.Add(i, linea);
                        i++;
                    }
                    if (contenidoAgregar.Contains("\n"))
                    {
                        pos--;
                    }
                    
                }
                Dictionary<int, Linea>.KeyCollection keyColl = Lineas.Keys;

                var lineaFin = Linea.Crear(keyColl.Max() + 1, "@EOF@");
                Lineas.Add(keyColl.Max() + 1, lineaFin);
            }
        }

        private string [] AsignarLineaAgregar(string response)
        {
            if (!response.Equals(""))
            {
                if (response.Contains("\n"))
                {
                    return (new string[] { "@JL@", response.Replace("\n", "") });
                }
                return (new string[1] { response });
            }
            return new string[] { };
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
