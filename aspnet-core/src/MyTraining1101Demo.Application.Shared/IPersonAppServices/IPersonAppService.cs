using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyTraining1101Demo.PersonDto;
using MyTraining1101Demo.PhoneBook;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MyTraining1101Demo.IPersonAppServices
{
 public interface   IPersonAppService : IApplicationService
    {
       Task<ListResultDto<PersonListDto>> GetPeopleAsync(GetPeopleInput input);
       Task CreatePerson(CreatePersonInput input);
       Task DeletePerson(EntityDto input);
        Task DeletePhone(EntityDto<long> input);
       Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input);
        Task EditPerson(EditPersonInput input);
        Task<GetPersonForEditOutput> GetPersonForEdit(GetPersonForEditInput input);
    }
}
