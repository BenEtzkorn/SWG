using System;

namespace Warmups.BLL
{
    public class Arrays
    {
        private object int32;

        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6) return true;
            else return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length == 0) return false;

            else if (numbers[0] == numbers[numbers.Length - 1]) return true;

            else return false;
        }
        public int[] MakePi(int n)
        {

            double pi = Math.PI;

            string pie = pi.ToString();

            pie = pie.Remove(1, 1);

            int [] outputPie = new int [n];

            for (int i = 0; i < n; i++)

                { 
                    int tempNum = int.Parse(pie.Substring(i, 1));

                    outputPie[i] = tempNum;
                }
               
            return outputPie;

        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1]) return true;
            else return false;
        }
        
        public int Sum(int[] numbers)
        {
            int sum = 0;

            for ( int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int first = numbers[0];

            int[] rotateOutput = new int[numbers.Length];

            for (int i=0; i < numbers.Length-1; i++)
            {
                rotateOutput[i] = numbers[i + 1];
            }

            rotateOutput[numbers.Length - 1] = first;

            return rotateOutput;
        }
        
        public int[] Reverse(int[] numbers)
        {
            int L = numbers.Length - 1;

            int[] reverseOutput = new int[L+1];

            for (int i = L; i>=0; i -= 1)
            {
                reverseOutput[L - i] = numbers[i];
            }

            return reverseOutput;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int maxValue = 0;

            if (numbers[0] > numbers[numbers.Length - 1]) maxValue = numbers[0];
            else maxValue = numbers[numbers.Length - 1];

            int[] higherwins = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                higherwins[i] = maxValue;
            }

            return higherwins;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int middleA = a[1];
            int middleB = b[1];

            int [] middle = new int[2];

            middle[0] = middleA;
            middle[1] = middleB;

            return middle;
        }
        
        public bool HasEven(int[] numbers)
        {

            bool even = false;

            for (int i = 0; i < numbers.Length; i++)

                { 

                if (numbers[i] % 2 == 0) even = true;

                }

            return even;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int [] doubleArray = new int[2 * numbers.Length];
     
            for (int i = 0; i <= 2*numbers.Length-2; i++)
            {
                doubleArray[i] = 0;
            }

            doubleArray[2 * numbers.Length - 1] = numbers[numbers.Length - 1];

            return doubleArray;
        }

        public bool Double23(int[] numbers)
        {
            int two = 0;
            int three = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2) two = two + 1;
                else if (numbers[i] == 3) three = three + 1;
            }

            if (two == 2 || three == 2) return true;
            return false;
       
        }
        
        public int[] Fix23(int[] numbers)
        {

            for (int i = 0; i < numbers.Length; i++)

            {
                if (numbers[i] == 2 && numbers[i + 1] == 3) numbers[i + 1] = 0;
            }
            return numbers;

        }
        
        public bool Unlucky1(int[] numbers)
        {
            if (numbers[0] == 1 && numbers[1] == 3) return true;

            else  if (numbers[1] == 1 && numbers[2] == 3) return true;

            else if (numbers[numbers.Length - 3] == 1 && numbers[numbers.Length-2] == 3) return true;

            else if (numbers[numbers.Length - 2] == 1 && numbers[numbers.Length-1] == 3) return true;

            else return false;
        }
        
        public int[] Make2(int[] a, int[] b)
        {


            int[] makeIt = new int[2]; 

            if (a.Length >= 2)

            {
                makeIt[0] = a[0];
                makeIt[1] = a[1];

                return makeIt;
            }

            else if (a.Length == 1)
            {
                makeIt[0] = a[0];
                makeIt[1] = b[0];

                return makeIt;
            }

            else
            {
                makeIt[0] = b[0];
                makeIt[1] = b[1];

                return makeIt;
            }
            
        }

    }
}
