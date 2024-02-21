using Task_5.Models;

namespace Task_5.Interfaces
{
    public interface IFakerService
    {
        public IEnumerable<UserModel> GenerateUsers(int count, string region, int seed, double countOfError = 0);
        protected UserModel GenerateFakeUser();

        public void ConfigureFaker(string region, int seed = 1);
    }
}
