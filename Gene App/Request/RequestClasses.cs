using System;
using System.Collections.Generic;
using System.Text;

namespace Gene_App
{
    
    class Token
    {
        readonly string accessToken;
        readonly string code;
        readonly string message;

        public string AccessToken { get => accessToken; }
        public string Code { get => code; }
        public string Message { get => message; }

        public Token(string accessToken, string code, string message)
        {
            this.accessToken = accessToken;
            this.code = code;
            this.message = message;
        }
    }
    class Login
    {

        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        readonly string username;
        readonly string password;

        public string Username => username;

        public string Password => password;
    }
    class JobRequest
    {
        class Job
        {
            readonly string id;
            readonly string type;
            readonly string strand;
            readonly string strandEncoded;
            readonly string geneEncodded;

            public string Id => id;

            public string Type => type;

            public string Strand => strand;

            public string StrandEncoded => strandEncoded;

            public string GeneEncodded => geneEncodded;
        }
        readonly string code;
        readonly string message;

        public string Code => code;

        public string Message => message;
    }

}
