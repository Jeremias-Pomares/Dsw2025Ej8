using System;

public class MontoException : Exception
{
    // Mensaje predeterminado
    private const string DefaultMessage = "El monto ingreso no es valido. Los montos deben ser mayores a 0";

    // Constructores
    public SaldoInsuficienteException() : base(DefaultMessage) { }
    
}