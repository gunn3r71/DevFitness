using System;

namespace DevFitness.API.Models.users.ViewModels
{
    /// <summary>
    /// User model
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// User id
        /// </summary>
        public int Id { get; set; }

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

        /// <summary>
        /// User status
        /// </summary>
        public bool Active { get; set; }
    }
}