using CompiladorForm.Transversal;
using System;
using System.Linq;

namespace CompiladorForm.AnalisisLexico
{
    public class AnalizadorLexicoMorse
    {
        private string Lexema;
        private int EstadoActual;
        private bool ContinuarAnalisis = true;
        private int Puntero;
        private int NumeroLineaActual;
        private Linea LineaActual;
        private string CaracterActual;
        private ComponenteLexico Componente;
        public static string Compilado = "";

        public AnalizadorLexicoMorse()
        {
            NumeroLineaActual = 0;
        }
        private void CargarNuevaLinea()
        {
            NumeroLineaActual++;
            LineaActual = Cache.ObtenerCache().ObtenerLinea(NumeroLineaActual);
            NumeroLineaActual = LineaActual.ObtenerNumeroLinea();
            InicializarPuntero();
            if (LineaActual.ObtenerContenido().Equals("@EOF@"))
            {
                ContinuarAnalisis = false;
            }
        }
        private void LeerSiguienteCaracter()
        {
            CaracterActual = "????";

            if (LineaActual.EsFinArchivo())
            {
                CaracterActual = LineaActual.ObtenerContenido();
            }
            if ("@JL@".Equals(LineaActual.ObtenerContenido()))
            {
                CaracterActual = "@JL@";
            }
            else if (Puntero > LineaActual.ObtenerContenido().Length)
            {
                CaracterActual = "@FL@";
            }
            else
            {
                CaracterActual = LineaActual.ObtenerContenido().Substring(Puntero-1,1);
                AdelantarPuntero();
            }
        }
        private void InicializarPuntero()
        {
            Puntero = 1;
        }
        private void AdelantarPuntero()
        {
            Puntero++;
        }

        private void DevolverPuntero()
        {
            Puntero = Puntero != 1 ? Puntero - 1 : 1;
        }

        private void Resetear()
        {
            CaracterActual = string.Empty;
            ResetearLexema();
            ContinuarAnalisis = true;
            EstadoActual = 0;
            Componente = null;
        }
        private void ResetearLexema()
        {
            Lexema = string.Empty;
        }
        public ComponenteLexico Analizar()
        {
            Resetear();
            CargarNuevaLinea();
            while (ContinuarAnalisis)
            {
                if (EstadoActual == 0)
                {
                    EstadoCero();
                }
                else if (EstadoActual == 1)
                {
                    EstadoUno();
                }
                else if (EstadoActual == 2)
                {
                    EstadoDos();
                }
                else if (EstadoActual == 3)
                {
                    EstadoTres();
                }
                else if(EstadoActual == 4)
                {
                    EstadoCuatro();
                }
                else if(EstadoActual == 5)
                {
                    EstadoCinco();
                }
                else if(EstadoActual== 6)
                {
                    EstadoSeis();
                }
                else if(EstadoActual== 7)
                {
                    EstadoSiete();
                }
            }
            return Tablas.TablaMaestra.SincronizarTabla(Componente);
        }

        private void EstadoCero()
        {
            LeerSiguienteCaracter();
            if (EsLetra())
            {
                EstadoActual = 1;
            }
            else if (EsDigito())
            {
                EstadoActual = 2;
            }
            else if (EsSigno())
            {
                EstadoActual = 3;
            }
            else if (EsFinLinea())
            {
                EstadoActual = 6;
            }
            else if (EsSaltoDeLinea() || EsBlanco())
            {
                EstadoActual = 4;
            }
            else if (EsOtro())
            {
                EstadoActual = 5;
            }
            else if (EsFinDocumento())
            {
                ContinuarAnalisis = false;
            }
        }


        private void EstadoUno()
        {
            FormarLetra();
            EstadoActual = 0;
            Compilado += Lexema + " ";
        }

        private void EstadoDos()
        {
            FormarDigito();
            EstadoActual = 0;
            Compilado += Lexema + " ";
        }

        private void EstadoTres()
        {
            FormaSigno();
            EstadoActual = 0;
            Compilado += Lexema + " ";

        }

        private void EstadoCuatro()
        {
            do
            {
                if (EsSaltoDeLinea())
                {
                    CargarNuevaLinea();
                }
                LeerSiguienteCaracter();
            } while (EsSaltoDeLinea() || EsBlanco());
            EstadoActual = 7;
        }

        private void EstadoCinco()
        {
            Lexema = "#";
            Compilado += Lexema + " ";
            EstadoActual = 0;
        }
        private void EstadoSeis()
        {
            Resetear();
            CargarNuevaLinea();
        }

        private void EstadoSiete()
        {
            Lexema = "/";
            Compilado += Lexema +" ";
            DevolverPuntero();
            EstadoActual = 0;
        }

        private bool EsFinDocumento()
        {
            return "@EOF@".Equals(CaracterActual);
        }

        private bool EsOtro()
        {
            return !(DiccionarioToMorse.MorseAlfabeto.ContainsKey(CaracterActual) && DiccionarioToMorse.MorseaNumeros.ContainsKey(CaracterActual) && DiccionarioToMorse.MorseaPuntuacion.ContainsKey(CaracterActual));
        }
        
        private bool EsBlanco()
        {
            return " ".Equals(CaracterActual); 
        }

        private bool EsSaltoDeLinea()
        {
            return "@JL@".Equals(CaracterActual);
        }

        private bool EsFinLinea()
        {
            return "@FL@".Equals(CaracterActual);
            
        }

        private void FormaSigno()
        {
            Lexema = DiccionarioToMorse.MorseaPuntuacion[CaracterActual];
            CrearComponente(Lexema, Categoria.CARACTER, NumeroLineaActual, Puntero - Lexema.Length, Puntero - 1);

        }

        private bool EsSigno()
        {
            char comillaDoble = '"';
            string[] opciones = { ".", ",", "?", "'","!","/","(",")","&",":",";",
            "=","+","-","_", comillaDoble.ToString(),"$","@","¿", "¡"};
            return opciones.Contains(CaracterActual) && DiccionarioToMorse.MorseaPuntuacion.ContainsKey(CaracterActual);
        }

        private void FormarDigito()
        {
            Lexema = DiccionarioToMorse.MorseaNumeros[CaracterActual];
            CrearComponente(Lexema, Categoria.NUMERO, NumeroLineaActual, Puntero - Lexema.Length, Puntero - 1);

        }

        private bool EsDigito()
        {
            return char.IsDigit(CaracterActual.ToCharArray()[0]);
        }

        private bool EsLetra()
        {
            return char.IsLetter(CaracterActual.ToCharArray()[0]) && DiccionarioToMorse.MorseAlfabeto.ContainsKey(CaracterActual);
        }

        private void FormarLetra()
        {
            Lexema = DiccionarioToMorse.MorseAlfabeto[CaracterActual];
            CrearComponente(Lexema, Categoria.LETRA, NumeroLineaActual, Puntero - Lexema.Length, Puntero - 1);
        }
        private void CrearComponente(string Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal)
        {
             if (IdentificadorTipoComponenteUtil.EsLiteral(Categoria))
            {
                Componente = ComponenteLexico.CrearLiteral(Lexema, Categoria, NumeroLinea, PosicionIncial, PosicionFinal);
            }
            else
            {
                Componente = ComponenteLexico.CrearDummy(Lexema, Categoria, NumeroLinea, PosicionIncial, PosicionFinal);
            }
        }
    }



}
