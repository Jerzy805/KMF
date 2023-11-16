using System.Security.Claims;

namespace KMF.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
        bool IsAdmin();
    }

    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor contextAccessor;
        public UserContext(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public CurrentUser? GetCurrentUser()
        {
            var user = contextAccessor?.HttpContext?.User;

            if (user == null || !user.Identity!.IsAuthenticated)
            {
                return null;
            }

            var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            return new CurrentUser(id, email, roles);
        }

        public bool IsAdmin()
        {
            var user = GetCurrentUser();

            if (user != null || user!.Email == "j.chmiel2006@gmail.com" || user!.Email == "osiedle5@wp.pl" || user.IsInRole("Admin"))
            {
                return true;
            }

            return false;
        }
    }
}
