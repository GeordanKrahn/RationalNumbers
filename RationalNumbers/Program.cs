// See https://aka.ms/new-console-template for more information
using static System.Console;
using RationalNumbers; // Make sure to link the file


// The following lines are all tests for the Fraction class.
Fraction fraction = new(1, 5), fraction2 = new(36, 60);
WriteLine(fraction);
WriteLine(fraction2);
Fraction fraction3 = fraction2.Simplified();
WriteLine(fraction3);
WriteLine(fraction3.Float);
WriteLine(fraction2.Double);
Fraction fraction4 = new(1, 3), fraction5 = new(5, 2);
Fraction fraction6 = fraction4 + fraction5;
Fraction fraction7 = fraction4 - fraction5;
Fraction fraction8 = fraction5 - fraction4;
WriteLine(fraction6);
WriteLine(fraction7);
WriteLine(fraction8);
Fraction fraction9 = fraction5 * fraction4;
Fraction fraction10 = fraction5 / fraction4;
WriteLine(fraction9);
WriteLine(fraction10);
WriteLine(-fraction);