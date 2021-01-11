using System.Collections.Generic;
using UnityEngine;

public class CarManager : Singleton<CarManager>
{
    #region Properties
    public List<Cars> cars;
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
