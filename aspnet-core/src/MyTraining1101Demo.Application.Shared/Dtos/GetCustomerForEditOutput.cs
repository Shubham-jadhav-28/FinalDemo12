using System;
using System.Collections.Generic;
using System.Text;

namespace MyTraining1101Demo.Dtos
{
    public class GetCustomerForEditOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public List<long> UserIds { get; set; } = new List<long>();
    }

}
