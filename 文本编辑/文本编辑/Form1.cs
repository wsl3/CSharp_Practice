using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using note2;
namespace note
{
    public partial class Form1 : Form
    {
        public int a = 0;
        public int i = -1;
        public int k = 0;
        public int j = 0;
        public int b = 0;
        public int c = 0;
        public int d = 0;
        public int f = 0;
        public string rtb = "";
        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;      //定时器的可见性
            timer1.Interval = 1000;     //定时器的时间间隔设置为1000ms
            this.toolStripStatusLabel1.Text = "系统当前时间：" + DateTime.Now.ToString();
            this.toolStripStatusLabel2.Text = "行:1 , 列:1";

            this.toolStripMenuItem18.Enabled = false;
            this.toolStripMenuItem19.Enabled = false;
            this.toolStripMenuItem20.Enabled = false;
            this.toolStripMenuItem21.Enabled = false;
        }
        [System.Runtime.InteropServices.DllImport("User32.DLL")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int iParam);
        private const int EM_LINEFROMCHAR = 0xC9;
        private const int EM_LINEINDEX = 0xBB;
        private Point GetCursorPos(RichTextBox richtextBox)
        {
            Point cursorPos = new Point(0, 0);
            int x, y;
            y = SendMessage(richtextBox.Handle, EM_LINEFROMCHAR, richtextBox.SelectionStart, 0);
            x = richtextBox.SelectionStart - SendMessage(richtextBox.Handle, EM_LINEINDEX, y, 0);
            cursorPos.Y = ++y;
            cursorPos.X = ++x;
            return cursorPos;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //自动换行
            toolStripMenuItem24.Checked = false;
            d = 1;
            saveFileDialog1.FileName = "*.txt";
            openFileDialog1.FileName = "*.txt";
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)    //关闭窗口弹出对话框，在Form1的事件中加入FormClosing事件。
        {
            DialogResult result;
            try
            {
                if (rtb != richTextBox1.Text)
                {
                    result = MessageBox.Show("文件 " + this.Text + " 的文字已经改变。\r\n\r\n想保存文件吗？", "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        if (saveFileDialog1.ShowDialog() == DialogResult.Yes)
                        {
                            richTextBox1.SaveFile(saveFileDialog1.FileName.ToString(), RichTextBoxStreamType.PlainText);
                            richTextBox1.Text = "";
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        this.Dispose();
                    }
                    else
                        e.Cancel = true;
                }
            }
            catch { }
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text + DateTime.Now.ToString();
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Point currentPos = GetCursorPos(this.richTextBox1);
            this.toolStripStatusLabel2.Text = "行:" + currentPos.Y + ", 列:" + currentPos.X;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.toolStripStatusLabel1.Text = "系统当前时间：" + DateTime.Now.ToString();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
        // 文件-打印
        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            try
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch
            {
                MessageBox.Show("未安装打印机！");
            }
        }

        //文件-退出
        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 文件-新建
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "*.txt";
            openFileDialog1.FileName = "*.txt";
            DialogResult result;
            try
            {
                if (rtb != richTextBox1.Text)
                {
                    result = MessageBox.Show("文件 " + this.Text + " 的文字已经改变。\r\n\r\n想保存文件吗？", "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        saveFileDialog1.ShowDialog();
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        richTextBox1.Text = "";
                        rtb = richTextBox1.Text;
                    }
                    else if (result == DialogResult.No)
                    {
                        richTextBox1.Text = "";
                        rtb = richTextBox1.Text;
                    }
                }
                else
                {
                    richTextBox1.Text = "";
                    rtb = richTextBox1.Text;
                    this.Text = "无标题－记事本";
                    //剪切 复制
                    toolStripMenuItem14.Enabled = false;
                    toolStripMenuItem15.Enabled = false;
                    toolStripMenuItem17.Enabled = false;
                    toolStripMenuItem18.Enabled = false;
                    toolStripMenuItem19.Enabled = false;
                }
            }
            catch { }
        }

