using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace HttpClientBug.Constants
{
    internal class ApiConstants
    {
        public static readonly string Host = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
        internal const string ApiBase = "weatherforecast/";
    }
}
