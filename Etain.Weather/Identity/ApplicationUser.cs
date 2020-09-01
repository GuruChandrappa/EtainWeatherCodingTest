using Microsoft.AspNet.Identity.EntityFramework;

namespace Microsoft.AspNetCore.Identity
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
