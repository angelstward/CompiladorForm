using CompiladorForm.Transversal;

namespace CompiladorForm.Tablas
{
    public class TablaMaestra
    {

        private TablaMaestra()
        {

        }

        public static ComponenteLexico SincronizarTabla(ComponenteLexico Componente)
        {
            if (Componente != null)
            {
                Componente = TablaPalabrasReservadas.ComprobarPalabraReservada(Componente);
                switch (Componente.ObtenerTipo())
                {
                    case TipoComponente.DUMMY:
                          TablaDummys.Agregar(Componente);
                        break;
                    case TipoComponente.PALABRA_RESERVADA:
                        TablaPalabrasReservadas.Agregar(Componente);
                        break;
                    case TipoComponente.LITERAL:
                        TablaLiterales.Agregar(Componente);
                        break;
                    case TipoComponente.SIMBOLO:
                        TablaSimbolos.Agregar(Componente);
                        break;

                }
                return Componente;
            }
            return default;

        }
        public static void Limpiar()
        {
            TablaDummys.Limpiar();
            TablaPalabrasReservadas.Limpiar();
            TablaLiterales.Limpiar();
            TablaSimbolos.Limpiar();
        }

    }
}
