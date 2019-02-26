using Models;

namespace ERP.Dto
{
    public class EditConsignmentViewModel
    {
        public EditConsignmentViewModel()
        {
            ConsignmentOrder = new ConsignmentOrder();

        }
        public string MillJson { get; set; }
        public string ConsignmentOrderJson { get; set; }
        public ConsignmentOrder ConsignmentOrder { get; set; }
    }
}
