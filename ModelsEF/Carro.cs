using System;
using System.Collections.Generic;

namespace ProjetoMVC.ModelsEF;

public partial class Carro
{
    public int IdCarro { get; set; }

    public string ModeloCarro { get; set; } = null!;

    public string FabricanteMotor { get; set; } = null!;

    public int? IdEquipe { get; set; }

    public virtual Equipe? IdEquipeNavigation { get; set; }
}
