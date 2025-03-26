using System;

namespace Exemplo4;

public class Venda
{
    public int Id { get; set; }
    public Cliente Cliente { get; set; } = null!;
    public int Numero { get; set; }
    public double Valor { get; set; }
}
