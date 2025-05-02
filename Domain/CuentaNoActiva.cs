using System;

public class CuentaNoActivaException : Exception
{
    // Mensaje predeterminado
    private const string DefaultMessage = "La cuenta que esta intentando usar no se encuentra activa.";

    // Constructores
    public CuentaNoActivaException() : base(DefaultMessage) { }
    
}