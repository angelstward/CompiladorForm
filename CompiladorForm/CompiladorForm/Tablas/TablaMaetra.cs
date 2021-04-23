using System;

public class TablaMaestra
{
	public TablaMaestra()
	{

		private TablaMaestra()
        {

        }

		public static ComponenteLexico SincronizarTabla(ComponenteLexico componente)
        {
			if(componente !=null)
            {
                componente = TablaPalabrasReservadas.ComprobarPalabraReservada(componente);

                switch (componente.obtenerCategoria())
                {
                    case TipoComponente.DUMMY:
                        TablaDummies.Agregar(componente);
                        break;
                    case TipoComponente.PALABRA_RESERVADA:
                        TablaPalabraReservadas.Agregar(componente);
                        break;
                    case TipoComponente.LITERAL:
                        TablaLIterales.Agregar(componente);
                        break;
                    case TipoComponente.SIMBOLO:
                        TablaSimbolos.Agregar(componente);
                        break;
                }
            }
        }
	}
}
