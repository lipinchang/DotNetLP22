using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOverloadingApplication
{
    internal class Program
    {   //ctor tab x2      //if u do not write any constructor, compiler will give u a default. when u write one urself, it will only use what u write

        Program()
        {
            Console.WriteLine("default constructor");
        }

        Program(int i)
        {
            Console.WriteLine("parameterized constructor");
        }
        void Add(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine("the sum of {0} and {1} is {2}", num1, num2, sum);
        }

        void Add(int num1)
        {
            int sum = num1++;
            Console.WriteLine("the incremented value of {0} is {1}", num1, sum);
        }

        void Add(string str1, string str2)
        {
            string res = str1 +" "+ str2;
            Console.WriteLine("the concat value of {0} and {1} is {2}", str1, str2, res);
        }

        public int Solution(int N)   //to be reviewed again
        {
            //first need to convert from dec to binary
           
            string binary = Convert.ToString(N, 2);
            Console.WriteLine("binary: "+ binary);  //1100101000000000
            int countZero = 0;
            bool firstOne = false;
            int maxCount = -1;
            //Console.WriteLine("binary: "+binary);

            for (int i = 0; i < binary.Length; i++)   //10000010001
            {
                if (binary[i] == '1' && firstOne == false)  //for start only
                {
                    //bool true
                    firstOne = true;
                }
                //for second start?
                else if (binary[i] == '0' && firstOne == false && maxCount != -1)
                {
                    countZero++;
                }
               
                else if (firstOne == true && binary[i] == '0')
                {
                    //start count0
                    countZero++;
                }
                else if (binary[i] == '1' && firstOne == true && binary[i-1]!='1')
                {
                    maxCount = Math.Max(countZero,maxCount);
                    countZero = 0;
                    firstOne = false;
                }
                    
            }
            return maxCount;

            //classmate solution
            //string bits = Convert.ToString(N, 2);
            //int longest = 0;
            //int count = 0;
            //for (int i = 0; i < bits.Length; i++)
            //{
            //    if (bits[i] == '0')
            //        count++;

            //    else
            //    {
            //        longest = Math.Max(count, longest);
            //        count = 0;
            //    }
            //}
            //return longest;
        }

        public bool AuthenticateCardNumber(long digits)
        {
            int[] reversed = new int[16];
            string strNum = digits.ToString();
            int revCount = 0;

            for (int i = 15; i >= 0; i--)
            {
                //reversed
                int c = Int32.Parse(strNum[i].ToString());
                reversed[revCount++] = c;
            }

            Console.WriteLine("---------");
            
            for (int i = 1; i <= 16; i++)
            {
                if (i % 2 == 0)
                {
                    reversed[i-1] = reversed[i-1] * 2;
                }
            }

            int count = 0, sum=0, m;
            
            for (int i = 0; i < 16; i++)
            {
                count = getDigits(reversed[i], count);
                if (count > 1)
                {
                    while (reversed[i] > 0)
                    {
                        m = reversed[i] % 10;
                        sum = sum + m;
                        reversed[i] = reversed[i] / 10;

                    }
                    reversed[i] = sum;
                }

                count = 0;
                sum = 0;
               
            }

            //sum of all numbers
            for (int i = 0; i < 16; i++)
            {
                sum += reversed[i];
            }

            if (sum % 10 == 0)
                return true;
            else
                return false;

            //foreach (var item in reversed)
            //{
            //    Console.WriteLine(item);
            //}
         
        }

        public int getDigits(int n1, int nodigits)
        {
            if (n1 == 0)
                return nodigits;

            return getDigits(n1 / 10, ++nodigits);
        }

        public void FindNonRepeatingNumber()
        {
            Console.WriteLine("Please key in 11 numbers, one by one separated by comma");
            int[] arr = new int[11];
            int i = 0;
            string strNumbers = Console.ReadLine();
            foreach (var sn in strNumbers.Split(','))
            {
                int n = Convert.ToInt32(sn);
                // work with n
                arr[i++] = n;
            }

            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}

            int ii, j;
         
            for (ii = 0; ii < 11; ii++)
            {
                for (j = 0; j < 11; j++)
                {
                    if (arr[ii] == arr[j] && ii != j)
                        //repeated
                        break;
                    
                }
                if (j == 11)
                {                   
                    Console.WriteLine("non repeating element is: "+ arr[ii]);
                    
                }
            }
            
        }

        public void FindMedianAndMode()
        {
            bool isPositive = true;
            List<int> list = new List<int>();
            int no = 0;

            while (isPositive)
            {
                Console.WriteLine("Please enter a neg no.");
                no = Convert.ToInt32(Console.ReadLine());
                if (no > 0)
                    list.Add(no);
                else
                    isPositive = false;
            }
            list.Sort();

            //median 
            int size = list.Count;

            if (size % 2 != 0)
                Console.WriteLine("Median: " + (double)list[size / 2]);
            else
            {
                double xx = ((double)list[size / 2 - 1] + (double)list[size / 2]) / 2;

                Console.WriteLine("Median: " + xx);
            }
            //mode
            int[] count = new int[size + 1];
            for (int i = 0; i < size + 1; i++)
                count[i] = 0;

            for (int i = 0; i < list.Count; i++)
                count[list[i]]++;

            // mode is the index with maximum count
            int mode = 0;
            int k = count[0];
            for (int i = 1; i < size + 1; i++)
            {
                if (count[i] > k)
                {
                    k = count[i];
                    mode = i;
                }

            }
            Console.WriteLine("mode: "+mode);
        }

        static void Main(string[] args)
        {
            //Program program = new Program(1);    //overloading
            //program.Add("hello", "world");
            //program.Add(10,20);
            //program.Add(20);


            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine(employee[i]);
            //}
            //Console.WriteLine("the index of skill MS SQL is "+employee["MS SQL"]);


            //Employee e1 = new Employee();
            //Employee e2 = new Employee();
            //e1[0] = "Java";
            //Employee e3 = e1 + e2;
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine(e3[i]);
            //}
            //returns
            //Java and C#
            //MS SQL
            //DevOps

            Program p = new Program();
            //int sol = p.Solution(1162);
            //Console.WriteLine("sol: "+ sol);

            //Console.WriteLine(p.FindNonRepeatingNumber());
            p.FindMedianAndMode();
            Console.ReadKey();
        }
    }
}
