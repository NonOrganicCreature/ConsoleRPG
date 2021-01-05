using ConsoleRPG.Player;

namespace ConsoleRPG
{
    public interface IConnectable
    {
        bool ValidateCredentials(AuthenticationData authenticationData);
    }
}