using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class DeviceUseRecord
    {
        public Guid Id { get; set; }
        [DisplayName("设备开启时间")]
        public DateTime OpenTime { get; set; }
        [DisplayName("设备关闭时间")]
        public DateTime CloseTime { get; set; }

        #region 导航属性=====================================================================================
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        #endregion===========================================================================================  
    }
}