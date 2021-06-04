
using CompiladorForm.AnalisisLexico;
using CompiladorForm.GestorErrores;
using CompiladorForm.Transversal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CompiladorForm.AnalisisSintactico
{
    public class AnalizadorSintactico
    {
        private readonly AnalizadorLexico analex = new AnalizadorLexico();
        private ComponenteLexico componente = null;
        private string traza;
        private readonly bool mostrarTraza = true;
        private readonly Stack<double> pila = new Stack<double>();
        private string lexemaAnterior = "";
        private bool apilar = true;

        public Dictionary<string, object> Analizar(bool x)
        {
            

            traza = "";
            pila.Clear();
            Avanzar();
            Expresion("-");
            Dictionary<string, object> resultado = new Dictionary<string, object>
            {
                { "COMPONENTE", componente },
                { "PILA", pila }
            };

            return resultado;
        }

        private void Expresion(string posicion)
        {
            posicion = posicion + "-->";
            formarTrazaEntrada(posicion, "Expresion");
            Termino(posicion);
            ExpresionPrima(posicion);
            formarTrazaSalida(posicion, "Expresion");
        }

      
        private void Termino(string posicion)
        {
            posicion = posicion + "-->";
            formarTrazaEntrada(posicion, "Multdiv");
            Factor(posicion);
            TerminoPrima(posicion);
            formarTrazaSalida(posicion, "Multdiv");
        }

        private void ExpresionPrima(string posicion)
        {
            posicion = posicion + "-->"; componente.ObtenerCategoria();
            formarTrazaEntrada(posicion, "CSumaResta");

            if (Categoria.SUMA.Equals(componente.ObtenerCategoria()))
            {
                Avanzar();
                Expresion(posicion);
                if (!ManejadorErrores.HayErrores())
                {
                    double derecho = pila.Pop();
                    double izquierdo = pila.Pop();
                    pila.Push(izquierdo + derecho);
                    traza = traza + posicion + "Operando: " + izquierdo + "+" + derecho + "\n";
                }
            }
            else if (Categoria.RESTA.Equals(componente.ObtenerCategoria()))
            {
                Avanzar();
                Expresion(posicion);
                if (!ManejadorErrores.HayErrores())
                {
                    double derecho = pila.Pop();
                    double izquierdo = pila.Pop();
                    pila.Push(izquierdo + derecho);
                    traza = traza + posicion + "Operando: " + izquierdo + "+" + derecho + "\n";
                }
            }
            formarTrazaSalida(posicion, "CSumaResta");
        }

        private void TerminoPrima(string posicion)
        {
            posicion = posicion + "-->";
            formarTrazaEntrada(posicion, "CMultdiv");
            if (Categoria.MULTIPLICACION.Equals(componente.ObtenerCategoria()))
            {
                Avanzar();
                if (!ManejadorErrores.HayErrores())
                {
                    if ((Categoria.NUMERO_ENTERO.Equals(componente.ObtenerCategoria()) || Categoria.NUMERO_DECIMAL.Equals(componente.ObtenerCategoria())))
                    {
                        double derecho = Convert.ToDouble(componente.ObtenerLexema());
                        double izquierdo = pila.Pop();
                        pila.Push(izquierdo * derecho);
                        apilar = false;
                        traza = traza + posicion + "Operando: " + izquierdo + "*" + derecho + "\n";
                        Termino(posicion);
                    }
                }
                else
                {
                    Termino(posicion);
                    if (!ManejadorErrores.HayErrores())
                    {
                        double derecho = pila.Pop();
                        double izquierdo = pila.Pop();
                        pila.Push(izquierdo * derecho);
                        traza = traza + posicion + "Operando: " + izquierdo + "*" + derecho + "\n";
                    }
                }

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
                        traza = traza + posicion + "Operando: " + izquierdo + "/" + derecho + "\n";
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
                        Termino(posicion);
                    }
                }
                else
                {
                    Termino(posicion);
                    if (!ManejadorErrores.HayErrores())
                    {
                        double derecho = pila.Pop();
                        double izquierdo = pila.Pop();
                        traza = traza + posicion + "Operando: " + izquierdo + "/" + derecho + "\n";
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
                    }
                }
            }
            formarTrazaSalida(posicion, "CMultDiv");
        }

        // <Factor> := ENTERO|NUMERO_DECIMAL|(<Expresion>)
        private void Factor(string posicion)
        {
            posicion = posicion + "-->";
            formarTrazaEntrada(posicion, "Resto");

            if (Categoria.NUMERO_ENTERO.Equals(componente.ObtenerCategoria()))
            {
                if (apilar)
                {
                    if (lexemaAnterior.Equals("-"))
                    {
                        pila.Push(Convert.ToDouble(componente.ObtenerLexema()) * -1);
                    }
                    else
                    {
                        pila.Push(Convert.ToDouble(componente.ObtenerLexema()));
                    }
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
                    if (lexemaAnterior.Equals("-"))
                    {
                        pila.Push(Convert.ToDouble(componente.ObtenerLexema()) * -1);
                    }
                    else
                    {
                        pila.Push(Convert.ToDouble(componente.ObtenerLexema()));
                    }
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
                Expresion(posicion);

                if (Categoria.PARENTESIS_CIERRA.Equals(componente.ObtenerCategoria()))
                {
                    Avanzar();
                }
                else
                {
                    Error error = Error.CrearErrorSintactico(componente.ObtenerLexema(), componente.ObtenerCategoria(),
                    componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal(),
                    "componente no valido en la posicion actual", "Lei \"" + componente.ObtenerLexema() + "\" y esperaba el parentesis que cierra: \")\"",
                    "Asegurese de que el caracter sea el parentesis que cierra: \")\"");

                    ManejadorErrores.Reportar(error);
                }
            }
            else
            {
                Error error = Error.CrearErrorSintactico(componente.ObtenerLexema(), componente.ObtenerCategoria(),
                  componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal(),
                  "componente no valido en la posicion actual", "Lei \"" + componente.ObtenerLexema() + "\" y esperaba un entero, NUMERO_DECIMAL o parentesis que abre" +
                  "un Numero, NUMERO_DECIMAL o parentesis que abre" + ")",
                  "Asegurese de que el caracter sea un entero, NUMERO_DECIMAL o parentesis que abre");

                ManejadorErrores.Reportar(error);

                throw new Exception("Se ha presentado un error de tipo Stopper durante el analisis sintactico verifique la consola de errores");
            }
            formarTrazaSalida(posicion, "Resto");
        }

        private void Avanzar()
        {            
            componente = analex.Analizar();
        }

        private void formarTrazaEntrada(string posicion, string nombreRegla)
        {
            traza = traza + posicion + "Entrada Regla :" + nombreRegla + ", Categoria: " + componente.ObtenerCategoria() + "\n";
            //imprimirTraza();
        }

        private void formarTrazaSalida(string posicion, string Nombreregla)
        {
            traza = traza + posicion + "Salida Regla :" + Nombreregla + ", componente" + componente.ObtenerCategoria() + "\n";
            //imprimirTraza();
        }

        private void imprimirTraza()
        {
            if (mostrarTraza)
            {
                MessageBox.Show(traza);
            }
        }
    }

}