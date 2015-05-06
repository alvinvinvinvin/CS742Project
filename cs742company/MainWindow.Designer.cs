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
            this.ExceptionReportor = new System.Windows.Forms.TextBox();
            this.ExceptionLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hireManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fireManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hireEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fireEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deAssignProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeAddHoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportHoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbb_divisions = new System.Windows.Forms.ComboBox();
            this.cbb_projects = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbox_managerName = new System.Windows.Forms.TextBox();
            this.tbox_employees = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbox_estimatedH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbox_employeeOfProject = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExceptionReportor
            // 
            this.ExceptionReportor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExceptionReportor.Location = new System.Drawing.Point(129, 529);
            this.ExceptionReportor.Multiline = true;
            this.ExceptionReportor.Name = "ExceptionReportor";
            this.ExceptionReportor.ReadOnly = true;
            this.ExceptionReportor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ExceptionReportor.Size = new System.Drawing.Size(791, 139);
            this.ExceptionReportor.TabIndex = 1;
            // 
            // ExceptionLabel
            // 
            this.ExceptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExceptionLabel.Location = new System.Drawing.Point(4, 527);
            this.ExceptionLabel.Name = "ExceptionLabel";
            this.ExceptionLabel.Size = new System.Drawing.Size(109, 27);
            this.ExceptionLabel.TabIndex = 2;
            this.ExceptionLabel.Text = "Exception:";
            this.ExceptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.operationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // initToolStripMenuItem
            // 
            this.initToolStripMenuItem.Name = "initToolStripMenuItem";
            this.initToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.initToolStripMenuItem.Text = "Company Initialization";
            this.initToolStripMenuItem.Click += new System.EventHandler(this.initToolStripMenuItem_Click);
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hireManagerToolStripMenuItem,
            this.fireManagerToolStripMenuItem,
            this.moveManagerToolStripMenuItem,
            this.hireEmployeeToolStripMenuItem,
            this.fireEmployeeToolStripMenuItem,
            this.moveEmployeeToolStripMenuItem,
            this.addNewProjectToolStripMenuItem,
            this.removeProjectToolStripMenuItem,
            this.assignProjectToolStripMenuItem,
            this.deAssignProjectToolStripMenuItem,
            this.employeeAddHoursToolStripMenuItem,
            this.completeProjectToolStripMenuItem,
            this.reportHoursToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // hireManagerToolStripMenuItem
            // 
            this.hireManagerToolStripMenuItem.Name = "hireManagerToolStripMenuItem";
            this.hireManagerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.hireManagerToolStripMenuItem.Text = "Hire Manager";
            this.hireManagerToolStripMenuItem.Click += new System.EventHandler(this.hireManagerToolStripMenuItem_Click);
            // 
            // fireManagerToolStripMenuItem
            // 
            this.fireManagerToolStripMenuItem.Name = "fireManagerToolStripMenuItem";
            this.fireManagerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.fireManagerToolStripMenuItem.Text = "Fire Manager";
            this.fireManagerToolStripMenuItem.Click += new System.EventHandler(this.fireManagerToolStripMenuItem_Click);
            // 
            // moveManagerToolStripMenuItem
            // 
            this.moveManagerToolStripMenuItem.Name = "moveManagerToolStripMenuItem";
            this.moveManagerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.moveManagerToolStripMenuItem.Text = "Move Manager";
            this.moveManagerToolStripMenuItem.Click += new System.EventHandler(this.moveManagerToolStripMenuItem_Click);
            // 
            // hireEmployeeToolStripMenuItem
            // 
            this.hireEmployeeToolStripMenuItem.Name = "hireEmployeeToolStripMenuItem";
            this.hireEmployeeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.hireEmployeeToolStripMenuItem.Text = "Hire Employee";
            this.hireEmployeeToolStripMenuItem.Click += new System.EventHandler(this.hireEmployeeToolStripMenuItem_Click);
            // 
            // fireEmployeeToolStripMenuItem
            // 
            this.fireEmployeeToolStripMenuItem.Name = "fireEmployeeToolStripMenuItem";
            this.fireEmployeeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.fireEmployeeToolStripMenuItem.Text = "Fire Employee";
            this.fireEmployeeToolStripMenuItem.Click += new System.EventHandler(this.fireEmployeeToolStripMenuItem_Click);
            // 
            // moveEmployeeToolStripMenuItem
            // 
            this.moveEmployeeToolStripMenuItem.Name = "moveEmployeeToolStripMenuItem";
            this.moveEmployeeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.moveEmployeeToolStripMenuItem.Text = "Move Employee";
            this.moveEmployeeToolStripMenuItem.Click += new System.EventHandler(this.moveEmployeeToolStripMenuItem_Click);
            // 
            // addNewProjectToolStripMenuItem
            // 
            this.addNewProjectToolStripMenuItem.Name = "addNewProjectToolStripMenuItem";
            this.addNewProjectToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addNewProjectToolStripMenuItem.Text = "Add New Project";
            this.addNewProjectToolStripMenuItem.Click += new System.EventHandler(this.addNewProjectToolStripMenuItem_Click);
            // 
            // removeProjectToolStripMenuItem
            // 
            this.removeProjectToolStripMenuItem.Name = "removeProjectToolStripMenuItem";
            this.removeProjectToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.removeProjectToolStripMenuItem.Text = "Remove Project";
            this.removeProjectToolStripMenuItem.Click += new System.EventHandler(this.removeProjectToolStripMenuItem_Click);
            // 
            // assignProjectToolStripMenuItem
            // 
            this.assignProjectToolStripMenuItem.Name = "assignProjectToolStripMenuItem";
            this.assignProjectToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.assignProjectToolStripMenuItem.Text = "Assign Project";
            this.assignProjectToolStripMenuItem.Click += new System.EventHandler(this.assignProjectToolStripMenuItem_Click);
            // 
            // deAssignProjectToolStripMenuItem
            // 
            this.deAssignProjectToolStripMenuItem.Name = "deAssignProjectToolStripMenuItem";
            this.deAssignProjectToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.deAssignProjectToolStripMenuItem.Text = "DeAssign Project";
            this.deAssignProjectToolStripMenuItem.Click += new System.EventHandler(this.deAssignProjectToolStripMenuItem_Click);
            // 
            // employeeAddHoursToolStripMenuItem
            // 
            this.employeeAddHoursToolStripMenuItem.Name = "employeeAddHoursToolStripMenuItem";
            this.employeeAddHoursToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.employeeAddHoursToolStripMenuItem.Text = "Employee Add Hours";
            this.employeeAddHoursToolStripMenuItem.Click += new System.EventHandler(this.employeeAddHoursToolStripMenuItem_Click);
            // 
            // completeProjectToolStripMenuItem
            // 
            this.completeProjectToolStripMenuItem.Name = "completeProjectToolStripMenuItem";
            this.completeProjectToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.completeProjectToolStripMenuItem.Text = "Complete Project";
            this.completeProjectToolStripMenuItem.Click += new System.EventHandler(this.completeProjectToolStripMenuItem_Click);
            // 
            // reportHoursToolStripMenuItem
            // 
            this.reportHoursToolStripMenuItem.Name = "reportHoursToolStripMenuItem";
            this.reportHoursToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.reportHoursToolStripMenuItem.Text = "Report Hours";
            this.reportHoursToolStripMenuItem.Click += new System.EventHandler(this.reportHoursToolStripMenuItem_Click);
            // 
            // cbb_divisions
            // 
            this.cbb_divisions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_divisions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbb_divisions.FormattingEnabled = true;
            this.cbb_divisions.Location = new System.Drawing.Point(16, 61);
            this.cbb_divisions.Name = "cbb_divisions";
            this.cbb_divisions.Size = new System.Drawing.Size(212, 24);
            this.cbb_divisions.TabIndex = 4;
            this.cbb_divisions.SelectedValueChanged += new System.EventHandler(this.cbb_divisions_SelectedValueChanged);
            // 
            // cbb_projects
            // 
            this.cbb_projects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_projects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbb_projects.FormattingEnabled = true;
            this.cbb_projects.Location = new System.Drawing.Point(261, 61);
            this.cbb_projects.Name = "cbb_projects";
            this.cbb_projects.Size = new System.Drawing.Size(346, 24);
            this.cbb_projects.TabIndex = 11;
            this.cbb_projects.SelectedValueChanged += new System.EventHandler(this.cbb_projects_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Divisions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Manager";
            // 
            // tbox_managerName
            // 
            this.tbox_managerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbox_managerName.Location = new System.Drawing.Point(16, 129);
            this.tbox_managerName.Name = "tbox_managerName";
            this.tbox_managerName.ReadOnly = true;
            this.tbox_managerName.Size = new System.Drawing.Size(212, 26);
            this.tbox_managerName.TabIndex = 7;
            // 
            // tbox_employees
            // 
            this.tbox_employees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbox_employees.Location = new System.Drawing.Point(16, 207);
            this.tbox_employees.Multiline = true;
            this.tbox_employees.Name = "tbox_employees";
            this.tbox_employees.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbox_employees.Size = new System.Drawing.Size(212, 273);
            this.tbox_employees.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(17, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Employees";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(257, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Projects";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(258, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Estimated time by divisions";
            // 
            // tbox_estimatedH
            // 
            this.tbox_estimatedH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbox_estimatedH.Location = new System.Drawing.Point(262, 129);
            this.tbox_estimatedH.Multiline = true;
            this.tbox_estimatedH.Name = "tbox_estimatedH";
            this.tbox_estimatedH.ReadOnly = true;
            this.tbox_estimatedH.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbox_estimatedH.Size = new System.Drawing.Size(345, 190);
            this.tbox_estimatedH.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(258, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(500, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Employees working on this project and the hours reported:";
            // 
            // tbox_employeeOfProject
            // 
            this.tbox_employeeOfProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbox_employeeOfProject.Location = new System.Drawing.Point(261, 362);
            this.tbox_employeeOfProject.Multiline = true;
            this.tbox_employeeOfProject.Name = "tbox_employeeOfProject";
            this.tbox_employeeOfProject.ReadOnly = true;
            this.tbox_employeeOfProject.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbox_employeeOfProject.Size = new System.Drawing.Size(647, 149);
            this.tbox_employeeOfProject.TabIndex = 17;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 679);
            this.Controls.Add(this.tbox_employeeOfProject);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbox_estimatedH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbb_projects);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbox_employees);
            this.Controls.Add(this.tbox_managerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_divisions);
            this.Controls.Add(this.ExceptionLabel);
            this.Controls.Add(this.ExceptionReportor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ExceptionReportor;
        private System.Windows.Forms.Label ExceptionLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbb_divisions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbox_managerName;
        private System.Windows.Forms.TextBox tbox_employees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbb_projects;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbox_estimatedH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbox_employeeOfProject;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hireManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fireManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hireEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fireEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deAssignProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeAddHoursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportHoursToolStripMenuItem;

    }
}

