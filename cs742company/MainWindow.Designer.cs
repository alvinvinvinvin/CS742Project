namespace cs742company
{
    partial class MainWindow
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
            this.ReadFile = new System.Windows.Forms.Button();
            this.ExceptionReportor = new System.Windows.Forms.TextBox();
            this.ExceptionLabel = new System.Windows.Forms.Label();
            this.Divisions = new System.Windows.Forms.ListBox();
            this.DivisionLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReadFile
            // 
            this.ReadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ReadFile.Location = new System.Drawing.Point(17, 12);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(155, 33);
            this.ReadFile.TabIndex = 0;
            this.ReadFile.Text = "ReadFile";
            this.ReadFile.UseVisualStyleBackColor = true;
            this.ReadFile.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // ExceptionReportor
            // 
            this.ExceptionReportor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExceptionReportor.Location = new System.Drawing.Point(127, 359);
            this.ExceptionReportor.Multiline = true;
            this.ExceptionReportor.Name = "ExceptionReportor";
            this.ExceptionReportor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ExceptionReportor.Size = new System.Drawing.Size(747, 172);
            this.ExceptionReportor.TabIndex = 1;
            this.ExceptionReportor.WordWrap = false;
            // 
            // ExceptionLabel
            // 
            this.ExceptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExceptionLabel.Location = new System.Drawing.Point(12, 359);
            this.ExceptionLabel.Name = "ExceptionLabel";
            this.ExceptionLabel.Size = new System.Drawing.Size(109, 27);
            this.ExceptionLabel.TabIndex = 2;
            this.ExceptionLabel.Text = "Exception:";
            this.ExceptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Divisions
            // 
            this.Divisions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Divisions.FormattingEnabled = true;
            this.Divisions.ItemHeight = 20;
            this.Divisions.Location = new System.Drawing.Point(17, 86);
            this.Divisions.Name = "Divisions";
            this.Divisions.Size = new System.Drawing.Size(155, 244);
            this.Divisions.TabIndex = 3;
            // 
            // DivisionLable
            // 
            this.DivisionLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DivisionLable.Location = new System.Drawing.Point(12, 60);
            this.DivisionLable.Name = "DivisionLable";
            this.DivisionLable.Size = new System.Drawing.Size(100, 23);
            this.DivisionLable.TabIndex = 4;
            this.DivisionLable.Text = "Divisions:";
            this.DivisionLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 543);
            this.Controls.Add(this.DivisionLable);
            this.Controls.Add(this.Divisions);
            this.Controls.Add(this.ExceptionLabel);
            this.Controls.Add(this.ExceptionReportor);
            this.Controls.Add(this.ReadFile);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReadFile;
        private System.Windows.Forms.TextBox ExceptionReportor;
        private System.Windows.Forms.Label ExceptionLabel;
        private System.Windows.Forms.ListBox Divisions;
        private System.Windows.Forms.Label DivisionLable;

    }
}

