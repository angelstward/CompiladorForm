using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CompiladorForm.AnalisisLexico;
using CompiladorForm.GestorErrores;
using CompiladorForm.Transversal;
using CompiladorForm.AnalisisSintactico;


namespace CompiladorForm.AnalisisSintactico
{
    public class AnalizadorSintacticoMorseLatino : AnalizadorSintacticoBase
    {

        private ComponenteLexico Componente;
        private AnalizadorLexicoMorseLatino AnaLex;
        private StringBuilder TrazaDerivacion;
        private Stack<double> pila = new Stack<double>();
        private StringBuilder resultadoCompilacion;


        public Dictionary<String, Object> Analizar(bool depurar)
        {
            AnaLex = new AnalizadorLexicoMorseLatino();
            TrazaDerivacion = new StringBuilder();
            resultadoCompilacion = new StringBuilder();
            Avanzar();
            MorseLatino(0);

            if (depurar)
            {
                System.Windows.Forms.MessageBox.Show(TrazaDerivacion.ToString());
            }
            Dictionary<String, Object> resultado = new Dictionary<String, Object>();
            resultado.Add("COMPONENTE", Componente);
            resultado.Add("RESULTADO", resultadoCompilacion);

            return resultado;
        }

        private void MorseLatino(int jerarquia)
        {
            TrazarEntrada("<LatinMorse>", jerarquia);
            Alfabeto(jerarquia + 1);
            MorseLatinoAux(jerarquia + 1);
            TrazarSalida("</LatinMorse>", jerarquia);


        }

        private void MorseLatinoAux(int jerarquia)
        {
            TrazarEntrada("<LatinoMorseAux>", jerarquia);
            if (!Categoria.FIN_ARCHIVO.Equals(Componente.ObtenerCategoria()))
            {
                MorseLatino(jerarquia + 1);
            }
            TrazarSalida("</LatinoMorseAux>", jerarquia);
        }

        private void Alfabeto(int jerarquia)
        {
            TrazarEntrada("<Alfabeto>", jerarquia);

            if (DiccionarioMorseLatino.ExisteCategoria(Componente.ObtenerCategoria()))
            {
                FormarResultado(Componente);
                Avanzar();
            }
            else
            {
                String causa = "Categoria no valida" + Componente.ObtenerCategoria();
                String falla = "Caracter no reconocido por el lenguaje";
                String solucion = "Asegurese que la entrada sea sintacticamente correcta";
                Error error = Error.CrearErrorSintactico(Componente.ObtenerLexema(), Categoria.ERROR, Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), falla, causa, solucion);
                ManejadorErrores.Reportar(error);
                throw new Exception("Se ha producido un error del tipo stopper dentro del compilador en el analizador sintactico");
            }
            TrazarSalida("</Alfabeto>", jerarquia);
        }

        private void FormarResultado(ComponenteLexico Componente)
        {

            resultadoCompilacion.Append(DiccionarioMorseLatino.MorseAlfabeto[Componente.ObtenerCategoria()]);
            /*do
            {
                resultadoCompilacion.Replace("/ / ", "/ ");
            } while (resultadoCompilacion.ToString().Contains("/ / "));*/
        }

        private void Avanzar()
        {
            Componente = AnaLex.Analizar();
        }

        private void TrazarEntrada(string NombreRegla, int jerarquia)
        {
            TrazaDerivacion.Append(FormarCadenaEspaciosEnBlanco(jerarquia));
            TrazaDerivacion.Append("(").Append(Componente.ObtenerCategoria()).Append(")");
            TrazaDerivacion.Append(Environment.NewLine);
        }

        private void TrazarSalida(string NombreRegla, int jerarquia)
        {
            TrazaDerivacion.Append(FormarCadenaEspaciosEnBlanco(jerarquia));
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

