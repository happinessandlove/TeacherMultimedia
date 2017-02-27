using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class Building
    {

        public Building()
        {
            this.Classrooms = new List<ClassRoom>();
        }
        public Guid Id { get; set; }
        [DisplayName("楼号"), MyRequired, MaxLength(10)]
        public string Number { get; set; }

        #region 导航属性=====================================================================================
        public virtual List<ClassRoom> Classrooms { get; set; }
        #endregion===========================================================================================  
    }  
    }