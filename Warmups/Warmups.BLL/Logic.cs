using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            int cigNum = 0;

            if (cigars >= 40 && cigars <= 60) cigNum = 1;
            if (isWeekend == false && cigNum == 1) return true;
            if (cigars >= 40) cigNum = 2;
            if (isWeekend == true && cigNum == 2) return true;
            return false;
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            bool more = false;
            bool less = false;

            if (yourStyle >= 8 || dateStyle >= 8) more = true;
            if (yourStyle <= 2 || dateStyle <= 2) less = true;

            if (less == true) return 0;
            if (more == true && less == false) return 2;
            else return 1;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            bool goodTemp = false;
            bool sumTemp = false;

            if (temp >= 60 && temp<= 90) goodTemp = true;
            if (temp >= 60 && temp<= 100) sumTemp = true;
            if (isSummer == false && goodTemp == true) return true;
            if (isSummer == true && sumTemp == true) return true;
            else return false;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (isBirthday != true)
            {
                if (speed <= 60) return 0;
                else if (speed >= 61 && speed <= 80) return 1;
                else return 2;
            }

            else
            {
                if (speed <= 65) return 0;
                else if (speed >= 66 && speed <= 85) return 1;
                else return 2;
            }
        }
        
        public int SkipSum(int a, int b)
        {
            if (a + b >= 10 && a + b <= 20) return 20;
            return a + b;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            if (vacation == true) return "10:00";
            else if (day == 0 || day == 6) return "10:00";
            else return "7:00";
        }
        
        public bool LoveSix(int a, int b)
        {
            if (a + b == 6 || a - b == 6) return true;
            else if (a==6 || b==6) return true;
            else return false;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode)
            {
                if (n <= 1 || n >= 10) return true;

                else return false;
            }

            else
            {
                if (n >= 1 && n <= 10) return true;
                else return false;
            }
        }
        
        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0 || (n -1) % 11 == 0) return true;
            else return false;
        }
        
        public bool Mod20(int n)
        {
            if ((n-1) % 20 == 0 || (n - 2) % 20 == 0) return true;
            else return false;
        }
        
        public bool Mod35(int n)
        {
            if (n % 3 == 0 && n % 5 != 0) return true;
            else if (n % 5 == 0 && n % 3 != 0) return true;
            else return false;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep) return false;

            else if (!isMorning) return true;

            else if (isMorning && isMom) return true;

            else return false;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c || a + c == b) return true;

            else if (b + c == a) return true;

            else return false;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (a < b && b < c) return true;

            else if (bOk && c > a) return true;

            else return false;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (equalOk)
            {
                if (a <= b && b <= c) return true;

                else return false;
            }

            if (a < b && b < c) return true;

            else return false;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            if (a % 10 == b % 10) return true;
            else if (b % 10 == c % 10) return true;
            else if (a % 10 == c % 10) return true;
            else return false;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            if (!noDoubles) return die1 + die2;

            if (noDoubles && die1 != die2) return die1 + die2;

            else if (die1 == die2 && die1 == 6) return 7;

            else return die1 + die2 + 1;
        }

    }
}
