using System;
using System.Collections.Generic;

namespace ProjetoMVC.Data.ModelsEF;

public partial class ViewEquipe
{
    public int IdCarro { get; set; }

    public string ModeloCarro { get; set; } = null!;

    public string FabricanteMotor { get; set; } = null!;

    public int? IdEquipe { get; set; }
}
