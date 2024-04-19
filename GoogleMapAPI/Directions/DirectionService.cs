using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Directions
{
    public class DirectionService : IDirectionService, IDisposable
    {
        public DirectionsResponse GetResponse(DirectionsRequest request)
        {
            return HttpRequest.GetRequest<DirectionsResponse>(request.URL);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

