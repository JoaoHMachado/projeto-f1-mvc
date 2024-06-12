using ProjetoMVC.ModelsEF;
using ProjetoMVC.Repository;

namespace ProjetoMVC.Services;

public interface IEquipServices
{
    Task<Equipe?> GetEquipByIdAsync(string equipId);
    Task<List<Equipe>> GetAllEquipsAsync();
}

public class EquipServices(IRepository repository) : IEquipServices
{
    public async Task<Equipe?> GetEquipByIdAsync(string equipId) =>
        await repository.GetEquipByIdAsync(equipId);

    public async Task<List<Equipe>> GetAllEquipsAsync() =>
        await repository.GetAllEquipsAsync();
}