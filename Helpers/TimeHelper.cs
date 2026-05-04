using System.Net.NetworkInformation;
using TimeZoneConverter;

namespace nkay_fabs_backend.Helpers
{
    public static class TimeHelper
    {
        private static readonly TimeZoneInfo WAT = TZConvert.GetTimeZoneInfo("Africa/Lagos");


        public static DateTime NowWAT()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, WAT);
        }
    }
}
