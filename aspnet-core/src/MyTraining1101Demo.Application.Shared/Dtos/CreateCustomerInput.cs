using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTraining1101Demo.Dtos
{
    public class CreateCustomerInput
    {
        [Required]
        public string Name { get; set; }

   
        [EmailAddress]
        public string EmailId { get; set; }

        public string Address { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public List<long> UserIds { get; set; }
    }
}
