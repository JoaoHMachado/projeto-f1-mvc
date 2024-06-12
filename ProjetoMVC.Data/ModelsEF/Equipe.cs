using System;
using System.Collections.Generic;

namespace ProjetoMVC.Data.ModelsEF;

public partial class Equipe
{
    public int IdEquipe { get; set; }

    public string NomeEquipe { get; set; } = null!;

    public string? SlugEquipe { get; set; }

    public string? UrlFotoScuderia { get; set; }

    public string? UrlFotoPilotos { get; set; }

    public string? UrlImagemExibicao { get; set; }

    public string? CorScuderia { get; set; }

    public virtual ICollection<Carro> Carros { get; set; } = new List<Carro>();

    public virtual ICollection<Chefe> Cheves { get; set; } = new List<Chefe>();

    public virtual ICollection<Conquista> Conquista { get; set; } = new List<Conquista>();

    public virtual ICollection<Piloto> Pilotos { get; set; } = new List<Piloto>();
}
