
using Abp.Runtime.Validation;
using IsMatch.AbpStudy.Dtos;
using IsMatch.AbpStudy.PhoneBooks.Persons;

namespace IsMatch.AbpStudy.PhoneBooks.Persons.Dtos
{
    public class GetPersonsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// ?????????????????????
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
