using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Class
    {
        public Class()
        {
            this.Students = new List<Student>();
        }

        public Guid Id { get; set; }

        #region 导航
        public Guid CollegeId { get; set; }
        public virtual College College { get; set; }        
        public virtual ICollection<Student> Students { get; set; }
        #endregion

        [MyRequired]
        [MyMaxLength(20)]
        public string Name { get; set; }

    }
}
