using Gene_App.Jobs.DNA;
using Gene_App.Request;

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gene_App
{
    class App
    {
        
        
        static async Task<JobRequest> DoJobOperation(Token token)
        {
            
            /*In this f, we check which job was received, then execute it, returning a jobRequest, with only code and message*/

            JobRequest jobRequest = await ApiRequests.RequestJob("https://gene.lacuna.cc/api/dna/jobs", token);

            Console.WriteLine(jobRequest.JobResult.Type);
            JobRequest jobResponse = new JobRequest();
            JobCompletedRequest completedRequest = new JobCompletedRequest();
            if (jobRequest.Code.Equals("Success"))
            {
                string jobType = jobRequest.JobResult.Type;


                if (jobType.Equals("DecodeStrand"))
                {
                    string strandDecoded = DNASerialization.DecodeStrandFromBase64(jobRequest.JobResult.StrandEncoded);

                    completedRequest.Strand = strandDecoded;

                    jobResponse = await ApiRequests.PostJob(completedRequest, token, "https://gene.lacuna.cc/api/dna/jobs/" + jobRequest.JobResult.Id + "/decode");



                }
                else if (jobType.Equals("EncodeStrand"))
                {

                    string strandEncoded = DNASerialization.EncodeStrandToBase64(jobRequest.JobResult.Strand);

                    completedRequest.StrandEncoded = strandEncoded;


                    jobResponse = await ApiRequests.PostJob(completedRequest, token, "https://gene.lacuna.cc/api/dna/jobs/" + jobRequest.JobResult.Id + "/encode");



                }
                else if (jobType.Equals("CheckGene"))
                {
                    string gene = DNASerialization.DecodeStrandFromBase64(jobRequest.JobResult.GeneEncoded);
                    string templateStrand = DNASerialization.DecodeStrandFromBase64(jobRequest.JobResult.StrandEncoded);
                    templateStrand = DNAAnalysis.FixTemplate(templateStrand);

                    completedRequest.IsActivated = DNAAnalysis.CheckStrandActivation(templateStrand, gene);
                    jobResponse = await ApiRequests.PostJob(completedRequest, token, "https://gene.lacuna.cc/api/dna/jobs/" + jobRequest.JobResult.Id + "/gene");
                                      
                }

            }
            return jobResponse;
        }
        static async Task Main()
        {
            

            try
            {
                string continueLogin = "yes";

                Login login = new Login();

                while (continueLogin.Equals("yes"))
                {
                    Token token = await ApiRequests.RequestToken("https://gene.lacuna.cc/api/users/login", login);
                    if (token.Code.Equals("Success"))
                    {
                        await JobLoop(token,1000);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("login failed, try again? yes/no");
                        continueLogin = Console.ReadLine();
                        if (continueLogin.Equals("yes"))
                        {
                            login.ReadUserInput();
                        }

                    }

                    
                    
                }

                
                
                


            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
        private async static Task<bool> JobLoop(Token token, int repetitions)
        {
            
            
            string continueJobs = "yes";
            for(int opCount=0;   continueJobs.Equals("yes") ; opCount++)
            {
                
                var taskState = await DoJobOperation(token);
                Console.WriteLine(taskState.Code);
                if (opCount >= repetitions)
                {
                    Console.WriteLine("To continue doing stuff type yes,\notherwise type anything else");
                    continueJobs = Console.ReadLine();
                    opCount = 0;



                }
                
            }
            return true;

        }


    }

    
}
