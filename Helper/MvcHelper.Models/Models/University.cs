using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class University
    {
        public University()
        {
            this.Colleges = new List<College>();
        }

        public Guid Id { get; set; }

        #region 导航
        public virtual ICollection<College> Colleges { get; set; }
        #endregion

        [MyRequired]
        [MyMaxLength(20)]
        public string Name { get; set; }

    }
}
