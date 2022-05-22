using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.API.Models
{
    public partial class BaseResponse
    {
        public bool Status { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public virtual void AddError(string message)
        {
            if (Errors == null)
                Errors = new List<string>();

            Errors = Errors.Append(message);
        }

        public virtual void Success()
        {
            Status = true;
        }

        public virtual void Error(Exception ex)
        {
            Status = false;
            AddError(ex.Message);
        }
    }

    public partial class BaseResponse<T> : BaseResponse where T : class
    {
        public T Data { get; set; }

        public virtual void Success(T data)
        {
            Status = true;
            Data = data;
        }

        public override void Error(Exception ex)
        {
            Data = null;
            base.Error(ex);
        }
    }
}
