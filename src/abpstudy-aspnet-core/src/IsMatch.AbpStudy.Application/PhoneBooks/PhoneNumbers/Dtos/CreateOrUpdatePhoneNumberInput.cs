

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;

namespace IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.Dtos
{
    public class CreateOrUpdatePhoneNumberInput
    {
        [Required]
        public PhoneNumberEditDto PhoneNumber { get; set; }

    }
}