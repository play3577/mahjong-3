﻿namespace Mahjong.Forms
{
    partial class Config
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.BackgroundColor = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button_setup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel_color = new System.Windows.Forms.Panel();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // BackgroundColor
            // 
            this.BackgroundColor.AutoSize = true;
            this.BackgroundColor.Location = new System.Drawing.Point(12, 9);
            this.BackgroundColor.Name = "BackgroundColor";
            this.BackgroundColor.Size = new System.Drawing.Size(53, 12);
            this.BackgroundColor.TabIndex = 0;
            this.BackgroundColor.Text = "設定速度";
            // 
            // button_setup
            // 
            this.button_setup.Location = new System.Drawing.Point(70, 23);
            this.button_setup.Name = "button_setup";
            this.button_setup.Size = new System.Drawing.Size(75, 23);
            this.button_setup.TabIndex = 2;
            this.button_setup.Text = "設定";
            this.button_setup.UseVisualStyleBackColor = true;
            this.button_setup.Click += new System.EventHandler(this.button_setup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel_color);
            this.groupBox1.Controls.Add(this.button_setup);
            this.groupBox1.Location = new System.Drawing.Point(14, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定背景";
            // 
            // panel_color
            // 
            this.panel_color.BackColor = System.Drawing.Color.LimeGreen;
            this.panel_color.Location = new System.Drawing.Point(18, 21);
            this.panel_color.Name = "panel_color";
            this.panel_color.Size = new System.Drawing.Size(33, 25);
            this.panel_color.TabIndex = 3;
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(13, 25);
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(170, 42);
            this.trackBarSpeed.SmallChange = 5;
            this.trackBarSpeed.TabIndex = 5;
            this.trackBarSpeed.TickFrequency = 5;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 128);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BackgroundColor);
            this.Controls.Add(this.trackBarSpeed);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.Text = "設定";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BackgroundColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_setup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel_color;
        private System.Windows.Forms.TrackBar trackBarSpeed;
    }
}