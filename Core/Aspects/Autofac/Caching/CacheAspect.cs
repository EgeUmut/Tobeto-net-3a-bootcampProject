using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching;

public class CacheAspect : MethodInterception
{
    private int _duration;
    private ICacheManager _cacheManager;

    public CacheAspect(int duration = 60)// 60dk içinde cache timeout veriyor
    {
        _duration = duration;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    public override void Intercept(IInvocation invocation)
    {
        //ezbere bilmene gerek yok ama mantığını anla.
        //metot'un tam ismini string olarak methodName e alıyor.
        //metot içindeki parametre varsa hepsini bir listeye alıp "," ile ayırıyor.
        // ?? işareti varsa bunu ekle yoksa bunu ekle (istenen string varsa onu ekler yoksa null)

        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
        var arguments = invocation.Arguments.ToList();
        var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
        if (_cacheManager.IsAdd(key)) // cache de var mı diye kontrol ediyor
        {
            invocation.ReturnValue = _cacheManager.Get(key);
            return;
        }
        invocation.Proceed(); // buraya geldiyse cache de yoktur bu yüzden ekliyor
        _cacheManager.Add(key, invocation.ReturnValue, _duration);
    }
}
