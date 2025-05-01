using System;

public class MontoException : Exception
{
    // Mensaje predeterminado
    private const string DefaultMessage = "La cuenta que esta intentando usar no se encuentra activa.";

    // Constructores
    public SaldoInsuficienteException() : base(DefaultMessage) { }
    
}