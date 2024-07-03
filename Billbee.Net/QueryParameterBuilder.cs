using System;
using System.Collections.Generic;
using System.Globalization;

namespace Billbee.Net;

public class QueryParameterBuilder
{
    private readonly Dictionary<string, string> _queryParams = new();

    public void Add(string key, string value)
    {
        if (!string.IsNullOrEmpty(value)) _queryParams[key] = value;
    }

    public void Add(string key, bool value)
    {
        _queryParams[key] = value.ToString();
    }

    public void Add(string key, long? value)
    {
        if (value.HasValue) _queryParams[key] = value.Value.ToString();
    }

    public void AddDate(string key, DateTime? date)
    {
        if (date.HasValue) Add(key, date.Value.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
    }

    public void AddDateWithoutTime(string key, DateTime? date)
    {
        if (date.HasValue) Add(key, date.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
    }

    public void AddList<T>(string keyPrefix, IEnumerable<T> list)
    {
        if (list != null)
        {
            var index = 0;
            foreach (var item in list) Add($"{keyPrefix}[{index++}]", item.ToString());
        }
    }

    public Dictionary<string, string> Build()
    {
        return _queryParams;
    }
}