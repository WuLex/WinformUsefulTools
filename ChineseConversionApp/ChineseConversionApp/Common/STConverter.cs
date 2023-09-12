using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChineseConversionApp.Common
{
    public class STConverter
    {
        /// <summary> 
        /// 简体转换为繁体
        /// </summary> 
        /// <param name="str">简体字</param> 
        /// <returns>繁体字</returns> 
        public static string GetTraditional(string str)
        {
            string r = string.Empty;
            r = ChineseConverter.Convert(str, ChineseConversionDirection.SimplifiedToTraditional);
            return r;
        }

        /// <summary> 
        /// 繁体转换为简体
        /// </summary> 
        /// <param name="str">繁体字</param> 
        /// <returns>简体字</returns> 
        public static string GetSimplified(string str)
        {
            string r = string.Empty;
            r = ChineseConverter.Convert(str, ChineseConversionDirection.TraditionalToSimplified);
            return r;
        }

        // 判断字符串中是否包含繁体字
        //public static bool ContainsTraditionalChinese(string text)
        //{
        //    //foreach (char c in text)
        //    //{
        //    //    if ((c >= 0x20000 && c <= 0x2A6DF) || (c >= 0x2F800 && c <= 0x2FA1F) || (c >= '\u3400' && c <= '\u4DBF'))
        //    //    {
        //    //        return true; // 包含繁体汉字
        //    //    }
        //    //}
        //    //return false; // 不包含繁体汉字

        //    //// 正则表达式模式匹配繁体字（Unicode范围：\u4E00-\u9FFF）
        //    //string pattern = @"[\uD840-\uD869\uDC00-\uDFFF][\u20000-\u2A6DF\u2F800-\u2FA1F]";
        //    //MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        //    //return matches.Count > 0; // 包含繁体字如果匹配数量大于0
        //}

    }
}
