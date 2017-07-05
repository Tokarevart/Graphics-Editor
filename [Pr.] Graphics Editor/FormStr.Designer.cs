namespace _Pr.__Graphics_Editor
{
    partial class FormStr
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
            this.tbStr = new System.Windows.Forms.TextBox();
            this.btnStr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbStr
            // 
            this.tbStr.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStr.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbStr.Location = new System.Drawing.Point(12, 12);
            this.tbStr.Multiline = true;
            this.tbStr.Name = "tbStr";
            this.tbStr.Size = new System.Drawing.Size(569, 109);
            this.tbStr.TabIndex = 0;
            // 
            // btnStr
            // 
            this.btnStr.Location = new System.Drawing.Point(249, 127);
            this.btnStr.Name = "btnStr";
            this.btnStr.Size = new System.Drawing.Size(97, 34);
            this.btnStr.TabIndex = 1;
            this.btnStr.Text = "Готово";
            this.btnStr.UseVisualStyleBackColor = true;
            this.btnStr.Click += new System.EventHandler(this.btnStr_Click);
            // 
            // FormStr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 170);
            this.Controls.Add(this.btnStr);
            this.Controls.Add(this.tbStr);
            this.Name = "FormStr";
            this.ShowIcon = false;
            this.Text = "Текст строки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStr;
        private System.Windows.Forms.Button btnStr;
    }
}