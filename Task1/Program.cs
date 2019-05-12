using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {                       
            var startTime = new int[3];
            var endTime = new int[3];

            var digits = new int[10];

            ReadFile(@"\\Mac\Home\Desktop\projects\Учебная практика\Task1\Task1\bin\Debug\INPUT.TXT", ref startTime, ref endTime);

            IncTime(ref endTime);

            do
            {
                digits[startTime[0] % 10]++;
                digits[startTime[0] / 10]++;

                digits[startTime[1] % 10]++;
                digits[startTime[1] / 10]++;

                digits[startTime[2] % 10]++;
                digits[startTime[2] / 10]++;
                IncTime(ref startTime);
            } while ((startTime[0] != endTime[0]) || (startTime[1] != endTime[1]) || (startTime[2] != endTime[2]));

            foreach (var i in digits)
                Console.WriteLine(i);           
        }

        public static void ReadFile(string filePath, ref int[] startTime, ref int[] endTime)
        {
          var reader = new StreamReader(filePath);

            string line1 = reader.ReadLine();
            string line2 = reader.ReadLine();

            startTime[0] = int.Parse(Convert.ToString(line1[0]) + Convert.ToString(line1[1]));
            startTime[1] = int.Parse(Convert.ToString(line1[3]) + Convert.ToString(line1[4]));
            startTime[2] = int.Parse(Convert.ToString(line1[6]) + Convert.ToString(line1[7]));

            endTime[0] = int.Parse(Convert.ToString(line2[0]) + Convert.ToString(line2[1]));
            endTime[1] = int.Parse(Convert.ToString(line2[3]) + Convert.ToString(line2[4]));
            endTime[2] = int.Parse(Convert.ToString(line2[6]) + Convert.ToString(line2[7]));
        }            

        public static void IncTime(ref int[] time)
        {
            time[2]++;
            if (time[2] == 60)
            {
                time[2] = 0;
                time[1]++;
            }
            if (time[1] == 60)
            {
                time[1] = 0;
                time[0]++;                
            }
            if (time[0] == 24)
                time[0] = 0;
        }
    }
}