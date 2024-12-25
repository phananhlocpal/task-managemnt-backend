using System;
using Core.Domain.Enumerations;

namespace Core.Domain.Entities
{
    // Entity: User
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public UserRoleEnum Role { get; private set; }

        // Constructor
        public User(Guid id, string name, string email, UserRoleEnum userRoleEnum)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty", nameof(email));

            Id = id;
            Name = name;
            Email = email;
            Role = userRoleEnum;
        }

        // Parameterless constructor for EF Core
        private User() { }
    }
}