using DataAccessLayer.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;
using FizzWare.NBuilder;
using DataAccessLayer;

namespace AccountTest
{
    [TestFixture]
    public class UserRepositoryUnitTest
    {
        UserRepository _userRepository;
        EntityConnection _connection;
        IList<UserProfile> _userList;

        [SetUp]
        public void Init()
        {
            _connection = Effort.EntityConnectionFactory.CreateTransient("name=BazaarEntities");
            _userRepository = new UserRepository(_connection);
        }

        private void PopulateRepository(int numberOfUsers)
        {
            _userRepository = new UserRepository(_connection);
            int salt = Faker.RandomNumber.Next();
            if (numberOfUsers > 0)
            {
                _userList = Builder<UserProfile>.CreateListOfSize(numberOfUsers)
                    .All()
                        .With(u => u.Username = Faker.Internet.UserName())
                        .With(u => u.Salt = salt)
                        .With(u => u.Password = Faker.Lorem.GetFirstWord() + salt)
                    .Build();
                foreach (var item in _userList)
                {
                    _userRepository.Register(item.Username, item.Password);
                }
            }
        }

        [Test]
        public void RegisterDuplicateAccount()
        {
            PopulateRepository(1);
            var user = _userList[0];
            Guid guid = _userRepository.Register(user.Username, "Password doesn't matter");
            Assert.AreEqual(Guid.Empty, guid);
        }

        [Test]
        public void RegisterNullUsername()
        {
            PopulateRepository(0);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _userRepository.Register(null, "Mah password"));
        }
    }
}
