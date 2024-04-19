using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Directions
{
    public interface IDirectionService
    {
        DirectionsResponse GetResponse(DirectionsRequest request);
    }
}
