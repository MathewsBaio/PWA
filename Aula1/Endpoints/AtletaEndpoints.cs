using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Aula1.DAOs;
using Aula1.Models;

namespace Aula1.Endpoints;

public static class AtletaEndpoints
{
    internal static void MapearAtletas(this WebApplication app)
    {
        string pasta = "atletas";
        app.MapGet($"/{pasta}", Get);
        app.MapGet($"/{pasta}/{{id}}", GetById);
        app.MapPost($"/{pasta}", Post);
        app.MapPut($"/{pasta}/{{id}}", Put);
        app.MapDelete($"/{pasta}/{{id}}", Delete);
    }

    private static AtletaDAO GetDAO() => new AtletaDAO();

    private static IResult Get()
    {
        return TypedResults.Ok(GetDAO().RetornarTodos());
    }

    private static IResult GetById(long id)
    {
        var obj = GetDAO().RetornarPorId(id);
        return obj == null ? TypedResults.NotFound() : TypedResults.Ok(obj);
    }

    private static IResult Post(Atleta obj)
    {
        var objetos = GetDAO().RetornarTodos();
        obj.Id = objetos.Count == 0 ? 1 : objetos.Max(x => x.Id) + 1;
        
        GetDAO().Inserir(obj);
        return TypedResults.Created($"/atletas/{obj.Id}", obj);
    }

    private static IResult Put(long id, Atleta obj)
    {
        GetDAO().Alterar(obj);
        
        return TypedResults.NoContent();
    }

    private static IResult Delete(long id)
    {
        GetDAO().Excluir(id);
        
        return TypedResults.NoContent();
    }
}
