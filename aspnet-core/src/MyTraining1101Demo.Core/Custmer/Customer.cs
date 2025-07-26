using Abp.Domain.Entities.Auditing;
using MyTraining1101Demo.Custmer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTraining1101Demo.Customers
{
    [Table("Customers")]
    public class Customer : FullAuditedEntity
    {
        [Required]
        public string Name { get; set; }

       
        public string EmailId { get; set; }

     
        public DateTime? RegistrationDate { get; set; }
        public string Address { get; set; }



        public virtual ICollection<CustomerUser> CustomerUsers { get; set; }

     
    }
}
