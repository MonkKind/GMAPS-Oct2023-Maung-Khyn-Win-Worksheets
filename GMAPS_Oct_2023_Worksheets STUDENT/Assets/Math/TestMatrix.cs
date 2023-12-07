using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D(new float[,]
       {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
       });

        HMatrix2D mat2 = new HMatrix2D(new float[,]
        {
            { 9, 8, 7 },
            { 6, 5, 4 },
            { 3, 2, 1 }
        });

        HMatrix2D resultMat;
        resultMat = mat1 * mat2;
        resultMat.Print();

        HVector2D vec1 = new HVector2D(1, 2);
        HVector2D resultVec = mat1 * vec1;
        //resultVec.Print();
    } 
    void Start()
    {
        //mat.SetIdentity();
        //mat.Print();
        //Question2();  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
