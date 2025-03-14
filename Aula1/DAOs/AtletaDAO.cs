using System;
using System.Reflection;
using Aula1.Models;
using Dapper;
using Microsoft.Data.Sqlite;

/*
dotnet add package Microsoft.Data.Sqlite
dotnet add package Dapper
*/

namespace Aula1.DAOs;

public class AtletaDAO
{
    public void Inserir(Atleta obj)
    {
        const string sql = "INSERT INTO atleta" +
            " (id, nome, altura, peso)" +
            " values " +
            " (@Id, @Nome, @Altura, @Peso)";
        
        Executar(sql, obj);
    }

    public void Alterar(Atleta obj)
    {
        const string sql = "UPDATE atleta" +
            " SET nome = @Nome, altura = @Altura, peso = @Peso" +
            " WHERE " +
            " id = @Id";

        Executar(sql, obj);
    }

    public void Excluir(long id)
    {
        const string sql = "DELETE atleta" +
            " WHERE " +
            " id = @Id";

        Executar(sql, new { Id = id });
    }

    public IList<Atleta> RetornarTodos()
    {
        const string sql = "SELECT id as Id, nome as Nome, altura as Altura, peso as Peso" + 
            " FROM atleta" + 
            " ORDER BY nome";

        return Selecionar(sql);
    }

    public Atleta? RetornarPorId(long id)
    {
        const string sql = "SELECT id as Id, nome as Nome, altura as Altura, peso as Peso" + 
            " FROM atleta" + 
            " WHERE id = @id";

        return SelecionarUnico(sql, new { id });
    }

    private void Executar(string sql, object obj)
    {
        using var conexao = new SqliteConnection("Data Source=db/app.db");

        conexao.Open();

        conexao.Execute(sql, obj); 
    }

    private IList<Atleta> Selecionar(string sql, object? obj = null)
    {
        using var conexao = new SqliteConnection("Data Source=db/app.db");

        conexao.Open();

        if (obj == null)
            return conexao.Query<Atleta>(sql).ToList();

        return conexao.Query<Atleta>(sql, obj).ToList();
    }

    private Atleta? SelecionarUnico(string sql, object? obj = null)
    {
        using var conexao = new SqliteConnection("Data Source=db/app.db");

        conexao.Open();

        if (obj == null)
            return conexao.QuerySingle<Atleta>(sql);

        return conexao.QuerySingle<Atleta>(sql, obj);
    }
}
