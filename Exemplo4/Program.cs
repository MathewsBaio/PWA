using System.Text.RegularExpressions;
using Exemplo4;
using Microsoft.Data.Sqlite;

var sql = "INSERT INTO venda (id, id_cliente, numero, valor)" + 
          " VALUES (@Id, @Cliente.Id, @Numero, @Valor)";

var obj = new Venda { Id = 2, Numero = 10, Valor = 12.3, Cliente = new Cliente { Id = 123, Nome = "Zé" } } ;

using (SqliteConnection conexao = new SqliteConnection("Data Source=db/app.db"))
{
    conexao.Open();

    conexao.Executar(sql, obj);
}

Console.WriteLine("Inserção finalizada");