namespace SmartWarehouseRobot
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
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.txtPickLocation = new System.Windows.Forms.TextBox();
            this.txtDropLocation = new System.Windows.Forms.TextBox();
            this.txtLoadWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpScheduledStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkRequiresEmergencyRobot = new System.Windows.Forms.CheckBox();
            this.dgvAssignedTasks = new System.Windows.Forms.DataGridView();
            this.btnCompleteTask = new System.Windows.Forms.Button();
            this.cmbTaskFilter = new System.Windows.Forms.ComboBox();
            this.btnShowRobots = new System.Windows.Forms.Button();
            this.lblAvailableRobots = new System.Windows.Forms.Label();
            this.lblAvgLoadWeight = new System.Windows.Forms.Label();
            this.lblServiceDueSoon = new System.Windows.Forms.Label();
            this.btnAddRobot = new System.Windows.Forms.Button();
            this.btnUpdateRobot = new System.Windows.Forms.Button();
            this.btnRemoveRobot = new System.Windows.Forms.Button();
            this.cmbRemoveRobot = new System.Windows.Forms.ComboBox();
            this.txtRobotModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxLoadCapacity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrentBatteryLevel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIsEmergencyRobot = new System.Windows.Forms.CheckBox();
            this.cmbRobotFilter = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbUpdateRobot = new System.Windows.Forms.ComboBox();
            this.txtNewMaxLoadCapacity = new System.Windows.Forms.TextBox();
            this.txtNewBatteryLevel = new System.Windows.Forms.TextBox();
            this.dtpNewLastServiceDate = new System.Windows.Forms.DateTimePicker();
            this.groupBoxRobotManagement = new System.Windows.Forms.GroupBox();
            this.groupBoxTaskManagement = new System.Windows.Forms.GroupBox();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignedTasks)).BeginInit();
            this.groupBoxRobotManagement.SuspendLayout();
            this.groupBoxTaskManagement.SuspendLayout();
            this.groupBoxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Location = new System.Drawing.Point(73, 146);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTask.TabIndex = 0;
            this.btnCreateTask.Text = "Create Task";
            this.btnCreateTask.UseVisualStyleBackColor = true;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // txtPickLocation
            // 
            this.txtPickLocation.Location = new System.Drawing.Point(68, 12);
            this.txtPickLocation.Name = "txtPickLocation";
            this.txtPickLocation.Size = new System.Drawing.Size(100, 20);
            this.txtPickLocation.TabIndex = 1;
            // 
            // txtDropLocation
            // 
            this.txtDropLocation.Location = new System.Drawing.Point(68, 38);
            this.txtDropLocation.Name = "txtDropLocation";
            this.txtDropLocation.Size = new System.Drawing.Size(100, 20);
            this.txtDropLocation.TabIndex = 2;
            // 
            // txtLoadWeight
            // 
            this.txtLoadWeight.Location = new System.Drawing.Point(67, 71);
            this.txtLoadWeight.Name = "txtLoadWeight";
            this.txtLoadWeight.Size = new System.Drawing.Size(100, 20);
            this.txtLoadWeight.TabIndex = 3;
            this.txtLoadWeight.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-25, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Load Weight (kg):";
            // 
            // dtpScheduledStartTime
            // 
            this.dtpScheduledStartTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpScheduledStartTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpScheduledStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScheduledStartTime.Location = new System.Drawing.Point(67, 97);
            this.dtpScheduledStartTime.Name = "dtpScheduledStartTime";
            this.dtpScheduledStartTime.Size = new System.Drawing.Size(122, 20);
            this.dtpScheduledStartTime.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-92, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Scheduled Start Time:";
            // 
            // chkRequiresEmergencyRobot
            // 
            this.chkRequiresEmergencyRobot.AutoSize = true;
            this.chkRequiresEmergencyRobot.Location = new System.Drawing.Point(48, 123);
            this.chkRequiresEmergencyRobot.Name = "chkRequiresEmergencyRobot";
            this.chkRequiresEmergencyRobot.Size = new System.Drawing.Size(156, 17);
            this.chkRequiresEmergencyRobot.TabIndex = 7;
            this.chkRequiresEmergencyRobot.Text = "Requires Emergency Robot";
            this.chkRequiresEmergencyRobot.UseVisualStyleBackColor = true;
            // 
            // dgvAssignedTasks
            // 
            this.dgvAssignedTasks.AllowUserToAddRows = false;
            this.dgvAssignedTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignedTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignedTasks.Location = new System.Drawing.Point(72, 12);
            this.dgvAssignedTasks.Name = "dgvAssignedTasks";
            this.dgvAssignedTasks.ReadOnly = true;
            this.dgvAssignedTasks.Size = new System.Drawing.Size(469, 254);
            this.dgvAssignedTasks.TabIndex = 8;
            this.dgvAssignedTasks.SelectionChanged += new System.EventHandler(this.dgvAssignedTasks_SelectionChanged);
            // 
            // btnCompleteTask
            // 
            this.btnCompleteTask.Enabled = false;
            this.btnCompleteTask.Location = new System.Drawing.Point(224, 270);
            this.btnCompleteTask.Name = "btnCompleteTask";
            this.btnCompleteTask.Size = new System.Drawing.Size(115, 23);
            this.btnCompleteTask.TabIndex = 9;
            this.btnCompleteTask.Text = "Complete Task";
            this.btnCompleteTask.UseVisualStyleBackColor = true;
            this.btnCompleteTask.Click += new System.EventHandler(this.btnCompleteTask_Click);
            // 
            // cmbTaskFilter
            // 
            this.cmbTaskFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskFilter.FormattingEnabled = true;
            this.cmbTaskFilter.Items.AddRange(new object[] {
            "All",
            "Assigned",
            "Completed"});
            this.cmbTaskFilter.Location = new System.Drawing.Point(12, 12);
            this.cmbTaskFilter.Name = "cmbTaskFilter";
            this.cmbTaskFilter.Size = new System.Drawing.Size(42, 21);
            this.cmbTaskFilter.TabIndex = 10;
            this.cmbTaskFilter.SelectedIndexChanged += new System.EventHandler(this.cmbTaskFilter_SelectedIndexChanged);
            // 
            // btnShowRobots
            // 
            this.btnShowRobots.Location = new System.Drawing.Point(315, -258);
            this.btnShowRobots.Name = "btnShowRobots";
            this.btnShowRobots.Size = new System.Drawing.Size(83, 23);
            this.btnShowRobots.TabIndex = 11;
            this.btnShowRobots.Text = "Show Robots";
            this.btnShowRobots.UseVisualStyleBackColor = true;
            this.btnShowRobots.Click += new System.EventHandler(this.btnShowRobots_Click);
            // 
            // lblAvailableRobots
            // 
            this.lblAvailableRobots.AutoSize = true;
            this.lblAvailableRobots.Location = new System.Drawing.Point(58, 34);
            this.lblAvailableRobots.Name = "lblAvailableRobots";
            this.lblAvailableRobots.Size = new System.Drawing.Size(90, 13);
            this.lblAvailableRobots.TabIndex = 12;
            this.lblAvailableRobots.Text = "Available Robots:";
            // 
            // lblAvgLoadWeight
            // 
            this.lblAvgLoadWeight.AutoSize = true;
            this.lblAvgLoadWeight.Location = new System.Drawing.Point(58, 47);
            this.lblAvgLoadWeight.Name = "lblAvgLoadWeight";
            this.lblAvgLoadWeight.Size = new System.Drawing.Size(93, 13);
            this.lblAvgLoadWeight.TabIndex = 13;
            this.lblAvgLoadWeight.Text = "Avg Load Weight:";
            // 
            // lblServiceDueSoon
            // 
            this.lblServiceDueSoon.AutoSize = true;
            this.lblServiceDueSoon.Location = new System.Drawing.Point(58, 60);
            this.lblServiceDueSoon.Name = "lblServiceDueSoon";
            this.lblServiceDueSoon.Size = new System.Drawing.Size(97, 13);
            this.lblServiceDueSoon.TabIndex = 14;
            this.lblServiceDueSoon.Text = "Service Due Soon:";
            // 
            // btnAddRobot
            // 
            this.btnAddRobot.Location = new System.Drawing.Point(72, 126);
            this.btnAddRobot.Name = "btnAddRobot";
            this.btnAddRobot.Size = new System.Drawing.Size(75, 23);
            this.btnAddRobot.TabIndex = 15;
            this.btnAddRobot.Text = "Add Robot";
            this.btnAddRobot.UseVisualStyleBackColor = true;
            this.btnAddRobot.Click += new System.EventHandler(this.btnAddRobot_Click);
            // 
            // btnUpdateRobot
            // 
            this.btnUpdateRobot.Location = new System.Drawing.Point(148, 406);
            this.btnUpdateRobot.Name = "btnUpdateRobot";
            this.btnUpdateRobot.Size = new System.Drawing.Size(87, 23);
            this.btnUpdateRobot.TabIndex = 16;
            this.btnUpdateRobot.Text = "Update Robot";
            this.btnUpdateRobot.UseVisualStyleBackColor = true;
            this.btnUpdateRobot.Click += new System.EventHandler(this.btnUpdateRobot_Click);
            // 
            // btnRemoveRobot
            // 
            this.btnRemoveRobot.Location = new System.Drawing.Point(396, 324);
            this.btnRemoveRobot.Name = "btnRemoveRobot";
            this.btnRemoveRobot.Size = new System.Drawing.Size(103, 23);
            this.btnRemoveRobot.TabIndex = 17;
            this.btnRemoveRobot.Text = "Remove Robot";
            this.btnRemoveRobot.UseVisualStyleBackColor = true;
            this.btnRemoveRobot.Click += new System.EventHandler(this.btnRemoveRobot_Click);
            // 
            // cmbRemoveRobot
            // 
            this.cmbRemoveRobot.FormattingEnabled = true;
            this.cmbRemoveRobot.Location = new System.Drawing.Point(406, 297);
            this.cmbRemoveRobot.Name = "cmbRemoveRobot";
            this.cmbRemoveRobot.Size = new System.Drawing.Size(121, 21);
            this.cmbRemoveRobot.TabIndex = 18;
            this.cmbRemoveRobot.Text = "Current Robot List";
            // 
            // txtRobotModel
            // 
            this.txtRobotModel.Location = new System.Drawing.Point(62, 19);
            this.txtRobotModel.Name = "txtRobotModel";
            this.txtRobotModel.Size = new System.Drawing.Size(100, 20);
            this.txtRobotModel.TabIndex = 19;
            this.txtRobotModel.Text = "Enter robot model";
            this.txtRobotModel.Enter += new System.EventHandler(this.txtRobotModel_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Robot Model:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtMaxLoadCapacity
            // 
            this.txtMaxLoadCapacity.Location = new System.Drawing.Point(56, 48);
            this.txtMaxLoadCapacity.Name = "txtMaxLoadCapacity";
            this.txtMaxLoadCapacity.Size = new System.Drawing.Size(100, 20);
            this.txtMaxLoadCapacity.TabIndex = 21;
            this.txtMaxLoadCapacity.Text = "Enter capacity (kg)";
            this.txtMaxLoadCapacity.Enter += new System.EventHandler(this.txtMaxLoadCapacity_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Max Load Capacity (kg):";
            // 
            // txtCurrentBatteryLevel
            // 
            this.txtCurrentBatteryLevel.Location = new System.Drawing.Point(56, 84);
            this.txtCurrentBatteryLevel.Name = "txtCurrentBatteryLevel";
            this.txtCurrentBatteryLevel.Size = new System.Drawing.Size(100, 20);
            this.txtCurrentBatteryLevel.TabIndex = 23;
            this.txtCurrentBatteryLevel.Text = "Enter battery (%)";
            this.txtCurrentBatteryLevel.Enter += new System.EventHandler(this.txtCurrentBatteryLevel_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Battery Level (%):";
            // 
            // chkIsEmergencyRobot
            // 
            this.chkIsEmergencyRobot.AutoSize = true;
            this.chkIsEmergencyRobot.Location = new System.Drawing.Point(-36, 103);
            this.chkIsEmergencyRobot.Name = "chkIsEmergencyRobot";
            this.chkIsEmergencyRobot.Size = new System.Drawing.Size(111, 17);
            this.chkIsEmergencyRobot.TabIndex = 25;
            this.chkIsEmergencyRobot.Text = "Emergency Robot";
            this.chkIsEmergencyRobot.UseVisualStyleBackColor = true;
            this.chkIsEmergencyRobot.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cmbRobotFilter
            // 
            this.cmbRobotFilter.FormattingEnabled = true;
            this.cmbRobotFilter.Items.AddRange(new object[] {
            "All",
            "",
            "Low Battery (<25%)",
            "",
            "Due Service (7 days)",
            "",
            "Emergency Ready"});
            this.cmbRobotFilter.Location = new System.Drawing.Point(-122, 14);
            this.cmbRobotFilter.Name = "cmbRobotFilter";
            this.cmbRobotFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbRobotFilter.TabIndex = 26;
            this.cmbRobotFilter.Text = "All";
            this.cmbRobotFilter.SelectedIndexChanged += new System.EventHandler(this.cmbRobotFilter_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-7, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Pick Location:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-7, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Drop Location:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(76, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Task Creation";
            // 
            // cmbUpdateRobot
            // 
            this.cmbUpdateRobot.FormattingEnabled = true;
            this.cmbUpdateRobot.Location = new System.Drawing.Point(129, 379);
            this.cmbUpdateRobot.Name = "cmbUpdateRobot";
            this.cmbUpdateRobot.Size = new System.Drawing.Size(121, 21);
            this.cmbUpdateRobot.TabIndex = 28;
            this.cmbUpdateRobot.Text = "Robot List";
            // 
            // txtNewMaxLoadCapacity
            // 
            this.txtNewMaxLoadCapacity.Location = new System.Drawing.Point(135, 327);
            this.txtNewMaxLoadCapacity.Name = "txtNewMaxLoadCapacity";
            this.txtNewMaxLoadCapacity.Size = new System.Drawing.Size(100, 20);
            this.txtNewMaxLoadCapacity.TabIndex = 29;
            this.txtNewMaxLoadCapacity.Text = "Enter new capacity (kg)";
            this.txtNewMaxLoadCapacity.Enter += new System.EventHandler(this.txtNewMaxLoadCapacity_Enter);
            this.txtNewMaxLoadCapacity.Leave += new System.EventHandler(this.txtMaxLoadCapacity_Leave);
            // 
            // txtNewBatteryLevel
            // 
            this.txtNewBatteryLevel.Location = new System.Drawing.Point(135, 310);
            this.txtNewBatteryLevel.Name = "txtNewBatteryLevel";
            this.txtNewBatteryLevel.Size = new System.Drawing.Size(100, 20);
            this.txtNewBatteryLevel.TabIndex = 29;
            this.txtNewBatteryLevel.Text = "Enter new battery level (%)";
            this.txtNewBatteryLevel.Enter += new System.EventHandler(this.txtNewBatteryLevel_Enter);
            this.txtNewBatteryLevel.Leave += new System.EventHandler(this.txtNewBatteryLevel_Leave);
            // 
            // dtpNewLastServiceDate
            // 
            this.dtpNewLastServiceDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpNewLastServiceDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpNewLastServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNewLastServiceDate.Location = new System.Drawing.Point(129, 350);
            this.dtpNewLastServiceDate.Name = "dtpNewLastServiceDate";
            this.dtpNewLastServiceDate.Size = new System.Drawing.Size(121, 20);
            this.dtpNewLastServiceDate.TabIndex = 5;
            // 
            // groupBoxRobotManagement
            // 
            this.groupBoxRobotManagement.Controls.Add(this.txtRobotModel);
            this.groupBoxRobotManagement.Controls.Add(this.btnAddRobot);
            this.groupBoxRobotManagement.Controls.Add(this.txtMaxLoadCapacity);
            this.groupBoxRobotManagement.Controls.Add(this.txtCurrentBatteryLevel);
            this.groupBoxRobotManagement.Controls.Add(this.chkIsEmergencyRobot);
            this.groupBoxRobotManagement.Controls.Add(this.label3);
            this.groupBoxRobotManagement.Controls.Add(this.label4);
            this.groupBoxRobotManagement.Controls.Add(this.label5);
            this.groupBoxRobotManagement.Location = new System.Drawing.Point(352, 371);
            this.groupBoxRobotManagement.Name = "groupBoxRobotManagement";
            this.groupBoxRobotManagement.Size = new System.Drawing.Size(200, 105);
            this.groupBoxRobotManagement.TabIndex = 30;
            this.groupBoxRobotManagement.TabStop = false;
            this.groupBoxRobotManagement.Text = "Robot Management";
            // 
            // groupBoxTaskManagement
            // 
            this.groupBoxTaskManagement.Controls.Add(this.txtPickLocation);
            this.groupBoxTaskManagement.Controls.Add(this.btnCreateTask);
            this.groupBoxTaskManagement.Controls.Add(this.txtDropLocation);
            this.groupBoxTaskManagement.Controls.Add(this.txtLoadWeight);
            this.groupBoxTaskManagement.Controls.Add(this.dtpScheduledStartTime);
            this.groupBoxTaskManagement.Controls.Add(this.chkRequiresEmergencyRobot);
            this.groupBoxTaskManagement.Controls.Add(this.label7);
            this.groupBoxTaskManagement.Controls.Add(this.label6);
            this.groupBoxTaskManagement.Controls.Add(this.label8);
            this.groupBoxTaskManagement.Controls.Add(this.label1);
            this.groupBoxTaskManagement.Controls.Add(this.label2);
            this.groupBoxTaskManagement.Location = new System.Drawing.Point(35, 419);
            this.groupBoxTaskManagement.Name = "groupBoxTaskManagement";
            this.groupBoxTaskManagement.Size = new System.Drawing.Size(200, 187);
            this.groupBoxTaskManagement.TabIndex = 30;
            this.groupBoxTaskManagement.TabStop = false;
            this.groupBoxTaskManagement.Text = "Task Management";
            this.groupBoxTaskManagement.Enter += new System.EventHandler(this.groupBoxTaskManagement_Enter);
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.lblServiceDueSoon);
            this.groupBoxStatus.Controls.Add(this.btnShowRobots);
            this.groupBoxStatus.Controls.Add(this.lblAvailableRobots);
            this.groupBoxStatus.Controls.Add(this.lblAvgLoadWeight);
            this.groupBoxStatus.Controls.Add(this.cmbRobotFilter);
            this.groupBoxStatus.Location = new System.Drawing.Point(267, 506);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(200, 100);
            this.groupBoxStatus.TabIndex = 30;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Robot Status";
            this.groupBoxStatus.Enter += new System.EventHandler(this.groupBoxStatus_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1506, 615);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBoxTaskManagement);
            this.Controls.Add(this.groupBoxRobotManagement);
            this.Controls.Add(this.txtNewBatteryLevel);
            this.Controls.Add(this.txtNewMaxLoadCapacity);
            this.Controls.Add(this.cmbUpdateRobot);
            this.Controls.Add(this.cmbRemoveRobot);
            this.Controls.Add(this.btnRemoveRobot);
            this.Controls.Add(this.btnUpdateRobot);
            this.Controls.Add(this.cmbTaskFilter);
            this.Controls.Add(this.btnCompleteTask);
            this.Controls.Add(this.dgvAssignedTasks);
            this.Controls.Add(this.dtpNewLastServiceDate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignedTasks)).EndInit();
            this.groupBoxRobotManagement.ResumeLayout(false);
            this.groupBoxRobotManagement.PerformLayout();
            this.groupBoxTaskManagement.ResumeLayout(false);
            this.groupBoxTaskManagement.PerformLayout();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateTask;
        private System.Windows.Forms.TextBox txtPickLocation;
        private System.Windows.Forms.TextBox txtDropLocation;
        private System.Windows.Forms.TextBox txtLoadWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpScheduledStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkRequiresEmergencyRobot;
        private System.Windows.Forms.DataGridView dgvAssignedTasks;
        private System.Windows.Forms.Button btnCompleteTask;
        private System.Windows.Forms.ComboBox cmbTaskFilter;
        private System.Windows.Forms.Button btnShowRobots;
        private System.Windows.Forms.Label lblAvailableRobots;
        private System.Windows.Forms.Label lblAvgLoadWeight;
        private System.Windows.Forms.Label lblServiceDueSoon;
        private System.Windows.Forms.Button btnAddRobot;
        private System.Windows.Forms.Button btnUpdateRobot;
        private System.Windows.Forms.Button btnRemoveRobot;
        private System.Windows.Forms.ComboBox cmbRemoveRobot;
        private System.Windows.Forms.TextBox txtRobotModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaxLoadCapacity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrentBatteryLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsEmergencyRobot;
        private System.Windows.Forms.ComboBox cmbRobotFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbUpdateRobot;
        private System.Windows.Forms.TextBox txtNewMaxLoadCapacity;
        private System.Windows.Forms.TextBox txtNewBatteryLevel;
        private System.Windows.Forms.DateTimePicker dtpNewLastServiceDate;
        private System.Windows.Forms.GroupBox groupBoxRobotManagement;
        private System.Windows.Forms.GroupBox groupBoxTaskManagement;
        private System.Windows.Forms.GroupBox groupBoxStatus;
    }
}

