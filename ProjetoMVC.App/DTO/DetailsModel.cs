using ProjetoMVC.Data.ModelsEF;

namespace ProjetoMVC.App.DTO
{
    public class DetailsModel
    {
        public List<Equipe> Equips { get; set; } 
        public Equipe SelectedEquip { get; set; }
       
    }
}
