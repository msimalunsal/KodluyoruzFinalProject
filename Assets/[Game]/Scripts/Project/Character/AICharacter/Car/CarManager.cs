using System.Collections.Generic;
using UnityEngine;

public class CarManager : Singleton<CarManager>
{
    #region Fields
    List<Cars> cars = new List<Cars>();
    #endregion

    #region Public Methods
    public void AddCar(Cars car)
    {
        if (!cars.Contains(car))
            cars.Add(car);
    }

    public void RemoveCar(Cars car)
    {
        if (cars.Contains(car))
            cars.Remove(car);
    }
    
    /// <summary>
    /// Set disable all cars
    /// </summary>
    public void Initiliaze()
    {
        foreach (var car in cars)
        {
            car.enabled = false;
        }
    }

    /// <summary>
    /// It does on enable the car at position given to itself
    /// </summary>
    /// <param name="car"></param>
    /// <param name="spawnTransform"></param>
    public void DoEnable(Cars car, Transform spawnTransform)
    {
        if (cars.Contains(car))
        {
            car.transform.position = spawnTransform.position;
            car.enabled = true;
        }            
    }

    /// <summary>
    /// It returns a random car from cars list
    /// </summary>
    /// <returns></returns>
    public Cars GetRandomCar()
    {
        int randIndex = Random.Range(0, cars.Count);
        return cars[randIndex];
    }
    #endregion
}
