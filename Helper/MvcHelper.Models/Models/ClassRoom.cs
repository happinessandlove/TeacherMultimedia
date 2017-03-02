using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class ClassRoom
    {
        [SelectListValueProperty]
        public Guid Id { get; set; }
        [DisplayName("教室号"), MyRequired, MaxLength(10),SelectListTextProperty]
        public string Number { get; set; }
        #region  导航属性==============================================================================================
        public virtual Device Device { get; set; }
        public Guid BuildingId { get; set; }
        public virtual Building Building { get; set; }
        #endregion===========================================================================================
    }
}