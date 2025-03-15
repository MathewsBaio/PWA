using System;
using System.Reflection;
using Aula1.Models;

namespace Aula1.DAOs;

public class TreinadorDAO : BaseDAO<Treinador>
{
    protected override string NomeTabela = "treinador";
}
