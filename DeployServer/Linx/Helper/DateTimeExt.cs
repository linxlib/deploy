using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Helper
{
    public static class DateTimeExt
    {
        /// <summary>
        /// unix时间戳(秒)
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        public static long Unix(this DateTime now)
        {
            return (now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
        /// <summary>
        /// unix时间戳(毫秒)
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        public static long UnixMS(this DateTime now)
        {
            return (now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }
        /// <summary>
        /// 转到中国日期格式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fmt"></param>
        /// <returns></returns>
        public static string ToChineseDate(this DateTime dt,string fmt = "yyyy-MM-dd")
        {
            return dt.ToString(fmt);
        }
        /// <summary>
        /// 转到中国时间格式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fmt"></param>
        /// <returns></returns>
        public static string ToChineseDateTime(this DateTime dt, string fmt = "yyyy-MM-dd HH:mm:ss")
        {
            return dt.ToString(fmt);
        }
        /// <summary>
        /// 减去天数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SubtractDay(this DateTime dt,int day)
        {
            return dt.AddDays(-day);
        }
        /// <summary>
        /// 获取一天的0点
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime DayStart(this DateTime dt)
        {
            return DateTime.Parse( dt.ToString("yyyy-MM-dd 00:00:00"));
        }
        /// <summary>
        /// 获取一天的最后一秒
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime DayEnd(this DateTime dt)
        {
            return DateTime.Parse(dt.ToString("yyyy-MM-dd 23:59:59"));
        }
        /// <summary>
        /// 获取每月第一天
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime MonthStart(this DateTime dt)
        {
            return DateTime.Parse(dt.ToString("yyyy-MM-01 00:00:00"));
        }
        /// <summary>
        /// 获取月末
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime MonthEnd(this DateTime dt)
        {
            return DateTime.Parse(dt.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd 00:00:00"));
        }
        /// <summary>
        /// 转到DateTime
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        /// <exception cref="Exception">日期文本格式无效</exception>
        public static DateTime ToDateTime(this string dateStr)
        {
            if (DateTime.TryParse(dateStr, out var dt))
            {
                return dt;
            } else
            {
                throw new Exception("not valid datetime string");
            }
        }


    }
}
