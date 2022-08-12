﻿namespace Fintech.Dominio
{
    // ToDo: OO - herança.
    public class ContaCorrente : Conta
    {
        public ContaCorrente(Agencia agencia, int numero, string digitoVerificador)
        {
            Agencia = agencia;
            Numero = numero;
            DigitoVerificador = digitoVerificador;
        }

        public bool EmissaoChequeHabilitada { get; set; }
    }
}