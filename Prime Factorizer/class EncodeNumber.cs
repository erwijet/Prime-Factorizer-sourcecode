//simple libs

using System;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Da Encoder
/// </summary>
class EncodeNumber
{
    //nil constructor
    public EncodeNumber()
    {
    }

    //this is where the magic happens
    public int[] encodeNumber(int n)
    {
        if (n <= 1)
            return null;
        //int num = 1;  
        int nnew = n;
        List<int> arr = new List<int>();

        while (nnew > 1)
        {
            //num = 1;  
            for (int i = 2; i <= nnew; i++)
            {
                if (nnew % i == 0 && isPrime(i))
                {
                    arr.Add(i);
                    //num = num * i;  
                    nnew = nnew / i;
                    break;
                }

            }
            //nnew = nnew / num;  
        }
        return arr.ToArray();
    }

    //archived, use in update?
    public Boolean isPrime(int x)
    {
        bool status = true;
        for (int i = 2; i <= x / 2; i++)
        {
            if (x % i == 0)
            {
                status = false;
                break;
            }
        }
        return status;
    }
}