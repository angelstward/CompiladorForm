
using CompiladorForm.AnalisisLexico;
using CompiladorForm.GestorErrores;
using CompiladorForm.Transversal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CompiladorForm.AnalisisSintactico
{
    public class AnalizadorSintactico
    {
        private readonly AnalizadorLexico analex = new AnalizadorLexico();
        private ComponenteLexico componente = null;
        private bool apilar = true;
        private readonly Stack<double> pila = new Stack<double>();
        private StringBuilder TrazaDerivacion;


        public Dictionary<string, object> Analizar(bool x)
        {
            TrazaDerivacion = new StringBuilder();           
            Avanzar();
            Expresion(0);
            if (x)
            {
                Console.WriteLine(TrazaDerivacion.ToString());
                MessageBox.Show(TrazaDerivacion.ToString());
            }
            Dictionary<string, object> resultado = new Dictionary<string, object>
            {
                { "COMPONENTE", componente },
                { "PILA", pila }
            };

            return resultado;
        }

        private void Expresion(int jerarquia)
        {
            TrazarEntrada("<Expresion>", jerarquia);
            Termino(jerarquia + 1);
            ExpresionPrima(jerarquia + 1);
            TrazarSalida("</Expresion>", jerarquia);           
        }


        private void Termino(int jerarquia)
        {
            TrazarEntrada("<Termino>", jerarquia);
            Factor(jerarquia +1);
            TerminoPrima(jerarquia+1);
            TrazarSalida("</Termino>", jerarquia);
        }

        private void ExpresionPrima(int jerarquia)
        {
            TrazarEntrada("<ExpresionPrima>", jerarquia);

            if (Categoria.SUMA.Equals(componente.ObtenerCategoria()))
            {
                Avanzar();
                Expresion(jerarquia);
                double derecho = pila.Pop();
                TrazarPop(jerarquia, derecho);
                double izquierdo = pila.Pop();
                TrazarPop(jerarquia, izquierdo);
                pila.Push(izquierdo + derecho);
                TrazarSalida(izquierdo+"+"+derecho+"="+ (izquierdo+derecho), jerarquia);
                TrazarPush(jerarquia, izquierdo + derecho);                

            }
            else if (Categoria.RESTA.Equals(componente.ObtenerCategoria()))
            {
                Avanzar();
                Expresion(jerarquia);
                double derecho = pila.Pop();
                TrazarPop(jerarquia, derecho);
                double izquierdo = pila.Pop();
                TrazarPop(jerarquia, izquierdo);
                pila.Push(izquierdo - derecho);
                TrazarSalida(izquierdo+"-"+derecho+"="+ (izquierdo- derecho), jerarquia);
                TrazarPush(jerarquia, izquierdo + derecho);

            }
            TrazarSalida("</ExpresionPrima>", jerarquia);
        }

        private void TerminoPrima(int jerarquia)
        {
            TrazarEntrada("<TerminoPrima>", jerarquia);
            if (Categoria.MULTIPLICACION.Equals(componente.ObtenerCategoria()))
            {
                Avanzar();
                if (!ManejadorErrores.HayErrores())
                {
                    if ((Categoria.NUMERO_ENTERO.Equals(componente.ObtenerCategoria()) || Categoria.NUMERO_DECIMAL.Equals(componente.ObtenerCategoria())))
                    {

                        double derecho = Convert.ToDouble(componente.ObtenerLexema());
                        double izquierdo = pila.Pop();
                        TrazarPop(jerarquia, izquierdo);
                        pila.Push(izquierdo * derecho);
                        TrazarSalida(izquierdo + "*" + derecho + "=" + (izquierdo * derecho), jerarquia);
                        TrazarPush(jerarquia, izquierdo * derecho);
                        apilar = false;
                        Termino(jerarquia+1);
                    }
                }
                else
                {
                    Termino(jerarquia+1);
                    if (!ManejadorErrores.HayErrores())
                    {
                        double derecho = pila.Pop();
                        TrazarPop(jerarquia, derecho);
                        double izquierdo = pila.Pop();
                        TrazarPop(jerarquia, izquierdo);
                        TrazarPop(jerarquia, izquierdo);
                        pila.Push(izquierdo * derecho);
                        TrazarSalida(izquierdo + "*" + derecho + "=" + (izquierdo * derecho), jerarquia);
                        TrazarPush(jerarquia, izquierdo * derecho);
                        Termino(jerarquia + 1);
                    }
                }
                TrazarSalida("</TerminoPrima>", jerarquia);

            }
            else if (Categoria.DIVISION.Equals(componente.ObtenerCategoria()))
            {
                Avanzar();
                if (!ManejadorErrores.HayErrores())
                {
                    if ((Categoria.NUMERO_ENTERO.Equals(componente.ObtenerCategoria()) || Categoria.NUMERO_DECIMAL.Equals(componente.ObtenerCategoria())))
                    {
                        double derecho = Convert.ToDouble(componente.ObtenerLexema());
                        double izquierdo = pila.Pop();
                        TrazarPop(jerarquia,izquierdo);                        
                        if (derecho == 0)
                        {
                            Error error = Error.CrearErrorSintactico(componente.ObtenerLexema(), componente.ObtenerCategoria(),
                                componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal(),
                                "Division por cero", "Lei \"" + componente.ObtenerLexema() + "\" y esperaba un entero o NUMERO_DECIMAL diferente de cero"
                                   , "Asegurese de que el caracter sea un Entero o un NUMERO_DECIMAL");

                            ManejadorErrores.Reportar(error);
                            izquierdo = 1;
                            derecho = 1;
                        }                       
                        pila.Push(izquierdo / derecho);
                        apilar = false;
                        TrazarSalida(izquierdo + "/" + derecho + "=" + (izquierdo / derecho), jerarquia);
                        TrazarPush(jerarquia, izquierdo/derecho);                        
                        Termino(jerarquia+1);
                    }
                }
                else
                {
                    Termino(jerarquia+1);
                    if (!ManejadorErrores.HayErrores())
                    {
                        double derecho = pila.Pop();
                        TrazarPop(jerarquia,derecho);
                        double izquierdo = pila.Pop();
                        TrazarPop(jerarquia, izquierdo);                        
                        if (derecho == 0)
                        {
                            Error error = Error.CrearErrorSintactico(componente.ObtenerLexema(), componente.ObtenerCategoria(),
                                componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal(),
                                "Division por cero", "Lei \"" + componente.ObtenerLexema() + "\" y esperaba un entero o NUMERO_DECIMAL diferente de cero"
                                   , "Asegurese de que el caracter sea un Entero o un NUMERO_DECIMAL");

                            ManejadorErrores.Reportar(error);
                            izquierdo = 1;
                            derecho = 1;
                        }
                        pila.Push(izquierdo / derecho);
                        TrazarSalida(izquierdo + "/" + derecho + "=" + (izquierdo / derecho), jerarquia);
                        TrazarPush(jerarquia, izquierdo/derecho);
                        
                    }
                }
            }
            TrazarSalida("</TerminoPrima>", jerarquia);
        }

        // <Factor> := ENTERO|NUMERO_DECIMAL|(<Expresion>)
        private void Factor(int jerarquia)
        {
            TrazarEntrada("<Factor>", jerarquia);

            if (Categoria.NUMERO_ENTERO.Equals(componente.ObtenerCategoria()))
            {
                if (apilar)
                {
                    pila.Push(Convert.ToDouble(componente.ObtenerLexema()));
                    TrazarPush(jerarquia, Convert.ToDouble(componente.ObtenerLexema()));
                }
                else
                {
                    apilar = true;                   
                }            

                Avanzar();
            }
            else if (Categoria.NUMERO_DECIMAL.Equals(componente.ObtenerCategoria()))
            {
                if (apilar)
                {
                    pila.Push(Convert.ToDouble(componente.ObtenerLexema()));
                    TrazarPush(jerarquia, Convert.ToDouble(componente.ObtenerLexema()));

                }
                else
                {
                    apilar = true;
                }                
                Avanzar();
            }
            else if (Categoria.PARENTESIS_ABRE.Equals(componente.ObtenerCategoria()))
            {
                Avanzar();
                Expresion(jerarquia);

                if (Categoria.PARENTESIS_CIERRA.Equals(componente.ObtenerCategoria()))
                {
                    Avanzar();
                }
                else
                {
                    Error error = Error.CrearErrorSintactico(componente.ObtenerLexema(), componente.ObtenerCategoria(),
                    componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal(),
                    "componente no valido en la jerarquia actual", "Lei \"" + componente.ObtenerLexema() + "\" y esperaba el parentesis que cierra: \")\"",
                    "Asegurese de que el caracter sea el parentesis que cierra: \")\"");

                    ManejadorErrores.Reportar(error);
                }
            }
            else
            {
                Error error = Error.CrearErrorSintactico(componente.ObtenerLexema(), componente.ObtenerCategoria(),
                  componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal(),
                  "componente no valido en la jerarquia actual", "Lei \"" + componente.ObtenerLexema() + "\" y esperaba un entero, NUMERO_DECIMAL o parentesis que abre" +
                  "un Numero, NUMERO_DECIMAL o parentesis que abre" + ")",
                  "Asegurese de que el caracter sea un entero, NUMERO_DECIMAL o parentesis que abre");

                ManejadorErrores.Reportar(error);

                throw new Exception("Se ha presentado un error de tipo Stopper durante el analisis sintactico verifique la consola de errores");
            }
            TrazarSalida("</Factor>", jerarquia);
        }

        private void Avanzar()
        {
            componente = analex.Analizar();
        }

        private void TrazarEntrada(string NombreRegla, int jerarquia)
        {
            TrazaDerivacion.Append(FormarCadenaEspaciosEnBlanco(jerarquia));
            //TrazaDerivacion.Append("Entrando a derivar regla").Append(NombreRegla).Append("con componente").Append(Componente.ObtenerCategoria());
            TrazaDerivacion.Append("(").Append(componente.ObtenerCategoria()).Append(")");
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
            string EspaciosBlanco = "";
            for (int indice = 1; indice <= jerarquia * 2; indice++)
            {
                EspaciosBlanco = EspaciosBlanco + " ";
            }

            return EspaciosBlanco;

        }
    
    }

}