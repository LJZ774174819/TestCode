using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;


namespace TestCode
{
    class MatrixClass
    {
        public static Matrix<double> Demarcate(Matrix<double> P, Matrix<double> W)
        {
            Matrix<double> DMatrix = ((P.Transpose() * P).Inverse()) * P.Transpose() * W;
            return DMatrix;
        }


    }
}
