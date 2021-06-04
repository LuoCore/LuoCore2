using Microsoft.AspNetCore.Http;
using System;

namespace Utility
{
    public static class SessionHelper
    {
        /// <summary>
        /// Session写入
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static bool SetSession(this HttpContext httpContext, string key, string value)
        {
            try
            {
                httpContext.Session.SetString(key, value);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Session写入
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static bool SetSession(this HttpContext httpContext, string key, int value)
        {
            try
            {
                httpContext.Session.SetInt32(key, value);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public static string GetSession(this HttpContext httpContext, string key)
        {
            try
            {
                var value = httpContext.Session.GetString(key);
                if (string.IsNullOrEmpty(value))
                    value = string.Empty;
                return value;

            }
            catch (System.Exception)
            {
                return string.Empty;
            }
        }
        public static int GetSessionInt32(this HttpContext httpContext, string key)
        {
            try
            {
                var value = httpContext.Session.GetInt32(key);
                if (value == null)
                    value = -1;
                return Convert.ToInt32(value);

            }
            catch (System.Exception)
            {
                return -1;
            }
        }

    }
}
