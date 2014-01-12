﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
	internal static class ParameterBuilder
	{
		public static string ApplyAllParameters(object obj, string url)
		{
			if (obj == null) return url;

			var newUrl = url;

			foreach (var property in obj.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
			{
				foreach (var attribute in property.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Cast<JsonPropertyAttribute>())
				{
					var value = property.GetValue(obj, null);

					if (value == null) continue;

					if (string.Compare(attribute.PropertyName, "metadata", true) == 0)
					{
						var metadata = (Dictionary<string, string>)value;

						foreach (string key in metadata.Keys)
						{
							newUrl = ApplyParameterToUrl(newUrl, string.Format("metadata[{0}]", key), metadata[key]);
						}
					}
					else if (property.PropertyType == typeof(StripeDateFilter))
					{
						StripeDateFilter filter = (StripeDateFilter)value;
						if (filter.EqualTo.HasValue)
						{
							newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName, filter.EqualTo.Value.ConvertDateTimeToEpoch().ToString());
						}
						else
						{
							if (filter.LessThan.HasValue)
							{
								newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName + "[lt]", filter.LessThan.Value.ConvertDateTimeToEpoch().ToString());
							}
							if (filter.LessThanOrEqual.HasValue)
							{
								newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName + "[lte]", filter.LessThanOrEqual.Value.ConvertDateTimeToEpoch().ToString());
							}
							if (filter.GreaterThan.HasValue)
							{
								newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName + "[gt]", filter.GreaterThan.Value.ConvertDateTimeToEpoch().ToString());
							}
							if (filter.GreaterThanOrEqual.HasValue)
							{
								newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName + "[gte]", filter.GreaterThanOrEqual.Value.ConvertDateTimeToEpoch().ToString());
							}
						}
					}
					else
					{
						newUrl = ApplyParameterToUrl(newUrl, attribute.PropertyName, value.ToString());
					}
				}
			}

			return newUrl;
		}

		public static string ApplyParameterToUrl(string url, string argument, string value)
		{
			var token = "&";

			if (!url.Contains("?"))
				token = "?";

			return string.Format("{0}{1}{2}={3}", url, token, argument, HttpUtility.UrlEncode(value));
		}
	}
}
