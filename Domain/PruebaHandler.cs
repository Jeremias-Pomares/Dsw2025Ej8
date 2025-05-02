using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class PruebaHandler
    {
        private static CuentaBancaria[] cuentas = new CuentaBancaria[4];

        public PruebaHandler() { }
        public static void InstanciarCuentas()
        {
            CajaDeAhorro cajaAhorro1 = new CajaDeAhorro("0001", 0)
            {
                Titulares = new string[] { "Bae", "Elena" },
                TasaDeInteres = 0.02m
            };
            CajaDeAhorro cajaAhorro2 = new CajaDeAhorro("0002", 0)
            {
                Titulares = new string[] { "Sofia", "Lu" },
                TasaDeInteres = 0.02m
            };
            CuentaCorriente cuentaCorriente1 = new CuentaCorriente("0003", 0)
            {
                Titulares = new string[] { "Bae", "Jere" },
                LimiteDeDescubierto = 100,
                Comision = 0.02m
            };
            CuentaCorriente cuentaCorriente2 = new CuentaCorriente("0004", 0)
            {
                Titulares = new string[] { "Carolina", "Graciela" },
                LimiteDeDescubierto = 100,
                Comision = 0.02m
            };
            cuentas = new CuentaBancaria[]{cajaAhorro1,cajaAhorro2,cuentaCorriente1 ,cuentaCorriente2};

            Console.WriteLine("\n Cuentas Instanciadas: \n cuenta[0] = CA1 \n cuenta[1] = CA2 \n cuenta[2] = CC1 \n cuenta[3] = CC2");
        }

        public static void OperarConCuentas(Caso caso)
        {
            try
            {
                switch (caso)
                {
                    case Caso.C1_Depositar_Retirar_EXITO:
                        cuentas[0].Depositar(2000); //deposito 2000pe en CA1
                        cuentas[2].Depositar(2000); //deposito 2000pe en CC1
                        cuentas[0].Retirar(1000); //retiro 1000pe en CA1
                        cuentas[2].Retirar(1000); //retiro 1000pe en CC1
                        break;

                    case Caso.C2_Retirar_FALLO:
                        cuentas[1].Retirar(1000); //retiro 1000pe en CA2, deberia ser ERROR porque Saldo<monto
                        break;

                    case Caso.C3_Depositar_Retirar_FALLO:
                        cuentas[3].Depositar(2000); //deposito 2000pe en CC2
                        cuentas[3].Retirar(0);    //retiro 0 en CC2, deberia dar ERROR porque monto invalido
                        break;

                    case Caso.C4_Depositar_AplicarInteres_EXITO:
                        cuentas[0].Depositar(2000); //deposito 2000pe en CA1
                        ((CajaDeAhorro)cuentas[0]).AplicarInteres();
                        break;

                    case Caso.C5_Retirar_FALLO:
                        cuentas[3].Retirar(1000); //retiro 1000pe en CC2, debería ser ERROR porque Saldo-monto<limiteDescubierto
                        cuentas[3].Retirar(1000); //retiro 1000pe en CC2, debería ser ERROR porque cuenta no activa
                        break;
                }
                
            }
            catch (MontoNoValidoException ex)
            {
                Console.WriteLine($"\nExcepcion encontrada>> {ex.Message}");
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine($"\nExcepcion encontrada>> {ex.Message}");
            }

            finally
            {
                Console.WriteLine("\n Operacion terminada");
            }
        }

        public static void RecorrerCuentas()
        {
            int i=0;

            foreach(CuentaBancaria cuenta in cuentas)
            {
                var resumenCuenta = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta is CuentaCorriente ? "Cuenta Corriente" : "Caja de Ahorro",
                    Saldo = cuenta.Saldo,
                    EstadoCuenta = cuenta.EstadoCuenta
                };

                Console.WriteLine($"cuenta[{i}]: \nNúmero: {resumenCuenta.Numero} \nTipo: {resumenCuenta.Tipo} \nSaldo: {resumenCuenta.Saldo} \nEstado: {resumenCuenta.EstadoCuenta}");
                Console.WriteLine("\n============\n");
                i++;
            }
        }
    }
}
