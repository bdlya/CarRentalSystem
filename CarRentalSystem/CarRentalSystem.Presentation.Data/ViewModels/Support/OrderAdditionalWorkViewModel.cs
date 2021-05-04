using CarRentalSystem.Presentation.Data.ViewModels.Base;
using CarRentalSystem.Presentation.Data.ViewModels.Main;

namespace CarRentalSystem.Presentation.Data.ViewModels.Support
{
    public class OrderAdditionalWorkViewModel: BaseEntityViewModel
    {
        public int OrderId { get; set; }

        public OrderViewModel Order { get; set; }

        public int AdditionalServiceId { get; set; }

        public AdditionalWorkViewModel AdditionalWork { get; set; }
    }
}