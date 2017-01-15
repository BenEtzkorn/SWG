using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string s = "";

            for (int i = 1; i <= n; i++)
            {
                s = s + str;
            }
            return s;
        }

        public string FrontTimes(string str, int n)
        {
            string s = "";
            string outString = "";

            if (str.Length == 1) s = str.Substring(0);
            else if (str.Length == 2) s = str.Substring(0, 2);
            else s = str.Substring(0,3);

            for (int i=1; i<=n; i++)
            {
                outString = outString + s; 
            }

            return outString;
        }

        public int CountXX(string str)
        {
            int xxCount = 0;

            if (str.Length < 2) return xxCount;

            else 
                {
                    for (int i = 0; i < str.Length - 1; i++)
                    {
                        if (str.Substring(i,2) == "xx") xxCount = xxCount + 1;
                    }
                    return xxCount;
                }
        }

        public bool DoubleX(string str)
        {
            //I know this is supoosed to be a loop, but this looked simpler

            int location = str.IndexOf("xx");

            if (location == -1) return false;

            else if (location <= str.IndexOf("x")) return true; 
           
            else return false;
        }

        public string EveryOther(string str)
        {
            string s = "";

            for (int i = 0; i < str.Length; i+=2)
            {
                s = s + str.Substring(i,1);
            }
            return s;
        }

        public string StringSplosion(string str)
        {
            string s = "";

            for (int i = 0; i <= str.Length-1; i++)
            {
                s = s + str.Substring(0, i+1);
            }
            return s;
        }

        public int CountLast2(string str)
        {
            string lasttwo = str.Substring(str.Length-2, 2);

            int strCount = 0;

            for (int i = 0; i <= str.Length-4; i++)
            {
                if (str.Substring(i, 2) == lasttwo) strCount = strCount + 1;
            }

            return strCount;
        }

        public int Count9(int[] numbers)
        {
            int last = numbers.Length - 1;

            int  nineCount = 0;

            for (int i = 0; i <= last; i++)
            {
                if (numbers[i] == 9) nineCount = nineCount + 1;
            }
            return nineCount;
        }

        public bool ArrayFront9(int[] numbers)
        {
            int target = numbers.Length-1;

            int nineCount = 0;
            
            if (target > 3) target = 3;

            for (int i = 0; i <= target; i++)
            {
                if (numbers[i] == 9) nineCount = nineCount + 1;
            }

            if (nineCount > 0) return true;
            else return false;
        }

        public bool Array123(int[] numbers)
        {

            for (int i = 0; i <= numbers.Length - 3; i++)

            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i+2] == 3) return true;
            }

            return false;
        }

        public int SubStringMatch(string a, string b)
        {

            int target = Math.Min(a.Length, b.Length);

            int matchCount = 0;

            for (int i = 0; i <= target - 2; i++)

            {
                if (a.Substring(i, 2) == b.Substring(i, 2)) matchCount = matchCount + 1;
            }

            return matchCount;
        }

        public string StringX(string str)
        {
            string newString = "";

            for (int i = 0; i <= str.Length-1; i++)

            {
                if (i == 0 && str.Substring(i,1) == "x") newString = "x";

                else if (i < str.Length - 1 && str.Substring(i,1) != "x") newString = newString + str.Substring(i, 1);

                else if (i == str.Length - 1 && str.Substring(i,1) == "x") newString = newString + "x";

                else if (i == str.Length - 1 && str.Substring(i, 1) != "x") newString = newString + str.Substring(i, 1);
            }            
                
                return newString;
        }

        public string AltPairs(string str)
        {
            //I know this is supoosed to be a loop, but this looked simpler

            string s = str.Substring(0,2);

            if (str.Length >= 5 && str.Length < 7) s = s + str.Substring(4, 2);

            else if (str.Length >= 8 && str.Length <= 9 ) s = s + str.Substring(4, 2) + str.Substring(8, 1);

            else if (str.Length > 9) s = s + str.Substring(4, 2) + str.Substring(8, 2);

            return s;
        }
         
        public string DoNotYak(string str)
        {
            int start = str.IndexOf("yak");

            return str.Remove(start, 3);
        }

        public int Array667(int[] numbers)
        {
            int times = 0;

            for (int i = 0; i <= numbers.Length-2; i++)

            {
                if (numbers[i] == 6 && numbers[i + 1] == 6) times = times + 1;
                else if (numbers[i] == 6 && numbers[i + 1] == 7) times = times + 1;
            }

            return times;
        }

        public bool NoTriples(int[] numbers)
        {

            for (int i = 0; i <= numbers.Length - 3; i++)

            {
                if (numbers[i] == numbers[ i + 1 ] && numbers[ i + 1 ] == numbers[i + 2]) return false;
            }

            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            for (int i = 0; i <= numbers.Length - 3; i++)

            {
                if (numbers[i] + 5 == numbers[i + 1] && numbers[i] - 1 == numbers[i + 2]) return true;
            }

            return false ;
        }
 
    }
}
