using System;
using System.Collections.Generic;
using System.Text;

namespace Gene_App.Jobs.DNA
{
    public class DNASerialization
    {   
        private static string ConvertBytetoUnitStrand(byte bit)
        {
            return bit switch
            {
                0 => "A",
                3 => "T",
                1 => "C",
                2 => "G",
                _ => throw new ArgumentOutOfRangeException("can only receive values from 0 to 3, but got:", Convert.ToString(bit, toBase: 2)),
            };
        }
        private static string ConvertBytetoStrand(byte bit)
        {
            var stringBuilder = new StringBuilder(4);
            for(int i = 3; i >= 0; i--)
            {
                byte x = (byte)(bit >> i * 2);
                x = (byte)(x & 3); //x and 0b11
                stringBuilder.Append(ConvertBytetoUnitStrand(x));
            }
            return stringBuilder.ToString();

        } 
        public static string DecodeStrandFromBase64(string input)
        {
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
            if (input.Length != 4)
            {
                throw new ArgumentException("Lenght must be of size 4. " + input + input.Length.ToString());
            }
            byte bit = 0;
            for (int i = 0; i <=3; i++)
            {
                byte x = (byte)(ConvertUnitStrandtoByte(input[i].ToString()) << (3-i) * 2);
                bit += x;

            }
            return bit;
        }

        public static string EncodeStrandToBase64(string input)
        {
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
