using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Request.Common
{
    public abstract class AServiceResponse
    {
        [JsonProperty("status")]
        protected ServiceResponseStatus Status
        {
            get;
            set;
        }

        [JsonProperty("error_message")]
        protected string ErrorMessage
        {
            get;
            set;
        }

    }
}
