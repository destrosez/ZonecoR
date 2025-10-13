using Domain.Models;
using Mapster;
using ZonecoR.Contracts.Users;

namespace ZonecoR.Mappings
{
    public static class MapsterConfig
    {
        public static void Register()
        {
            TypeAdapterConfig.GlobalSettings.Default
                .NameMatchingStrategy(NameMatchingStrategy.Flexible);

            TypeAdapterConfig<CreateUserRequest, User>.NewConfig();

            TypeAdapterConfig<User, UserResponse>
                .NewConfig()
                .Map(d => d.CreatedUtc, s => s.created_at);
        }
    }
}