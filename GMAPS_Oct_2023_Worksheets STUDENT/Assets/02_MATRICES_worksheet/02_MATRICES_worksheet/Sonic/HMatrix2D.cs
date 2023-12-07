using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class HMatrix2D
{
    private float v1;
    private float v2;

    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        // your code here
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < multiArray.GetLength(0); y++)
        {
            for (int x = 0; x < multiArray.GetLength(1); x++)
            {
                Entries[y, x] = multiArray[y, x];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        Entries = new float[3, 3];
        // First row
        Entries[0, 0] = m00;
        Entries[0, 1] = m01;
        Entries[0, 2] = m02;

        // Second row
        Entries[1, 0] = m10;
        Entries[1, 1] = m11;
        Entries[1, 2] = m12;

        // Third row
        Entries[2, 0] = m20;
        Entries[2, 1] = m21;
        Entries[2, 2] = m22;
    }

    public HMatrix2D(float v1, float v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D(left.v1, right.v2);
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D(left.v1, right.v2);
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        return new HMatrix2D(left.v1, scalar);
    }

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
            (
                left.Entries[0, 0] * right.x + left.Entries[0, 1] * right.y,
                left.Entries[1, 0] * right.x + left.Entries[1, 1] * right.y
            );
    }

    //// Note that the second argument is a HMatrix2D object
    ////
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
                */
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],


            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            //Second Row
            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],


            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],


            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],

            //Third Row
            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],


            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],


            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
    );
    }

    //This checks every row and column for matching pairs within the matrix. If it finds a single pair that does not match, it returns false and says
    //the matrices are not equal. If all the pairs match, it returns true to say the matrices are equal
    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int i = 0; i < left.Entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.Entries.GetLength(1); j++)
            {
                if (left.Entries[i, j] != right.Entries[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    //This does the opposite of above
    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int i = 0; i < left.Entries.Length; i++)
        {
            for (int j = 0; j < left.Entries[i, j]; j++)
            {
                if (left.Entries[i, j] != right.Entries[i, j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    //public override bool Equals(object obj)
    //{
    //    // your code here
    //}

    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    //public HMatrix2D Transpose()
    //{
    //    return // your code here
    //}

    //public float GetDeterminant()
    //{
    //    return // your code here
    //}

    public void SetIdentity()
    {
        //for (int y = 0; y < Entries.GetLength(0); y++)
        //{
        //    for (int x = 0; x < Entries.GetLength(1); x++)
        //    {
        //        if (x == y)
        //        {
        //            Entries[y, x] = 1;
        //        }
        //        else
        //        {
        //            Entries[y, x] = 0;
        //        }
        //    }
        //}

        //Checks to see if x == y, if yes, sets to 1, if not, sets to 0.
        for (int y = 0; y < Entries.GetLength(0); y++)
        {
            for (int x = 0; x < Entries.GetLength(1); x++)
            {
                Entries[y, x] = (x == y) ? 1 : 0;
            }
        }
    }


    public void setTranslationMat(float transX, float transY)
    {
        SetIdentity();
        Entries[0,2] = transX;
        Entries[1,2] = transY;
    }

    public void setRotationMat(float rotDeg)
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        Entries[0, 0] = cos;
        Entries[0, 1] = -sin;
        Entries[0, 2] = sin;
        Entries[0, 3] = cos;
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
