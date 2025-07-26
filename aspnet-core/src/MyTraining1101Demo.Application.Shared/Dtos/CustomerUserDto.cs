using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1101Demo.Dtos
{
    public class CustomerUserDto : EntityDto
    {
        public int CustomerId { get; set; }
        public long UserId { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
