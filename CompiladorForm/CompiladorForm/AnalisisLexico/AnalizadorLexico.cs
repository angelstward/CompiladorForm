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
        private bool ContinuarAnalisis;
        private ComponenteLexico Componente;





        public AnalizadorLexico()
        {
            NumeroLineaActual = 0;
            CargarNuevaLinea();
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

        private bool EsFinalLinea()
        {
            return "@FL@".Equals(CaracterActual);
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
            ContinuarAnalisis = falase;
            Componente = null;
            ResetearLexema();

        }

        public ComponenteLexico Analizar()
        {
            Resetear();
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
                else if (EstadoActual == 4)
                {
                    EstadoCuatro();
                }
                else if (EstadoActual == 5)
                {
                    EstadoCinco();
                }
                else if (EstadoActual == 6)
                {
                    EstadoSeis();
                }
                else if (EstadoActual == 7)
                {
                    EstadoSiete();
                }
                else if (EstadoActual == 8)
                {
                    EstadoOcho();
                }
                else if (EstadoActual == 9)
                {
                    EstadoNueve();
                }
                else if (EstadoActual == 10)
                {
                    EstadoDiez();
                }
                else if (EstadoActual == 11)
                {
                    EstadoOnce();
                }
                else if (EstadoActual == 12)
                {
                    EstadoDoce();
                }
                else if (EstadoActual == 13)
                {
                    EstadoTrece();
                }
                else if (EstadoActual == 14)
                {
                    EstadoCatorce();
                }
                else if (EstadoActual == 15)
                {
                    EstadoQuince();
                }
                else if (EstadoActual == 16)
                {
                    EstadoDieciseis();
                }
                else if (EstadoActual == 17)
                {
                    EstadoDiecisiete();
                }
                else if (EstadoActual == 18)
                {
                    EstadoDieciocho();
                }
                else if (EstadoActual == 19)
                {
                    EstadoDiecinueve();
                }
                else if (EstadoActual == 20)
                {
                    EstadoVeinte();
                }
                else if (EstadoActual == 21)
                {
                    EstadoVeintiuno();
                }
                else if (EstadoActual == 22)
                {
                    EstadoVeintidos();
                }
                else if (EstadoActual == 23)
                {
                    EstadoVeintitres();
                }
                else if (EstadoActual == 24)
                {
                    EstadoVeinticuatro();
                }
                else if (EstadoActual == 25)
                {
                    EstadoVeinticinco();
                }
                else if (EstadoActual == 26)
                {
                    EstadoVeintiseis();
                }
                else if (EstadoActual == 27)
                {
                    EstadoVeintisiete();

                }
                else if (EstadoActual == 28)
                {
                    EstadoVeintiocho();
                }
                else if (EstadoActual == 29)
                {
                    EstadoVeintinueve();
                }
                else if (EstadoActual == 30)
                {
                    EstadoTreinta();
                }
                else if (EstadoActual == 31)
                {
                    EstadoTreintaiuno();
                }
                else if (EstadoActual == 32)
                {
                    EstadoTreintaidos();
                }
                else if (EstadoActual == 33)
                {
                    EstadoTreintaitres();
                }
                else if (EstadoActual == 34)
                {
                    EstadoTreintaicuatro();
                }
                else if (EstadoActual == 35)
                {
                    EstadoTreintaicinco();
                }
                else if (EstadoActual == 36)
                {
                    EstadoTreintaiseis();
                }

            }
            //Colocar el componente en la tabla de símbolos.
            return TablaMaestra.SincronizarTabla(Componente);
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

        private bool EsAsterico()
        {
            return "*".Equals(CaracterActual);
        }

        private bool EsPorcentaje()
        {
            return "%".Equals(CaracterActual);

        }
        private bool EsParentesisAbre()
        {
            return "(".Equals(CaracterActual);

        }
        private bool EsParentesisCierra()
        {
            return ")".Equals(CaracterActual);

        }

        private bool EsFinArchivo()
        {
            return "@EOF@".Equals(CaracterActual);

        }
        private bool EsSignoIgual()
        {
            return "=".Equals(CaracterActual);

        }
        private bool EsSignoMenorQue()
        {
            return "<".Equals(CaracterActual);

        }
        private bool EsSignoMayorQue()
        {
            return ">".Equals(CaracterActual);

        }

        private bool EsAsignacion()
        {
            return ":".Equals(CaracterActual);

        }

        private bool EsSignoDiferenteQue()
        {
            return "!".Equals(CaracterActual);

        }
        private bool EsAsterisco()
        {
            return "*".Equals(CaracterActual);
        }
        private bool EsFinLinea()
        {
            return "@FL@".Equals(CaracterActual);
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
            else if (EsPorcentaje())
            {
                EstadoActual = 9;
            }
            else if (EsParentesisAbre())
            {
                EstadoActual = 10;
            }
            else if (EsParentesisCierra())
            {
                EstadoActual = 11;
            }
            else if (EsFinArchivo())
            {
                EstadoActual = 12;
            }
            else if (EsSignoIgual())
            {
                EstadoActual = 12;
            }
            else if (EsSignoMenorQue())
            {
                EstadoActual = 20;
            }
            else if (EsSignoMayorQue())
            {
                EstadoActual = 21;
            }
            else if (EsAsignacion())
            {
                EstadoActual = 22;
            }
            else if (EsSignoDiferenteQue())
            {
                EstadoActual = 30;
            }
            else if (EsFinLinea())
            {
                EstadoActual = 13;
            }
            else
            {
                EstadoActual = 18;
            }
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
            if (EsLetra() || EsDigito() || EsGuionBajo() || EsSignoPesos())
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
            CrearComponente(Lexema, Categoria.SUMA, NumeroLinea, Puntero - Lexema.Length, Puntero - 1);
            ContinuarAnalisis = false;

        }

        private void EstadoSeis()
        {
           
            CrearComponente(Lexema, Categoria.RESTA, NumeroLinea, Puntero - Lexema.Length, Puntero - 1);
            ContinuarAnalisis = false;
        }

        private void EstadoSiete()
        {
            CrearComponente(Lexema, Categoria.MULTIPLICACION, NumeroLinea, Puntero - Lexema.Length, Puntero - 1);
            ContinuarAnalisis = false;
        }

        private void EstadoOcho()
        {
            LeerSiguienteCaracter();
            if (EsAsterisco())
            {
                EstadoActual = 34;
            }
            else if (EsSignoDivision())
            {
                EstadoActual = 36;
            }
            else
            {
                EstadoActual = 33;
            }
        }
        private void EstadoNueve()

        {

            CrearComponente(Lexema, Categoria.MODULO, NumeroLinea, Puntero - Lexema.Length, Puntero - 1);
            ContinuarAnalisis = false;
        }
        private void EstadoDiez()
        {
            ContinuarAnalisis = false;
            string Categoria = "PARENTESIS ABRE";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoOnce()
        {
            ContinuarAnalisis = false;
            string Categoria = "PARENTESIS CIERRA";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoDoce()
        {
            ContinuarAnalisis = false;
            string Categoria = "FIN DE ARCHIVO";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }

        private void EstadoTrece()
        {
            CargarNuevaLinea();
        }


        private void EstadoCatorce()
        {
            DevolverPuntero();
            CrearComponente(Lexema, Categoria.NUMERO_ENTERO, NumeroLinea, Puntero - Lexema.Length, Puntero - 1);
            ContinuarAnalisis = false;

        }

        private void EstadoQuince()
        {
            DevolverPuntero();
            CrearComponente(Lexema, Categoria.NUMERO_DECIMAL, NumeroLinea, Puntero - Lexema.Length, Puntero - 1);
            ContinuarAnalisis = false;
        }

        private void EstadoDieciseis()
        {
            DevolverPuntero();
            CrearComponente(Lexema, Categoria.IDENTIFICADOR, NumeroLinea, Puntero - Lexema.Length, Puntero - 1);
            ContinuarAnalisis = false;

        }

        private void EstadoDiecisiete()
        {
            DevolverPuntero();
            
            ContinuarAnalisis = false;
            string Causa = "Se esperaba un digito y se recibió: " + CaracterActual;
            string Falla = "NUMERO DECIMAL NO VALIDO";
            string Solucion = "";
            Error error = Error.CrearErrorLexico(Lexema, Categoria.NUMERO_DECIMAL, NumeroLineaActual, Puntero - Lexema.Lengt, Puntero - 1, Causa, Falla, Solucion);
            ManejadorErrores.Reportar(error);
            CrearComponente("1", error.ObtenerCategoria(), error.ObtenerNumeroLinea(), error.ObtenerPosicionInicial(), error.ObtenerPosicionFinal());
        }
        private void EstadoDieciocho()
        {
            ContinuarAnalisis = false;
            string Causa = "Se esperaba un caracter válido el lenguaje y se recibió " + CaracterActual;
            string Falla = "ERROR SIMBOLO NO VALIDO";
            string Solucion = "Asegúrese que el caracter sea válido";
            Error error = Error.CrearErrorLexico(Lexema, Categoria.NUMERO_DECIMAL, NumeroLineaActual, Puntero - Lexema.Lengt, Puntero - 1, Causa, Falla, Solucion);
            ManejadorErrores.Reportar(error);
            throw new Exception("Se ha presentado un error de tipo stopper del proceso de compilación. Por favor revise la consola de errores...");
        }
        private void EstadoDiecinueve()
        {
            ContinuarAnalisis = false;
            string Categoria = "IGUAL QUE";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoVeinte()
        {
            LeerSiguienteCaracter();
            if (EsSignoMayorQue())
            {
                EstadoActual = 23;
            }
            if (EsSignoIgual())
            {
                EstadoActual = 24;
            }
            else
            {
                EstadoActual = 25;
            }
        }
        private void EstadoVeintiuno()
        {
            LeerSiguienteCaracter();
            if (EsSignoIgual())
            {
                EstadoActual = 26;
            }
            else
            {
                EstadoActual = 27;
            }
        }
        private void EstadoVeintidos()
        {
            LeerSiguienteCaracter();
            if (EsSignoIgual())
            {
                EstadoActual = 28;
            }
            else
            {
                EstadoActual = 29;
            }
        }
        private void EstadoVeintitres()
        {
            ContinuarAnalisis = false;
            string Categoria = "DIFERENTE QUE";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoVeinticuatro()
        {
            ContinuarAnalisis = false;
            string Categoria = "MENOR O IGUAL QUE";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

        }
        private void EstadoVeinticinco()
        {
            DevolverPuntero();
            ContinuarAnalisis = false;
            string Categoria = "MENOR QUE";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoVeintiseis()
        {
            ContinuarAnalisis = false;
            string Categoria = "MAYOR O IGUAL QUE";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoVeintisiete()
        {
            DevolverPuntero();
            ContinuarAnalisis = false;
            string Categoria = "MAYOR QUE";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoVeintiocho()
        {
            ContinuarAnalisis = false;
            string Categoria = "ASIGNACION";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoVeintinueve()
        {

            DevolverPuntero();
            ContinuarAnalisis = false;
            string Causa = "Se esperaba un = y se recibio " + CaracterActual;
            string Falla = "ERROR ASIGNACION NO VALIDA";
            string Solucion = "";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoTreinta()
        {
            LeerSiguienteCaracter();
            if (EsSignoIgual())
            {
                EstadoActual = 31;
            }
            else
            {
                EstadoActual = 32;
            }
        }
        private void EstadoTreintaiuno()
        {
            ContinuarAnalisis = false;
            string Categoria = "DIFERENTE QUE";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoTreintaidos()
        {
            DevolverPuntero();
            ContinuarAnalisis = false;
            string Causa = "Se esperaba un = y se recibio " + CaracterActual;
            string Falla = "ERROR ASIGNACION NO VALIDA";
            string Solucion = "";
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
        }
        private void EstadoTreintaicuatro()
        {
            LeerSiguienteCaracter();
            if (EsAsterico())
            {
                EstadoActual = 35;
            }
        }

        private void EstadoTreintaicinco()
        {
            LeerSiguienteCaracter();
            if (!EsAsterico())
            {
                EstadoActual = 34;
            }
            else if (EsSignoDivision())
            {
                EstadoActual = 0;
            }
        }

        private void EstadoTreintaitres()
        {
            DevolverPuntero();
            CrearComponente(Lexema, Categoria.DIVISION, NumeroLinea, Puntero - Lexema.Length, Puntero - 1);
            ContinuarAnalisis = false;
        }

        private void EstadoTreintaiseis()
        {
            LeerSiguienteCaracter();
            if ("@FL@".Equals(CaracterActual))
            {
                LeerSiguienteCaracter();
            }
            if (EsFinLinea())
            {
                EstadoActual = 13;
            }
        }


        private void CrearComponente(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal){

            Componente = ComponenteLexico.Crear(Lexema, Categoria, NumeroLinea, PosicionIncial, PosicionFinal);

        }
    }
}
