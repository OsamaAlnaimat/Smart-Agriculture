using MediatR;
using SmartAgriculture.Application.Farms.Dtos;

namespace SmartAgriculture.Application.Farms.Queries.GetFarmById
{
    public class GetFarmByIdQuery(int id) : IRequest<FarmDtos>
    {
        public int Id { get; } = id;
    }
}
