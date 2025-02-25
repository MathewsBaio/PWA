using System;

namespace Aula1.Models;

public class Treinador : IModel
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}
