using System.ComponentModel.DataAnnotations;

namespace ERP.ViewModels
{
    public class ApplicationRoleViewModel
    {
        public string Id { get; set; }

        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
