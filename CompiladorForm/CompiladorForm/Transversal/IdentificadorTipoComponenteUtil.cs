using System;

public class IdentificadorTipoComponenteUtil
{
	private static List<Categoria> TIPO_SIMBOLO = crearTipoSimbolo();
	private static List<Categoria> TIPO_LITERAL = crearTipoLiteral();



	private static crearTipoSimbolo()
    {
		List<Categoria> TipoSimbolo = new List<Categoria>();
		TipoSimbolo.Add(Categoria.IDENTIFICADOR);
		return TipoSimbolo;
    }

	private static crearTipoLiteral()
	{
		List<Categoria> TipoLiteral = new List<Categoria>();
		TipoLiteral.Add(Categoria.NUMERO_ENTERO);
		TipoLiteral.Add(Categoria.NUMERO_DECIMAL);
		TipoLiteral.Add(Categoria.IGUAL_QUE);
		TipoLiteral.Add(Categoria.PARENTESIS_ABRE);
		TipoLiteral.Add(Categoria.PARENTESIS_CIERRA);
		TipoLiteral.Add(Categoria.RESTA);
		TipoLiteral.Add(Categoria.SUMA);
		TipoLiteral.Add(Categoria.MULTIPLICACION);
		TipoLiteral.Add(Categoria.DIVISION);
		TipoLiteral.Add(Categoria.MODULO);
		return TipoLiteral;
	}

	public static EsLiteral(Categoria Categoria)
	{
		return TIPO_LITERAL.contains(Categoria);
	}
	public static EsSimbolo(Categoria Categoria)
	{
		return TIPO_SIMBOLO.contains(Categoria);
	}

	public IdentificadorTipoComponenteUtil()
	{
	}
}
