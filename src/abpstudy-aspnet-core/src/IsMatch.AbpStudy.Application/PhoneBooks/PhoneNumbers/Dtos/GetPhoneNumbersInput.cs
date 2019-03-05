
using Abp.Runtime.Validation;
using IsMatch.AbpStudy.Dtos;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;

namespace IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.Dtos
{
    public class GetPhoneNumbersInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
