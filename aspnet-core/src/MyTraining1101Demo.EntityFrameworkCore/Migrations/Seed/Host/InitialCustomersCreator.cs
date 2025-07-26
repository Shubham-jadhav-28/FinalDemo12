

using MyTraining1101Demo.Customers;
using MyTraining1101Demo.EntityFrameworkCore;
using System;
using System.Linq;

namespace MyTraining1101Demo.Migrations.Seed.Host
{
    public class InitialCustomersCreator
    {
        private readonly MyTraining1101DemoDbContext _context;

        public InitialCustomersCreator(MyTraining1101DemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCustomers();
        }

        private void CreateCustomers()
        {
            AddCustomerIfNotExists("Shubham", "shubham@example.com", "Mumbai", DateTime.Now);
            AddCustomerIfNotExists("John Doe", "john@example.com", "New York", new DateTime(2023, 5, 1));
        }

        private void AddCustomerIfNotExists(string name, string email, string address, DateTime? registrationDate)
        {
            var existing = _context.Customers.FirstOrDefault(c => c.EmailId == email);
            if (existing == null)
            {
                _context.Customers.Add(new Customer
                {
                    Name = name,
                    EmailId = email,
                    Address = address,
                    RegistrationDate = registrationDate
                });
            }
        }
    }
}
