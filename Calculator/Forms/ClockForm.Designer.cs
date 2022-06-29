namespace Calculator.Forms
{
    partial class ClockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.timeLabel = new System.Windows.Forms.Label();
            this.dateTimeUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.dateLabel = new System.Windows.Forms.Label();
            this.argbValUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // statusStrip
            //
            this.statusStrip.BackColor = System.Drawing.Color.Gainsboro;
            this.statusStrip.GripMargin = new System.Windows.Forms.Padding(1);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.toolStripProgressBar
            });
            this.statusStrip.Location = new System.Drawing.Point(0, 189);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(484, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            //
            // toolStripProgressBar
            //
            this.toolStripProgressBar.BackColor = System.Drawing.Color.DarkBlue;
            this.toolStripProgressBar.ForeColor = System.Drawing.Color.DarkBlue;
            this.toolStripProgressBar.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(480, 20);
            this.toolStripProgressBar.Step = 1;
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            //
            // timeLabel
            //
            this.timeLabel.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.timeLabel.Location = new System.Drawing.Point(10, 10);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(1);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(464, 75);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // dateLabel
            //
            this.dateLabel.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.dateLabel.Location = new System.Drawing.Point(10, 87);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(1);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(464, 75);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Date";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // ClockForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClockForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clock";
            this.Load += new System.EventHandler(this.ClockForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClockForm_KeyDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer dateTimeUpdateTimer;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Timer argbValUpdateTimer;
    }
}
