using Signature_Assessment_Models;

namespace Signature_Assessment_API.Contracts
{
    public interface IUserService
    {
        Person Login(string name, string password);
        Person GetPersonById(int id);
    }
}