        //文件-打开
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            DialogResult result;
            try
            {
                if (rtb != richTextBox1.Text)
                {
                    result = MessageBox.Show("文件 " + this.Text + " 的文字已经改变。\r\n\r\n想保存文件吗？", "记事本", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        saveFileDialog1.ShowDialog();
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        openFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        openFileDialog1.ShowDialog();
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        rtb = richTextBox1.Text;
                    }
                    else if (result == DialogResult.No)
                    {
                        openFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        openFileDialog1.ShowDialog();
                        richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        rtb = richTextBox1.Text;
                    }
                }
                else
                {
                    openFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                    openFileDialog1.ShowDialog();
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    rtb = richTextBox1.Text;
                }
                this.Text = Path.GetFileName(openFileDialog1.FileName) + "- 记事本";
                saveFileDialog1.FileName = openFileDialog1.FileName;
                //撤销
                toolStripMenuItem13.Enabled = false;
            }
            catch { }
        }

        //文件-保存
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "无标题－记事本")
                {
                    if (d == 1)
                    {
                        saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                        saveFileDialog1.ShowDialog();
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        this.Text = Path.GetFileName(saveFileDialog1.FileName) + "- 记事本";
                    }
                }
                else
                {
                    saveFileDialog1.Filter = @"|*.txt;*.cs";
                    if (this.Text == Path.GetFileName(openFileDialog1.FileName) + "- 记事本")
                        richTextBox1.SaveFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    else
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
                rtb = richTextBox1.Text;
            }
            catch { }
        }
        //文件-另存为
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                if (d == 1)
                {
                    saveFileDialog1.Filter = @"文本文档(*.txt)|*.txt|所有格式|*.txt;*.doc;*.cs;*.rtf;*.sln";
                    saveFileDialog1.ShowDialog();
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = Path.GetFileName(saveFileDialog1.FileName) + "- 记事本";
                    rtb = richTextBox1.Text;
                }
            }
            catch { }
        }
        //文件-页面设置
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                pageSetupDialog1.Document = printDocument1;
                pageSetupDialog1.Document.DefaultPageSettings.Color = false;
                this.pageSetupDialog1.ShowDialog();
            }
            catch { }
        }
        //复制
        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        //状态栏
        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            if (k == -1)
            {
                statusStrip1.Show();
                toolStripMenuItem26.Checked = true;
                k = 0;
            }
            else
            {
                statusStrip1.Hide();
                toolStripMenuItem26.Checked = false;
                k = -1;
            }
        }
        //编辑-撤销
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (a == 0)
            {
                richTextBox1.Undo();
                a = 1;
            }
            else if (a == 1)
            {
                richTextBox1.Redo();
                a = 0;
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        //查找
        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            //Form2 f2 = new Form2();
            //f2.f1 = this;
            //f2.Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {

            //Form2 f2 = new Form2();
            //f2.Show();
            //f2.f1 = this;

        }
        //替换
        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            //Form3 f3 = new Form3();
            //f3.Show();
            //f3.f1 = this;
        }
        //转到
        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            //Form5 f5 = new Form5();
            //f5.LineNumber = SendMessage(this.richTextBox1.Handle, EM_LINEFROMCHAR, this.richTextBox1.SelectionStart, 0) + 1;
            /*if ((f5.ShowDialog() == DialogResult.OK) && (f5.LineNumber < this.richTextBox1.Lines.Length))
            {
                this.richTextBox1.SelectionLength = 0;
                this.richTextBox1.SelectionStart = SendMessage(this.richTextBox1.Handle, EM_LINEINDEX, f5.LineNumber - 1, 0);
                this.richTextBox1.Focus();
                Point cursorPos = GetCursorPos(this.richTextBox1);
                this.toolStripStatusLabel2.Text = "行：" + cursorPos.Y.ToString() + " 列：" + cursorPos.X.ToString();
            }*/
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = DateTime.Now.ToString();
        }
        //自动换行
        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
              if (j == 0)
              {
                  toolStripMenuItem21.Enabled = false;
                  if (toolStripMenuItem26.Checked == true)
                  {
                      statusStrip1.Hide();
                      toolStripMenuItem26.Checked = false;
                      toolStripMenuItem24.Checked = true;
                      toolStripMenuItem26.Enabled = false;
                      richTextBox1.WordWrap = true;
                      b = 1;
                  }
                  else
                  {
                      richTextBox1.WordWrap = true;
                      toolStripMenuItem24.Checked = true;
                      toolStripMenuItem26.Enabled = false;
                  }
                  j = -1;
              }
              else
              {
                  toolStripMenuItem21.Enabled = true;
                  if (b == 1)
                  {
                      statusStrip1.Show();
                      toolStripMenuItem26.Checked = true;
                      richTextBox1.WordWrap = false;
                      toolStripMenuItem26.Enabled = true;
                      toolStripMenuItem24.Checked = false;
                      b = 0;
                  }
                  else
                  {
                      toolStripMenuItem24.Checked = false;
                      toolStripMenuItem26.Enabled = true;
                      richTextBox1.WordWrap = false;
                  }
                  j = 0;
              }
        }
        //字体
        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionFont = fontDialog1.Font;
                }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }
    }
}
