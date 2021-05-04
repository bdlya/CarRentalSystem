using CarRentalSystem.Application.Data.Models.Base;
using CarRentalSystem.Application.Data.Models.Main;

namespace CarRentalSystem.Application.Data.Models.Support
{
    public class OrderAdditionalWorkModel: BaseEntityModel
    {
        public int OrderId { get; set; }

        public OrderModel Order { get; set; }

        public int AdditionalWorkId { get; set; }

        public AdditionalWorkModel AdditionalWork { get; set; }
    }
}