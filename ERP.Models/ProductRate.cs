using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ProductRate
    {
        public Guid Id { get; set; }

        [DisplayName("Asking Rate")]
        public double AskingRate { get; set; }

        [DisplayName("Minimum Rate")]
        public double MinimumRate { get; set; }

        [DisplayName("Maximum Rate")]
        public double MaximumRate { get; set; }

        [DisplayName("Active?")]
        public bool IsActive { get; set; }

        [DisplayName("Fabric")]
        [ForeignKey("Fabric")]
        public Guid? FabricId { get; set; }
        public Fabric Fabric { get; set; }

        //[NotMapped]
        //public string Description
        //{
        //    get
        //    {

        //        return string.Format("{0}/{1}", Fabric.Code, Fabric.FabricType.Type);
        //    }
        //}

    }
}
