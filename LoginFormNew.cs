using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using metalAssistor.HttpUtil;

namespace metalAssistor
{
    public partial class LoginFormNew : Form
    {
        public LoginFormNew()
        {
            InitializeComponent();
            m_aeroEnabled = false;
        }

        #region 窗体圆角的实现
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Normal)
            {
                //SetWindowRegion();
            }
            else
            {
                this.Region = null;
            }
        }

        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            FormPath = GetRoundedRectPath(rect,4);
            this.Region = new Region(FormPath);
        }

        /// <summary>  
        ///   
        /// </summary>  
        /// <param name="rect">窗体大小</param>  
        /// <param name="radius">圆角大小</param>  
        /// <returns></returns>  
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arcRect, 180, 90);//左上角  

            arcRect.X = rect.Right - diameter;//右上角  
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rect.Bottom - diameter;// 右下角  
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rect.Left;// 左下角  
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }
        #endregion 

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            ResultMode r=WebAPI.Login(textBoxX1.Text, textBoxX2.Text);
            if (r != null && r.Code == "200")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                labelTip.Visible = true;
                labelTip.Text = r.Msg;
            }
        }

        private void judianFormLabel1_ButtonClick(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        #region 窗口移动
        private Point mPoint = Point.Empty;
        private bool isMouseDown = false;
        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            //mPoint = new Point(e.X, e.Y);
            //isMouseDown = true;
        }
        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && isMouseDown && !mPoint.IsEmpty)
            //{
            //    this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            //}
        }
        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            //isMouseDown = false;
            //mPoint = Point.Empty;
        }
        #endregion

        #region 窗口阴影
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            if (m.Msg == 0x0112 && m.WParam.ToInt32() == 61490) 
                return;

            base.WndProc(ref m);

            //if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
            //    m.Result = (IntPtr)HTCAPTION;

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (m_aeroEnabled)
            {
                e.Graphics.Clear(Color.WhiteSmoke);
            }
        }
        #endregion

    }
}
