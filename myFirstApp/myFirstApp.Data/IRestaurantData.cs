﻿using Microsoft.CodeAnalysis;
using myFirstApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace myFirstApp.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public int Id => Id;

        public InMemoryRestaurantData()

        {
            restaurants = new List<Restaurant>()
            {
            new Restaurant { Id = 1, Name= "Zimbu", Location="Manchester", Cuisine=CuisineType.Nepali },
             new Restaurant { Id = 2, Name= "Steak and BBQ hub", Location="Manchester City", Cuisine=CuisineType.American },
              new Restaurant { Id = 3, Name= "El Doritto", Location="Monroe", Cuisine=CuisineType.Mexican }
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant) 
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }
        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == UpdatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = UpdatedRestaurant.Name;
                restaurant.Location = UpdatedRestaurant.Location;
                restaurant.Cuisine = UpdatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}