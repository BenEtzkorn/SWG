using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile == bSmile) return true;
            return false;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isWeekday == false || isVacation == true) return true;
            return false;
        }

        public int SumDouble(int a, int b)
        {
            if (a == b) return (a + b) * 2;
            return (a + b);
        }

        public int Diff21(int n)
        {
            if (n > 21) return 2 * (n - 21);
            else if (n - 21 <= 0) return (21 - n);
            return (n - 21);
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == true)
            {
                if (hour > 20 || hour < 7) return true;
            }
            else if (isTalking == false)
            {
                return false;
            }
            return false;
        }

        public bool Makes10(int a, int b)
        {
            if (a + b == 10 || a == 10 || b == 10) return true;
            return false;
        }

        public bool NearHundred(int n)
        {
            if (Math.Abs(n - 100) <= 10 || Math.Abs(n - 200) <= 10) return true;
            return false;
        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if (negative == true)
            {
                if (a < 0 && b < 0) return true;
            }
            else
                   if (Math.Abs(a) + Math.Abs(b) > b + a) return true;
            return false;
        }

        public string NotString(string s)
        {
            if (s.Length < 5) return "not " + s;
            else if (s.Substring(0, 3) == "not") return s;
            return "not " + s;
        }

        public string MissingChar(string str, int n)
        {
            int i = n;
            string s = str;
            string cut = str.Remove(n, 1);
            return cut;
        }

        public string FrontBack(string str)
        {
            int length = str.Length;

            if (length == 1) return str;

            else if (length == 2) return str.Substring(1, 1) + str.Substring(0, 1);

            else return str.Substring(length - 1, 1) + str.Substring(1, length -2) + str.Substring(0, 1);
        }

        public string Front3(string str)
        {
            int length = str.Length;

            if (length < 3) return str + str + str;

            string front = str.Substring(0, 3);

            return front + front + front;
        }

        public string BackAround(string str)
        {
            string last = str.Substring(str.Length - 1, 1);
            return last + str + last;
        }

        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0) return true;
            return false;
        }

        public bool StartHi(string str)
        {
            int length = str.Length;

            if (length == 1) return false;

            string hi = str.Substring(0, 2);

            if (length == 2 && hi == "hi") return true;

            if (length == 2 && hi != "hi") return false;

            string space = str.Substring(2, 1);
            
            if (hi == "hi")
            {
                if (space == " " && str.Length >= 2) return true;
                if (space == "," && str.Length >= 2) return true;
            }
            return false;
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 < 0 && temp2 > 100) return true;
            if (temp1 >100 && temp2 <0) return true;
            return false;
        }
        
        public bool Between10and20(int a, int b)
        {
            if (a >= 10 && a <= 20) return true;
            if (b >= 10 && b <= 20) return true;
            return false;
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            if (a >= 13 && a <= 19) return true;
            if (b >= 13 && b <= 19) return true;
            if (c >= 13 && c <= 19) return true;
            return false;
        }
        
        public bool SoAlone(int a, int b)
        {
            int x = 0;
            int y = 0;

            if (a >= 13 && a <= 19) x=1;
            if (b >= 13 && b <= 19) y=1;
            if (x + y == 1) return true;
            return false;
        }
        
        public string RemoveDel(string str)
        {
            string check = str.Substring(1, 3);

            if (check == "del") return str.Remove(1, 3);
            return str;
        }
        
        public bool IxStart(string str)
        {
            string check = str.Substring(1, 2);

            if (check == "ix") return true;
            return false;
        }
        
        public string StartOz(string str)
        {
            if (str.Length >= 2)
            {
                string first = str.Substring(0, 1);
                string second = str.Substring(1, 1);

                if (first == "o" && second == "z") return "oz";
                if (first == "o") return "o";
                if (second == "z") return "z";
            }
            else if (str.Length >= 1)
            {
                if (str == "o") return "o";
                if (str == "z") return "z";
                return "";
            }
            return "";
        }
        
        public int Max(int a, int b, int c)
        {
            if (a > b && a > c) return a;
            else if (b > a && b > c) return b;
            else return c;
        }
        
        public int Closer(int a, int b)
        {
            int x = 0;
            int y = 0;

            x = Math.Abs(a - 10);
            y = Math.Abs(b - 10);

            if (x == y) return 0;
            if (x > y) return b;
            return a;
        }
        
        public bool GotE(string str)
        {
            int NumberofEs = 0;

            for (int x=0; x < str.Length; x++)
           {
                if (str.Substring(x,1) == "e") NumberofEs = NumberofEs +1;
           }

            if (NumberofEs >= 1 && NumberofEs <= 3) return true;
            return false;
        }
        
        public string EndUp(string str)
        {
            int length = str.Length;

            if (length <= 3) return str.ToUpper();

            string lastThree = str.Substring(length - 3, 3);

            string theRest = str.Substring(0, length - 3);

            return theRest + lastThree.ToUpper();
        }
        
        public string EveryNth(string str, int n)
        {
            string combo = "";

            for (int x = 0; x < str.Length; x += n)
            {
                combo = combo + str.Substring(x, 1);
            }
            return combo;
        }
    }
}
