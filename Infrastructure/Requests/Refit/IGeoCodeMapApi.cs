using Refit;

namespace Infrastructure.Requests.Refit
{
    public interface IGeoCodeMapApi
    {
        /// <summary>
        /// This request solicite the query: /reverse?lat{lat}&lon={lon}&api_key=api_key
        /// We use AliasAs to set params of the query.
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>

        [Get("/reverse")]
        public Task<object> SearchAddressAsync(
            [AliasAs("lat")] string lat,
            [AliasAs("lon")] string lng,
            [AliasAs("api_key")] string apiKey);


    }
}
