using System;
using static System.Math;

       
Console.WriteLine("Write 3 numbers ");
double x = double.Parse(Console.ReadLine());
double y = double.Parse(Console.ReadLine());
double z = double.Parse(Console.ReadLine());
double a=0;
double b=0;
if( Pow(x,3)+5*Pow(y,-z)+Pow(z,2) >= 0 || a!=0 || y+z/a!=0 || x+(a/(y+z/a))!=0)
{
    a = Sqrt(Pow(x,3)+5*Pow(y,-z)+Pow(z,2)) - Pow(Abs(Sin(x)-Cos(y)),1/3);
    b = a/(x+(a/(y+z/a)));
    Console.WriteLine("a:{0}", a);
    Console.WriteLine("b:{0}", b);

}
else
{
    Console.WriteLine("Doesn`t correspond to ODZ!");
}
        