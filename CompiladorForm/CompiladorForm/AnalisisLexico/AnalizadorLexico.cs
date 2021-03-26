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
                else if(EstadoActual == 4)
                {
                    EstadoCuatro();
                }
                                else if(EstadoActual == 5)
                {
                    EstadoCinco();
                }
                                else if(EstadoActual == 6)
                {
                    EstadoSeis();
                }
                                else if(EstadoActual == 7)
                {
                    EstadoSiete();
                }
                else if (EstadoActual == 14)
                {
                    EstadoCatorce();
                }
                else if (EstadoActual == 15)
                {
                    EstadoQuince();
                }
                else if(EstadoActual == 16)
                {
                    EstadoDieciseis();
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
                EstadoActual = 5;
            }
            else if (EsSignoResta())
            {
              EstadoActual = 6;
            }
            else if (EsSignoMultiplicacion())
            {
                EstadoActual = 7;
            }
            else if (EsSignoDivision())
            {
                 EstadoActual = 8;
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

                private void EstadoCuatro()
        {
            LeerSiguienteCaracter();
            if(EsLetra() || EsDigito() || EsGuionBajo() || EsSignoPesos())
            {
                FormarComponente();
            }
            else
            {
                EstadoActual = 16;
            }
        }

        private void EstadoCinco()
        {
            ContiniarAnalisis = false;
            string Categoria = "SUMA";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }

        private void EstadoSeis()
        {
            ContiniarAnalisis = false;
            string Categoria = "RESTA";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }

        private void EstadoSiete()
        {
            ContiniarAnalisis = false;
            string Categoria = "MULTIPLICACION";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }

        private void EstadoOcho()
        {
            LeerSiguienteCaracter();
            if (EsAsterisco()){
                EstadoActual = 34;
            }else if (EsSignoDivision())
            {
                EstadoActual = 36;
            }
            else
            {
                EstadoActual = 33;
            }
        }

                private bool EsAsterico()
        {
            return "*".Equals(CaracterActual);
        }

        private void EstadoTrece()
        {
            LeerSiguienteCaracter();

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

        private void EstadoDieciseis()
        {
            DevolverPuntero();
            ContiniarAnalisis = false;
            string Categoria = "IDENTIFICADOR";
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

                private void EstadoTreintaYCuatro()
        {
            LeerSiguienteCaracter();
            if (EsAsterico())
            {
                EstadoActual = 35;
            }
        }

                private void EstadoTreintaYCinco()
        {
            LeerSiguienteCaracter();
            if (!EsAsterico())
            {
                EstadoActual = 34;
            }else if (EsSignoDivision())
            {
                EstadoActual = 0;
            }
        }

        private void EstadoTreintaYTres()
        {
            DevolverPuntero();
            ContiniarAnalisis = false;
            string Categoria = "DIVISION";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }

        private void EstadoTreintaYSeis()
        {
            LeerSiguienteCaracter()
            if ("@FL@".Equals(CaracterActual))
            {
                EstadoActual = 13
            }
        }


    }
}
