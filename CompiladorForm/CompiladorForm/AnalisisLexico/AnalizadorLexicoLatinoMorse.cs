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
                /* else if(EstadoActual == 4)
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
                 }*/
             }
             return Tablas.TablaMaestra.SincronizarTabla(Componente);
         }

         private void EstadoCero()
         {
            LeerSiguienteCaracter();
            if (EsFinDocumento())
            {
                EstadoActual = 1;
            }else if (EsFinLinea()) {

                EstadoActual = 2;
            }else if ("A".Equals(CaracterActual) || "a".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();

            }
            else if ("B".Equals(CaracterActual) || "b".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("C".Equals(CaracterActual) || "c".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("D".Equals(CaracterActual) || "d".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("E".Equals(CaracterActual) || "e".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("F".Equals(CaracterActual) || "f".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("G".Equals(CaracterActual) || "g".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("H".Equals(CaracterActual) || "h".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("I".Equals(CaracterActual) || "i".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("J".Equals(CaracterActual) || "j".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("K".Equals(CaracterActual) || "k".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("L".Equals(CaracterActual) || "l".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("M".Equals(CaracterActual) || "m".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("N".Equals(CaracterActual) || "n".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("O".Equals(CaracterActual) || "o".Equals(CaracterActual))
            {
                EstadoActual = 3;
                FormarComponente();
            }
            else if ("P".Equals(CaracterActual) || "p".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("Q".Equals(CaracterActual) || "q".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("R".Equals(CaracterActual) || "r".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("S".Equals(CaracterActual) || "s".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("T".Equals(CaracterActual) || "t".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("U".Equals(CaracterActual) || "u".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("V".Equals(CaracterActual) || "v".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("W".Equals(CaracterActual) || "w".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("X".Equals(CaracterActual) || "x".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("Y".Equals(CaracterActual) || "y".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("Z".Equals(CaracterActual) || "z".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if (EsBlanco())
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("Á".Equals(CaracterActual) || "á".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("É".Equals(CaracterActual) || "é".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("Ó".Equals(CaracterActual) || "ó".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("Ñ".Equals(CaracterActual) || "ñ".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("0".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("1".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("2".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("3".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("4".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("5".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("6".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("7".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("8".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("9".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if (".".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if (",".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("¿".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("?".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("'".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("¡".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("!".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("/".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("(".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if (")".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("&".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("$".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("+".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("-".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if (":".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if (";".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("=".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("_".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("\"".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else if ("@".Equals(CaracterActual))
            {
                  EstadoActual = 3;FormarComponente();
            }
            else
            {
                EstadoActual = 4;
            }

        }

        
         //private void EstadoUno()
         //{
         //    FormarLetra();
         //    EstadoActual = 0;
         //    Compilado += Lexema + " ";
         //}

         //private void EstadoDos()
         //{
         //    FormarDigito();
         //    EstadoActual = 0;
         //    Compilado += Lexema + " ";
         //}

         //private void EstadoTres()
         //{
         //    FormaSigno();
         //    EstadoActual = 0;
         //    Compilado += Lexema + " ";

         //}

         //private void EstadoCuatro()
         //{
         //    do
         //    {
         //        if (EsSaltoDeLinea())
         //        {
         //            CargarNuevaLinea();
         //        }
         //        LeerSiguienteCaracter();
         //    } while (EsSaltoDeLinea() || EsBlanco());
         //    EstadoActual = 7;
         //}

         //private void EstadoCinco()
         //{
         //    Lexema = "#";
         //    Compilado += Lexema + " ";
         //    EstadoActual = 0;
         //}
         //private void EstadoSeis()
         //{
         //    Resetear();
         //    CargarNuevaLinea();
         //}

         //private void EstadoSiete()
         //{
         //    Lexema = "/";
         //    Compilado += Lexema +" ";
         //    DevolverPuntero();
         //    EstadoActual = 0;
         //}

         private bool EsFinDocumento()
         {
             return "@EOF@".Equals(CaracterActual);
         }

         //private bool EsOtro()
         //{
         //    return !(DiccionarioLatinoMorse.MorseAlfabeto.ContainsKey(CaracterActual) && DiccionarioLatinoMorse.MorseaNumeros.ContainsKey(CaracterActual) && DiccionarioLatinoMorse.MorseaPuntuacion.ContainsKey(CaracterActual));
         //}

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

         private void FormarComponente()
         {

         }

        /*private void FormaSigno()
        {

            Lexema = DiccionarioLatinoMorse.MorseaPuntuacion[CaracterActual];
            CrearComponente(Lexema, Categoria.CARACTER, NumeroLineaActual, Puntero - Lexema.Length, Puntero - 1);

        }

        private bool EsSigno()
        {
            char comillaDoble = '"';
            string[] opciones = { ".", ",", "?", "'","!","/","(",")","&",":",";",
            "=","+","-","_", comillaDoble.ToString(),"$","@","¿", "¡"};
            return opciones.Contains(CaracterActual) && DiccionarioLatinoMorse.MorseaPuntuacion.ContainsKey(CaracterActual);
        }

        private void FormarDigito()
        {
            Lexema = DiccionarioLatinoMorse.MorseaNumeros[CaracterActual];
            CrearComponente(Lexema, Categoria.NUMERO, NumeroLineaActual, Puntero - Lexema.Length, Puntero - 1);

        }

        private bool EsDigito()
        {
            return char.IsDigit(CaracterActual.ToCharArray()[0]);
        }

        private bool EsLetra()
        {
            return char.IsLetter(CaracterActual.ToCharArray()[0]) && DiccionarioLatinoMorse.MorseAlfabeto.ContainsKey(CaracterActual);
        }

        private void FormarLetra()
        {
            Lexema = DiccionarioLatinoMorse.MorseAlfabeto[CaracterActual];
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
        }*/
    }



}
