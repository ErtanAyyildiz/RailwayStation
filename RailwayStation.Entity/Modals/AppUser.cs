using Microsoft.AspNetCore.Identity;

namespace RailwayStation.Entity.Modals
{
    public class AppUser:IdentityUser<int>
    {
        public string? NameSurname { get; set; }
    }
}
