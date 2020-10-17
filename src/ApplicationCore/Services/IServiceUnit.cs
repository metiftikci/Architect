namespace Architect.ApplicationCore.Services
{
    public interface IServiceUnit
    {
        IUserService UserService { get; }
        IRecordService RecordService { get; }

        TService GetService<TService>();
    }
}
