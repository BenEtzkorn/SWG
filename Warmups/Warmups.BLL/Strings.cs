using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            string s = "";

            s = "Hello " + name + "!";

            return s;
        }

        public string Abba(string a, string b)
        {
            string s = "";

            s = string.Format("{0}{1}{2}{3}",a,b,b,a);

            return s;
        }

        public string MakeTags(string tag, string content)
        {
            string rv = $"<{tag}>{content}</{tag}>";
            return rv;
        }

        public string InsertWord(string container, string word) {

            string s = string.Format("{0}{1}{2}", container.Substring(0, container.Length / 2), word, container.Substring(container.Length / 2, container.Length / 2));

            return s;
        }

        public string MultipleEndings(string str)
        {
            string part = str.Substring(str.Length - 2, 2);

            string s = string.Format("{0}{0}{0}", part);

            return s;
        }

        public string FirstHalf(string str)
        {
            string s = str.Substring(0, str.Length / 2);

            return s;
        }

        public string TrimOne(string str)
        {
            string s = str.Substring(1, str.Length - 2);

            return s;
        }

        public string LongInMiddle(string a, string b)
        {
            string s = "";

            if (a.Length > b.Length) s = b + a + b;
            else s = a + b + a;

            return s;
        }

        public string RotateLeft2(string str)
        {
            string s = "";

            if (str.Length == 2) s = str;

            else s = str.Substring(2, str.Length - 2) + str.Substring(0, 2);

            return s;

        }

        public string RotateRight2(string str)
        {
            string s = "";

            if (str.Length == 2) s = str;

            else s = str.Substring(str.Length-2, 2) + str.Substring(0, str.Length-2);

            return s;
        }

        public string TakeOne(string str, bool fromFront)
        {
            string s = "";

            if (fromFront) s = str.Substring(0, 1);

            else s = str.Substring(str.Length-1, 1);

            return s;
        }

        public string MiddleTwo(string str)
        {
            string s = "";

            s = str.Substring(str.Length / 2 - 1, 2);

            return s;
        }

        public bool EndsWithLy(string str)
        {

            if (str.Length < 2) return false;

            else if (str.Substring(str.Length - 2, 2) == "ly") return true;

            else return false;
;        }

        public string FrontAndBack(string str, int n)
        {

            string s = "";

            s = str.Substring(0, n) + str.Substring(str.Length - n, n);

            return s;
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            string s = "";

            if (n + 2 > str.Length) s = str.Substring(0, 2);

            else s = str.Substring(n, 2);

            return s;
        }

        public bool HasBad(string str)
        {
            if (str.Length < 4) return false;

            else if (str.Substring(0, 3) == "bad" || str.Substring(1, 3) == "bad") return true;

            else return false;
        }

        public string AtFirst(string str)
        {
            string s = "";

            if (str.Length == 0) s = "@@";

            else if (str.Length == 1) s = str.Substring(0, 1) + "@";

            else s = str.Substring(0, 2);

            return s;
        }

        public string LastChars(string a, string b)
        {
            string s = "";

            if (a.Length == 0) a = "@";

            if (b.Length == 0) b = "@";

            s = a.Substring(0, 1) + b.Substring(b.Length - 1, 1);

            return s;
        }

        public string ConCat(string a, string b)
        {
            string s = "";

            if (a == "") s = b;

            else if (b == "") s = a;

            else if (a.Substring(a.Length - 1, 1) == b.Substring(0, 1)) s = a + b.Substring(1, b.Length - 1);

            else s = a + b;

            return s;
        }

        public string SwapLast(string str)
        {
            string s = "";

            if (str.Length == 0 || str.Length == 1) s = str;

            else if (str.Length == 2) s = str.Substring(1, 1) + str.Substring(0, 1);

            else s = str.Substring(0, str.Length - 2) + str.Substring(str.Length - 1, 1) + str.Substring(str.Length - 2, 1);

            return s;
        }

        public bool FrontAgain(string str)
        {
            if (str.Substring(0, 2) == str.Substring(str.Length - 2, 2)) return true;
            else return false;
        }

        public string MinCat(string a, string b)
        {
            int aL = a.Length;
            int bL = b.Length;
            string s = "";

            if (aL == bL) s = a + b;

            else if (aL > bL) s = a.Substring(aL - bL, bL) + b;

            else s = a + b.Substring(bL - aL, aL);

            return s;

        }

        public string TweakFront(string str)
        {
            string s = "";

            if (str == "") s = str;

            else if (str.Substring(0, 1) == "a" && str.Substring(1, 1) == "b") s = str;

            else if (str.Substring(0, 1) == "a") s = "a" + str.Substring(2, str.Length - 2);

            else if (str.Substring(1, 1) == "b") s = "b" + str.Substring(2, str.Length - 2);

            else s = str.Substring(2, str.Length - 2);

            return s;
        }

        public string StripX(string str)
        {
            string s = "";

            if (str == "") s = str;

            else if (str.Length == 1 && str.Substring(0, 1) == "x") s = "";

            else if (str.Length == 1 && str.Substring(0, 1) != "x") s = str;

            else if (str.Substring(0, 1) == "x" && str.Substring(str.Length - 1, 1) == "x") s = str.Substring(1, str.Length - 2);

            else if (str.Substring(0, 1) == "x") s = str.Substring(1, str.Length - 1);

            else if (str.Substring(str.Length - 1, 1) == "x") s = str.Substring(0, str.Length - 1);

            else s = str;

            return s;
        }
    }
}
