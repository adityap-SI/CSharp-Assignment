namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Question1
             Console.WriteLine("Enter the no of numbers to be entered");
             int a = Convert.ToInt32(Console.ReadLine());
             int[] arr = new int[a];
             for (int i = 0; i < a; i++)
             {
                 arr[i] = Convert.ToInt32(Console.ReadLine());
             }
             for (int i = a - 1; i >= 0; i--)
             {
                 Console.WriteLine(arr[i]);
             }*/

            /*Question 2
            Console.WriteLine("Enter the length of the array:");
            int b = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[b];
            for (int i = 0; i < b; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int c= 0;
            for (int i =0; i <b; i++)
            {
                c = c + arr[i];

            }
            Console.WriteLine(c);*/

            //Control structure
            //1
            /* Console.WriteLine("CheckCredit");
             Console.WriteLine("Enter your Purchase price");
             int value = Convert.ToInt32(Console.ReadLine());
             if (value > 10000)
             {
                 Console.WriteLine("ERROR");
             }
             else
             {
                 Console.WriteLine("Approved");
             }*/

            /*Question 3
            Console.WriteLine("Enter the length of the array:");
            int a = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[a];
            int[] arr_new = new int[a];
            for (int i = 0; i < a; i++)
           {
            arr[i] = Convert.ToInt32(Console.ReadLine());
            arr_new[i] = arr[i];
            }
          for (int i = 0; i < a; i++)
          {
         Console.WriteLine(arr_new[i]);
          }*/
            //Question 4
            /* Console.WriteLine("Enter the value of n");
             int n = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine("Enter the positon from where you want to delete");
             int pos = Convert.ToInt32(Console.ReadLine());
             int[] arr = new int[n];
             for (int i = 0; i < n; i++)
             {
                 arr[i] = Convert.ToInt32(Console.ReadLine());
             }
             for (int i = pos; i < n-1; i++)
             {
                 arr[i - 1] = arr[i];
             }
             for (int i = 0; i < n; i++)
             {
                 Console.WriteLine(arr[i]);
             }*/
            /*
                        Console.WriteLine("Enter marks of the students");

                        int[] a = new int[10];

                        for (int i = 0; i < a.Length; i++)
                        {
                            a[i] = Convert.ToInt32(Console.ReadLine());
                        }

                        int max = 0;
                        int avg = 0;

                        for (int i = 0; i < a.Length; i++)
                        {

                            if (a[i] >= max)
                            {
                                max = a[i];
                            }

                            avg = avg + a[i];

                        }

                        Console.WriteLine(max);
                        Console.WriteLine(avg / 10);

                    }*/
            //4
           /* int pos;
            Console.WriteLine("Enter the size of an array");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] num = new int[n];
            Console.WriteLine("Elements before deletion:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter the numbers{i + 1}");
                num[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Enter the Position");
            pos = Convert.ToInt32(Console.ReadLine());
            for (int i = pos ; i < n; i++)
            {
               if( i == pos)
                {
                    
                }
            }
            Console.WriteLine("Elements after deletion: ");
            for (int i = 0; i < n-1; i++)
            {
                Console.WriteLine(num[i]);
            }*/




            //String
            /*Console.Write("Enter a string: ");
            string input = Console.ReadLine().ToLower();

            char[] chars = input.ToCharArray();
            Array.Sort(chars);
            string sortedString = new string(chars);

            Console.WriteLine($"The string in alphabetical order is: {sortedString}");*/
            //1 
            /* Console.WriteLine("Enter the String");
             string str = Convert.ToString(Console.ReadLine());
             Console.WriteLine("Enter the character to need count");
             char ch = Convert.ToChar(Console.ReadLine());
             int count = 0;
             for (int i = 0; i < str.Length; i++)
             {
                 if (ch == str[i])
                 {
                     count++;
                 }
             }
             Console.WriteLine(count);
             Console.ReadKey();*/


            //2
           /* Console.Write("Enter a string: ");
            string input = Console.ReadLine().ToLower();

            char[] chars = input.ToCharArray();
            Array.Sort(chars);
            string sortedString = new string(chars);

            Console.WriteLine($"The string in alphabetical order is: {sortedString}");*/
        }

    }
}