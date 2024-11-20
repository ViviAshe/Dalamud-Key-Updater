namespace DalamudKey_Updater
{
    partial class Form1
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
            this.SaveBranchButton = new System.Windows.Forms.Button();
            this.requesttimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.BranchComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SaveBranchButton
            // 
            this.SaveBranchButton.Location = new System.Drawing.Point(173, 28);
            this.SaveBranchButton.Name = "SaveBranchButton";
            this.SaveBranchButton.Size = new System.Drawing.Size(184, 41);
            this.SaveBranchButton.TabIndex = 0;
            this.SaveBranchButton.Text = "Set Branch";
            this.SaveBranchButton.UseVisualStyleBackColor = true;
            this.SaveBranchButton.Click += new System.EventHandler(this.SaveBranchButton_Click);
            // 
            // requesttimer
            // 
            this.requesttimer.Enabled = true;
            this.requesttimer.Tick += new System.EventHandler(this.requesttimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loading branches";
            // 
            // BranchComboBox
            // 
            this.BranchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BranchComboBox.FormattingEnabled = true;
            this.BranchComboBox.Location = new System.Drawing.Point(16, 35);
            this.BranchComboBox.Name = "BranchComboBox";
            this.BranchComboBox.Size = new System.Drawing.Size(151, 28);
            this.BranchComboBox.TabIndex = 3;
            this.BranchComboBox.SelectedIndexChanged += new System.EventHandler(this.BranchComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 81);
            this.Controls.Add(this.BranchComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveBranchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Dalamud Key Updater";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveBranchButton;
        private System.Windows.Forms.Timer requesttimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BranchComboBox;
    }
}

