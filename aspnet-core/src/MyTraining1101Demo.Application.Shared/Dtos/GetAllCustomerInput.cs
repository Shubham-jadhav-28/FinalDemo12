using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1101Demo.Dtos
{
    public class GetAllCustomerInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
