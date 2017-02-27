using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Student
    {
        //public Guid Id { get; set; }
        //public int Id { get; set; }
        [Key,MyMaxLength(11)]
        public string No { get; set; }

        #region 导航
        [DisplayName("班级")]
        [MySelect]
        public Guid ClassId { get; set; }

        //[AssociatedQuery("班级","clas.id","clas.name")]
        //[AssociatedQuery("学校", "Clas.college.university.id", "clas.college.university.name")]
        //[AssociatedQuery(QueryPropertyType.String, "clas.college.university.name", "学校名称")]
        [DisplayName("班级")]
        public virtual Class Class { get; set; }
        #endregion

        [DisplayName("姓名")]
        [MyRequired, MyMaxLength(20)]
        public string Name { get; set; }

        [DisplayName("手机号码"),MyMobile,MyMaxLength(15)]
        public string MobileNumber { get; set; }
        
        [DisplayName("年龄")]
        [MyRequired, MyInteger, MyRange(0, 100)]
        public decimal Age { get; set; }

        [DisplayName("入学时间"), DataType(DataType.Date)]
        [MyDate]
        public DateTime? AdmissionDate { get; set; }

        [DisplayName("性别")]
        [MyRequired(ErrorMessage = "请选择性别")]
        public string Gender { get; set; }

        [DisplayName("是否在校生")]
        public bool? InSchool { get; set; }

        [DisplayName("状态")]
        [MySelect]
        public StudentStatus Status { get; set; }

    }

}