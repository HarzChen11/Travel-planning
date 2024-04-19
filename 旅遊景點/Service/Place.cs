using GoogleMapAPI.Place.Autocomplete;
using GoogleMapAPI.Place.BasePlace;
using GoogleMapAPI.Place.PlaceDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoogleMapAPI.Place.Autocomplete.AutocompleteResponse;

namespace 旅遊景點.Service
{
    internal class Place
    {
        private PlaceDetailResponse _placeDetail;
        public string PlaceInfo
        {
            get
            {
                return $@"地址：{_placeDetail.result.formatted_address}<br/>電話：{_placeDetail.result.formatted_phone_number}<br/>網站：<a href='{ _placeDetail.result.website}'>{ _placeDetail.result.website}</a><br/>Google Map：<a href='{_placeDetail.result.url}'>{_placeDetail.result.url}</a>";
            }
        }

        public AutocompleteResponse getAutoCompletePlaces(String keyword, Action<Prediction[]> action)
        {
            AutocompleteRequest request = new AutocompleteRequest();
            request.input = keyword;
            request.language = "zh-TW";
            var response = new PlaceService().GetResponse<AutocompleteResponse>(request);
            action.Invoke(response.predictions);
            return response;
        }

        public PlaceDetailResponse getDetail(string placeID, Action<PlaceDetailResponse> action = null)
        {
            PlaceDetailRequest request = new PlaceDetailRequest();
            request.place_id = placeID;
            request.language = "zh-TW";
            _placeDetail = new PlaceService().GetResponse<PlaceDetailResponse>(request);
            if (action != null)
                action.Invoke(_placeDetail);
            return _placeDetail;
        }
    }
}
