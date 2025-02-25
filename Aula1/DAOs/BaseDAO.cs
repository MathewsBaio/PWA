using System;
using System.Text.Json;
using Aula1.Models;

namespace Aula1.DAOs;

public abstract class BaseDAO<T> where T : IModel
{
    protected abstract string Caminho { get; }

    public void Inserir(T obj)
    {
        dados.Add(obj);
        Salvar();
    }

    private void Salvar()
    {
        File.WriteAllText(Caminho, JsonSerializer.Serialize(dados));
    }

    public void Alterar(T obj)
    {
        var objExistente = dados.FirstOrDefault(x => x.Id == obj.Id);

        if (objExistente == null)
            throw new Exception("Registro inexistente");

        dados.Remove(objExistente);
        dados.Add(obj);

        Salvar();
    }

    public void Excluir(long id)
    {
        var objExistente = dados.FirstOrDefault(x => x.Id == id);

        if (objExistente == null)
            throw new Exception("Registro inexistente");

        dados.Remove(objExistente);

        Salvar();
    }

    public IList<T> RetornarTodos() => ObterDados();

    public T? RetornarPorId(long id) => ObterDados().FirstOrDefault(x => x.Id == id);

    private IList<T> ObterDados()
    {
        try
        {
            var conteudo = File.ReadAllText(Caminho);

            return dados = JsonSerializer.Deserialize<IList<T>>(conteudo) ?? [];
        }
        catch
        {
            return [];
        }
    }

    private static IList<T> dados = [];
}
