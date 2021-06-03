using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CompiladorForm.AnalisisLexico;
using CompiladorForm.GestorErrores;
using CompiladorForm.Transversal;

namespace CompiladorForm.AnalisisSintactico
{
    public class AnalizadorSintacticoMorse
    {
        private Transversal.ComponenteLexico Componente;
        private AnalizadorLexicoMorse AnaLex;
        private StringBuilder TrazaDerivacion;
        private Stack<double> pila = new Stack<double>();
        private IEnumerable<Categoria> categoriasValidas = new List<Categoria>() { Categoria.CADENA_ACENTO, Categoria.CADENA_CARACTER, Categoria.CADENA_LETRA, Categoria.CADENA_NUMERO };



        public Dictionary<String, Object> Analizar()
        {
            AnaLex = new AnalizadorLexicoMorse();
            TrazaDerivacion = new StringBuilder();
            Avanzar();
            Morse();

            Dictionary<String, Object> resultado = new Dictionary<String, Object>();
            resultado.Add("COMPONENTE", Componente);

            return resultado;
        }

        //<Morse> := <cadena-letra><Morse>|<cadena-número><Morse>|<cadena-carácter><Morse>
        private void Morse()
        {
            if (Componente.ObtenerCategoria().Equals(Categoria.CADENA_LETRA))
            {
                Avanzar();
                Morse();
            }
            else if (Componente.ObtenerCategoria().Equals(Categoria.CADENA_NUMERO))
            {
                Avanzar();
                Morse();
            }
            else if (Componente.ObtenerCategoria().Equals(Categoria.CADENA_CARACTER))
            {
                Avanzar();
                Morse();
            }
            else
            {
                string Falla = "ERROR NUMERO NO VALIDO";
                string Solucion = "Revise la entrada";
                Error error = Error.CrearErrorSintactico(Componente.ObtenerLexema(), Categoria.CARACTER, Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), "Se esperaba CARACTER y se recibio :" + Componente.ObtenerLexema(), Falla, Solucion);
                ManejadorErrores.Reportar(error);
            }
            
        }

