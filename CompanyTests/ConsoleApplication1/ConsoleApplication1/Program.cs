using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class c1 { 
struct CarA
{
    public CarA(int wheels)
    {
        Wheels = wheels;
    }

    public int Wheels { get; private set; }
}

struct CarB
{
    public CarB(int wheels) : this()
    {
        Wheels = wheels;
    }

    public int Wheels { get; private set; }
}

public static void Main(string[] args)
    {

        Func<int, int> f1 = (int x) => x * 2;
        Func<int, int> f2 = (x) => { return x * 2; };
        var m = Math.;

        Console.ReadLine();
    }
}
