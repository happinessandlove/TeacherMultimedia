using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class College
    {
        public College()
        {
            this.Classes = new List<Class>();
        }

        public Guid Id { get; set; }

        #region 导航
        public Guid UniversityId { get; set; }
        public virtual University University { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        #endregion

        [MyRequired]
        [MyMaxLength(20)]
        public string Name { get; set; }

    }
}
