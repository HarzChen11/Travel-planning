using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Request.GeoCoding
{
    public class GeocodingService : IGeocodingService, IDisposable
    {
        public GeocodeResponse GetResponse(GeocodingRequest request)
        {
            return HttpRequest.GetRequest<GeocodeResponse>(request.URL);
        }

        public Task<GeocodeResponse> GetResponseAsync(GeocodingRequest request)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
