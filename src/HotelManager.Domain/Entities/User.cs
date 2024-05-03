using HotelManager.Core.Domain;
using HotelManager.Core.Exceptions;
using HotelManager.Core.Enums;

namespace HotelManager.Domain.Entities
{
    public class User : Entity
    {
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Password { get; private set; }
        public UserRole Role { get; private set; }
        public string? Cpf { get; private set; }
        public string? Phone { get; private set; }
        public double Fine { get; private set; }
        public bool Blocked { get; private set; }
        public bool Deleted { get; private set; }

        protected User() { }

        private User(string? name, string? email, string? password, UserRole role, string? cpf, string? phone)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Cpf = cpf;
            Phone = phone;
            Fine = 0;

            Validations();
        }

        public static User Create(string? name, string? email, string? password, UserRole role, string? cpf, string? phone)
        {
            return new User(name, email, password, role, cpf, phone);
        }

        public void Update(string? name, string? cpf, string? email, string? phone)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Phone = phone;

            Validations();
        }

        public void UpdatePassword(string? password)
        {
            Password = password;

            AssertionHelper.ArgumentNotEmpty(Password, "A senha do usuário não pode ser vazia.");
            AssertionHelper.ArgumentLength(Password, 100, "A senha não pode ter mais que 100 caracteres");
        }

        public void AddFine(double amount)
        {
            Fine += amount;

            AssertionHelper.ArgumentLessThan(Fine, 0, "A multa não pode ser negativa");
        }

        public void RemoveFine()
        {
            Fine = 0;
        }

        public void Block()
        {
            Blocked = true;
        }

        public void Unblock()
        {
            Blocked = false;
        }

        public void Delete()
        {
            Deleted = true;
        }

        private void Validations()
        {
            AssertionHelper.ArgumentNotEmpty(Name, "O nome do usuário não pode ser vazio.");
            AssertionHelper.ArgumentLength(Name, 100, "O nome não pode ter mais que 100 caracteres");
            AssertionHelper.ArgumentNotEmpty(Email, "O email do usuário não pode ser vazio.");
            AssertionHelper.ArgumentLength(Email, 100, "O e-mail não pode ter mais que 100 caracteres");
            AssertionHelper.ArgumentNotEmpty(Password, "A senha do usuário não pode ser vazia.");
            AssertionHelper.ArgumentLength(Password, 100, "A senha não pode ter mais que 100 caracteres");
            AssertionHelper.ArgumentNotEmpty(Cpf, "O CPF do usuário não pode ser vazio.");
            AssertionHelper.ArgumentLength(Cpf, 11, "O cpf não pode ter mais que 11 caracteres");
            AssertionHelper.ArgumentNotEmpty(Phone, "O telefone do usuário não pode ser vazio.");
            AssertionHelper.ArgumentLength(Phone, 20, "O cpf não pode ter mais que 11 caracteres");
        }
    }
}