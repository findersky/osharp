﻿// -----------------------------------------------------------------------
//  <copyright file="BitmapToImageSourceConverter.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2017 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-12-27 1:20</last-date>
// -----------------------------------------------------------------------

using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

using OSharp.Utility.Extensions;


namespace OSharp.Utility.Wpf.Converters
{
    public class BitmapToImageSourceConverter : IValueConverter
    {
        /// <summary>
        /// 转换值。
        /// </summary>
        /// <returns>
        /// 转换后的值。如果该方法返回 null，则使用有效的 null 值。
        /// </returns>
        /// <param name="value">绑定源生成的值。</param>
        /// <param name="targetType">绑定目标属性的类型。</param>
        /// <param name="parameter">要使用的转换器参数。</param>
        /// <param name="culture">要用在转换器中的区域性。</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Bitmap bmp = value as Bitmap;
            if (bmp == null)
            {
                return null;
            }
            byte[] bytes = bmp.ToBytes();
            using (MemoryStream ms = new MemoryStream(bytes, false))
            {
                BitmapImage source = new BitmapImage();
                source.BeginInit();
                source.StreamSource = ms;
                source.CacheOption = BitmapCacheOption.OnLoad;
                source.EndInit();
                return source;
            }
        }

        /// <summary>
        /// 转换值。
        /// </summary>
        /// <returns>
        /// 转换后的值。如果该方法返回 null，则使用有效的 null 值。
        /// </returns>
        /// <param name="value">绑定目标生成的值。</param>
        /// <param name="targetType">要转换到的类型。</param>
        /// <param name="parameter">要使用的转换器参数。</param>
        /// <param name="culture">要用在转换器中的区域性。</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}