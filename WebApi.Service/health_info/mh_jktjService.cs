using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.IRepository.health_info;
using WebApi.IService.health_info;
using WebApi.Models.Models.health_info;

namespace WebApi.Service.health_info
{
    public class mh_jktjService : BaseService<mh_jktj>, Imh_jktjService
    {
        private readonly Imh_jktjRepository _Repository;
        /// <summary>
        /// 构造函数注入对应的业务仓储
        /// </summary>
        /// <param name="Repository"></param>
        public mh_jktjService(Imh_jktjRepository Repository)
        {
            base._iBaseRepository = this._Repository = Repository;
        }
    }
}
