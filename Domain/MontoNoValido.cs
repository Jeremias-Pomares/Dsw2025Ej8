using System;

public class MontoNoValidoException : Exception
{
    // Mensaje predeterminado
    private const string DefaultMessage = "El monto ingreso no es valido. Los montos deben ser mayores a 0";

    // Constructores
    public MontoNoValidoException() : base(DefaultMessage) { }
    
}