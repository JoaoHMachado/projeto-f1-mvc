using System;
using System.Collections.Generic;

namespace ProjetoMVC.ModelsEF;

public partial class Equipes2
{
    public int? EquipeId { get; set; }

    public string NomeEquipe { get; set; } = null!;

    public string Construtor { get; set; } = null!;

    public string NomeChefe { get; set; } = null!;

    public string NomePiloto1 { get; set; } = null!;

    public string NacionalidadePiloto1 { get; set; } = null!;

    public string NomePiloto2 { get; set; } = null!;

    public string NacionalidadePiloto2 { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public string Motor { get; set; } = null!;

    public string? QtdGrandesPremios { get; set; }

    public string? QtdTitulosConstrutores { get; set; }

    public string? QtdTitulosPilotos { get; set; }

    public string? QtdVitorias { get; set; }

    public string? QtdPodios { get; set; }

    public string? QtdPolePosition { get; set; }

    public string? QtdVoltasRapidas { get; set; }
}
