

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IsMatch.AbpStudy.PhoneBooks.Persons;

namespace IsMatch.AbpStudy.PhoneBooks.Persons.Dtos
{
    public class CreateOrUpdatePersonInput
    {
        [Required]
        public PersonEditDto Person { get; set; }

    }
}