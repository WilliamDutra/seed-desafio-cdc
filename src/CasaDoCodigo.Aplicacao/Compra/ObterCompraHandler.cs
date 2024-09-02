using System;
using Npgsql;
using System.Data;
using CasaDoCodigo.Data;
using CasaDoCodigo.Dominio;

namespace CasaDoCodigo.Aplicacao.Compra
{
    public class ObterCompraHandler
    {
        private CasaDoCodigoContext _dbContext;

        public ObterCompraHandler(CasaDoCodigoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Dominio.Compra Handle(ObterCompraCommand command)
        {
			Dominio.Compra? compra = null;

            var select = @"select 
								pedido.id pedido_id,
								pedido.email,
								pedido.nome,
								pedido.sobrenome,
								pedido.documento,
								pedido.telefone,
								pedido.logradouro,
								pedido.complemento,
								pedido.cep,
								pedido.cidade,
								pedido.cupom_id,
								pedido.total,
								item_pedido.id item_pedido_id,
								item_pedido.pedido_id,
								item_pedido.quantidade,
								item_pedido.preco,
								item_pedido.total,
								cupom.nome nome_cupom,
								cupom.valor,
								cupom.id cupom_id,
								cupom.validade
							from 
								pedido pedido
							inner join
								item_pedido item_pedido
							on
								item_pedido.pedido_id = pedido.id
							inner join
								cupom cupom
							on
								cupom.id = pedido.cupom_id
							where
								pedido.id = @id";

            var pgCommand = new NpgsqlCommand();
            pgCommand.CommandType = CommandType.Text;
            pgCommand.CommandText = select;
            pgCommand.Parameters.Add(new NpgsqlParameter("@id", command.Id.ToString()));
			pgCommand.Connection = _dbContext.Conexao;

            using (var reader = pgCommand.ExecuteReader())
            {

                while (reader.Read())
                {
					compra = new Dominio.Compra(reader["email"].ToString(), reader["nome"].ToString(), reader["sobrenome"].ToString(), new Documento(reader["documento"].ToString()), new Endereco(reader["logradouro"].ToString(), reader["cep"].ToString(), reader["cidade"].ToString(), Guid.Empty, Guid.Empty, reader["complemento"].ToString()), reader["telefone"].ToString());
					compra.AdicionarPedido(Convert.ToInt32(reader["quantidade"].ToString()), decimal.Parse(reader["preco"].ToString()), Guid.Parse(reader["item_pedido_id"].ToString()));
					var cupom = Dominio.Cupom.Restaurar(Guid.Parse(reader["item_pedido_id"].ToString()), reader["nome_cupom"].ToString(), decimal.Parse(reader["valor"].ToString()), DateTime.Parse(reader["validade"].ToString()));
					compra.AplicarCupom(cupom);
                }
            }

			return compra;
        }

		
    }
}
