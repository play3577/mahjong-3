﻿namespace Mahjong.Forms
{
    partial class CPK
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
            this.Chow = new System.Windows.Forms.Button();
            this.Pong = new System.Windows.Forms.Button();
            this.Kong = new System.Windows.Forms.Button();
            this.Win = new System.Windows.Forms.Button();
            this.Pass = new System.Windows.Forms.Button();
            this.DarkKong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Chow
            // 
            this.Chow.Enabled = false;
            this.Chow.Location = new System.Drawing.Point(12, 7);
            this.Chow.Name = "Chow";
            this.Chow.Size = new System.Drawing.Size(43, 23);
            this.Chow.TabIndex = 0;
            this.Chow.UseVisualStyleBackColor = true;
            this.Chow.Click += new System.EventHandler(this.Chow_Click);
            // 
            // Pong
            // 
            this.Pong.Enabled = false;
            this.Pong.Location = new System.Drawing.Point(61, 7);
            this.Pong.Name = "Pong";
            this.Pong.Size = new System.Drawing.Size(43, 23);
            this.Pong.TabIndex = 1;
            this.Pong.UseVisualStyleBackColor = true;
            this.Pong.Click += new System.EventHandler(this.Pong_Click);
            // 
            // Kong
            // 
            this.Kong.Enabled = false;
            this.Kong.Location = new System.Drawing.Point(110, 7);
            this.Kong.Name = "Kong";
            this.Kong.Size = new System.Drawing.Size(43, 23);
            this.Kong.TabIndex = 1;
            this.Kong.UseVisualStyleBackColor = true;
            this.Kong.Click += new System.EventHandler(this.Kong_Click);
            // 
            // Win
            // 
            this.Win.Enabled = false;
            this.Win.Location = new System.Drawing.Point(208, 7);
            this.Win.Name = "Win";
            this.Win.Size = new System.Drawing.Size(43, 23);
            this.Win.TabIndex = 1;
            this.Win.UseVisualStyleBackColor = true;
            this.Win.Click += new System.EventHandler(this.Win_Click);
            // 
            // Pass
            // 
            this.Pass.Location = new System.Drawing.Point(257, 7);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(43, 23);
            this.Pass.TabIndex = 2;
            this.Pass.UseVisualStyleBackColor = true;
            this.Pass.Click += new System.EventHandler(this.Pass_Click);
            // 
            // DarkKong
            // 
            this.DarkKong.Location = new System.Drawing.Point(159, 7);
            this.DarkKong.Name = "DarkKong";
            this.DarkKong.Size = new System.Drawing.Size(43, 23);
            this.DarkKong.TabIndex = 3;
            this.DarkKong.UseVisualStyleBackColor = true;
            this.DarkKong.Click += new System.EventHandler(this.DarkKong_Click);
            // 
            // CPK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 38);
            this.ControlBox = false;
            this.Controls.Add(this.DarkKong);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.Win);
            this.Controls.Add(this.Kong);
            this.Controls.Add(this.Pong);
            this.Controls.Add(this.Chow);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CPK";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CPK_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Chow;
        private System.Windows.Forms.Button Pong;
        private System.Windows.Forms.Button Kong;
        private System.Windows.Forms.Button Win;
        private System.Windows.Forms.Button Pass;
        private System.Windows.Forms.Button DarkKong;
    }
}