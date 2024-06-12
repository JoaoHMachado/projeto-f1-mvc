using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Data.ModelsEF;

namespace ProjetoMVC.App.Repository;

public interface IRepository
{
    Task<Equipe?> GetEquipByIdAsync(string equipId);
    Task<List<Equipe>> GetAllEquipsAsync();
    Task<Equipe?> GetEquipBySlugAsync(string slug);
}

public class EquipsRepository(Formula1Context dbContext) : IRepository
{
    public async Task<Equipe?> GetEquipByIdAsync(string equipId) =>
        await dbContext
            .Equipes
            .Include(e => e.Carros)
            .Include(e => e.Cheves)
            .Include(e => e.Conquista)
            .Include(e => e.Pilotos)
            .SingleOrDefaultAsync(e => e.IdEquipe.Equals(equipId));

    public async Task<List<Equipe>> GetAllEquipsAsync() => await dbContext
        .Equipes
        .Include(e => e.Carros)
        .Include(e => e.Cheves)
        .Include(e => e.Conquista)
        .Include(e => e.Pilotos).ToListAsync();

    public async Task<Equipe?> GetEquipBySlugAsync(string slug) => await dbContext
        .Equipes
        .Include(e => e.Carros)
        .Include(e => e.Cheves)
        .Include(e => e.Conquista)
        .Include(e => e.Pilotos)
        .SingleOrDefaultAsync(e => e.SlugEquipe!.Equals(slug.ToLower()));
    

}