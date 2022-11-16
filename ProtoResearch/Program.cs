using Google.Protobuf;
using System;
using System.IO;
using System.Text;
using ProtoResearch;
namespace ProtoResearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Test data = new();
            data.SentIds.Add(18);
            data.SentIds.Add(21);
            data.SentIds.Add(3123123999);
            data.SentIds.Add(12);


            using (var fileStream = File.Create("testData.bin"))
            {
                data.WriteTo(fileStream);
            }*/


            Browser Browser = new Browser();

            string url = "https://api.steampowered.com/ILoyaltyRewardsService/GetReactions/v1?access_token=85f8ec7d3bfb69b706c69adf2df5c063&input_protobuf_encoded=CAMQtuXD05CAgIgB";
            HttpResponseMessage response = Browser.UrlGetToHttp(url).Result;
            Stream stream = response.Content.ReadAsStream();
            Console.WriteLine(stream.Length);
            MemoryStream ms = new();
            stream.CopyTo(ms);
            byte[] bin = ms.ToArray();
            
            AlreadySentAwards data = AlreadySentAwards.Parser.ParseFrom(bin);

            Console.WriteLine();
                       
        }
    }
}