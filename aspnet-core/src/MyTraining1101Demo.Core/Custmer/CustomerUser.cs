using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

using MyTraining1101Demo.Authorization.Users;
using MyTraining1101Demo.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1101Demo.Custmer
{
    [Table("CustomerUsers")]
    public class CustomerUser : CreationAuditedEntity
    {
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }


    }
}
