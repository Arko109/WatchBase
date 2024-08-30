using Microsoft.Extensions.Logging;
using System.Text.Json;
using WatchBase.Models;

namespace WatchBase.Services;
public class WatchBaseService(HttpClient httpClient, ILogger<WatchBaseService> logger)
{
    private readonly string _baseUrl = "https://api.watchbase.com/v1/";
    private readonly string _query = "?key=B4PMCSMEXeGo1c0Lpk5HmEQw2bKhSqaIwzhuJ9cy&format=json";

    public async Task<IEnumerable<Brand>?> GetBrands()
    {
        try
        {
            var url = _baseUrl + "brands" + _query;
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return JsonSerializer.Deserialize<BrandsResult>(content)?.Brands;
            else
            {
                logger.LogWarning("GetBrands did not succeed, code {response.StatusCode}", response.StatusCode);
                return null;
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to get brands");
            return null;
        }
    }

    public async Task<IEnumerable<Family>?> GetFamilies(Brand brand)
    {
        try
        {
            var url = _baseUrl + "families" + _query + "&brand-id=" + brand.Id;
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return JsonSerializer.Deserialize<FamiliesResult>(content)?.Families;
            else
            {
                logger.LogWarning("GetFamilies did not succeed, code {response.StatusCode}", response.StatusCode);
                return null;
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to get families");
            return null;
        }
    }

    public async Task<IEnumerable<Watch>?> GetWatches(Brand brand, Family family)
    {
        try
        {
            var url = _baseUrl + "watches" + _query + "&brand-id=" + brand.Id + "&family-id=" + family.Id;
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return JsonSerializer.Deserialize<WatchesResult>(content)?.Watches;
            else
            {
                logger.LogWarning("GetWatches did not succeed, code {response.StatusCode}", response.StatusCode);
                return null;
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to get watches");
            return null;
        }
    }

    public async Task<WatchDetails?> GetWatchDetails(Watch watch)
    {
        try
        {
            var url = _baseUrl + "watch" + _query + "&id=" + watch.Id;
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return JsonSerializer.Deserialize<WatchDetailsResult>(content)?.Watch;
            else
            {
                logger.LogWarning("GetWatchDetails did not succeed, code {response.StatusCode}", response.StatusCode);
                return null;
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, "Failed to get watch details");
            return null;
        }
    }
}
