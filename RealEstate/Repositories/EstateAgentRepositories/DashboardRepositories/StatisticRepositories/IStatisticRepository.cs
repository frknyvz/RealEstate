namespace RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        int AllProductCount();
        int ProductCountByEmployeeId(int id);
        int ProductCountByStatusFalse(int id);
        int ProductCountByStatusTrue(int id);

    }
}
