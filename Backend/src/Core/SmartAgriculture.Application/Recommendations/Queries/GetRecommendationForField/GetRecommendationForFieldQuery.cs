using MediatR;
using SmartAgriculture.Application.Recommendations.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Recommendations.Queries.GetRecommendationForField
{
    public class GetRecommendationForFieldQuery(int farmId, int fieldId):IRequest<RecommendationDto>
    {
        public int FarmId { get; set; } = farmId;
        public int FieldId { get; set; } = fieldId; 
    }
}
