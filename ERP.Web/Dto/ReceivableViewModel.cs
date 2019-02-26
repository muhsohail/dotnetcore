using Models;

namespace ERP.Dto
{
    public class ReceivableViewModel
    {

        public Receivable Receivable { get; set; }  
        public string MillJson { get; set; }
        public string ReceivableJson { get; set; }

        public string ButtonText { get; set; }
    }
}
