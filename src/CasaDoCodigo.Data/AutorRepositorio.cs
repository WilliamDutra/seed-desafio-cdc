using CasaDoCodigo.Dominio;
using Npgsql;
using System.Data;

namespace CasaDoCodigo.Data
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private CasaDoCodigoContext _DbContext;

        public AutorRepositorio(CasaDoCodigoContext dbContext)
        {
            _DbContext = dbContext;
        }

        public Autor? ObterPorEmail(string email)
        {
            Autor? autor = null;

            string select = @"select 
	                            id, 
	                            nome, 
	                            email, 
	                            descricao 
                            from 
	                            autor where email = @email";
            
            var command = new NpgsqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = select;
            command.Parameters.Add(new NpgsqlParameter("@email", email));
            command.Connection = _DbContext.Conexao;

            using (var reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Guid id = Guid.Parse(reader["id"].ToString());
                    string nome = reader["nome"].ToString();
                    string mail = reader["email"].ToString();
                    string descricao = reader["descricao"].ToString();
                    autor = Autor.Restaurar(id, nome, mail, descricao);
                }
            }

            return autor;
        }

        public void Salvar(Autor autor)
        {
            string insert = @"insert into autor 
                            (
	                            id,
	                            nome,
	                            email,
	                            descricao
                            )
                            values
                            (
	                            @id,
	                            @nome,
	                            @email,
	                            @descricao
                            );";


            using (var command = new NpgsqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", autor.Id));
                command.Parameters.Add(new NpgsqlParameter("@nome", autor.Nome));
                command.Parameters.Add(new NpgsqlParameter("@email", autor.Email));
                command.Parameters.Add(new NpgsqlParameter("@descricao", autor.Descricao));
                command.ExecuteNonQuery();
            }
        }
    }
}