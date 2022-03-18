using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ToysAndGamesTesting
{
    public class ProductDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", "Spiderman"),
                new KeyValuePair<string, string>("Description", " "),
                new KeyValuePair<string, string>("AgeRestriction", "5"),
                new KeyValuePair<string, string>("Company", "Marvel"),
                new KeyValuePair<string, string>("Price", "200")
            });

            var formContent2 = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", "Dr Optipus"),
                new KeyValuePair<string, string>("Description", " "),
                new KeyValuePair<string, string>("AgeRestriction", "5"),
                new KeyValuePair<string, string>("Company", "Marvel"),
                new KeyValuePair<string, string>("Price", "200")
            });


            yield return new object[] { formContent, HttpStatusCode.Created };
            yield return new object[] { formContent2, HttpStatusCode.Created };
        }
    }
}
