using System;

public class SaldoInsuficienteException : Exception
{
    // Mensaje predeterminado
    private const string DefaultMessage = "La cuenta no cuenta con saldo suficiente para la operación solicitada.";

    // Constructores
    public SaldoInsuficienteException() : base(DefaultMessage) { }
    
    // Constructor adicional con datos específicos (opcional)
    public SaldoInsuficienteException(decimal saldoActual, decimal montoRequerido)
        : base($"Saldo insuficiente. Saldo actual: {saldoActual}, Monto requerido: {montoRequerido}")
    {
        SaldoActual = saldoActual;
        MontoRequerido = montoRequerido;
    }

    // Propiedades adicionales para contexto (opcional)
    public decimal SaldoActual { get; }
    public decimal MontoRequerido { get; }
}