using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        internal class ImageBox : ScrollableControl
        {
            private Color m_ColorCoordinate;
            private PointF[] m_Points;
            private float m_Scale;
            private SizeF m_ImageSize;
            public int people;
            public int[] x;
            public int[] y;
            public int middle_x;
            public int middle_y;
            /// <summary>
                /// 构造函数
                /// </summary>
            public ImageBox(int people, int[] x, int[] y, int middle_x, int middle_y)
            {
                this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
                m_ColorCoordinate = Color.Red;
                this.m_Scale = 1;
                this.people = people;
                this.x = x;
                this.y = y;
                this.middle_x = middle_x;
                this.middle_y = middle_y;

            }
            /// <summary>
                /// 画布的大小
                /// </summary>
            
            public SizeF ImageSize
            {
                get
                {
                    return m_ImageSize;
                }
                set
                {
                    this.m_ImageSize = value;
                    this.AutoScrollMinSize = Size.Ceiling(new SizeF(this.m_ImageSize.Width * this.m_Scale, this.m_ImageSize.Height * this.m_Scale));
                }
            }
            /// <summary>
                /// 坐标系的X,Y两轴的颜色
                /// </summary>
            public Color ColorCoordinate
            {
                get
                {
                    return this.m_ColorCoordinate;
                }
                set
                {
                    this.m_ColorCoordinate = value;
                    this.Invalidate(this.ClientRectangle, false);
                }
            }
            /// <summary>
                /// 重写以进行绘制
                /// </summary>
                /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                this.drawMathImage(e.Graphics, this.getStartPoint(), this.m_Scale);
            }
            /// <summary>
                /// 得到Sin函数值坐标点
                /// </summary>
                /// <returns></returns>
            public void DrawSin()
            {
                List<PointF> list = new List<PointF>();
                for (int i = -100 * (int)Math.PI; i < 100 * (int)Math.PI; i++)
                {
                    float x = i / 100.0f;
                    float y = (float)Math.Sin((double)x);
                    list.Add(new PointF(x * 100, y * 100));
                }
                m_Points = list.ToArray();
                this.Invalidate();
            }
            /// <summary>
                /// 得到抛物线函数值坐标点
                /// </summary>
                /// <returns></returns>
            public void DrawPow()
            {
                List<PointF> list = new List<PointF>();
                for (int i = -100; i < (int)100; i++)
                {
                    float x = i / 100f;
                    float y = (float)Math.Pow((double)x, 2);
                    list.Add(new PointF(x * 100, y * 100));
                }
                m_Points = list.ToArray();
                this.Invalidate();
            }
            public void ClearFunImage()
            {
                this.m_Points = null;
                this.Invalidate();
            }
            /// <summary>
                /// 放大图像的倍数
                /// </summary>
                /// <param name="scale"></param>
            public void ScaleImage(float scale)
            {
                float tmp = scale;
                if (tmp > 0)
                {
                    this.m_Scale = tmp;
                    SizeF size = new SizeF(this.m_ImageSize.Width * this.m_Scale, this.m_ImageSize.Height * this.m_Scale);

                    base.AutoScrollMinSize = Size.Ceiling(size);
                    this.Invalidate();
                }
            }
            /// <summary>
                /// 由当前的滚动信息得到开始点以用来计算绘图原点信息
                /// </summary>
                /// <returns></returns>
            private PointF getStartPoint()
            {
                SizeF size = new SizeF(this.m_ImageSize.Width * this.m_Scale, this.m_ImageSize.Height * this.m_Scale);
                PointF point = this.AutoScrollPosition;

                if (size.Width > this.ClientRectangle.Width && size.Height < this.ClientRectangle.Height)
                {
                    point.Y += (this.ClientRectangle.Height - size.Height) / 2.0f;
                }
                else if (size.Width < this.ClientRectangle.Width && size.Height > this.ClientRectangle.Height)
                {
                    point.X += (this.ClientRectangle.Width - size.Width) / 2.0f;
                }
                else if (size.Width <= this.ClientRectangle.Width && size.Height <= this.ClientRectangle.Height)
                {
                    point.Y += (this.ClientRectangle.Height - size.Height) / 2.0f;
                    point.X += (this.ClientRectangle.Width - size.Width) / 2.0f;
                }
                return point;
            }
            /// <summary>
                /// 使用指定的Graphics对象进行绘图
                /// </summary>
                /// <param name="g">用来绘图的Graphics对象</param>
                /// <param name="startPoint">绘图的时候坐标的偏移量</param>
            private void drawMathImage(Graphics g, PointF start, float scale)
            {
                //建立坐标中点坐标
                float tmpOX = this.AutoScrollMinSize.Width / 2.0f;
                float tmpOY = this.AutoScrollMinSize.Height / 2.0f;

                GraphicsState state = g.Save();
                using (Matrix matrix = new Matrix(1, 0, 0, -1, 0, 0))
                {
                    g.Transform = matrix;
                    g.PageUnit = GraphicsUnit.Pixel;
                    g.TranslateTransform(tmpOX + start.X, -tmpOY - start.Y, MatrixOrder.Prepend);
                    g.ScaleTransform(this.m_Scale, this.m_Scale, MatrixOrder.Prepend);

                    float maxX = tmpOX / scale;
                    float maxY = tmpOY / scale;

                    //绘制坐标轴线
                    using (Pen pen = new Pen(this.m_ColorCoordinate, 1))
                    {
                        g.DrawLine(pen, -maxX, 0.0f, maxX, 0.0f);
                        g.DrawLine(pen, 0.0f, -maxY, 0.0f, maxY);

                        g.DrawLine(pen, maxX, 0.0f, maxX - 2.0f, 2.0f);
                        g.DrawLine(pen, maxX, 0.0f, maxX - 2.0f, -2.0f);

                        g.DrawLine(pen, 0.0f, maxY, 2.0f, maxY - 2.0f);
                        g.DrawLine(pen, 0.0f, maxY, -2.0f, maxY - 2.0f);
                    }

                    Font star_Font = new Font("Arial", 20, FontStyle.Regular);//设置星号的字体样式
                    int circularity_W = 1; //画笔的粗细
                    Pen myPen = new Pen(Color.Red, circularity_W);
                    for (int i=0; i<x.Length; i++)
                    {
                        //绘制居民位置
                        string star_Str = "*";  //星星
                        g.DrawString(star_Str, star_Font, myPen.Brush, new PointF(x[i], y[i]));
                    }

                    //绘制超市位置
                    star_Font = new Font("Arial", 20, FontStyle.Regular);//设置星号的字体样式
                    myPen = new Pen(Color.Blue, circularity_W);
                    g.DrawString("$", star_Font, myPen.Brush, new PointF(middle_x, middle_y));

                }
                g.Restore(state);
            }
            /// <summary>
                /// 重写以切换Sin,Pow函数图像进行绘图测试
                /// </summary>
                /// <param name="e"></param>
            protected override void OnMouseDown(MouseEventArgs e)
            {
                base.OnMouseDown(e);
                if (e.Button == MouseButtons.Right)
                {
                    this.ClearFunImage();
                    return;
                }
                switch (e.Clicks)
                {
                    case 1:
                        this.DrawSin();
                        break;
                    case 2:
                        this.DrawPow();
                        break;
                }
            }
            protected override bool ProcessDialogKey(Keys keyData)
            {
                if (keyData == Keys.Add)
                {
                    this.ScaleImage(this.m_Scale + this.m_Scale * 0.02f);
                }
                else if (keyData == Keys.Subtract)
                {
                    this.ScaleImage(this.m_Scale - this.m_Scale * 0.02f);
                }
                return base.ProcessDialogKey(keyData);
            }
        }
        
        


        public Form2()
        {
            InitializeComponent();

            //计算点的坐标
            
            Random ro = new Random();
           
            int people = ro.Next(15, 30);
            int[] x = new int[people];
            int[] y = new int[people];
            int temp = 0;
            int middle_x = 0, middle_y = 0;
            int x_length = 0, y_length = 0;
            for(int i=0; i<people; i++)
            {
                x[i] = ro.Next(-250, 250);
                y[i] = ro.Next(-250, 250);
            }
            for (int i = 0; i < people - 1; i++)
            {
                for (int j = people - 1; j > i; j--)
                {
                    if (x[i] > x[j])
                    {
                        temp = x[i];
                        x[i] = x[j];
                        x[j] = temp;
                    }
                    if (y[i] > y[j])
                    {
                        temp = y[i];
                        y[i] = y[j];
                        y[j] = temp;
                    }
                }
            }
            if (people % 2 == 0)
            {
                middle_x = (x[people / 2] + x[people / 2 - 1]) / 2;
                middle_y = (y[people / 2] + y[people / 2 - 1]) / 2;
            }
            else
            {
                middle_x = x[(people - 1) / 2];
                middle_y = y[(people - 1) / 2];
            }
            for (int i = 0; i < people; i++)
            {
                if (x[i] > middle_x)
                {
                    x_length += x[i] - middle_x;
                }
                else
                {
                    x_length += middle_x - x[i];
                }
                if (y[i] > middle_y)
                {
                    y_length += y[i] - middle_y;
                }
                else
                {
                    y_length += middle_y - y[i];
                }
            }
            //this.textBox1.Text = (x_length + y_length).ToString();

            //画图
            ImageBox box = new ImageBox(people, x, y, middle_x, middle_y);
            box.Dock = DockStyle.Fill;
            box.ImageSize = new Size(900, 800);
            this.Controls.Add(box);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
