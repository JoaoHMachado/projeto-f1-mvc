using Microsoft.EntityFrameworkCore;
using ProjetoMVC.ModelsEF;

namespace ProjetoMVC.Repository;

public interface IRepository
{
    Task<Equipe?> GetEquipByIdAsync(string equipId);
    Task<List<Equipe>> GetAllEquipsAsync();
}

public class Repository(Formula1Context dbContext) : IRepository
{
    public async Task<Equipe?> GetEquipByIdAsync(string equipId) =>
        await dbContext
            .Equipes
            .Include(e => e.Carros)
            .Include(e => e.Chefes)
            .Include(e => e.Conquista)
            .Include(e => e.Pilotos)
            .SingleOrDefaultAsync(e => e.IdEquipe.Equals(equipId));

    public async Task<List<Equipe>> GetAllEquipsAsync() => await dbContext
        .Equipes
        .Include(e => e.Carros)
        .Include(e => e.Chefes)
        .Include(e => e.Conquista)
        .Include(e => e.Pilotos).ToListAsync();
}