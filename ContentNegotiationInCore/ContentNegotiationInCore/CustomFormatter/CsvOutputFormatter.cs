using ContentNegotiationInCore.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentNegotiationInCore.CustomFormatter
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(Student).IsAssignableFrom(type) || typeof(IEnumerable<Student>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<Student>)
            {
                foreach (var student in (IEnumerable<Student>)context.Object)
                {
                    FormatCsv(buffer, student);
                }
            }
            else
            {
                FormatCsv(buffer, (Student)context.Object);
            }

            using (var writer = context.WriterFactory(response.Body, selectedEncoding))
            {
                return writer.WriteAsync(buffer.ToString());
            }
        }

        private static void FormatCsv(StringBuilder buffer, Student Student)
        {
            buffer.AppendLine($"{Student.FName},\"{Student.LName},\"{Student.Age},\"{Student.City}\"");
        }
    }
}
