using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1101Demo.PersonDto
{
    public static class PersonConsts
    {
        public const int MaxNameLength = 50; 
        public const int MaxSurnameLength = 50; 
        public const int MaxEmailAddressLength = 100; 
    }
    public class CreatePersonInput
    {
        [Required]
        [MaxLength(PersonConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PersonConsts.MaxSurnameLength)]
        public string Surname { get; set; }

        [EmailAddress]
        [MaxLength(PersonConsts.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
        public string ProfilePicture { get; set; }
    }

}
