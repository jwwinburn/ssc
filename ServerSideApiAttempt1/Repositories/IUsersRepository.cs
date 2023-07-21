using ServerSideApiAttempt1.Models;

namespace ServerSideApiAttempt1.Repositories
{
    public interface IUsersRepository
    {
        Users GetByFirebaseUserId(string firebaseUserId);
    }
}