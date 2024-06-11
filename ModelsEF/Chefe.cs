using System;
using System.Collections.Generic;

namespace ProjetoMVC.ModelsEF;

public partial class Chefe
{
    public int IdChefe { get; set; }

    public string NomeChefe { get; set; } = null!;

    public int? IdEquipe { get; set; }

    public virtual Equipe? IdEquipeNavigation { get; set; }
}
