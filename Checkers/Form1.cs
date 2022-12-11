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

        private int oldSizeWidth = 0;
        private int oldSizeHeight = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            this.oldSizeWidth = this.Size.Width;
            this.oldSizeHeight = this.Size.Height;

            GameSession.Start(this);
        }
        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (oldSizeHeight != 0 && oldSizeWidth != 0)
            {
                if (this.Size.Width < SettingsManger.boardSize || this.Size.Height < SettingsManger.boardSize)
                {
                    MessageBox.Show("Error: Cannot resize below the board's size", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Size = new Size(800, 553);
                    this.CenterToScreen();
                }
                else
                {
                    GameSession.SizeChanged(this.Size.Width, this.Size.Height);
                    oldSizeHeight = this.Size.Height;
                    oldSizeWidth = this.Size.Width;
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
