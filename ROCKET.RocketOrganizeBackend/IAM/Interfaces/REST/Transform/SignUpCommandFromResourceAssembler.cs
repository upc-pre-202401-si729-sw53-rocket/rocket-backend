using ROCKET.RocketOrganizeBackend.IAM.Domain.Model.Commands;
using ROCKET.RocketOrganizeBackend.IAM.Interfaces.REST.Resources;

namespace ROCKET.RocketOrganizeBackend.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}