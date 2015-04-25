using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EFFrameTest2.Model.Entites
{
    [DataContract]
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        [DataMember]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 公司id
        /// </summary>
        [DataMember]
        public int CompanyId { get; set; }


        /// <summary>
        /// 状态-----对应userstatus枚举
        /// </summary>
        [DataMember]
        public int Status { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [DataMember]
        public string NativePlace
        {
            get;
            set;
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember]
        public string IDCard { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [DataMember]
        public string Mobile { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [DataMember]
        public string WeiXin { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [DataMember]
        public string Tel { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [DataMember]
        public string QQ { get; set; }

        [NotMapped]
        [DataMember]
        public IList<UserReRole> RoleList { get; set; }

        ///// <summary>
        ///// 角色
        ///// </summary>
        //public ICollection<Role> Roles { get; set; }
    }
}
