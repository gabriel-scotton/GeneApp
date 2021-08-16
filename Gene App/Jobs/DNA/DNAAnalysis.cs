using System;
using System.Collections.Generic;
using System.Text;

namespace Gene_App.Jobs.DNA
{
    public class DNAAnalysis
    {
        public static string FixTemplate(string str)
        {
            string initial = str.Substring(0, 3);
            if (initial.Equals("GTA"))
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
                            throw new ArgumentException();


                    }
                }
                str = new string(charArray);
               
                return str;

            }
            else if (initial.Equals("CAT"))
            {
                return str;
            }
            //throw new ArgumentException(str.Substring(0, 3)+" is an invalid input");
            return str;
        }

        public static bool CheckStrandActivation(string template, string gene)
        {
            

            template = FixTemplate(template);
            
            
            for(int i=0; i < gene.Length / 2; i++)
            {
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
