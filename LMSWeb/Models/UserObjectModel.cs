namespace LMSWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserObject")]
    public partial class UserObjectModel
    {
        public int UserObjectId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50)]
        [DisplayName("User Name")]
        public string UserObjectName { get; set; }

        [DataType(DataType.Password)]

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(100)]
        [DisplayName("Password")]
        public string UserObjectPassword { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
