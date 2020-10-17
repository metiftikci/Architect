namespace Architect.ApplicationCore.Services
{
    public interface IServiceUnit
    {
        IUserService UserService { get; }

        TService GetService<TService>();
    }
}
