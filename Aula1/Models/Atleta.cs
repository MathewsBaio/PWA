using System;

namespace Aula1.Models;

public class Atleta : IModel
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public double Altura { get; set; }
    public double Peso { get; set; }
}
