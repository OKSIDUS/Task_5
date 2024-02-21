using Bogus;
using Task_5.Interfaces;
using Task_5.Models;

namespace Task_5.Services
{
    public class FakerService : IFakerService
    {
        private Faker<UserModel> _faker;

        public IEnumerable<UserModel> GenerateUsers(int count, string region, int seed, double countOfError = 0)
        {
            var users = new List<UserModel>();
            ConfigureFaker(region, seed);
            var error = new ErrorGenerator(region);
            for (int i = 0; i < count; i++)
            {
                users.Add(error.MakeError(GenerateFakeUser(),countOfError));

            }

            return users;
        }

        public UserModel GenerateFakeUser()
        {
            var user = _faker.Generate();
            int lastComma = user.Address.LastIndexOf(',');
            string newAddress = user.Address.Substring(0, lastComma);
            user.Address = newAddress;
            
            return user;
        }

        public void ConfigureFaker(string region, int seed)
        {
            _faker = new Faker<UserModel>(region)
                .RuleFor(u => u.UserId, f => f.Random.Uuid().ToString())
                .RuleFor(u => u.UserName, f => f.Name.FullName())
                .RuleFor(u => u.Address, f => f.Address.FullAddress())
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());
            _faker.UseSeed(seed);
        }
    }
}
