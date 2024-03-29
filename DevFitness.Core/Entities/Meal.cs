﻿using System;
using DevFitness.Core.Entities.Base;

namespace DevFitness.Core.Entities
{
    public class Meal : Entity
    {
        protected Meal()
        {
        }

        public Meal(string description, int calories, DateTime date, int userId) : base()
        {
            Description = description;
            Calories = calories;
            Date = date;
            UserId = userId;
        }

        public string Description { get; private set; }
        public int Calories { get; private set; }
        public DateTime Date { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
    }
}
