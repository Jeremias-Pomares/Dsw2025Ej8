using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CajaDeAhorro : CuentaBancaria
{
    public decimal TasaDeInteres { get; init; }
    public CajaDeAhorro(string Numero, decimal Saldo) : base(Numero, Saldo)
    {
        EstadoCuenta = Estado.Activa;
    }
    
    public override void Depositar(decimal monto)
    {
        Saldo += monto;
    }
    public override void Retirar(decimal monto)
    {
        if (monto <= 0)
            throw new MontoNoValidoException();
        if (Saldo < monto)
        {
            EstadoCuenta = Estado.Suspendida;
            throw new SaldoInsuficienteException();
        }

        Saldo -= monto;
    }
    public void AplicarInteres()
    {
        Saldo += Saldo * TasaDeInteres;
    }
}
