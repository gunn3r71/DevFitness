using System;
using System.ComponentModel.DataAnnotations;

namespace DevFitness.API.Models.users.InputModels
{
    /// <summary>
    /// Update user model
    /// </summary>
    /// Campos nulos para escapar dos valores default
    public class UpdateUserInputModel
    {
        /// <summary>
        /// User id
        /// </summary>
        [Required(ErrorMessage = "The {0} field cannot be null.")]
        public int? Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [Required(ErrorMessage = "The {0} field cannot be null.")]
        public string FullName { get; set; }

        /// <summary>
        /// User height
        /// </summary>
        [Required(ErrorMessage = "The {0} field cannot be null.")]
        public double? Height { get; set; }

        /// <summary>
        /// User weight
        /// </summary>
        [Required(ErrorMessage = "The {0} field cannot be null.")]
        public double? Weight { get; set; }

        /// <summary>
        /// User birthdate
        /// </summary>
        [Required(ErrorMessage = "The {0} field cannot be null.")]
        public DateTime? BirthDate { get; set; }
    }
}