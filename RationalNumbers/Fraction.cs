using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers
{
    /// <summary>
    /// Represents Rational number Maths
    /// </summary>
    public class Fraction
    {
        /// <summary>
        /// Top value
        /// </summary>
        public int Numerator { get; private set; }

        /// <summary>
        /// Bottom value. Cannot be Zero.
        /// </summary>
        public int Denominator { get; private set; }

        /// <summary>
        /// float type representation of this Fraction
        /// </summary>
        public float Float
        {
            get
            {
                return Numerator / (float)Denominator;
            }
        }

        /// <summary>
        /// double type representation of this Fraction
        /// </summary>
        public double Double
        {
            get
            {
                return Numerator / (double)Denominator;
            }
        }

        /// <summary>
        /// Creates an instance set to (1/1)
        /// </summary>
        public Fraction() : this(1, 1) { }

        /// <summary>
        /// Sets the Numerator to 1 | Sets the Denominator to the specified value.
        /// </summary>
        /// <param name="denominator">Bottom value to set.</param>
        public Fraction(int denominator) : this(1, denominator) { }

        /// <summary>
        /// Sets the Numerator to the specified value | Sets the Denominator to the specified value.
        /// </summary>
        /// <param name="numerator">Top value to set.</param>
        /// <param name="denominator">Bottom value to set.</param>
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            try
            {
                if (denominator == 0)
                {
                    throw new Exception("Denominator Cannot be ZERO, Undefined");
                }
                Denominator = denominator;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Denominator = 1;
            }
        }

        /// <summary>
        /// Constructor takes another fraction as its argument
        /// </summary>
        /// <param name="f">Fraction to copy</param>
        public Fraction(Fraction f) : this(f.Numerator, f.Denominator) { }

        /// <summary>
        /// Switches the Denominator and Numerator
        /// </summary>
        /// <param name="success">If this fails, a division by Zero occured.</param>
        /// <returns>a new fraction with the values switched.</returns>
        public Fraction Inverted(out bool success)
        {
            success = Numerator != 0;
            return success ? new(Denominator, Numerator) : new(-1, 1);
        }

        /// <summary>
        /// Reduces the fraction, if possible.
        /// </summary>
        /// <returns>new reduced Fraction</returns>
        public Fraction Simplified()
        {
            int gcf = GreatestCommonFactor();
            return new(Numerator / gcf, Denominator / gcf);
        }

        /// <summary>
        /// Switches the Denominator and Numerator for THIS fraction
        /// If the Numerator is Zero, this inversion will abort.
        /// </summary>
        public void Invert()
        {

        }

        /// <summary>
        /// Reduces THIS fraction, if possible
        /// </summary>
        public void Simplify()
        {

        }

        /// <returns>Greatest Common Factor (as Integer) between Numerator and Denominator</returns>
        public int GreatestCommonFactor()
        {
            return GreatestCommonFactor(Numerator, Denominator);
        }

        /// <summary>
        /// Finds the GCF between 2 integer values.
        /// </summary>
        /// <param name="a">arg 1</param>
        /// <param name="b">arg 2</param>
        /// <returns>Integer</returns>
        public static int GreatestCommonFactor(int a, int b)
        {
            List<int> aFactors = new(), bFactors = new();
            int GCF = 1;
            for (int i = (int)(a / 2.0f); i > 0; i--)
            {
                if (a % i == 0)
                {
                    aFactors.Add(i);
                }
            }
            for (int i = (int)(b / 2.0f); i > 0; i--)
            {
                if (b % i == 0)
                {
                    bFactors.Add(i);
                }
            }

            // compare each element with each other. 
            // if the values at each index match
            // AND its greater than the current GCF, then overwrite GCF
            for (int i = 0; i < aFactors.Count; i++)
            {
                for (int j = 0; j < bFactors.Count; j++)
                {
                    if (aFactors[i] == bFactors[j])
                    {
                        GCF = aFactors[i] > GCF ? aFactors[i] : GCF;
                    }
                }
            }
            return GCF;
        }

        /// <summary>
        /// Adds 2 fractions
        /// </summary>
        /// <param name="a">arg 1</param>
        /// <param name="b">arg 2</param>
        /// <returns>Fraction</returns>
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction aP = new(b.Denominator * a.Numerator, b.Denominator * a.Denominator),
                        bP = new(a.Denominator * b.Numerator, a.Denominator * b.Denominator);

            return new(aP.Numerator + bP.Numerator, aP.Denominator);
        }

        /// <summary>
        /// Subtracts 2 fractions
        /// </summary>
        /// <param name="a">arg 1</param>
        /// <param name="b">arg 2</param>
        /// <returns>Fraction</returns>
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction aP = new(b.Denominator * a.Numerator, b.Denominator * a.Denominator),
                        bP = new(a.Denominator * b.Numerator, a.Denominator * b.Denominator);

            return new(aP.Numerator - bP.Numerator, aP.Denominator);
        }

        /// <summary>
        /// Negates the Fraction
        /// </summary>
        /// <param name="a">arg 1</param>
        /// <param name="b">arg 2</param>
        /// <returns>Fraction</returns>
        public static Fraction operator -(Fraction a)
        {
            return new(-a.Numerator, a.Denominator);
        }

        /// <summary>
        /// Multiplies 2 fractions
        /// </summary>
        /// <param name="a">arg 1</param>
        /// <param name="b">arg 2</param>
        /// <returns>Fraction</returns>
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        /// <summary>
        /// Divides 2 fractions
        /// </summary>
        /// <param name="a">arg 1</param>
        /// <param name="b">arg 2</param>
        /// <returns>Fraction</returns>
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        /// <summary>
        /// String representation of a fraction
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"({Numerator}/{Denominator})";
        }
    }
}
