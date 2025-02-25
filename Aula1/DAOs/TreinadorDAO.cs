using System;
using System.Reflection;
using Aula1.Models;

namespace Aula1.DAOs;

public class TreinadorDAO : BaseDAO<Treinador>
{
    protected override string Caminho => Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "treinadores.json"
        );
}
