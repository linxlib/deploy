using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Linx.Helper
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// 是否为null或空
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string inputStr)
        {
            return string.IsNullOrEmpty(inputStr);
        }
        /// <summary>
        /// 是否为null或" "
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string inputStr)
        {
            return string.IsNullOrWhiteSpace(inputStr);
        }

        /// <summary>
        /// 不是null或空
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string _this)
        {
            return !string.IsNullOrEmpty(_this);
        }
        /// <summary>
        /// 不是null或空格
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static bool IsNotNullOrWhiteSpace(this string _this)
        {
            return !string.IsNullOrWhiteSpace(_this);
        }
        /// <summary>
        /// 计算32位小写md5值
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string MD5Hex32(this string txt)
        {
            byte[] sor = Encoding.UTF8.GetBytes(txt);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                //加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
                strbul.Append(result[i].ToString("x2"));
            }
            return strbul.ToString();
        }

        private static readonly string[] ChinaIDProvinceCodes = {
             "11", "12", "13", "14", "15",
             "21", "22", "23",
             "31", "32", "33", "34", "35", "36", "37",
             "41", "42", "43", "44", "45", "46",
             "50", "51", "52", "53", "54",
             "61", "62", "63", "64", "65",
             "71",
             "81", "82",
             "91"
        };
        private static bool CheckChinaID18(string ID)
        {
            ID = ID.ToUpper();
            Match m = Regex.Match(ID, @"\d{17}[\dX]", RegexOptions.IgnoreCase);
            if (!m.Success)
            {
                return false;
            }
            if (!ChinaIDProvinceCodes.Contains(ID.Substring(0, 2)))
            {
                return false;
            }
            CultureInfo zhCN = new CultureInfo("zh-CN", true);
            if (!DateTime.TryParseExact(ID.Substring(6, 8), "yyyyMMdd", zhCN, DateTimeStyles.None, out DateTime birthday))
            {
                return false;
            }
            if (!birthday.In(new DateTime(1800, 1, 1), DateTime.Today))
            {
                return false;
            }
            int[] factors = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += (ID[i] - '0') * factors[i];
            }
            int n = (12 - sum % 11) % 11;
            return n < 10 ? ID[17] - '0' == n : ID[17].Equals('X');
        }
        private static bool CheckChinaID15(string ID)
        {
            Match m = Regex.Match(ID, @"\d{15}", RegexOptions.IgnoreCase);
            if (!m.Success)
            {
                return false;
            }
            if (!ChinaIDProvinceCodes.Contains(ID.Substring(0, 2)))
            {
                return false;
            }
            CultureInfo zhCN = new CultureInfo("zh-CN", true);
            if (!DateTime.TryParseExact("19" + ID.Substring(6, 6), "yyyyMMdd", zhCN, DateTimeStyles.None, out DateTime birthday))
            {
                return false;
            }
            return birthday.In(new DateTime(1800, 1, 1), new DateTime(2000, 1, 1));
        }
        /// <summary>
        /// 判断时间是否在区间内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="start">开始</param>
        /// <param name="end">结束</param>
        /// <param name="mode">模式</param>
        /// <returns></returns>
        public static bool In(this in DateTime @this, DateTime start, DateTime end, RangeMode mode = RangeMode.Close)
        {
            return mode switch
            {
                RangeMode.Open => start < @this && end > @this,
                RangeMode.Close => start <= @this && end >= @this,
                RangeMode.OpenClose => start < @this && end >= @this,
                RangeMode.CloseOpen => start <= @this && end > @this,
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null)
            };
        }
        /// <summary>
        /// 区间模式
        /// </summary>
        public enum RangeMode
        {
            /// <summary>
            /// 开区间
            /// </summary>
            Open,

            /// <summary>
            /// 闭区间
            /// </summary>
            Close,

            /// <summary>
            /// 左开右闭区间
            /// </summary>
            OpenClose,

            /// <summary>
            /// 左闭右开区间
            /// </summary>
            CloseOpen
        }
        public static bool IsIDCard(this string idcardStr)
        {
            return idcardStr.Length switch
            {
                18 => CheckChinaID18(idcardStr),
                15 => CheckChinaID15(idcardStr),
                _ => false
            };
        }

        private static readonly Regex EmailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);

        private static readonly Regex MobileRegex = new Regex("^1[0-9]{10}$");

        private static readonly Regex PhoneRegex = new Regex(@"^(\d{3,4}-?)?\d{7,8}$");

        private static readonly Regex IpRegex = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");

        private static readonly Regex DateRegex = new Regex(@"(\d{4})-(\d{1,2})-(\d{1,2})");

        private static readonly Regex NumericRegex = new Regex(@"^[-]?[0-9]+(\.[0-9]+)?$");

        private static readonly Regex ZipcodeRegex = new Regex(@"^\d{6}$");

        private static readonly Regex IdRegex = new Regex(@"^[1-9]\d{16}[\dXx]$");
        /// <summary>
        /// 是否中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsChinese(this string str)
        {
            return Regex.IsMatch(@"^[\u4e00-\u9fa5]+$", str);
        }

        /// <summary>
        /// 是否为邮箱名
        /// </summary>
        public static bool IsEmail(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            return EmailRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否为手机号
        /// </summary>
        public static bool IsMobile(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            return MobileRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否为固话号
        /// </summary>
        public static bool IsPhone(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            return PhoneRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否为IP
        /// </summary>
        public static bool IsIp(this string s)
        {
            return IpRegex.IsMatch(s);
        }
        /// <summary>
        /// 是否为邮政编码
        /// </summary>
        public static bool IsZipCode(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            return ZipcodeRegex.IsMatch(s);
        }

        public static string AESQjEncrypt(this string content, string KEY = "qijin.cooc.nijiq")
        {

            byte[] byteKEY = Encoding.UTF8.GetBytes(KEY);
            byte[] byteIV = Encoding.UTF8.GetBytes(KEY);

            byte[] byteContnet = Encoding.UTF8.GetBytes(content);

            var _aes = new RijndaelManaged();
            _aes.Padding = PaddingMode.PKCS7;
            _aes.Mode = CipherMode.CBC;
            //_aes.BlockSize = 16;

            _aes.Key = byteKEY;
            _aes.IV = byteIV;

            var _crypto = _aes.CreateEncryptor(byteKEY, byteIV);
            byte[] decrypted = _crypto.TransformFinalBlock(
                byteContnet, 0, byteContnet.Length);

            _crypto.Dispose();

            return Convert.ToBase64String(decrypted);
        }
        public static string AESQjDecrypt(this string decryptStr, string KEY = "qijin.cooc.nijiq")
        {

            byte[] byteKEY = Encoding.UTF8.GetBytes(KEY);
            byte[] byteIV = Encoding.UTF8.GetBytes(KEY);

            byte[] byteDecrypt = System.Convert.FromBase64String(decryptStr);

            var _aes = new RijndaelManaged();
            _aes.Padding = PaddingMode.PKCS7;
            _aes.Mode = CipherMode.CBC;

            _aes.Key = byteKEY;
            _aes.IV = byteIV;

            var _crypto = _aes.CreateDecryptor(byteKEY, byteIV);
            byte[] decrypted = _crypto.TransformFinalBlock(
                byteDecrypt, 0, byteDecrypt.Length);

            _crypto.Dispose();

            return Encoding.UTF8.GetString(decrypted);
        }

        public static decimal QjToDecimal(this string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return 0;

            decimal result = 0;
            try
            {
                result = Convert.ToDecimal(inputText);
            }
            catch (Exception)
            {
                return 0;
            }
            return result;
        }
        public static long QjToLong(this string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return 0;

            long result = 0;
            try
            {
                result = Convert.ToInt64(inputText);
            }
            catch (Exception)
            {
                return 0;
            }
            return result;
        }
        public static int QjToInt(this string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
                return 0;

            int result = 0;
            try
            {
                result = Convert.ToInt32(inputText);
            }
            catch (Exception)
            {
                return 0;
            }
            return result;
        }
    }
}