using ProjetoMVC.ModelsEF;

namespace ProjetoMVC.DTO
{
    public class EquipeModelo
    {
        public Equipe Equipe { get; set; }
        public Carro Carros { get; set; }
        public Chefe Chefes { get; set; }
        public Conquista Conquistas { get; set; }
        public List<Piloto> Pilotos { get; set; }
    }
}
