using System;
using System.Collections.Generic;

namespace ProjetoMVC.ModelsEF;

public partial class Piloto
{
    public int IdPiloto { get; set; }

    public string NomePiloto { get; set; } = null!;

    public string NacionalidadePiloto { get; set; } = null!;

    public int? IdEquipe { get; set; }

    public virtual Equipe? IdEquipeNavigation { get; set; }
}
