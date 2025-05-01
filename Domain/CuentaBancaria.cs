namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public string Numero{get;private set;}
    public decimal Saldo{get; private set;}
    public Estado EstadoCuenta {get; set;}
    public string[] Titulares {get;init;}

    public CuentaBancaria(string numero, decimal saldo)
    {
        if (string.IsNullOrEmpty(numero))
            throw new ArgumentException("Número de cuenta inválido.");
        
        if (saldo < 0)
            throw new ArgumentException("El saldo no puede ser negativo.");
        Numero = numero;
        Saldo = saldo;
    }
    
    public void Depositar(decimal monto)
    {
        //Depende del tipo de cuenta
    }

    public void Retirar(decimal monto)
    {
        //Depende del tipo de cuenta
    }

}
