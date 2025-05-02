using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CajaDeAhorro : CuentaBancaria
{
    public CajaDeAhorro(string Numero, decimal Saldo, Estado Estado, string[] Titulares) : base(Numero, Saldo)
    {
    }
    public decimal TasaDeInteres { get; init; }
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
            throw new SaldoInsuficienteException();
            Estado = Estado.Suspendida;
        }
        Saldo -= monto;
    }
    public override void AplicarInteres()
    {
        Saldo += Saldo * TasaDeInteres;
    }
}
