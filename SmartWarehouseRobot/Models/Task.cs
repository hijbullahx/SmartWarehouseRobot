using System;
using System.ComponentModel.DataAnnotations;

namespace SmartWarehouseRobot.Models
{
    public class Task
    {
        public Guid TaskID { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Pick location is required.")]
        public string PickLocation { get; set; }

        [Required(ErrorMessage = "Drop location is required.")]
        public string DropLocation { get; set; }

        [Range(10, 1000, ErrorMessage = "Load weight must be between 10 and 1000 kg.")]
        public float LoadWeight { get; set; }

        [Required(ErrorMessage = "Scheduled start time is required.")]
        public DateTime ScheduledStartTime { get; set; }

        public bool RequiresEmergencyRobot { get; set; }

        [Required(ErrorMessage = "Task status is required.")]
        public string Status { get; set; } = "Assigned";
    }
}