        //<cadena-letra> := <letra>|<letra><cadena-letra>
        private void CadenaLetra()
        {
            if (Componente.ObtenerCategoria().Equals(Categoria.LETRA))
            {
                Letra();
            }
            else if (Componente.ObtenerCategoria().Equals(Categoria.CADENA_LETRA))
            {
                Avanzar();
                Letra();
            }
            else
            {
                string Falla = "ERROR NUMERO NO VALIDO";
                string Solucion = "Revise la entrada";
                Error error = Error.CrearErrorSintactico(Componente.ObtenerLexema(), Categoria.CARACTER, Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), "Se esperaba CARACTER y se recibio :" + Componente.ObtenerLexema(), Falla, Solucion);
                ManejadorErrores.Reportar(error);
            }
        }

        //<letra> := a|A|B|b|C|c| ... Z|z|Á | á | É | é | Ó | ó
        private void Letra()
        {
            if (Componente.ObtenerCategoria().Equals(Categoria.LETRA))
            {
                Avanzar();
            }
            else
            {
                string Falla = "ERROR NUMERO NO VALIDO";
                string Solucion = "Revise la entrada";
                Error error = Error.CrearErrorSintactico(Componente.ObtenerLexema(), Categoria.CARACTER, Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), "Se esperaba NUMERO y se recibio :" + Componente.ObtenerLexema(), Falla, Solucion);
                ManejadorErrores.Reportar(error);
            }

        }

        //<cadena-número> := <número> | <número><cadena-número>
        private void CadenaNumero()
        {
            if (Componente.ObtenerCategoria().Equals(Categoria.NUMERO))
            {
                Numero();
            }
            else if (Componente.ObtenerCategoria().Equals(Categoria.CADENA_NUMERO))
            {
                Avanzar();
                Numero();
            }
            else
            {
                string Falla = "ERROR NUMERO NO VALIDO";
                string Solucion = "Revise la entrada";
                Error error = Error.CrearErrorSintactico(Componente.ObtenerLexema(), Categoria.CARACTER, Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), "Se esperaba CARACTER y se recibio :" + Componente.ObtenerLexema(), Falla, Solucion);
                ManejadorErrores.Reportar(error);
            }
        }

        //<número> := 1|2|3|4|5|6|7|8|9|0
        private void Numero()
        {
            if (Componente.ObtenerCategoria().Equals(Categoria.NUMERO))
            {
                Avanzar();
            }
            else
            {
                string Falla = "ERROR NUMERO NO VALIDO";
                string Solucion = "Revise la entrada";
                Error error = Error.CrearErrorSintactico(Componente.ObtenerLexema(), Categoria.CARACTER, Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), "Se esperaba NUMERO y se recibio :" + Componente.ObtenerLexema(), Falla, Solucion);
                ManejadorErrores.Reportar(error);
            }

        }

        //<cadena-caracter> := <caracter>|<cadena-caracter><carácter>
        private void CadenaCaracter()
        {
            if (Componente.ObtenerCategoria().Equals(Categoria.CARACTER))
            {
                Caracter();
            }
            else if (Componente.ObtenerCategoria().Equals(Categoria.CADENA_CARACTER))
            {
                Avanzar();
                Caracter();
            }
            else
            {
                string Falla = "ERROR CARACTER NO VALIDO";
                string Solucion = "Revise la entrada";
                Error error = Error.CrearErrorSintactico(Componente.ObtenerLexema(), Categoria.CARACTER, Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), "Se esperaba CARACTER y se recibio :" + Componente.ObtenerLexema(), Falla, Solucion);
                ManejadorErrores.Reportar(error);
            }
        }

        //<carácter> := . | , | ‘ | ? | ! | / | ( | ) | & | : | ; | = | + | - | ¡ | ¿ | @ | $ | “ | _ |<Espacio_blanco> 
        private void Caracter()
        {
            if (Componente.ObtenerCategoria().Equals(Categoria.CARACTER) || Componente.ObtenerCategoria().Equals(Categoria.ESPACIO_BLANCO))
            {
                Avanzar();
            }
            else
            {
                string Falla = "ERROR CARACTER NO VALIDO";
                string Solucion = "Revise la entrada";
                Error error = Error.CrearErrorSintactico(Componente.ObtenerLexema(), Categoria.CARACTER, Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), "Se esperaba CARACTER y se recibio :" + Componente.ObtenerLexema(), Falla, Solucion);
                ManejadorErrores.Reportar(error);
            }
          
        }
        private void EspacioBlanco(string posicion)
        {
            if (Componente.ObtenerCategoria().Equals(Categoria.ESPACIO_BLANCO))
            {
                Avanzar();
            }
            else
            {
                string Falla = "ERROR SIMBOLO NO VALIDO";
                string Solucion = "Asegúrese que el caracter sea ESPACIO";
                Error error = Error.CrearErrorSintactico(Componente.ObtenerLexema(), Categoria.ESPACIO_BLANCO, Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(),Componente.ObtenerPosicionFinal(), "Se esperaba ESPACIO y se recibio :" + Componente.ObtenerLexema(), Falla, Solucion);
                ManejadorErrores.Reportar(error);
            }
        }
       


        private void Avanzar()
        {
            Componente = AnaLex.Analizar();
        }

        private void TrazarEntrada(string NombreRegla, int jerarquia)
        {
            TrazaDerivacion.Append(FormarCadenaEspaciosEnBlanco(jerarquia));
            //TrazaDerivacion.Append("Entrando a derivar regla").Append(NombreRegla).Append("con componente").Append(Componente.ObtenerCategoria());
            TrazaDerivacion.Append("(").Append(Componente.ObtenerCategoria()).Append(")");
            TrazaDerivacion.Append(Environment.NewLine);
        }

        private void TrazarSalida(string NombreRegla, int jerarquia)
        {
            TrazaDerivacion.Append(FormarCadenaEspaciosEnBlanco(jerarquia));
            //TrazaDerivacion.Append("Saliendo a derivar regla").Append(NombreRegla);
            TrazaDerivacion.Append(NombreRegla);
            TrazaDerivacion.Append(Environment.NewLine);

        }
        public void TrazarPush(int jerarquia, double valor)
        {
            TrazaDerivacion.Append(FormarCadenaEspaciosEnBlanco(jerarquia));
            TrazaDerivacion.Append("PUSH->").Append(valor);
            TrazaDerivacion.Append(Environment.NewLine);

        }
        public void TrazarPop(int jerarquia, double valor)
        {
            TrazaDerivacion.Append(FormarCadenaEspaciosEnBlanco(jerarquia));
            TrazaDerivacion.Append("POP->").Append(valor);
            TrazaDerivacion.Append(Environment.NewLine);

        }

        private string FormarCadenaEspaciosEnBlanco(int jerarquia)
        {
            String EspaciosBlanco = "";
            for (int indice = 1; indice <= jerarquia * 2; indice++)
            {
                EspaciosBlanco = EspaciosBlanco + "";
            }

            return EspaciosBlanco;

        }
    }
}

