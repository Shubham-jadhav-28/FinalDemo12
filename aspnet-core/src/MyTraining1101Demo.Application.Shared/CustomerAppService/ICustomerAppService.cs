using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTraining1101Demo.Authorization.Users.Dto;
using MyTraining1101Demo.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace MyTraining1101Demo.CustomerAppService
{
    public interface ICustomerAppService : IApplicationService
    {

        Task<PagedResultDto<CustomerDto>> GetAll(GetAllCustomerInput input);
        Task Create(CreateCustomerInput input);
        Task DeleteCustomer(EntityDto input);
        Task EditCustomer(EditCustomerInput input);
        Task<GetCustomerForEditOutput> GetCustomerForEdit(GetCustomerForEditInput input);
        Task<ListResultDto<CustomerUserDto>> GetAllCustomerUsersAsync();
        Task<ListResultDto<UserListDto>> GetUnassignedUsersAsync();
    }
}
