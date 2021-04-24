using CompiladorForm.GestorErrores;
using System;
using System.Text;

namespace CompiladorForm.Transversal
{

	public class ComponenteLexico
	{
		private String Lexema;
		private Categoria Categoria;
		private int NumeroLinea;
		private int PosicionIncial;
		private int PosicionFinal;
		private TipoComponente Tipo;


		protected ComponenteLexico(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal, TipoComponente Tipo)
		{
			this.Lexema = Lexema;
			this.Categoria = Categoria;
			this.NumeroLinea = NumeroLinea;
			this.PosicionIncial = PosicionIncial;
			this.PosicionFinal = PosicionFinal;
			this.Tipo = Tipo;

		}

		public static ComponenteLexico CrearSimbolo(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal)
		{
			return new ComponenteLexico(Lexema, Categoria, NumeroLinea, PosicionIncial, PosicionFinal, TipoComponente.SIMBOLO);
		}

		public static ComponenteLexico Crear(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal)
		{
			return new ComponenteLexico(Lexema, Categoria, NumeroLinea, PosicionIncial, PosicionFinal, TipoComponente.DUMMY);
		}

		public static ComponenteLexico CrearPalabraReservada(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal)
		{
			return new ComponenteLexico(Lexema, Categoria, NumeroLinea, PosicionIncial, PosicionFinal, TipoComponente.PALABRA_RESERVADA);
		}

		public static ComponenteLexico CrearPalabraLiteral(String Lexema, Categoria Categoria, int NumeroLinea, int PosicionIncial, int PosicionFinal)
		{
			return new ComponenteLexico(Lexema, Categoria, NumeroLinea, PosicionIncial, PosicionFinal, TipoComponente.LITERAL);
		}


		public static ComponenteLexico CrearPalabraLiteral(String Lexema, Categoria Categoria)
		{
			return new ComponenteLexico(Lexema, Categoria, 0, 0, 0, TipoComponente.PALABRA_RESERVADA);
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

		public TipoComponente ObtenerTipo()
		{
			return Tipo;
		}

		public override string ToString()
        {
			StringBuilder informacion = new StringBuilder();
			informacion.Append("Categoria: " ).Append(ObtenerCategoria()).Append(Environment.NewLine);
			informacion.Append("Lexema: ").Append(ObtenerLexema()).Append(Environment.NewLine);
			informacion.Append("Numero de linea: ").Append(ObtenerNumeroLinea()).Append(Environment.NewLine);
			informacion.Append("Posición inicial: ").Append(ObtenerPosicionInicial()).Append(Environment.NewLine);
			informacion.Append("Posición final: ").Append(ObtenerPosicionFinal()).Append(Environment.NewLine);

			return informacion.ToString();

        }

        
    }
}
