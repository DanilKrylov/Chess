using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Authorize.DtoModels
{
    public class AuthorizeOperationResult
    {
        public bool Successed { get; set; }

        public JwtInfo JwtInfo { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();

        public AuthorizeOperationResult(bool seccessed)
        {
            Successed = seccessed;
        }

        public AuthorizeOperationResult(bool seccessed, JwtInfo jwtInfo)
        {
            Successed = seccessed;
            JwtInfo = jwtInfo;
        }

        public void AddError(string propertyName, string error)
        {
            if (!Errors.ContainsKey(propertyName))
            {
                Errors[propertyName] = new List<string>();
            }

            Errors[propertyName].Add(error);
        }
    }
}
