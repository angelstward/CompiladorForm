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

		public static  Error CreaErrorLexico(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal, String Falla, String Causa, String Solucion)
		{
			return (Lexema, Categoria,NumeroLinea, PosicionIncial, PosicionFinal,Falla,Causa,Solucion);

		}

		public String ObtenerLexema()
		{
			return Lexema;
		}

		public String ObtenerCategoria()
		{
			return Categoria;
		}

		public String ObtenerNumeroLinea()
		{
			return NumeroLinea;
		}

		public String ObtenerPosicionInicial()
		{
			return PosicionIncial;
		}

		public String ObtenerPosicionFinal()
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

		public String ObtenerTipo()
		{
			return Tipo;
		}


	}
}

