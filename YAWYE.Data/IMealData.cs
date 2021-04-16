﻿using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public interface IMealData
    {
        IEnumerable<Meal> GetMealByName(string name);
        IEnumerable<Meal> GetAll();
        List<Product> AddIngredient(int pId, int mid);
        Meal LoadIngredients(Meal meal);
        Dictionary<string, decimal> GetStatistics(int mid);
        public IEnumerable<int> GetRelatedById(int mid);
        public IEnumerable<Meal> GetMealsByOwner(string owner);

    }
}
