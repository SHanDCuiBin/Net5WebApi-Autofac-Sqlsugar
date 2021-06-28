

namespace WebApi.Models.Models.basicinfo
{
    /// <summary>
    /// web系统表--模块按钮
    /// </summary>
    public class sys_modulebutton
    {
        /// <summary>
        /// web系统表--模块按钮
        /// </summary>
        public sys_modulebutton()
        {
        }

        /// <summary>
        /// 按钮主键
        /// </summary>
        public System.String F_Id { get; set; }

        /// <summary>
        /// 模块主键
        /// </summary>
        public System.String F_ModuleId { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public System.String F_ParentId { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        public System.Int32? F_Layers { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public System.String F_EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public System.String F_FullName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public System.String F_Icon { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public System.Int32? F_Location { get; set; }

        /// <summary>
        /// 事件
        /// </summary>
        public System.String F_JsEvent { get; set; }

        /// <summary>
        /// 连接
        /// </summary>
        public System.String F_UrlAddress { get; set; }

        /// <summary>
        /// 分开线
        /// </summary>
        public System.SByte? F_Split { get; set; }

        /// <summary>
        /// 公共
        /// </summary>
        public System.SByte? F_IsPublic { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public System.SByte? F_AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public System.SByte? F_AllowDelete { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public System.Int32? F_SortCode { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public System.SByte? F_DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public System.SByte? F_EnabledMark { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public System.String F_Description { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public System.DateTime? F_CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public System.String F_CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public System.DateTime? F_LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public System.String F_LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public System.DateTime? F_DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public System.String F_DeleteUserId { get; set; }
    }
}