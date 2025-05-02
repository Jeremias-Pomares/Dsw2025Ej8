using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CuentaCorriente : CuentaBancaria
{   
    public decimal LimiteDeDescubierto { get; init; }
    public decimal Comision { get; init; }
    public CuentaCorriente(string Numero, decimal Saldo) : base(Numero, Saldo)
    {
        EstadoCuenta = Estado.Activa;
    }
    
    public override void Depositar(decimal monto)
    {
        monto -= monto * Comision;
        Saldo += monto;
    }
    public override void Retirar(decimal monto)
    {
        if (monto <= 0)
            throw new MontoNoValidoException();
        if(EstadoCuenta != Estado.Activa)
            throw new CuentaNoActivaException();
        if (Saldo - monto < -LimiteDeDescubierto)
        {
            EstadoCuenta = Estado.Suspendida;
            throw new SaldoInsuficienteException();
        }
        Saldo -= monto;
    }
}