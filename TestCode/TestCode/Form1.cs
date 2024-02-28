using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace TestCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //计算图像坐标X转换为世界坐标X
             txtWorldX.Text = ((Convert.ToDouble(txtResult_a.Text) * Convert.ToDouble(txtPicX.Text)) + (Convert.ToDouble(txtResult_b.Text) * Convert.ToDouble(txtPicY.Text)) + Convert.ToDouble(txtResult_c.Text)).ToString();
            //计算图像坐标Y转换为世界坐标Y
            txtWorldY.Text = ((Convert.ToDouble(txtResult_d.Text) * Convert.ToDouble(txtPicX.Text)) + (Convert.ToDouble(txtResult_e.Text) * Convert.ToDouble(txtPicY.Text)) + Convert.ToDouble(txtResult_f.Text)).ToString();
            
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            double[,] n =
            {
                { 2,2,3},
                { 4,5,6},
                { 7,8,9}
            };
            Matrix<double> m = Matrix<double>.Build.Dense(3, 3, 0.5);
            m.Inverse();
            //var p = DenseMatrix.OfArray(n);
            var p = Matrix.Build.DenseOfArray(n);
            //p = (DenseMatrix)p.Transpose();
            //p = (DenseMatrix)p.Inverse();
            richTextBox1.Text = m.ToString();
            richTextBox1.Text = p.ToString();

        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            //建立图像坐标矩阵
            double[,] P =
            {
                {Convert.ToDouble(txtP1_X.Text),Convert.ToDouble(txtP1_Y.Text),Convert.ToDouble(txtP1_Z.Text)},
                {Convert.ToDouble(txtP2_X.Text),Convert.ToDouble(txtP2_Y.Text),Convert.ToDouble(txtP2_Z.Text)},
                {Convert.ToDouble(txtP3_X.Text),Convert.ToDouble(txtP3_Y.Text),Convert.ToDouble(txtP3_Z.Text)},
                {Convert.ToDouble(txtP4_X.Text),Convert.ToDouble(txtP4_Y.Text),Convert.ToDouble(txtP4_Z.Text)},
                {Convert.ToDouble(txtP5_X.Text),Convert.ToDouble(txtP5_Y.Text),Convert.ToDouble(txtP5_Z.Text)},
                {Convert.ToDouble(txtP6_X.Text),Convert.ToDouble(txtP6_Y.Text),Convert.ToDouble(txtP6_Z.Text)},
                {Convert.ToDouble(txtP7_X.Text),Convert.ToDouble(txtP7_Y.Text),Convert.ToDouble(txtP7_Z.Text)},
                {Convert.ToDouble(txtP8_X.Text),Convert.ToDouble(txtP8_Y.Text),Convert.ToDouble(txtP8_Z.Text)},
                {Convert.ToDouble(txtP9_X.Text),Convert.ToDouble(txtP9_Y.Text),Convert.ToDouble(txtP9_Z.Text)}
            };
             Matrix<double> PMatrix = Matrix.Build.DenseOfArray(P);

            //建立机器手X坐标矩阵
            double[,] Wx =
           {
                {Convert.ToDouble(txtW1_X.Text)},
                {Convert.ToDouble(txtW2_X.Text)},
                {Convert.ToDouble(txtW3_X.Text)},
                {Convert.ToDouble(txtW4_X.Text)},
                {Convert.ToDouble(txtW5_X.Text)},
                {Convert.ToDouble(txtW6_X.Text)},
                {Convert.ToDouble(txtW7_X.Text)},
                {Convert.ToDouble(txtW8_X.Text)},
                {Convert.ToDouble(txtW9_X.Text)}
            };
            Matrix<double> WxMatrix = Matrix.Build.DenseOfArray(Wx);

            //建立机器手Y坐标矩阵
            double[,] Wy =
           {
                {Convert.ToDouble(txtW1_Y.Text)},
                {Convert.ToDouble(txtW2_Y.Text)},
                {Convert.ToDouble(txtW3_Y.Text)},
                {Convert.ToDouble(txtW4_Y.Text)},
                {Convert.ToDouble(txtW5_Y.Text)},
                {Convert.ToDouble(txtW6_Y.Text)},
                {Convert.ToDouble(txtW7_Y.Text)},
                {Convert.ToDouble(txtW8_Y.Text)},
                {Convert.ToDouble(txtW9_Y.Text)}
            };
            Matrix<double> WyMatrix = Matrix.Build.DenseOfArray(Wy);

            //计算abc系数
            Matrix<double> abcMatrix = MatrixClass.Demarcate(PMatrix, WxMatrix);
            //计算def系数
            Matrix<double> defMatrix = MatrixClass.Demarcate(PMatrix, WyMatrix);

            //显示输出信息
            richTextBox1.AppendText("输入的图像坐标矩阵为：\n"+PMatrix.ToString());
            richTextBox1.AppendText("输入的机械手X坐标矩阵为：\n"+WxMatrix.ToString());
            richTextBox1.AppendText("输入的机械手Y坐标矩阵为：\n" + WyMatrix.ToString());
            richTextBox1.AppendText("输入的abc系数坐标矩阵为：\n" + abcMatrix.ToString());
            richTextBox1.AppendText("输入的def系数坐标矩阵为：\n" + defMatrix.ToString());

            //将abcdef值显示到控件上
            txtResult_a.Text = abcMatrix[0, 0].ToString();
            txtResult_b.Text = abcMatrix[1, 0].ToString();
            txtResult_c.Text = abcMatrix[2, 0].ToString();
            txtResult_d.Text = defMatrix[0, 0].ToString();
            txtResult_e.Text = defMatrix[1, 0].ToString();
            txtResult_f.Text = defMatrix[2, 0].ToString();
        }
    }
}
