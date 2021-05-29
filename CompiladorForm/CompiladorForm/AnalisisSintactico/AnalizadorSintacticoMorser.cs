using System;
using System.Collections.Generic;
using System.Text;

namespace CompiladorForm.AnalisisSintactico
{
    public class AnalizadorSintactico
    {
        private Transversal.ComponenteLexico Componente;
        private AnalisisLexico.AnalizadorLexico AnaLex;
        private StringBuilder TrazaDerivacion;
        private Stack<double> pila = new Stack<double>();


        public Dictionary<String, Object> Analizar(bool depurar)
        {
            AnaLex = new AnalisisLexico.AnalizadorLexico();
            TrazaDerivacion = new StringBuilder();
            Avanzar();
            Expresion(0);

            if (depurar)
            {
                System.Windows.Forms.MessageBox.Show(TrazaDerivacion.ToString());
            }
            Dictionary<String, Object> resultado = new Dictionary<String, Object>();
            resultado.Add("COMPONENTE" , Componente);
            resultado.Add("PILA", pila);

            return resultado;
        }
        private void Expresion(int jerarquia)
        {
            TrazarEntrada("<Expresion>", jerarquia);

            Termino(jerarquia + 1);
            ExpresionPrima(jerarquia + 1);

            TrazarSalida("</Expresion>", jerarquia);
        }

        private void ExpresionPrima(int jerarquia)
        {
            TrazarEntrada("<ExpresionPrima>", jerarquia);
            if (Transversal.Categoria.SUMA.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
                Expresion(jerarquia + 1);

                double derecho = pila.Pop();
                TrazarPop(jerarquia, derecho);

                double izquiero = pila.Pop();
                TrazarPop(jerarquia, izquiero);

               
                double resultado = izquiero + derecho;
                TrazarSalida(izquiero + "+" + derecho + "=" + resultado, jerarquia);
                pila.Push(resultado);
                TrazarPush(jerarquia, resultado);

            }
            else if (Transversal.Categoria.RESTA.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
                Expresion(jerarquia + 1);
                double derecho = pila.Pop();
                TrazarPop(jerarquia, derecho);

                double izquiero = pila.Pop();
                TrazarPop(jerarquia, izquiero);

                pila.Push(izquiero - derecho);
                double resultado = izquiero - derecho;
                TrazarSalida(izquiero + "-" + derecho + "=" + resultado, jerarquia);
                pila.Push(resultado);
            }

            TrazarSalida("</ExpresionPrima>", jerarquia);

        }

        private void Termino(int jerarquia)
        {
            TrazarEntrada("<Termino>", jerarquia);
            Factor(jerarquia + 1);
            TerminoPrima(jerarquia + 1);
            TrazarSalida("</Termino>", jerarquia);

        }


        private void TerminoPrima(int jerarquia)
        {
            TrazarEntrada("<TerminoPrima>", jerarquia);
            if (Transversal.Categoria.MULTIPLICACION.Equals(Componente.ObtenerCategoria()))
            {
      
                Avanzar();
                Termino(jerarquia + 1);

                double derecho = pila.Pop();
                TrazarPop(jerarquia, derecho);

                double izquiero = pila.Pop();
                TrazarPop(jerarquia, izquiero);

                pila.Push(izquiero * derecho);
                double resultado = izquiero * derecho;
                TrazarSalida(izquiero + "*" + derecho + "=" + resultado, jerarquia);
                pila.Push(resultado);

            }
            else if (Transversal.Categoria.DIVISION.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
                Termino(jerarquia + 1);

                double derecho = pila.Pop();
                TrazarPop(jerarquia, derecho);

                double izquiero = pila.Pop();
                TrazarPop(jerarquia, izquiero);
                if (derecho == 0)
                {
                    derecho = 1;
                    string Causa = "No es posible llevar a cabo una división por cero.";
                    string Falla = "Divisor cero";
                    string Solucion = "Asegúrese que el divisor es diferente de cero.";
                    GestorErrores.Error error = GestorErrores.Error.CrearErrorSemantico(Componente.ObtenerLexema(), Componente.ObtenerCategoria(), Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Causa, Falla, Solucion);
                    GestorErrores.ManejadorErrores.Reportar(error);
                    throw new Exception("Se ha presentado un error de tipo stopper del proceso de compilación. Por favor revise la consola de errores...");
                }
               
                double resultado = izquiero / derecho;
                TrazarSalida(izquiero + "/" + derecho + "=" + resultado, jerarquia);
                pila.Push(resultado);
                TrazarPush(jerarquia, resultado);
            }
            TrazarSalida("</TerminoPrima>", jerarquia);

        }

        private void Factor(int jerarquia)
        {
            TrazarEntrada("<Factor>", jerarquia);

            if (Transversal.Categoria.NUMERO_ENTERO.Equals(Componente.ObtenerCategoria()))
            {
                double valor = Convert.ToDouble(Componente.ObtenerLexema());
                pila.Push(Convert.ToDouble(Componente.ObtenerLexema()));
                TrazarPush(jerarquia, valor);
                Avanzar();

            }
            else if (Transversal.Categoria.NUMERO_DECIMAL.Equals(Componente.ObtenerCategoria()))
            {
                double valor = Convert.ToDouble(Componente.ObtenerLexema());
                pila.Push(Convert.ToDouble(Componente.ObtenerLexema()));
                TrazarPush(jerarquia, valor);
                Avanzar();
                
            }

            else if (Transversal.Categoria.PARENTESIS_ABRE.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
                Expresion(jerarquia + 1);

                if (Transversal.Categoria.PARENTESIS_CIERRA.Equals(Componente.ObtenerCategoria()))
                {
                    Avanzar();

                }else
                {
                    string Causa = "Se esperaba un paréntesis que cierra y recibí" + Componente.ObtenerCategoria();
                    string Falla = "Paréntesis desequilibrados";
                    string Solucion = "Asegurese que los paréntesis que se abran, tambien se cierren.";
                    GestorErrores.Error error = GestorErrores.Error.CrearErrorSintactico(Componente.ObtenerLexema(), Componente.ObtenerCategoria(), Componente.ObtenerNumeroLinea(),Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Causa, Falla, Solucion);
                    GestorErrores.ManejadorErrores.Reportar(error);
                    throw new Exception("Se ha presentado un error de tipo stopper del proceso de compilación. Por favor revise la consola de errores...");
                }
               
            }
            else
            {
                string Causa = "Se esperaba número entero, número decimal ó  paréntesis que abre y recibí" + Componente.ObtenerCategoria();
                string Falla = "Componente lexico recibido no permitido segun las reglas del lenguaje ";
                string Solucion = "Asegurese que en esta posición exista un Se esperaba número entero, número decimal ó  paréntesis que abre.";
                GestorErrores.Error error = GestorErrores.Error.CrearErrorSintactico(Componente.ObtenerLexema(), Componente.ObtenerCategoria(), Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Causa, Falla, Solucion);
                GestorErrores.ManejadorErrores.Reportar(error);
                throw new Exception("Se ha presentado un error de tipo stopper del proceso de compilación. Por favor revise la consola de errores...");
            }

            TrazarSalida("</Factor>", jerarquia);


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

