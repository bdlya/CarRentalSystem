using CarRentalSystem.View.ViewModels.Base;

namespace CarRentalSystem.View.ViewModels
{
    public class OrderAdditionalServiceViewModel: BaseEntityViewModel
    {
        public int OrderId { get; set; }

        public OrderViewModel Order { get; set; }

        public int AdditionalServiceId { get; set; }

        public AdditionalServiceViewModel AdditionalService { get; set; }
    }
}