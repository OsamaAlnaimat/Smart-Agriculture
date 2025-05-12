namespace SmartAgriculture.Application.Users
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}