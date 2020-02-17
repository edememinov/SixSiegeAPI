using RSixSiegeHUD.Data.Entities;

namespace RSixSiegeHUD.Infrastructure.Factories.Factories
{
    public class UserFactory
    {
        public User CreateUser(dynamic jsonObject)
        {
            if (jsonObject == null)
            {
                return null;
            }
            var userUbisoft = jsonObject.GetValue("userUbisoft");
            if (userUbisoft == null)
            {
                return null;
            }

            return new User()
            {
                OverWolfId = jsonObject.GetValue("userId"),
                UbisoftId = userUbisoft,
                UserName = jsonObject.GetValue("username")
            };

        }
    }
}
