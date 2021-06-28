

namespace WebApi.Models.Models.sys_config
{
    /// <summary>
    /// 
    /// </summary>
    public class mh_permissionmenu
    {
        /// <summary>
        /// 
        /// </summary>
        public mh_permissionmenu()
        {
        }

        /// <summary>
        /// 主键
        /// </summary>
        public System.String Id { get; set; }

        /// <summary>
        /// 权限编码，来源权限信息表
        /// </summary>
        public System.String PermissionId { get; set; }

        /// <summary>
        /// 菜单编码，来源菜单信息表
        /// </summary>
        public System.Int32 MenuId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? Createtime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public System.String Createuser { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public System.DateTime? Updatetime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public System.String Updateuser { get; set; }

        /// <summary>
        /// 删除状态。0：未删除，1：删除
        /// </summary>
        public System.Int32? DelFlag { get; set; }
    }
}