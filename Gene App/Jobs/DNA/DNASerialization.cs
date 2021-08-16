using System;
using System.Collections.Generic;
using System.Text;

namespace Gene_App.Jobs.DNA
{
    public class DNASerialization
    {   
        private static string ConvertBytetoUnitaryStrand(byte bit)
        {
            //takes 2 bits and converts to single strand
            return bit switch
            {
                0 => "A",//a=0b00
                3 => "T",//t=0b11
                1 => "C",//c=0b01
                2 => "G",//g=0b10
                _ => throw new ArgumentOutOfRangeException("can only receive values from 0 to 3, but got:", Convert.ToString(bit, toBase: 2)),
            };
        }
        private static string ConvertBytetoStrand(byte bit)
        {
            //takes a byte and turns into syze 4 strand
            var stringBuilder = new StringBuilder(4);
            for(int i = 3; i >= 0; i--)
            {
                // takes the 2 bits correspondant to each gene and throws them at the lowest significantive places
                byte x = (byte)(bit >> i * 2);
                x = (byte)(x & 3); //x and 0b11
                stringBuilder.Append(ConvertBytetoUnitaryStrand(x));
            }
            return stringBuilder.ToString();

        } 
        public static string DecodeStrandFromBase64(string input)
        {
            // taking entire B64 string and turn into "human friendly" strand
            byte[] bytes = Convert.FromBase64String(input);

            var stringBuilder = new StringBuilder(bytes.Length*4 );
            foreach(byte b in bytes)
            {
                stringBuilder.Append(ConvertBytetoStrand(b));
            }
            return stringBuilder.ToString();

        }

        private static byte ConvertUnitStrandtoByte(string input)
        {
            return input switch
            {
                "A" => 0,
                "T" => 3,
                "C" => 1,
                "G" => 2,
                _ => throw new ArgumentException("can only receive : A , T , C , G ||| but got: ", input),

            };
        }
        private static byte ConvertStrandtoByte(string input)
        {
            //Takes a lenght 4 strand and converts to byte
            if (input.Length != 4)
            {
                throw new ArgumentException("Lenght must be of size 4. " + input + input.Length.ToString());
            }
            byte bit = 0;
            for (int i = 0; i <=3; i++)
            {
                // first chars go to MS byte
                byte x = (byte)(ConvertUnitStrandtoByte(input[i].ToString()) << (3-i) * 2);
                bit += x;

            }
            return bit;
        }

        public static string EncodeStrandToBase64(string input)
        {
            //Takes a "human friendly" stramd, turns into b64 string
            var byteList = new List<byte>();

            for (int i =0; i < input.Length/4; i++)
            {
                string dnaSegment = input.Substring(i*4, 4);
                byteList.Add(ConvertStrandtoByte(dnaSegment));
            }
            byte[] byteArray = byteList.ToArray();

            var sb = new StringBuilder();
            foreach(byte b in byteArray)
            {
                sb.Append(Convert.ToString(b, toBase: 16));
            }
           
            return Convert.ToBase64String(byteArray);




        }


        
    }
}
