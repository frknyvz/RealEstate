using RealEstate_API.Dtos.ToDoListDtos;

namespace RealEstate_API.Repositories.ToDoListRepositories
{
    public interface IToDoListRepository
    {

        Task<List<ResultToDoListDto>> GetAllToDoListAsync();
        void CreateToDoList(CreateToDoListDto createToDoListDto);
        void UpdateToDoList(UpdateToDoListDto updateToDoListDto);
        void DeleteToDoList(int id);
        Task<GetByIdToDoListDto> GetToDoList(int id);

    }
}
