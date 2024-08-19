using Npgsql;
using System.Data;
using CasaDoCodigo.Dominio;

namespace CasaDoCodigo.Data
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private CasaDoCodigoContext _DbContext;

        public AutorRepositorio(CasaDoCodigoContext dbContext)
        {
            _DbContext = dbContext;
        }

        public Categoria? ObterCategoriaPorNome(string categoria)
        {
            Categoria? cat = null;

            string select = @"select 
	                            id, 
	                            nome, 
	                            descricao 
                            from 
	                            categoria where nome = @nome";

            var command = new NpgsqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = select;
            command.Parameters.Add(new NpgsqlParameter("@nome", categoria));
            command.Connection = _DbContext.Conexao;

            using (var reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Guid id = Guid.Parse(reader["id"].ToString());
                    string nome = reader["nome"].ToString();
                    string descricao = reader["descricao"].ToString();
                    cat = Categoria.Restaurar(id, nome, descricao);
                }
            }

            return cat;
        }

        public List<Livro> ObterLivroPorNome(string nome)
        {
            List<Livro> livros = new List<Livro>();

            string select = @"
                                SELECT 
                                     id,
	                                isbn,
	                                titulo,
	                                resumo,
                                    preco,
	                                sumario,
	                                numero_paginas,
	                                data_publicacao,
	                                categoria_id,
	                                autor_id
                                FROM
                                    livro WHERE titulo = @titulo";

            var command = new NpgsqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = select;
            command.Parameters.Add(new NpgsqlParameter("@titulo", nome));
            command.Connection = _DbContext.Conexao;

            using (var reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Guid id = Guid.Parse(reader["id"].ToString());
                    string isbn = reader["isbn"].ToString();
                    string titulo = reader["titulo"].ToString();
                    string resumo = reader["resumo"].ToString();
                    string suamario = reader["sumario"].ToString();
                    int numeroPaginas = Convert.ToInt32(reader["numero_paginas"].ToString());
                    decimal preco = decimal.Parse(reader["preco"].ToString());
                    DateTime dataPublicacao = DateTime.Parse(reader["data_publicacao"].ToString());
                    Guid categoriaId = Guid.Parse(reader["categoria_id"].ToString());
                    Guid autorId = Guid.Parse(reader["autor_id"].ToString());

                    livros.Add(Livro.Restaurar(id, isbn, titulo, resumo, suamario, preco, numeroPaginas, dataPublicacao, categoriaId, autorId));
                }
            }

            return livros;

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

        public List<Livro> ObterTodosOsLivros()
        {
            List<Livro> livros = new List<Livro>();

            string select = @"
                                SELECT 
                                     id,
	                                isbn,
	                                titulo,
	                                resumo,
	                                sumario,
                                    preco,
	                                numero_paginas,
	                                data_publicacao,
	                                categoria_id,
	                                autor_id
                                FROM
                                    livro";

            var command = new NpgsqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = select;
            command.Connection = _DbContext.Conexao;

            using (var reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Guid id = Guid.Parse(reader["id"].ToString());
                    string isbn = reader["isbn"].ToString();
                    string titulo = reader["titulo"].ToString();
                    string resumo = reader["resumo"].ToString();
                    string suamario = reader["sumario"].ToString();
                    int numeroPaginas = Convert.ToInt32(reader["numero_paginas"].ToString());
                    decimal preco = decimal.Parse(reader["preco"].ToString());
                    DateTime dataPublicacao = DateTime.Parse(reader["data_publicacao"].ToString());
                    Guid categoriaId = Guid.Parse(reader["categoria_id"].ToString());
                    Guid autorId = Guid.Parse(reader["autor_id"].ToString());

                    livros.Add(Livro.Restaurar(id, isbn, titulo, resumo, suamario, preco, numeroPaginas, dataPublicacao, categoriaId, autorId));
                }
            }

            return livros;
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
    
        public void Salvar(Categoria categoria)
        {
            string insert = @"insert into categoria
                            (
	                            id,
	                            nome,
	                            descricao
                            )
                            values
                            (
	                            @id,
	                            @nome,
	                            @descricao
                            );";


            using (var command = new NpgsqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", categoria.Id));
                command.Parameters.Add(new NpgsqlParameter("@nome", categoria.Nome));
                command.Parameters.Add(new NpgsqlParameter("@descricao", categoria.Descricao));
                command.ExecuteNonQuery();
            }

        }

        public void Salvar(Livro livro)
        {
            string insert = @"INSERT INTO livro
                            (
	                            id,
	                            isbn,
	                            titulo,
	                            resumo,
	                            sumario,
	                            numero_paginas,
	                            data_publicacao,
	                            categoria_id,
	                            autor_id
                            )
                            VALUES
                            (
	                            @id,
	                            @isbn,
	                            @titulo,
                                @resumo,
	                            @sumario,
	                            @numero_paginas,
	                            @data_publicacao,
	                            @categoria_id,
	                            @autor_id
                            );";


            using (var command = new NpgsqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", livro.Id));
                command.Parameters.Add(new NpgsqlParameter("@titulo", livro.Titulo));
                command.Parameters.Add(new NpgsqlParameter("@isbn", livro.Isbn));
                command.Parameters.Add(new NpgsqlParameter("@resumo", livro.Resumo));
                command.Parameters.Add(new NpgsqlParameter("@sumario", livro.Sumario));
                command.Parameters.Add(new NpgsqlParameter("@numero_paginas", livro.NumeroDePaginas));
                command.Parameters.Add(new NpgsqlParameter("@data_publicacao", livro.DataPublicacao));
                command.Parameters.Add(new NpgsqlParameter("@categoria_id", livro.CategoriaId));
                command.Parameters.Add(new NpgsqlParameter("@autor_id", livro.AutorId));
                command.ExecuteNonQuery();
            }

        }
    }
}