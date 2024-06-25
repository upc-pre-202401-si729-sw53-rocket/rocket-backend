using ROCKET.RocketOrganizeBackend.IAM.Domain.Model.Commands;
using ROCKET.RocketOrganizeBackend.IAM.Interfaces.REST.Resources;

namespace ROCKET.RocketOrganizeBackend.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}