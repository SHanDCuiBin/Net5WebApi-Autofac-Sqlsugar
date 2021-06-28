

namespace WebApi.Models.Models.mh_cms
{
    /// <summary>
    /// 调价单表
    /// </summary>
    public class pms_modify_price
    {
        /// <summary>
        /// 调价单表
        /// </summary>
        public pms_modify_price()
        {
        }

        /// <summary>
        /// 主键：调价单表
        /// </summary>
        public System.Int32 id { get; set; }

        /// <summary>
        /// 产品id
        /// </summary>
        public System.Int32? product_id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public System.String product_name { get; set; }

        /// <summary>
        /// 供应商id
        /// </summary>
        public System.Int32? supplier_id { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public System.String supplier_name { get; set; }

        /// <summary>
        /// 产品类别id
        /// </summary>
        public System.Int32? product_type_id { get; set; }

        /// <summary>
        /// 产品类别名称
        /// </summary>
        public System.String product_type_name { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public System.String model { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public System.String unit { get; set; }

        /// <summary>
        /// 调价方式
        /// </summary>
        public System.String type { get; set; }

        /// <summary>
        /// 数量下限
        /// </summary>
        public System.Int32? quantity_floor { get; set; }

        /// <summary>
        /// 当前单价
        /// </summary>
        public System.Decimal? unit_price { get; set; }

        /// <summary>
        /// 发票类型：(1 增值税普通发票；2 增值税专用发票)
        /// </summary>
        public System.String invoice_no { get; set; }

        /// <summary>
        /// 税率
        /// </summary>
        public System.Decimal? tax_rate { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public System.DateTime? effective_date { get; set; }

        /// <summary>
        /// 创建人id
        /// </summary>
        public System.Int32? founder { get; set; }

        /// <summary>
        /// 修改人id
        /// </summary>
        public System.Int32? reviser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime? creation_time { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public System.DateTime? revision_time { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public System.String create_user { get; set; }

        /// <summary>
        /// 是否删除 0 ：禁用 1：正常
        /// </summary>
        public System.Int32? is_delect { get; set; }
    }
}