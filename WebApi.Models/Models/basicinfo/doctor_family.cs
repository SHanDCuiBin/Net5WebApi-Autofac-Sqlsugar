

namespace WebApi.Models.Models.basicinfo
{
    /// <summary>
    /// 家医信息
    /// </summary>
    public class doctor_family
    {
        /// <summary>
        /// 家医信息
        /// </summary>
        public doctor_family()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public System.String id { get; set; }

        /// <summary>
        /// 家庭医生机构id
        /// </summary>
        public System.String docf_orgid { get; set; }

        /// <summary>
        /// 团队id
        /// </summary>
        public System.String team_id { get; set; }

        /// <summary>
        /// 家医id
        /// </summary>
        public System.String doctor_id { get; set; }

        /// <summary>
        /// 家医姓名
        /// </summary>
        public System.String doctor_name { get; set; }
    }
}