using CompiladorForm.Transversal;
using System;

namespace CompiladorForm.GestorErrores
{
	public class Error
	{
		private String Lexema;
		private Categoria Categoria;
		private int NumeroLinea;
		private int PosicionIncial;
		private int PosicionFinal;
		private String Falla;
		private String Causa;
		private String Solucion;
		private TipoError Tipo;

		private Error(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal, String Falla, String Causa, String Solucion, TipoError Tipo)
        {
			this.Lexema = Lexema;
			this.Categoria = Categoria;
			this.NumeroLinea = NumeroLinea;
			this.PosicionIncial = PosicionIncial;
			this.PosicionFinal = PosicionFinal;
			this.Falla = Falla;
			this.Causa = Causa;
			this.Solucion = Solucion;
			this.Tipo = Tipo;	
		}
       

        public  static Error CrearErrorLexico(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal, String Falla, String Causa, String Solucion)
		{
			return new Error(Lexema, Categoria,NumeroLinea, PosicionIncial, PosicionFinal,Falla,Causa,Solucion, TipoError.LEXICO);

		}

		public static Error CrearErrorSintactico(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal, String Falla, String Causa, String Solucion)
		{
			return new Error(Lexema, Categoria, NumeroLinea, PosicionIncial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);

		}

		public static Error CrearErrorSemantico(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal, String Falla, String Causa, String Solucion)
		{
			return new Error(Lexema, Categoria, NumeroLinea, PosicionIncial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);

		}

		public String ObtenerLexema()
		{
			return Lexema;
		}

		public Categoria ObtenerCategoria()
		{
			return Categoria;
		}

		public int ObtenerNumeroLinea()
		{
			return NumeroLinea;
		}

		public int ObtenerPosicionInicial()
		{
			return PosicionIncial;
		}

		public int ObtenerPosicionFinal()
		{
			return PosicionFinal;
		}


		public String ObtenerFalla()
        {
			return Falla;
        }

		public String ObtenerCausa()
		{
			return Causa;
		}

		public String ObtenerSolucion()
		{
			return Solucion;
		}

		public TipoError ObtenerTipo()
		{
			return Tipo;
		}


	}
}

