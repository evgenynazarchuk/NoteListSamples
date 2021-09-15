using System;
using System.Collections.Generic;

namespace NoteListSamples.IntegrationTest.Support.Facade
{
    public class ActionResult<T>
        where T : class
    {
        public readonly T? Value = null;

        public readonly List<string>? Errors = null;

        public bool HasValue => Value is not null;

        public bool HasErrors => Errors is not null;

        public ActionResult(T value)
        {
            if (value is null)
            {
                throw new ArgumentNullException("ActionResult.Value is null");
            }

            this.Value = value;
        }

        public ActionResult()
        {
            this.Errors = new List<string>();
        }

        public ActionResult(string error)
        {
            this.Errors = new List<string>();
            this.Errors.Add(error);
        }

        public ActionResult<T> AddErrors(List<string> errors)
        {
            Errors?.AddRange(errors);
            return this;
        }
        public ActionResult<T> AddError(string error)
        {
            Errors?.Add(error);
            return this;
        }
    }
}
