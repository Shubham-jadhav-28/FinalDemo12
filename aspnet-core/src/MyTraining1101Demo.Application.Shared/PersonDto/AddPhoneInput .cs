using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTraining1101Demo.Enum;
using MyTraining1101Demo.PhoneBook;


namespace MyTraining1101Demo.PhoneBook
{
    public class AddPhoneInput
    {
        public static class PhoneConsts
        {
            public const int MaxNumberLength = 16;
        }

        [Range(1, int.MaxValue)]
        public int PersonId { get; set; }

        [Required]
        public PhoneType Type { get; set; }

        [Required]
        [MaxLength(PhoneConsts.MaxNumberLength)]
        public string Number { get; set; }
    }

}
