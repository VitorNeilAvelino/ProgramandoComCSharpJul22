﻿using Fintech.Dominio;
using Fintech.Dominio.Interfaces;
using System.Data.SqlClient;

namespace Fintech.Repositorios.SqlServer
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        private readonly string stringConexao;

        public MovimentoRepositorio(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public void Inserir(Movimento movimento)
        {
            var instrucao = @$"Insert Movimento(IdConta, Data, Valor, Operacao)
                                            values({movimento.Conta.Numero}, @Data, @Valor, @Operacao)";

            using (var conexao = new SqlConnection(stringConexao)) // using: descarte seguro de memória.
            {

            }
        }

        public Task<List<Movimento>> SelecionarAsync(int numeroAgencia, int numeroConta)
        {
            throw new NotImplementedException();
        }
    }
}