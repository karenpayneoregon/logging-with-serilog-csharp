using System;
using System.Collections.Generic;

namespace HidePathInExceptions.Classes
{
    public static class ExceptionExtensions
    {
        public static IEnumerable<Exception> FlattenHierarchy(this Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException(nameof(ex));
            }

            var innerException = ex;
            do
            {
                yield return innerException;
                innerException = innerException.InnerException;
            }
            while (innerException != null);
        }
        public static IEnumerable<T> InnerExceptions<T>(this Exception ex) where T : Exception
        {
            var rVal = new List<T>();

            Action<Exception> lambda = null!;

            lambda = (x) =>
            {
                if (x is T xt)
                {
                    rVal.Add(xt);
                }

                if (x.InnerException != null)
                {
                    lambda!(x.InnerException);
                }

                if (x is AggregateException ax)
                {
                    foreach (var aix in ax.InnerExceptions)
                        lambda!(aix);
                }
            };

            lambda(ex);

            return rVal;
        }
    }
}
