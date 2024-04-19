using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Request.GeoCoding
{
    public interface IGeocodingService
    {
        GeocodeResponse GetResponse(GeocodingRequest request);

        Task<GeocodeResponse> GetResponseAsync(GeocodingRequest request);
    }
}
