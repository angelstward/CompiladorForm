using System;

namespace CompiladorForm.Tablas
{
	public class TablaMaestra
	{

		private TablaMaestra()
        {

        }

		public static ComponenteLexico SincronizarTabla(componenteLexico Componente)
        {
            if (Componente != null)
            {
                Componente = TablaPalabrasReservadas.ComprobarPalabraReservada(Componente);
                switch(Componente.ObtenerCategoria())
                {
                    case  TipoComponente.DUMMY
                          TablaDummys.Agregar(Componente);
                        break;
                   case TipoComponente.PALABRA_RESERVADA
                        TablaPalabrasReservadas.Agregar(Componente);
                        break;
                   case TipoComponente.LITERAL
                        TablaLiterales.Agregar(Componente);
                        break;
                   case TipoComponente.SIMBOLO
                        TablaSimbolos.Agregar(Componente);
                        break;

                }


                return Componente;


            }

            public static Limpiar()
            {
                TablaDummys.Limpiar();
                TablaPalabrasReservadas.Limpiar();
                TablaLiterales.Limpiar();
                TablaSimbolos.Limpiar();

            }

        }

	}
}
