using System;
using System.Collections.Generic;

namespace ProjetoMVC.ModelsEF;

public partial class Equipe
{
    public int IdEquipe { get; set; }

    public string NomeEquipe { get; set; } = null!;

    public virtual ICollection<Carro> Carros { get; set; } = new List<Carro>();

    public virtual ICollection<Chefe> Chefes { get; set; } = new List<Chefe>();

    public virtual ICollection<Conquista> Conquista { get; set; } = new List<Conquista>();

    public virtual ICollection<Piloto> Pilotos { get; set; } = new List<Piloto>();
}
