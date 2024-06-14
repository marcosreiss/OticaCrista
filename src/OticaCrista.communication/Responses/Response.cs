using System.Text.Json.Serialization;

namespace OticaCrista.communication.Responses
{
    public class Response<TData>
    {
        #region ctos
        public Response()
            => StatusCode = 200;

        public Response(
            TData? data,
            int code = 200,
            string? message = null)
        {
            StatusCode = code;
            Message = message;
            Data = data;
        }

        #endregion

        #region Props

        public int StatusCode = 200;
        [JsonIgnore]
        public bool IsSuccess => StatusCode is >= 200 and <= 299;
        public string? Message { get; set; }
        public TData Data { get; set; }

        #endregion
    }
}
