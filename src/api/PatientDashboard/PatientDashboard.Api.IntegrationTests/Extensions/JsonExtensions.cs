using Newtonsoft.Json;

namespace PatientDashboard.Api.IntegrationTests.Extensions;

public static class JsonExtensions
{
    public static T FromJson<T>(this string json)
    {
        return JsonConvert.DeserializeObject<T>(json);
    } 
}