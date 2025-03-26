using Microsoft.Data.Sqlite;
using System.Data;
using System.Text.RegularExpressions;

public static class Douglas
{
    public static void Executar(this IDbConnection conexao, string sql, object parametros)
    {
        var regex = new Regex(@"\@[\w\.]+");
        
        var cmd = conexao.CreateCommand();
        
        var nomesParametros = regex.Matches(sql).Select(x => x.ToString().Substring(1)).OrderByDescending(x => x);

        foreach (var nomeParametro in nomesParametros)
        {
            sql = sql.Replace(nomeParametro, nomeParametro.Replace('.', '_'));
            var dbParametro = cmd.CreateParameter();
            dbParametro.ParameterName = nomeParametro.Replace('.', '_');
            dbParametro.Value = parametros.GetPropriedade(nomeParametro);

            cmd.Parameters.Add(dbParametro);

            //if (nomeParametro.Contains('.'))
//                sql = 
        }

        cmd.CommandText = sql;

        cmd.ExecuteNonQuery();
    }

    public static object? GetPropriedade(this object obj, string nomePropriedade)
    {
        Console.WriteLine("->" + nomePropriedade);

        var propriedades = nomePropriedade.Split('.');

        var objAtual = obj;

        for (var i = 0; i < propriedades.Length; i++)
        {
            objAtual = GetPropriedadeUnica(objAtual, propriedades[i]);

            if (objAtual == null)
                return objAtual;
        }

        return objAtual;
    }

    public static object? GetPropriedadeUnica(this object obj, string nomePropriedade)
    {
        Console.WriteLine("===>" + nomePropriedade);
        var tipo = obj.GetType();

        return tipo?.GetProperty(nomePropriedade)?.GetValue(obj);
    }
}