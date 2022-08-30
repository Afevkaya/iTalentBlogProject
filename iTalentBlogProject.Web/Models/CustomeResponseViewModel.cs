using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace iTalentBlogProject.Web.Models
{

    public class CustomeResponseViewModel<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        /// <summary>
        /// Static Factory Design Pattern
        /// </summary>
        public static CustomeResponseViewModel<T> Success(T data, int statusCode)
        {
            return new CustomeResponseViewModel<T> {Data = data, StatusCode = statusCode};
        }

        public static CustomeResponseViewModel<T> Success(int statusCode)
        {
            return new CustomeResponseViewModel<T> {StatusCode = statusCode};
        }

        public static CustomeResponseViewModel<T> Fail(List<string> errors, int statusCode)
        {
            return new CustomeResponseViewModel<T> {Errors = errors, StatusCode = statusCode};
        }

        public static CustomeResponseViewModel<T> Fail(string error, int statusCode)
        {
            return new CustomeResponseViewModel<T> {Errors = new List<string> {error}, StatusCode = statusCode};
        }
    }
}
