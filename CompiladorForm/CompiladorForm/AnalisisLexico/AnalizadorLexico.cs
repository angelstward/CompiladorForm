using CompiladorForm.Transversal;

namespace CompiladorForm.AnalisisLexico
{
    public class AnalizadorLexico
    {
        private int Puntero;
        private int NumeroLineaActual;
        private Linea LineaActual;
        private string CaracterActual;
        private string Lexema;
        private int EstadoActual;
        private bool ContiniarAnalisis;

        private AnalizadorLexico()
        {
            NumeroLineaActual = 0;
        }

        private void CargarNuevaLinea()
        {
            NumeroLineaActual++;
            LineaActual = Cache.ObtenerCache().ObtenerLinea(NumeroLineaActual);
            NumeroLineaActual = LineaActual.ObtenerNumeroLinea();
            InicializarPuntero();
        }

        private void InicializarPuntero()
        {
            Puntero = 1;
        }

        private void DevolverPuntero()
        {
            Puntero = Puntero != 1 ? Puntero - 1 : 1;
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
                CaracterActual = LineaActual.ObtenerContenido().Substring(Puntero, 1);
                AdelantarPuntero();
            }
        }
        private void AdelantarPuntero()
        {
            Puntero++;
        }
        private void FormarComponente()
        {
            Lexema = Lexema + CaracterActual;
        }
        private void ResetearLexema()
        {
            Lexema = string.Empty;
        }
        private void DevorarEspaciosBlanco()
        {
            string Blanco = " ";
            while (CaracterActual.Equals(Blanco))
            {
                LeerSiguienteCaracter();
            }
        }
        private void Resetear()
        {

        }

        public void Analizar()
        {
            Resetear();
            while (ContiniarAnalisis)
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
                else if (EstadoActual == 14)
                {
                    EstadoCatorce();
                }
                else if (EstadoActual == 15)
                {
                    EstadoQuince();
                }
                else if (EstadoActual == 17)
                {
                    EstadoDiecisiete();
                }
            }
        }



        private bool EsLetra()
        {
            return char.IsLetter(CaracterActual.ToCharArray()[0]);
        }

        private bool EsSignoPesos()
        {
            return "$".Equals(CaracterActual);
        }
        private bool EsGuionBajo()
        {
            return "_".Equals(CaracterActual);
        }
        private bool EsDigito()
        {
            return char.IsDigit(CaracterActual.ToCharArray()[0]);
        }
        private bool EsSignoDivision()
        {
            return "/".Equals(CaracterActual);
        }

        private bool EsSignoMultiplicacion()
        {
            return "*".Equals(CaracterActual);
        }

        private bool EsSignoResta()
        {
            return "-".Equals(CaracterActual);
        }

        private bool EsSignoSuma()
        {
            return "+".Equals(CaracterActual);
        }
        private bool EsComa()
        {
            return ",".Equals(CaracterActual);
        }
        private void EstadoCero()
        {
            LeerSiguienteCaracter();
            DevorarEspaciosBlanco();
            if (EsLetra() || EsSignoPesos() || EsGuionBajo())
            {
                EstadoActual = 4;
                FormarComponente();
            }
            else if (EsDigito())
            {
                EstadoActual = 1;
                FormarComponente();
            }
            else if (EsSignoSuma())
            {

            }
            else if (EsSignoResta())
            {

            }
            else if (EsSignoMultiplicacion())
            {

            }
            else if (EsSignoDivision())
            {

            }
            //Pendiente terminar
        }



        private void EstadoUno()
        {
            LeerSiguienteCaracter();

            if (EsDigito())
            {
                EstadoActual = 1;
                FormarComponente();
            }
            else if (EsComa())
            {
                EstadoActual = 2;
                FormarComponente();
            }
            else
            {
                EstadoActual = 14;
            }
        }
        private void EstadoDos()
        {
            LeerSiguienteCaracter();

            if (!EsDigito())
            {
                EstadoActual = 17;
            }
            else
            {
                EstadoActual = 3;
                FormarComponente();
            }
        }
        private void EstadoTres()
        {
            LeerSiguienteCaracter();

            if (!EsDigito())
            {
                EstadoActual = 15;
            }
            else
            {
                EstadoActual = 3;
                FormarComponente();
            }
        }
        private void EstadoCatorce()
        {
            DevolverPuntero();
            ContiniarAnalisis = false;
            string Categoria = "NUMERO ENTERO";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

        }

        private void EstadoQuince()
        {
            DevolverPuntero();
            ContiniarAnalisis = false;
            string Categoria = "NUMERO ENTERO";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }

        private void EstadoDiecisiete()
        {
            DevolverPuntero();
            ContiniarAnalisis = false;
            string Causa = "Se esperaba un digito y se recibió" + CaracterActual;
            string Falla = "NUMERO DECIMAL NO VALIDO";
            string Solucion = "";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }

    }
}
