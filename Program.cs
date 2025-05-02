using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PruebaHandler.InstanciarCuentas();
            PruebaHandler.OperarConCuentas(Caso.C5_Retirar_FALLO);
            PruebaHandler.RecorrerCuentas();
        }
        
    }
}
