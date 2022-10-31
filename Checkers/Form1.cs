using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private float oldSizeWidth = 0;
        private float oldSizeHeight = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            this.oldSizeWidth = this.Size.Width;
            this.oldSizeHeight = this.Size.Height;

            GameSession.Start(this);
        }
        //not done yet
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show($"HII {this.Size.Width} / {oldSizeWidth} = {(this.Size.Width / oldSizeWidth)} \n" +
                $" {this.Size.Height} / {oldSizeHeight} = {(this.Size.Height / oldSizeHeight)} ");
            if(oldSizeHeight != 0 && oldSizeWidth != 0) 
                GameSession.SizeChanged( (this.Size.Width / oldSizeWidth), (this.Size.Height / oldSizeHeight) );
        }
    }
}
