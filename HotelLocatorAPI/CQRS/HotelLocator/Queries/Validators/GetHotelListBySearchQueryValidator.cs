using FluentValidation;
using HotelLocator.API.CQRS.HotelLocator.Queries.GetHotelListBySearchParam;

namespace HotelLocator.API.CQRS.HotelLocator.Queries.Validators
{
    public class GetHotelListBySearchQueryValidator : AbstractValidator<GetHotelListBySearchQuery>
    {
        public GetHotelListBySearchQueryValidator()
        {
            RuleFor(m => m.HotelName).NotEmpty().Unless(m => m.Rating != null).WithMessage("Please enter hotel name or rating");
        }
    }
}
