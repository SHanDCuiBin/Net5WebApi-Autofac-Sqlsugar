using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Enums
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum EnumDatabase
    {
        basicinfo,                      //basicinfo库
        mhcms,                           //mh_cms库
        health_info,                    //health_info2015-当前库
        health_record,                  //health_record2015-当前库
        sysConfig                       //sys_config库
    }
}
