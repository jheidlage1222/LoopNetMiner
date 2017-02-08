namespace LoopNetMiner
{
    partial class MinerGUI
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
            this.btnInitiate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInitiate
            // 
            this.btnInitiate.Location = new System.Drawing.Point(168, 170);
            this.btnInitiate.Name = "btnInitiate";
            this.btnInitiate.Size = new System.Drawing.Size(75, 23);
            this.btnInitiate.TabIndex = 0;
            this.btnInitiate.Text = "Initiate";
            this.btnInitiate.UseVisualStyleBackColor = true;
            this.btnInitiate.Click += new System.EventHandler(this.btnIntiate_Click);
            // 
            // MinerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 329);
            this.Controls.Add(this.btnInitiate);
            this.Name = "MinerGUI";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInitiate;
    }
}

