using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using System.Linq.Dynamic.Core; 
using Abp.Linq.Extensions;      
using Microsoft.EntityFrameworkCore;


using MyTraining1101Demo.Authorization;
using MyTraining1101Demo.Authorization.Users;
using MyTraining1101Demo.Custmer;
using MyTraining1101Demo.Customers;
using MyTraining1101Demo.Dtos;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTraining1101Demo.Authorization.Users.Dto;

namespace MyTraining1101Demo.CustomerAppService
{
    public class CustomerAppService : MyTraining1101DemoAppServiceBase, ICustomerAppService
    {
        private readonly IRepository<Customer, int> _customerRepository;
        private readonly IRepository<CustomerUser, int> _customerUserRepository;
        private readonly IRepository<User, long> _userRepository;


        public CustomerAppService(
            IRepository<Customer, int> customerRepository, IRepository<CustomerUser, int> customerUserRepository, IRepository<User, long> userRepository
          )
        {
            _customerRepository = customerRepository;
            _customerUserRepository = customerUserRepository;
            _userRepository = userRepository;

        }

        public async Task<PagedResultDto<CustomerDto>> GetAll(GetAllCustomerInput input)
        {
          
            var query = _customerRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), c =>
                    c.Name.Contains(input.Filter) ||
                    c.EmailId.Contains(input.Filter) ||
                    c.Address.Contains(input.Filter));

          
            var totalCount = await query.CountAsync();

          
            var items = await query
                .OrderBy(input.Sorting ?? "name asc") 
                .PageBy(input) 
                .ToListAsync();

           
            return new PagedResultDto<CustomerDto>(
                totalCount,
                ObjectMapper.Map<List<CustomerDto>>(items)
            );
        }


        public async Task<ListResultDto<CustomerUserDto>> GetAllCustomerUsersAsync()
        {
            var customerUsers = await _customerUserRepository.GetAllIncluding(cu => cu.User)
                .Select(cu => new CustomerUserDto
                {
                    CustomerId = cu.CustomerId,
                    UserId = cu.UserId,
                    UserName = cu.User.UserName,
                    Email = cu.User.EmailAddress
                })
                .ToListAsync();

            return new ListResultDto<CustomerUserDto>(customerUsers);
        }

        public async Task Create(CreateCustomerInput input)
        {
            var customer = ObjectMapper.Map<Customer>(input);

            var customerId = await _customerRepository.InsertAndGetIdAsync(customer);

           
            if (input.UserIds != null && input.UserIds.Any())
            {
                foreach (var userId in input.UserIds)
                {
                    await _customerUserRepository.InsertAsync(new CustomerUser
                    {
                        CustomerId = customerId,
                        UserId = userId
                    });
                }
            }
        }

        public async Task DeleteCustomer(EntityDto input)
        {
            var customer = await _customerRepository.FirstOrDefaultAsync(input.Id);
            if (customer == null)
            {
                throw new UserFriendlyException("Customer not found.");
            }

          
            var relatedCustomerUsers = await _customerUserRepository
                .GetAll()
                .Where(cu => cu.CustomerId == input.Id)
                .ToListAsync();

            foreach (var customerUser in relatedCustomerUsers)
            {
                
                await _customerUserRepository.DeleteAsync(customerUser);
            }

            await _customerRepository.DeleteAsync(input.Id);
        }

        public async Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input)
        {
            var customer = await _customerRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<GetCustomerForEditOutput>(customer);

          
            var userIds = await _customerUserRepository
                .GetAll()
                .Where(x => x.CustomerId == input.Id)
                .Select(x => x.UserId)
                .ToListAsync();

            return new GetCustomerForEditOutput
            {
                Id = customer.Id,
                Name = customer.Name,
                EmailId = customer.EmailId,
                Address = customer.Address,
                RegistrationDate = customer.RegistrationDate,
                UserIds = userIds 
            };
        }


        public async Task EditCustomer(EditCustomerInput input)
        {
            var customer = await _customerRepository.GetAsync(input.Id);

            customer.Name = input.Name;
            customer.EmailId = input.EmailId;
            customer.Address = input.Address;
            customer.RegistrationDate = input.RegistrationDate;

            await _customerRepository.UpdateAsync(customer);

            if (input.UserIds != null)
            {
                var existingUsers = await _customerUserRepository.GetAllListAsync(x => x.CustomerId == input.Id);

                foreach (var user in existingUsers)
                {
                    await _customerUserRepository.DeleteAsync(user);
                }


                foreach (var userId in input.UserIds)
                {
                    await _customerUserRepository.InsertAsync(new CustomerUser
                    {
                        CustomerId = input.Id,
                        UserId = userId
                    });
                }
            }
        }
                                                                                                                                                                                        

        public async Task<ListResultDto<UserListDto>> GetUnassignedUsersAsync()
        {
            
            var assignedUserIds = await _customerUserRepository
                .GetAll()
                .Select(cu => cu.UserId)
                .Distinct()
                .ToListAsync();

           
            var unassignedUsers = await _userRepository
                .GetAll()
                .Where(u => !assignedUserIds.Contains(u.Id))
                .Where(u => u.IsActive) 
                .Select(u => new UserListDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Surname = u.Surname,
                    UserName = u.UserName,
                    EmailAddress = u.EmailAddress,
                    PhoneNumber = u.PhoneNumber,
                    ProfilePictureId = u.ProfilePictureId,
                    IsEmailConfirmed = u.IsEmailConfirmed,
                    IsActive = u.IsActive,
                    CreationTime = u.CreationTime
                })
                .ToListAsync();

            return new ListResultDto<UserListDto>(unassignedUsers);
        }
    }
}
