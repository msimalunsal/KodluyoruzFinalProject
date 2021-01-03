using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pedestrian : Character, Killable
{
    #region Constructor
    public Pedestrian() : base(CharacterControllerType.AI) { }
    #endregion

    #region Public methods from interfaces
    public void Kill()
    {
        EventManager.OnLevelFail.Invoke();
    }
    #endregion

    #region Private Methods
    void Movement()
    {
        if (IsDead == true)
            return;

        // Decide how to character movement (Dotween or use physics)  
        // Goal is reach to determined point
    }
    #endregion
}
