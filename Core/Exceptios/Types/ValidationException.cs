using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptios.Types;

public class ValidationException : Exception
{
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }

    public ValidationException() : base()
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ValidationException(string? messsage) : base(messsage)
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ValidationException(string? messsage, Exception exception) : base(messsage, exception)
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ValidationException(IEnumerable<ValidationExceptionModel> errors):base(BuildErrorMessage(errors))
    {
        Errors=errors;
    }

    private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors) 
    {
        IEnumerable<string> error = errors.Select(p => $"{Environment.NewLine} -- {p.Property} : {string.Join(Environment.NewLine,values:p.Errors ?? Array.Empty<string>())}");
        //validation yapılacak entity bilgilerini getir. örn:
        //name : can't be empty
        //password : must contain number
        //eğer yoksa boş döndür şu kısım ==>  ?? Array.Empty<string>()
        return $"Validation failed : {string.Join(string.Empty, error)}";

    }

    public class ValidationExceptionModel
    {
        public string? Property { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
