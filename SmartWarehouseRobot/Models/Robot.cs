using System;
using System.ComponentModel.DataAnnotations;

namespace SmartWarehouseRobot.Models
{
    public class Robot
    {
        public Guid RobotID { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Robot model is required.")]
        public string RobotModel { get; set; }

        [Range(10, 1000, ErrorMessage = "Max load capacity must be between 10 and 1000 kg.")]
        public float MaxLoadCapacity { get; set; }

        [Range(0, 100, ErrorMessage = "Battery level must be between 0 and 100%.")]
        public float CurrentBatteryLevel { get; set; }

        public DateTime LastServiceDate { get; set; }
        public bool IsEmergencyRobot { get; set; }

        public void ValidateLastServiceDate()
        {
            if (LastServiceDate < DateTime.Now.AddDays(-45))
            {
                throw new Exception($"Robot {RobotModel} is overdue for service (last serviced on {LastServiceDate:yyyy-MM-dd}).");
            }
        }
    }
}