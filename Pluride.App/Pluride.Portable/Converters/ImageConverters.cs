﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace Pluride.App.Portable.Converters
{
    /// <summary>
    /// Used to return a filled or empty image string
    /// </summary>
    class IsFilledIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        (bool)value ? $"{parameter}_filled.png" : $"{parameter}_empty.png";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Used to reaturn the speaker image with caching or default
    /// </summary>
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace((string)value))
                {
                    return new UriImageSource
                    {
                        Uri = new Uri((string)value),
                        CachingEnabled = true,
                        CacheValidity = TimeSpan.FromDays(3)
                    };
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine("Unable to convert image to URI: " + ex);
            }

            return ImageSource.FromFile("profile_generic_big.png");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}