using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MiniProject5Company.Application.Helpers
{
    public static class DtoFilterHelper
    {
        public static object RemoveNullProperties(object dto)
        {
            var json = JsonConvert.SerializeObject(dto, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return JsonConvert.DeserializeObject(json);
        }
    }
}
