using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Common.Models
{
    public class ServiceResultNoValue
    {
        public int Code { get; set; }
        public List<string> Errors { get; set; }

        public ServiceResultNoValue()
        {
            Code = ServiceResultCodes.Ok.GetHashCode();
        }

        public void AddException(Exception ex)
        {
            Code = (int)ServiceResultCodes.Error;
            Errors = new List<string>();
            Errors.Add("Message: " + ex.Message);
            Errors.Add("ExceptionType: " + ex.GetType().ToString());
            Errors.Add("StackTrace" + ex.StackTrace);

            Exception innerException = ex.InnerException;
            while (innerException != null)
            {
                Errors.Add("------------------------------");
                Errors.Add("Message: " + innerException.Message);
                Errors.Add("ExceptionType: " + innerException.GetType().ToString());
                Errors.Add("StackTrace" + innerException.StackTrace);
                innerException = innerException.InnerException;
            }
        }

        public void AddError(string message)
        {
            if (Errors == null)
            {
                Errors = new List<string>();
            }
            (Errors as List<string>).Add(message);
        }

        public void AddError(params string[] messages)
        {
            Code = (int)ServiceResultCodes.Bad;
            Errors = new List<string>();
            (Errors as List<string>).AddRange(messages);
        }

    }
}
