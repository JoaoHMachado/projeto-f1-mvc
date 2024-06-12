using ProjetoMVC.App.Repository;
using ProjetoMVC.Data.ModelsEF;

namespace ProjetoMVC.App.Services;

public interface IEquipServices
{
    Task<Equipe?> GetEquipByIdAsync(string equipId);
    Task<Equipe?> GetEquipBySlugAsync(string slug);
    Task<List<Equipe>> GetAllEquipsAsync(); 
}

public class EquipServices(IRepository repository) : IEquipServices
{
    public async Task<Equipe?> GetEquipByIdAsync(string equipId) =>
        await repository.GetEquipByIdAsync(equipId);

    public async Task<Equipe?> GetEquipBySlugAsync(string slug)=>
        await repository.GetEquipBySlugAsync(slug);

    public async Task<List<Equipe>> GetAllEquipsAsync() =>
        await repository.GetAllEquipsAsync();
 
    
}