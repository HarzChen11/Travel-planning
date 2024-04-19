using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI
{
    public enum ServiceResponseStatus
    {
        Ok = -1,
        Unknown = 0,
        InvalidRequest = 1,
        ZeroResults = 2,
        OverQueryLimit = 3,
        RequestDenied = 4,
        NotFound = 5,
        MaxWaypointsExceeded = 6
    }
}
