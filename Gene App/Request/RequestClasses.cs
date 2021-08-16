using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Gene_App.Request
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
        [JsonProperty("job")]
        job jobResult;
        [JsonProperty("code")]
        string code;
        
        string message;

        public string Code => code;

        public string Message => message;

        public job JobResult => jobResult;
        
        
        
    }
    public class job
    {
        [JsonProperty("id")]
        string id;
        [JsonProperty("type")]
        string type;
        [JsonProperty("strand")]
        string strand;
        [JsonProperty("strandEncoded")]
        string strandEncoded;
        [JsonProperty("geneEncoded")]
        string geneEncoded;

        public string Id => id;

        public string Type => type;

        public string Strand => strand;

        public string StrandEncoded => strandEncoded;

        public string GeneEncoded => geneEncoded;
    }
    internal class JobCompletedRequest
    {
        string strandEncoded;
        string strand;
        bool isActivated;

        public string StrandEncoded { get => strandEncoded; set => strandEncoded = value; }
        public string Strand { get => strand; set => strand = value; }
        public bool IsActivated { get => isActivated; set => isActivated = value; }
    }

}
