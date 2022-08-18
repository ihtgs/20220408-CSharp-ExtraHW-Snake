
namespace HW_extra_snake
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.txtUp = new System.Windows.Forms.TextBox();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tag = "snakeA";
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tag = "snakeB";
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1300;
            this.timer3.Tag = "Item";
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Enabled = true;
            this.timer4.Interval = 250;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // txtUp
            // 
            this.txtUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtUp.Location = new System.Drawing.Point(0, 0);
            this.txtUp.Name = "txtUp";
            this.txtUp.ReadOnly = true;
            this.txtUp.Size = new System.Drawing.Size(1113, 22);
            this.txtUp.TabIndex = 0;
            this.txtUp.TabStop = false;
            this.txtUp.Text = "(Player1) 上：W    下：S    左：A    右：D              (Player2)上：I    下：K    左：J    右：L" +
    "  ";
            this.txtUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDown
            // 
            this.txtDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDown.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDown.Location = new System.Drawing.Point(0, 490);
            this.txtDown.Name = "txtDown";
            this.txtDown.ReadOnly = true;
            this.txtDown.Size = new System.Drawing.Size(1113, 32);
            this.txtDown.TabIndex = 1;
            this.txtDown.TabStop = false;
            this.txtDown.Text = "暫時沒事可以寫";
            this.txtDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLeft
            // 
            this.txtLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtLeft.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtLeft.Location = new System.Drawing.Point(0, 22);
            this.txtLeft.Multiline = true;
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.ReadOnly = true;
            this.txtLeft.Size = new System.Drawing.Size(24, 468);
            this.txtLeft.TabIndex = 2;
            this.txtLeft.TabStop = false;
            this.txtLeft.Text = "操作鍵盤控制移動方向，這是螢幕保護程式";
            this.txtLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRight
            // 
            this.txtRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtRight.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRight.Location = new System.Drawing.Point(1089, 22);
            this.txtRight.Multiline = true;
            this.txtRight.Name = "txtRight";
            this.txtRight.ReadOnly = true;
            this.txtRight.Size = new System.Drawing.Size(24, 468);
            this.txtRight.TabIndex = 3;
            this.txtRight.TabStop = false;
            this.txtRight.Text = "移動滑鼠回到視窗畫面，這是螢幕保護程式";
            this.txtRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1113, 522);
            this.Controls.Add(this.txtRight);
            this.Controls.Add(this.txtLeft);
            this.Controls.Add(this.txtDown);
            this.Controls.Add(this.txtUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "轟";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.TextBox txtUp;
        private System.Windows.Forms.TextBox txtDown;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.TextBox txtRight;
    }
}

