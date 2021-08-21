using System;

namespace DevFitness.API.Models.users.InputModels
{
    /// <summary>
    /// User model
    /// </summary>
    public class AddUserInputModel
    {
        /// <summary>
        /// User name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// User height
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// User weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// User birthdate
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}