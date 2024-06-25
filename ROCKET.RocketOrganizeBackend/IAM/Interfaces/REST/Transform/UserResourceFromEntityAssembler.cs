using ROCKET.RocketOrganizeBackend.IAM.Domain.Model.Aggregates;
using ROCKET.RocketOrganizeBackend.IAM.Interfaces.REST.Resources;

namespace ROCKET.RocketOrganizeBackend.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(user.Id, user.Username);
    }
}