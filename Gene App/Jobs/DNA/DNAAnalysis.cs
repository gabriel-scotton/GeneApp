using System;
using System.Collections.Generic;
using System.Text;

namespace Gene_App.Jobs.DNA
{
    public class DNAAnalysis
    {
        public static string InvertDNA(string str)
        {
            var charArray = str.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)

            {
                
                char c = charArray[i];
                switch (c)
                {
                    case 'A':
                        charArray[i] = 'T';
                        break;
                    case 'T':
                        charArray[i] = 'A';
                        break;
                    case 'C':
                        charArray[i] = 'G';
                        break;
                    case 'G':
                        charArray[i] = 'C';
                        break;
                    default:
                        throw new ArgumentException("Argument is not a DNA strand");


                }
            }
            str = new string(charArray);

            return str;
        }
        public static string FixTemplate(string str)
        {
            //function makes sure template is the Main Strand, if not, inverts it to it
            string initial = str.Substring(0, 3);
            if (initial.Equals("GTA"))
            {
                return InvertDNA(str);

            }
            else if (initial.Equals("CAT"))
            {
                return str;
            }
            throw new ArgumentException("A gene starting with"+str.Substring(0, 3)+" is an invalid input");
            
        }

        public static bool CheckStrandActivation(string template, string gene)
        {
            

            template = FixTemplate(template);
            
            // checks if every substring bigger than half the gene is contained in the template Strand
            for(int i=0; i < gene.Length / 2; i++)
            {
                //splits gene to a subgene bigger than half
                string str = gene.Substring(i, (gene.Length / 2) + 1);
                if (template.Contains(str))
                {
                    return true;
                }
                    
            }
            return false;




        }
    }
}
