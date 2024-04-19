using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Place.BasePlace
{
    public class PlaceService : IDisposable
    {
        public TReponse GetResponse<TReponse>(PlaceRequest request)
        {
            return HttpRequest.GetRequest<TReponse>(request.URL);
        }

        public TReponse GetResponse<TRequest, TReponse>(TRequest request) where TRequest : PlaceRequest
        {
            return HttpRequest.GetRequest<TReponse>(request.URL);
        }

        public Task<PlaceResponse> GetResponseAsync<TRequest>(TRequest request) where TRequest : PlaceRequest
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
