using SmartWarehouseRobot.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartWarehouseRobot
{
    public partial class Form1 : Form
    {
        private static readonly List<Robot> Robots = new List<Robot>
        {
            new Robot { RobotModel = "RX-100", MaxLoadCapacity = 500, CurrentBatteryLevel = 75, LastServiceDate = DateTime.Now.AddDays(-40), IsEmergencyRobot = false },
            new Robot { RobotModel = "RX-200", MaxLoadCapacity = 1000, CurrentBatteryLevel = 90, LastServiceDate = DateTime.Now.AddDays(-5), IsEmergencyRobot = true },
            new Robot { RobotModel = "RX-300", MaxLoadCapacity = 200, CurrentBatteryLevel = 15, LastServiceDate = DateTime.Now.AddDays(-20), IsEmergencyRobot = false }
        };
        private static readonly List<(Task Task, Robot Robot)> AssignedTasks = new List<(Task, Robot)>();
        private static readonly List<(Task Task, Robot Robot)> CompletedTasks = new List<(Task, Robot)>();

        public Form1()
        {
            InitializeComponent();
            foreach (var robot in Robots)
            {
                var context = new ValidationContext(robot);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(robot, context, results, true))
                {
                    foreach (var result in results)
                    {
                        MessageBox.Show($"Robot validation error: {result.ErrorMessage}");
                    }
                }
            }
            cmbRobotFilter.SelectedIndexChanged += cmbRobotFilter_SelectedIndexChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshAssignedTasksGrid("All");
            CheckRobotNotifications();
            UpdateRobotStatus();
            UpdateRemoveRobotDropdown();
            UpdateUpdateRobotDropdown();

            // Form background color
            this.BackColor = Color.FromArgb(240, 240, 245); // Light grayish-blue

            // Button colors (blue background, white text)
            if (btnAddRobot != null)
            {
                btnAddRobot.BackColor = Color.FromArgb(100, 149, 237);
                btnAddRobot.ForeColor = Color.White;
            }
            if (btnUpdateRobot != null)
            {
                btnUpdateRobot.BackColor = Color.FromArgb(100, 149, 237);
                btnUpdateRobot.ForeColor = Color.White;
            }
            if (btnRemoveRobot != null)
            {
                btnRemoveRobot.BackColor = Color.FromArgb(100, 149, 237);
                btnRemoveRobot.ForeColor = Color.White;
            }
            if (btnCreateTask != null)
            {
                btnCreateTask.BackColor = Color.FromArgb(100, 149, 237);
                btnCreateTask.ForeColor = Color.White;
            }
            if (btnCompleteTask != null)
            {
                btnCompleteTask.BackColor = Color.FromArgb(100, 149, 237);
                btnCompleteTask.ForeColor = Color.White;
            }
            if (btnShowRobots != null)
            {
                btnShowRobots.BackColor = Color.FromArgb(100, 149, 237);
                btnShowRobots.ForeColor = Color.White;
            }

            // Label colors (bold and colored text)
            if (lblAvailableRobots != null)
            {
                lblAvailableRobots.Font = new Font("Arial", 9, FontStyle.Bold);
                lblAvailableRobots.ForeColor = Color.DarkBlue;
            }
            if (lblAvgLoadWeight != null)
            {
                lblAvgLoadWeight.Font = new Font("Arial", 9, FontStyle.Bold);
                lblAvgLoadWeight.ForeColor = Color.DarkBlue;
            }
            if (lblServiceDueSoon != null)
            {
                lblServiceDueSoon.Font = new Font("Arial", 9, FontStyle.Bold);
                lblServiceDueSoon.ForeColor = Color.Red;
            }

            // Add ToolTips for user guidance
            ToolTip toolTip = new ToolTip();
            if (txtRobotModel != null) toolTip.SetToolTip(txtRobotModel, "Enter the model name (e.g., RX-400)");
            if (txtMaxLoadCapacity != null) toolTip.SetToolTip(txtMaxLoadCapacity, "Enter capacity between 10-1000 kg");
            if (txtCurrentBatteryLevel != null) toolTip.SetToolTip(txtCurrentBatteryLevel, "Enter battery level between 0-100%");
            if (txtNewBatteryLevel != null) toolTip.SetToolTip(txtNewBatteryLevel, "Enter new battery level between 0-100%");
            if (txtNewMaxLoadCapacity != null) toolTip.SetToolTip(txtNewMaxLoadCapacity, "Enter new capacity between 10-1000 kg");
            if (txtPickLocation != null) toolTip.SetToolTip(txtPickLocation, "Enter pick-up location (e.g., A1)");
            if (txtDropLocation != null) toolTip.SetToolTip(txtDropLocation, "Enter drop-off location (e.g., B2)");
            if (txtLoadWeight != null) toolTip.SetToolTip(txtLoadWeight, "Enter load weight in kg");
        }

        private void CheckRobotNotifications()
        {
            foreach (var robot in Robots)
            {
                if (robot.CurrentBatteryLevel < 25)
                {
                    MessageBox.Show($"Warning: Robot {robot.RobotModel} has low battery ({robot.CurrentBatteryLevel}%).");
                }
                if (DateTime.Now > robot.LastServiceDate.AddDays(45))
                {
                    MessageBox.Show($"Alert: Robot {robot.RobotModel} is overdue for service (last serviced on {robot.LastServiceDate:yyyy-MM-dd}).");
                }
            }
        }

        private void UpdateRobotStatus()
        {
            ApplyRobotFilter();
        }

        private void ApplyRobotFilter()
        {
            var filteredRobots = Robots.AsEnumerable();
            string filter = cmbRobotFilter.SelectedItem?.ToString() ?? "All";

            switch (filter)
            {
                case "Low Battery (<25%)":
                    filteredRobots = Robots.Where(r => r.CurrentBatteryLevel < 25);
                    break;
                case "Due Service (7 days)":
                    filteredRobots = Robots.Where(r => DateTime.Now >= r.LastServiceDate.AddDays(38) && DateTime.Now <= r.LastServiceDate.AddDays(45));
                    break;
                case "Emergency Ready":
                    filteredRobots = Robots.Where(r => r.IsEmergencyRobot);
                    break;
                case "All":
                default:
                    filteredRobots = Robots.AsEnumerable();
                    break;
            }

            var availableRobots = filteredRobots.Where(r => !AssignedTasks.Any(t => t.Robot.RobotID == r.RobotID) && r.CurrentBatteryLevel >= 25).ToList();
            lblAvailableRobots.Text = $"Available Robots: {string.Join(", ", availableRobots.Select(r => r.RobotModel))}";
            var avgLoadWeight = AssignedTasks.Any() ? AssignedTasks.Average(t => t.Task.LoadWeight) : 0;
            lblAvgLoadWeight.Text = $"Avg Load Weight: {avgLoadWeight:F2} kg";
            var serviceDueSoon = filteredRobots.Where(r => DateTime.Now >= r.LastServiceDate.AddDays(38) && DateTime.Now <= r.LastServiceDate.AddDays(45)).ToList();
            lblServiceDueSoon.Text = $"Service Due Soon: {string.Join(", ", serviceDueSoon.Select(r => r.RobotModel))}";
        }

        private void cmbRobotFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRobotStatus();
        }

        private void btnAddRobot_Click(object sender, EventArgs e)
        {
            string robotModel = txtRobotModel.Text.Trim();

            if (string.IsNullOrEmpty(robotModel) || robotModel == "Enter robot model")
            {
                MessageBox.Show("Please enter a robot model!");
                return;
            }

            if (Robots.Any(r => r.RobotModel == robotModel))
            {
                MessageBox.Show($"A robot with model {robotModel} already exists!");
                return;
            }

            if (!float.TryParse(txtMaxLoadCapacity.Text.Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out float maxLoadCapacity) || maxLoadCapacity < 10 || maxLoadCapacity > 1000)
            {
                MessageBox.Show("Max Load Capacity must be between 10 and 1000 kg!");
                return;
            }

            if (!float.TryParse(txtCurrentBatteryLevel.Text.Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out float currentBatteryLevel) || currentBatteryLevel < 0 || currentBatteryLevel > 100)
            {
                MessageBox.Show("Battery Level must be between 0 and 100%!");
                return;
            }

            var newRobot = new Robot
            {
                RobotModel = robotModel,
                MaxLoadCapacity = maxLoadCapacity,
                CurrentBatteryLevel = currentBatteryLevel,
                LastServiceDate = DateTime.Now,
                IsEmergencyRobot = chkIsEmergencyRobot.Checked
            };

            Robots.Add(newRobot);
            MessageBox.Show($"Added new robot: {newRobot.RobotModel} (Capacity: {maxLoadCapacity} kg, Battery: {currentBatteryLevel}%, Emergency: {chkIsEmergencyRobot.Checked})");
            UpdateRobotStatus();
            UpdateRemoveRobotDropdown();
            UpdateUpdateRobotDropdown();

            txtRobotModel.Text = "Enter robot model";
            txtMaxLoadCapacity.Text = "Enter capacity (kg)";
            txtCurrentBatteryLevel.Text = "Enter battery (%)";
        }

        private void UpdateUpdateRobotDropdown()
        {
            cmbUpdateRobot.Items.Clear();
            foreach (var robot in Robots)
            {
                cmbUpdateRobot.Items.Add(robot.RobotModel);
            }
        }

        private void btnUpdateRobot_Click(object sender, EventArgs e)
        {
            if (cmbUpdateRobot.SelectedItem == null)
            {
                MessageBox.Show("Please select a robot to update!");
                return;
            }

            var robotModelToUpdate = cmbUpdateRobot.SelectedItem.ToString();
            var robotToUpdate = Robots.FirstOrDefault(r => r.RobotModel == robotModelToUpdate);
            if (robotToUpdate == null)
            {
                MessageBox.Show($"Robot {robotModelToUpdate} not found!");
                return;
            }

            if (!float.TryParse(txtNewBatteryLevel.Text, out float newBatteryLevel) || newBatteryLevel < 0 || newBatteryLevel > 100)
            {
                MessageBox.Show("Invalid battery level (must be 0-100%)!");
                return;
            }

            if (!float.TryParse(txtNewMaxLoadCapacity.Text, out float newMaxLoadCapacity) || newMaxLoadCapacity < 10 || newMaxLoadCapacity > 1000)
            {
                MessageBox.Show("Invalid max load capacity (must be 10-1000 kg)!");
                return;
            }

            robotToUpdate.CurrentBatteryLevel = newBatteryLevel;
            robotToUpdate.MaxLoadCapacity = newMaxLoadCapacity;
            robotToUpdate.LastServiceDate = dtpNewLastServiceDate.Value;

            MessageBox.Show($"Updated robot {robotToUpdate.RobotModel}: Battery to {robotToUpdate.CurrentBatteryLevel}%, Capacity to {robotToUpdate.MaxLoadCapacity} kg, Last Service to {robotToUpdate.LastServiceDate:yyyy-MM-dd}.");
            UpdateRobotStatus();
            UpdateUpdateRobotDropdown();

            txtNewBatteryLevel.Text = "Enter new battery level (%)";
            txtNewMaxLoadCapacity.Text = "Enter new capacity (kg)";
        }

        private void UpdateRemoveRobotDropdown()
        {
            cmbRemoveRobot.Items.Clear();
            foreach (var robot in Robots)
            {
                cmbRemoveRobot.Items.Add(robot.RobotModel);
            }
        }

        private void btnRemoveRobot_Click(object sender, EventArgs e)
        {
            if (cmbRemoveRobot.SelectedItem != null)
            {
                var robotModelToRemove = cmbRemoveRobot.SelectedItem.ToString();
                var robotToRemove = Robots.FirstOrDefault(r => r.RobotModel == robotModelToRemove);
                if (robotToRemove != null)
                {
                    Robots.Remove(robotToRemove);
                    MessageBox.Show($"Removed robot: {robotToRemove.RobotModel}");
                }
                else
                {
                    MessageBox.Show($"Robot {robotModelToRemove} not found!");
                }
            }
            else
            {
                MessageBox.Show("Please select a robot to remove!");
            }

            UpdateRobotStatus();
            UpdateRemoveRobotDropdown();
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (!float.TryParse(txtLoadWeight.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out float loadWeight))
                {
                    MessageBox.Show("Task Error: Please enter a valid number for Load Weight.");
                    return;
                }

                DateTime scheduledTime = dtpScheduledStartTime.Value;
                if (scheduledTime < DateTime.Now)
                {
                    MessageBox.Show("Task Error: Scheduled Start Time cannot be in the past.");
                    return;
                }

                var task = new Task
                {
                    PickLocation = txtPickLocation.Text,
                    DropLocation = txtDropLocation.Text,
                    LoadWeight = loadWeight,
                    ScheduledStartTime = scheduledTime,
                    RequiresEmergencyRobot = chkRequiresEmergencyRobot.Checked
                };

                var context = new ValidationContext(task);
                var results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(task, context, results, true);

                if (!isValid)
                {
                    foreach (var validationResult in results)
                    {
                        MessageBox.Show($"Task Error: {validationResult.ErrorMessage}");
                    }
                    return;
                }

                Robot bestRobot = null;
                string assignmentMessage = "Assignment failed: No compatible robot found.";

                var sortedRobots = Robots.OrderByDescending(r => r.CurrentBatteryLevel).ToList();
                foreach (var robot in sortedRobots)
                {
                    if (AssignTaskToRobot(task, robot, out string message))
                    {
                        bestRobot = robot;
                        assignmentMessage = message;
                        break;
                    }
                    else
                    {
                        assignmentMessage = message;
                    }
                }

                if (bestRobot != null && !AssignedTasks.Any(t => t.Task.TaskID == task.TaskID))
                {
                    AssignedTasks.Add((task, bestRobot));
                    MessageBox.Show($"Task assigned successfully to {bestRobot.RobotModel}.");
                }
                else
                {
                    MessageBox.Show($"Task assignment failed: {assignmentMessage}");
                }

                RefreshAssignedTasksGrid();
                UpdateRobotStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private bool AssignTaskToRobot(Task task, Robot robot, out string message)
        {
            if (AssignedTasks.Any(t => t.Robot.RobotID == robot.RobotID))
            {
                message = $"Assignment failed: Robot {robot.RobotModel} is already assigned to a task.";
                return false;
            }

            if (task.RequiresEmergencyRobot && !robot.IsEmergencyRobot)
            {
                message = "Assignment failed: Task requires an emergency robot, but this robot is not designated for emergencies.";
                return false;
            }
            if (!task.RequiresEmergencyRobot && robot.IsEmergencyRobot)
            {
                message = "Assignment failed: Task is non-emergency, but this robot is designated for emergencies only.";
                return false;
            }

            if (task.LoadWeight > robot.MaxLoadCapacity)
            {
                message = $"Assignment failed: Task weight ({task.LoadWeight} kg) exceeds robot's capacity ({robot.MaxLoadCapacity} kg).";
                return false;
            }

            foreach (var (existingTask, _) in AssignedTasks)
            {
                if (existingTask.ScheduledStartTime == task.ScheduledStartTime &&
                    (existingTask.PickLocation == task.PickLocation || existingTask.DropLocation == task.DropLocation))
                {
                    message = $"Assignment failed: Pick or drop location ({task.PickLocation}/{task.DropLocation}) is occupied at the scheduled time.";
                    return false;
                }
            }

            if (robot.CurrentBatteryLevel < 25)
            {
                message = $"Assignment failed: Robot's battery level ({robot.CurrentBatteryLevel}%) is too low.";
                return false;
            }

            try
            {
                robot.ValidateLastServiceDate();
            }
            catch (Exception ex)
            {
                message = $"Assignment failed: {ex.Message}";
                return false;
            }

            message = $"Task assigned to robot {robot.RobotModel} (ID: {robot.RobotID}, Battery: {robot.CurrentBatteryLevel}%).";
            return true;
        }

        private void RefreshAssignedTasksGrid(string filterStatus = "All")
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Task ID", typeof(string));
            dataTable.Columns.Add("Pick Location", typeof(string));
            dataTable.Columns.Add("Drop Location", typeof(string));
            dataTable.Columns.Add("Weight (kg)", typeof(float));
            dataTable.Columns.Add("Start Time", typeof(string));
            dataTable.Columns.Add("Emergency", typeof(bool));
            dataTable.Columns.Add("Robot Model", typeof(string));
            dataTable.Columns.Add("Robot Battery (%)", typeof(float));
            dataTable.Columns.Add("Status", typeof(string));

            var allTasks = AssignedTasks.Concat(CompletedTasks).ToList();
            foreach (var (task, robot) in allTasks)
            {
                if (filterStatus == "All" || task.Status == filterStatus)
                {
                    if (!dataTable.AsEnumerable().Any(row => row.Field<string>("Task ID") == task.TaskID.ToString()))
                    {
                        dataTable.Rows.Add(
                            task.TaskID,
                            task.PickLocation,
                            task.DropLocation,
                            task.LoadWeight,
                            task.ScheduledStartTime.ToString("yyyy-MM-dd HH:mm"),
                            task.RequiresEmergencyRobot,
                            robot.RobotModel,
                            robot.CurrentBatteryLevel,
                            task.Status
                        );
                    }
                }
            }

            dgvAssignedTasks.DataSource = dataTable;
            dgvAssignedTasks.ClearSelection();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgvAssignedTasks_SelectionChanged(object sender, EventArgs e)
        {
            btnCompleteTask.Enabled = dgvAssignedTasks.SelectedRows.Count > 0;
        }

        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAssignedTasks.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a task to complete.");
                    return;
                }

                var selectedRow = dgvAssignedTasks.SelectedRows[0];
                var taskId = selectedRow.Cells["Task ID"].Value.ToString();
                var taskToComplete = AssignedTasks.FirstOrDefault(t => t.Task.TaskID.ToString() == taskId);
                if (taskToComplete.Task != null)
                {
                    taskToComplete.Task.Status = "Completed";
                    CompletedTasks.Add(taskToComplete);
                    AssignedTasks.Remove(taskToComplete);
                    RefreshAssignedTasksGrid(cmbTaskFilter.SelectedItem?.ToString() ?? "All");
                    MessageBox.Show($"Task {taskId} marked as completed.");
                    UpdateRobotStatus();
                }
                else
                {
                    MessageBox.Show("Error: Selected task not found in assigned tasks.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing task: {ex.Message}");
            }
        }

        private void btnShowRobots_Click(object sender, EventArgs e)
        {
            var robotStatus = "Available Robots:\n\n";
            foreach (var robot in Robots)
            {
                var isAssigned = AssignedTasks.Any(t => t.Robot.RobotID == robot.RobotID);
                robotStatus += $"Model: {robot.RobotModel}, Capacity: {robot.MaxLoadCapacity} kg, Battery: {robot.CurrentBatteryLevel}%, Emergency: {robot.IsEmergencyRobot}, Status: {(isAssigned ? "Assigned" : "Available")}\n";
            }
            MessageBox.Show(robotStatus, "Robot Status");
        }

        private void cmbTaskFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAssignedTasksGrid(cmbTaskFilter.SelectedItem?.ToString() ?? "All");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Empty handler to resolve compilation error (if still needed)
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Empty handler to resolve compilation error (if still needed)
        }

        // Event handlers for txtRobotModel
        private void txtRobotModel_Enter(object sender, EventArgs e)
        {
            if (txtRobotModel.Text == "Enter robot model")
            {
                txtRobotModel.Text = "";
            }
        }

        private void txtRobotModel_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRobotModel.Text))
            {
                txtRobotModel.Text = "Enter robot model";
            }
        }

        // Event handlers for txtMaxLoadCapacity
        private void txtMaxLoadCapacity_Enter(object sender, EventArgs e)
        {
            if (txtMaxLoadCapacity.Text == "Enter capacity (kg)")
            {
                txtMaxLoadCapacity.Text = "";
            }
        }

        private void txtMaxLoadCapacity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaxLoadCapacity.Text))
            {
                txtMaxLoadCapacity.Text = "Enter capacity (kg)";
            }
        }

        // Event handlers for txtCurrentBatteryLevel
        private void txtCurrentBatteryLevel_Enter(object sender, EventArgs e)
        {
            if (txtCurrentBatteryLevel.Text == "Enter battery (%)")
            {
                txtCurrentBatteryLevel.Text = "";
            }
        }

        private void txtCurrentBatteryLevel_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentBatteryLevel.Text))
            {
                txtCurrentBatteryLevel.Text = "Enter battery (%)";
            }
        }

        // Event handlers for txtNewBatteryLevel
        private void txtNewBatteryLevel_Enter(object sender, EventArgs e)
        {
            if (txtNewBatteryLevel.Text == "Enter new battery level (%)")
            {
                txtNewBatteryLevel.Text = "";
            }
        }

        private void txtNewBatteryLevel_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewBatteryLevel.Text))
            {
                txtNewBatteryLevel.Text = "Enter new battery level (%)";
            }
        }

        // Event handlers for txtNewMaxLoadCapacity
        private void txtNewMaxLoadCapacity_Enter(object sender, EventArgs e)
        {
            if (txtNewMaxLoadCapacity.Text == "Enter new capacity (kg)")
            {
                txtNewMaxLoadCapacity.Text = "";
            }
        }

        private void txtNewMaxLoadCapacity_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewMaxLoadCapacity.Text))
            {
                txtNewMaxLoadCapacity.Text = "Enter new capacity (kg)";
            }
        }

        private void groupBoxTaskManagement_Enter(object sender, EventArgs e)
        {
        }

        private void groupBoxStatus_Enter(object sender, EventArgs e)
        {
            // Empty handler for now (you can add functionality later if needed)
        }
    }
}