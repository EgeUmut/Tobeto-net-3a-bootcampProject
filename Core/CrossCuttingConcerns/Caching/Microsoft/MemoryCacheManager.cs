using Microsoft.Extensions.Caching.Memory;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.IoC;
using Amazon.Runtime.Internal.Util;
using System.Reflection;

namespace Core.CrossCuttingConcerns.Caching.Microsoft;

public class MemoryCacheManager : ICacheManager
{
    IMemoryCache _memoryCache;

    public MemoryCacheManager()
    {
        _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
    }
    public void Add(string key, object value, int duration)
    {
        _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
    }

    public T Get<T>(string key)
    {
        return _memoryCache.Get<T>(key);
    }

    public object Get(string key)
    {
        return _memoryCache.Get(key); //tip dönüşümü üstteki daha kullanuşlı ama bu da uygun
    }

    public bool IsAdd(string key)
    {
        return _memoryCache.TryGetValue(key, out _); // out _  boş değer
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }

    public void RemoveByPattern(string pattern)
    {
        // github dan alındı burası
        // çalışma anında bellekten silmeye sağlıyor

        //Entries collection u bellekte bulup her bir cache elemanını gez.
        // aşağıdaki kurala uyan değerleri keysToRemove a alıp içini tek tek foreach ile gez key i uygun olanları kaldır.

        /*
        var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
        List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

        foreach (var cacheItem in cacheEntriesCollection)
        {
            ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
            cacheCollectionValues.Add(cacheItemValue);
        }

        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

        foreach (var key in keysToRemove)
        {
            _memoryCache.Remove(key);
        }*/

        var fieldInfo = typeof(MemoryCache).GetField("_coherentState", BindingFlags.Instance | BindingFlags.NonPublic);
        var propertyInfo = fieldInfo.FieldType.GetProperty("EntriesCollection", BindingFlags.Instance | BindingFlags.NonPublic);
        var value = fieldInfo.GetValue(_memoryCache);
        var dict = propertyInfo.GetValue(value) as dynamic;


        List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

        foreach (var cacheItem in dict)
        {
            ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
            cacheCollectionValues.Add(cacheItemValue);
        }

        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

        foreach (var key in keysToRemove)
        {
            _memoryCache.Remove(key);
        }
    }
}
