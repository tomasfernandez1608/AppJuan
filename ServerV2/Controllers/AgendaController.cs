using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class ZoomController : ControllerBase
{
    private const string ZoomClientId = "aG_Ie4N9SIq7T5NN0h_Rpw";
    private const string ZoomClientSecret = "U3u0UEjhulVn0ph5sZ441FRw47U7NrcH";
    private const string ZoomAccountId = "ocVxGZXtTP-S88aMBNkAtw";

    [HttpGet("meeting/list")]
    public async Task<IActionResult> ListMeeting()
    {
        try
        {
            var accessToken = await GetAccessToken();

            var apiUrl = "https://zoom.us/oauth/token?grant_type=account_credentials&account_id=" + ZoomAccountId;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ZoomClientId}:{ZoomClientSecret}")));

                var response = await httpClient.PostAsync(apiUrl, null);
                var responseContent = await response.Content.ReadAsStringAsync();

                var tokenResponse = System.Text.Json.JsonSerializer.Deserialize<ZoomTokenResponse>(responseContent);

                if (tokenResponse != null && !string.IsNullOrEmpty(tokenResponse.access_token))
                {
                    var meetingsUrl = await ListZoomMeeting(tokenResponse.access_token);
                    return Ok(meetingsUrl);
                }
                else
                {
                    return BadRequest("Failed to get access token.");
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpPost("meeting/create")]
    public async Task<IActionResult> CreateMeeting()
    {
        try
        {
            var accessToken = await GetAccessToken();

            var apiUrl = "https://zoom.us/oauth/token?grant_type=account_credentials&account_id=" + ZoomAccountId;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ZoomClientId}:{ZoomClientSecret}")));

                var response = await httpClient.PostAsync(apiUrl, null);
                var responseContent = await response.Content.ReadAsStringAsync();

                var tokenResponse = System.Text.Json.JsonSerializer.Deserialize<ZoomTokenResponse>(responseContent);

                if (tokenResponse != null && !string.IsNullOrEmpty(tokenResponse.access_token))
                {
                    var meetingUrl = await CreateZoomMeeting(tokenResponse.access_token);
                    return Ok(meetingUrl);
                }
                else
                {
                    return BadRequest("Failed to get access token.");
                }
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    private async Task<string> CreateZoomMeeting(string accessToken)
    {
        var apiUrl = $"https://api.zoom.us/v2/users/me/meetings";

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var requestBody = new
            {
                topic = "My ASP.NET Core API Zoom Meeting",
                type = 2, // Scheduled Meeting
                start_time = DateTime.UtcNow.AddMinutes(10).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                duration = 60,
                timezone = "UTC",
                settings = new
                {
                    host_video = true,
                    participant_video = true
                }
            };

            var requestContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiUrl, requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
    private async Task<string> ListZoomMeeting(string accessToken)
    {
        var apiUrl = $"https://api.zoom.us/v2/users/me/meetings?type=upcoming_meetings";

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.GetAsync(apiUrl);
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonConvert.SerializeObject(responseContent);
            return jsonResponse;
        }
    }


    private async Task<string> GetAccessToken()
    {
        var apiUrl = "https://zoom.us/oauth/token?grant_type=account_credentials&account_id=" + ZoomAccountId;

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ZoomClientId}:{ZoomClientSecret}")));

            var response = await httpClient.PostAsync(apiUrl, null);
            var responseContent = await response.Content.ReadAsStringAsync();

            var tokenResponse = System.Text.Json.JsonSerializer.Deserialize<ZoomTokenResponse>(responseContent);

            return tokenResponse.access_token;
        }
    }
}

public class ZoomTokenResponse
{
    public string access_token { get; set; }
    public string token_type { get; set; }
    public int expires_in { get; set; }
    public string scope { get; set; }
}
