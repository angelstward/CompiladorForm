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

        public void Analizar()
        {
            CargarNuevaLinea();
            while (ContinuarAnalisis)
            {
                LeerSiguienteCaracter();
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
        }
       
        private void EstadoSiete()
        {
            if (!EsSaltoDeLineaOBlanco())
            {
                Lexema = "/";
            }
            Compilado += Lexema +" ";
            EstadoActual = 0;
        }
        private void EstadoSeis()
        {
            Compilado += Lexema + " ";
            CargarNuevaLinea();

        }
        private void EstadoCinco()
        {
            Lexema = "#";
            Compilado += Lexema + " ";
            //LeerSiguienteCaracter();
            EstadoActual = 0;
        }
        private void EstadoCuatro()
        {
            if (EsOtro() || !EsSaltoDeLineaOBlanco())
            {
                EstadoActual = 7;
            }
            else if (EsSaltoDeLineaOBlanco())
            {
                EstadoActual = 4;
            }               
        }        

        private void EstadoTres()
        {
            FormaSigno();
            EstadoActual = 0;
            Compilado += Lexema + " ";
            //LeerSiguienteCaracter();
            
        }

        private void EstadoDos()
        {
            FormarDigito();
            EstadoActual = 0;
            Compilado += Lexema + " ";
            //LeerSiguienteCaracter();
        }

        private void EstadoUno()
        {
            FormarLetra();
            EstadoActual = 0;
            Compilado += Lexema + " ";
            //LeerSiguienteCaracter();            
        }

        private void EstadoCero()
        {
            //LeerSiguienteCaracter();
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
            else if (EsSaltoDeLineaOBlanco())
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

        private bool EsFinDocumento()
        {
            return "@EOF@".Equals(CaracterActual);
        }

        private bool EsOtro()
        {
            return DiccionarioToMorse.MorseAlfabeto.ContainsKey(CaracterActual) || DiccionarioToMorse.MorseaNumeros.ContainsKey(CaracterActual) || DiccionarioToMorse.MorseaPuntuacion.ContainsKey(CaracterActual);
        }
        
        private bool EsSaltoDeLineaOBlanco()
        {
            string[] blancoSalto = { " ", "\n", "\r" };
            return blancoSalto.Contains(CaracterActual);
        }

        private bool EsFinLinea()
        {
            return "@FL@".Equals(CaracterActual);
            
        }

        private void FormaSigno()
        {
            Lexema = DiccionarioToMorse.MorseaPuntuacion[CaracterActual];
        }

        private bool EsSigno()
        {
            char comillaDoble = '"';
            string[] opciones = { ".", ",", "?", "'","!","/","(",")","&",":",";",
            "=","+","-","_", comillaDoble.ToString(),"$","@","¿", "¡"};
            return opciones.Contains(CaracterActual);
        }

        private void FormarDigito()
        {
            Lexema = DiccionarioToMorse.MorseaNumeros[CaracterActual];
        }

        private bool EsDigito()
        {
            return char.IsDigit(CaracterActual.ToCharArray()[0]);
        }

        private bool EsLetra()
        {
            return char.IsLetter(CaracterActual.ToCharArray()[0]);
        }

        private void FormarLetra()
        {
            Lexema = DiccionarioToMorse.MorseAlfabeto[CaracterActual];
        }
    }

}
