using ROCKET.RocketOrganizeBackend.IAM.Domain.Model.Aggregates;
using ROCKET.RocketOrganizeBackend.IAM.Interfaces.REST.Resources;

namespace ROCKET.RocketOrganizeBackend.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}