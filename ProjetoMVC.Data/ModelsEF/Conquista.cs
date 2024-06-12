using System;
using System.Collections.Generic;

namespace ProjetoMVC.Data.ModelsEF;

public partial class Conquista
{
    public int IdConquista { get; set; }

    public string? QtdGrandesPremios { get; set; }

    public string? QtdTitulosConstrutores { get; set; }

    public string? QtdTitulosPilotos { get; set; }

    public string? QtdVitorias { get; set; }

    public string? QtdPodios { get; set; }

    public string? QtdPolePosition { get; set; }

    public string? QtdVoltasRapidas { get; set; }

    public int? IdEquipe { get; set; }

    public virtual Equipe? IdEquipeNavigation { get; set; }
}
