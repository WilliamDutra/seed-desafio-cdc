﻿using Npgsql;
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

        public Livro? ObterLivroPorId(Guid id)
        {
            Livro? livro = null;

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
                                    livro WHERE id = @id";

            var command = new NpgsqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = select;
            command.Parameters.Add(new NpgsqlParameter("@id", id.ToString()));
            command.Connection = _DbContext.Conexao;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Guid idLivro = Guid.Parse(reader["id"].ToString());
                    string isbn = reader["isbn"].ToString();
                    string titulo = reader["titulo"].ToString();
                    string resumo = reader["resumo"].ToString();
                    string suamario = reader["sumario"].ToString();
                    int numeroPaginas = Convert.ToInt32(reader["numero_paginas"].ToString());
                    decimal preco = decimal.Parse(reader["preco"].ToString());
                    DateTime dataPublicacao = DateTime.Parse(reader["data_publicacao"].ToString());
                    Guid categoriaId = Guid.Parse(reader["categoria_id"].ToString());
                    Guid autorId = Guid.Parse(reader["autor_id"].ToString());

                    livro = Livro.Restaurar(idLivro, isbn, titulo, resumo, suamario, preco, numeroPaginas, dataPublicacao, categoriaId, autorId);
                }
            }

            return livro;

        }

        public Pais? ObterPaisPorId(Guid id)
        {
            Pais? pais = null;

            string select = @"
                                SELECT 
                                     id,
	                                 nome,
                                     sigla
                                FROM
                                    pais WHERE id = @id";

            var command = new NpgsqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = select;
            command.Parameters.Add(new NpgsqlParameter("@id", id.ToString()));
            command.Connection = _DbContext.Conexao;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Guid idPais = Guid.Parse(reader["id"].ToString());
                    string nome = reader["nome"].ToString();
                    string sigla = reader["sigla"].ToString();                  
                    pais = Pais.Restaurar(idPais, nome, sigla);
                }
            }

            return pais;

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
                                preco,
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
                                @preco,
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
                command.Parameters.Add(new NpgsqlParameter("@preco", livro.Preco));
                command.Parameters.Add(new NpgsqlParameter("@numero_paginas", livro.NumeroDePaginas));
                command.Parameters.Add(new NpgsqlParameter("@data_publicacao", livro.DataPublicacao));
                command.Parameters.Add(new NpgsqlParameter("@categoria_id", livro.CategoriaId));
                command.Parameters.Add(new NpgsqlParameter("@autor_id", livro.AutorId));
                command.ExecuteNonQuery();
            }

        }

        public void Salvar(Estado estado)
        {
            string insert = @"INSERT INTO estado
                            (
	                            id,
	                            nome,
	                            sigla,
                                pais_id
                            )
                            VALUES
                            (
	                            @id,
	                            @nome,
	                            @sigla,
                                @pais_id
                            );";


            using (var command = new NpgsqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", estado.Id));
                command.Parameters.Add(new NpgsqlParameter("@sigla", estado.Sigla));
                command.Parameters.Add(new NpgsqlParameter("@nome", estado.Nome));
                command.Parameters.Add(new NpgsqlParameter("@pais_id", estado.PaisId));
                command.ExecuteNonQuery();
            }
        }

        public void Salvar(Pais pais)
        {
            string insert = @"INSERT INTO pais
                            (
	                            id,
	                            nome,
	                            sigla
                            )
                            VALUES
                            (
	                            @id,
	                            @nome,
	                            @sigla
                            );";


            using (var command = new NpgsqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", pais.Id));
                command.Parameters.Add(new NpgsqlParameter("@sigla", pais.Sigla));
                command.Parameters.Add(new NpgsqlParameter("@nome", pais.Nome));
                command.ExecuteNonQuery();
            }

        }

        public Pais? ObterPaisPorNome(string nome)
        {
            Pais? pais = null;

            string select = @"SELECT
	                            id,
	                            nome,
	                            sigla
                            FROM
	                            pais
                            WHERE nome = @nome";

            var command = new NpgsqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = select;
            command.Parameters.Add(new NpgsqlParameter("@nome", nome));
            command.Connection = _DbContext.Conexao;

            using (var reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Guid id = Guid.Parse(reader["id"].ToString());
                    string nomePais = reader["nome"].ToString();
                    string sigla = reader["sigla"].ToString();                    
                    pais = Pais.Restaurar(id, nome, sigla);
                }
            }

            return pais;

        }

        public Cupom? ObterCupomPorNome(string nome)
        {
            Cupom? cupom = null;

            string select = @"SELECT
	                            id,
	                            nome,
	                            valor,
	                            validade
                              FROM 
	                            cupom WHERE nome = @nome";

            var command = new NpgsqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = select;
            command.Parameters.Add(new NpgsqlParameter("@nome", nome));
            command.Connection = _DbContext.Conexao;

            using (var reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Guid id = Guid.Parse(reader["id"].ToString());
                    string nomeCupom = reader["nome"].ToString();
                    decimal valor = decimal.Parse(reader["valor"].ToString());
                    var validade = DateTime.Parse(reader["validade"].ToString());
                    cupom = Cupom.Restaurar(id, nome, valor, validade);
                }
            }

            return cupom;

        }

        public void Salvar(Cupom cupom)
        {
            string insert = @"INSERT INTO cupom
                            (
	                            id,
	                            nome,
	                            valor,
                                validade
                            )
                            VALUES
                            (
	                            @id,
	                            @nome,
	                            @valor,
                                @validade
                            );";


            using (var command = new NpgsqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = insert;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", cupom.Id));
                command.Parameters.Add(new NpgsqlParameter("@nome", cupom.Nome));
                command.Parameters.Add(new NpgsqlParameter("@valor", cupom.Valor));
                command.Parameters.Add(new NpgsqlParameter("@validade", cupom.Validade));
                command.ExecuteNonQuery();
            }


        }

        public void Salvar(Compra compra)
        {
            string insertCompra = @"INSERT INTO pedido 
                            (
	                            id,
	                            email,
	                            nome,
	                            sobrenome,
	                            documento,
	                            telefone,
	                            logradouro,
	                            cep,
	                            cidade,
	                            estado_id,
	                            pais_id,
	                            complemento,
	                            cupom_id,
	                            total
                            )
                            VALUES
                            (
	                            @id,
	                            @email,
	                            @nome,
	                            @sobrenome,
	                            @documento,
	                            @telefone,
	                            @logradouro,
	                            @cep,
	                            @cidade,
	                            @estado_id,
	                            @pais_id,
	                            @complemento,
	                            @cupom_id,
	                            @total
                            ) 
                            RETURNING id;";

            
            using (var command = new NpgsqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = insertCompra;
                command.Connection = _DbContext.Conexao;
                command.Parameters.Add(new NpgsqlParameter("@id", compra.Id));
                command.Parameters.Add(new NpgsqlParameter("@email", compra.Email));
                command.Parameters.Add(new NpgsqlParameter("@nome", compra.Nome));
                command.Parameters.Add(new NpgsqlParameter("@sobrenome", compra.Sobrenome));
                command.Parameters.Add(new NpgsqlParameter("@documento", compra.Documento.Numero));
                command.Parameters.Add(new NpgsqlParameter("@telefone", compra.Telefone));
                command.Parameters.Add(new NpgsqlParameter("@logradouro", compra.Endereco.Logradouro));
                command.Parameters.Add(new NpgsqlParameter("@cep", compra.Endereco.Cep));
                command.Parameters.Add(new NpgsqlParameter("@cidade", compra.Endereco.Cidade));
                command.Parameters.Add(new NpgsqlParameter("@estado_id", compra.Endereco.EstadoId));
                command.Parameters.Add(new NpgsqlParameter("@pais_id", compra.Endereco.PaisId));
                command.Parameters.Add(new NpgsqlParameter("@complemento", compra.Endereco.Complemento));
                command.Parameters.Add(new NpgsqlParameter("@cupom_id", compra.Cupom.Id));
                command.Parameters.Add(new NpgsqlParameter("@total", compra.Total));
                command.ExecuteNonQuery();
            }


            string insertPedido = @"INSERT INTO item_pedido
                                    (
	                                    id,
	                                    pedido_id,
	                                    quantidade,
	                                    preco,
	                                    total
                                    )
                                    VALUES
                                    (
	                                    @id, 
	                                    @pedido,
	                                    @quantidade,
	                                    @preco,
	                                    @total
                                    );";

            foreach (var pedido in compra.Pedidos)
            {

                using (var command = new NpgsqlCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = insertPedido;
                    command.Connection = _DbContext.Conexao;
                    command.Parameters.Add(new NpgsqlParameter("@id", pedido.Id));
                    command.Parameters.Add(new NpgsqlParameter("@pedido", compra.Id));
                    command.Parameters.Add(new NpgsqlParameter("@quantidade", pedido.Quantidade));
                    command.Parameters.Add(new NpgsqlParameter("@preco", pedido.Preco));
                    command.Parameters.Add(new NpgsqlParameter("@total", pedido.Total));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}