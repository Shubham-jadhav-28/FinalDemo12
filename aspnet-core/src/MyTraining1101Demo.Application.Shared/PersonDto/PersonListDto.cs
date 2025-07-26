using Abp.Application.Services.Dto;
using MyTraining1101Demo.Enum;
using MyTraining1101Demo.PhoneConsts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyTraining1101Demo.PersonDto
{
    public class PersonListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }
        public Collection<PhoneInPersonListDto> Phones { get; set; }
        public string ProfilePicture { get; set; }
    }
    public class PhoneInPersonListDto : CreationAuditedEntityDto<long>
    {
        public PhoneType Type { get; set; }

        public string Number { get; set; }
      public string ProfilePicture { get; set; }
    }
}
