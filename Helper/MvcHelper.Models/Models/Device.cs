using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class Device
    { 
        [Key,ForeignKey("ClassRoom")]
        public Guid ClassRoomId { get; set; }

        #region 导航属性=====================================================================================
        public virtual ClassRoom ClassRoom { get; set; }
        #endregion===========================================================================================

        [DisplayName("中控IP"), MyRequired]
        public string IP { get; set; }
        [DisplayName("添加设备时间")]
        public DateTime AddTime { get; set; }
        [DisplayName("添加人姓名"), MaxLength(10)]
        public String AddName { get; set; }
        [DisplayName("设备状态"), MyRequired]
        public bool State { get; set; }
        [DisplayName("备注"), MyMaxLength(100), DataType(DataType.MultilineText)]
        public string Remark { get; set; }
    }
}