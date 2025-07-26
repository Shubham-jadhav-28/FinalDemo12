using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTraining1101Demo.Dtos
{
    public class CustomerDto : FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Address { get; set; }
        public List<long> UserIds { get; set; }
        //public virtual ICollection<CustomerUser> CustomerUsers { get; set; }
    }
}
