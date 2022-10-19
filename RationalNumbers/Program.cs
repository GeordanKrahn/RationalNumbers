// See https://aka.ms/new-console-template for more information
using static System.Console;
using RationalNumbers; // Make sure to link the namespace0


// The following lines are all tests for the Fraction class.
Fraction fraction = new(6, 12), fraction2 = new(36, 60);
Fraction fraction3 = fraction.Simplified();
WriteLine(fraction);
WriteLine(fraction3);
Fraction a = new(1, 3), b = new(-2 , 3);
Fraction c = a + b;
Fraction d = a - b;
Fraction e = b - a;
Fraction f = a * b;
Fraction g = a / b;
WriteLine(a);
WriteLine(b);
WriteLine(c);
WriteLine(d);
WriteLine(e);
WriteLine(f);
WriteLine(g);
g.Invert();
WriteLine(g);
Fraction h = new();
if(g.Inverted(g, out h))
{
    WriteLine(h);
}
