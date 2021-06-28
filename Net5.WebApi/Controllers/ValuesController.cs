using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.IService.health_info;
using WebApi.Models.Models.health_info;
using WebApi.Models.Response;

namespace Net5.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 业务处理对象-属性注入
        /// </summary>
        public Imh_jktjService imh_JktjService { get; set; }

        /// <summary>
        /// 获取健康体检表记录
        /// </summary>
        [HttpGet]
        public async Task<ApiResult> GetJktj(DateTime startTime, DateTime endTime)
        {
            var result = await imh_JktjService.QueryableAsync(t => t.tjrq >= startTime && t.tjrq <= endTime);

            if (result != null && result.Count > 0)
            {
                return ApiResultHelper.Success(result);
            }
            else
            {
                return ApiResultHelper.Error("未获取到有效数据");
            }
        }
    }
}
