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
        
        
        static async Task<JobRequest> DoJobOperation()
        {
            Token token = await ApiRequests.RequestToken("https://gene.lacuna.cc/api/users/login");


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

                    if (jobResponse.Code.Equals("Fail")){
                        Console.WriteLine(gene);
                        Console.WriteLine(templateStrand);
                        Console.WriteLine(!completedRequest.IsActivated);

                    }

                }

            }
            return jobResponse;
        }
        static async Task Main()
        {
            

            try
            {

                while (true)
                {
                    var taskState = await DoJobOperation();
                    Console.WriteLine(taskState.Code);
                }

                
                
                


            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
    
}
