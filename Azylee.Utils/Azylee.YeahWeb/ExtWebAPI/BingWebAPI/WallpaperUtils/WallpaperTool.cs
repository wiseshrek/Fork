﻿using Azylee.Jsons;
using Azylee.YeahWeb.HttpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Azylee.YeahWeb.ExtWebAPI.BingWebAPI.WallpaperUtils
{
    /// <summary>
    /// Bing壁纸工具类
    /// </summary>
    public static class WallpaperTool
    {
        // 图片尺寸信息
        // 1920x1200   1920x1080    1366x768   1280x768    
        // 1024x768    800x600       800x480   768x1280  
        // 720x1280    640x480       480x800   400x240     
        // 320x240     240x320
        const string URL = "https://cn.bing.com/HPImageArchive.aspx?format=js&idx={0}&n=8";
        /// <summary>
        /// 获取今天的壁纸
        /// </summary>
        /// <returns></returns>
        public static WallpaperModel GetToday()
        {
            return GetSomeday(0);
        }
        /// <summary>
        /// 获取昨天的壁纸
        /// </summary>
        /// <returns></returns>
        public static WallpaperModel GetYesterday()
        {
            return GetSomeday(1);
        }
        /// <summary>
        /// 获取某一天的壁纸（每天8张）
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static WallpaperModel GetSomeday(int day)
        {
            WallpaperModel model = null;
            try
            {
                string rs = HttpTool.Get(string.Format(URL, day));
                model = Json.String2Object<WallpaperModel>(rs);
                return model;
            }
            catch (Exception e) { return null; }
        }
    }
}
