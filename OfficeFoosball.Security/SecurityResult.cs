using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeFoosball.Security
{
    public class SecurityResult
    {
        public List<string> ErrorMessages { get; } = new List<string>();
        public bool Succeeded => !ErrorMessages.Any();

        public void AddErrorMessage(string errorMessage)
        {
            ErrorMessages.Add(errorMessage);
        }

        public void AddErrorMessages(IEnumerable<string> errorMessages)
        {
            ErrorMessages.AddRange(errorMessages);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var error in ErrorMessages)
            {
                sb.AppendLine(error);
            }

            return sb.ToString();
        }
    }

    public class SecurityResult<T> : SecurityResult
    {
        public T Data { get; set; }
    }
}
