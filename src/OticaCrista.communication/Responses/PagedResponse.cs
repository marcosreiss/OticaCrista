using System.Text.Json.Serialization;

namespace OticaCrista.communication.Responses
{
    public class PagedResponse<TData> : Response<TData>
    {
        #region Ctor

        [JsonConstructor]
        public PagedResponse(
            TData? data,
            int totalCount,
            int currentPage = 1,
            int pageSize = 20,
            int code = 200,
            string message = "")
            : base(data, code, message)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            
        }

        #endregion

        #region Props

        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public int PageSize { get; set; } = 20;
        public int TotalCount { get; set; }

        #endregion
    }
}
