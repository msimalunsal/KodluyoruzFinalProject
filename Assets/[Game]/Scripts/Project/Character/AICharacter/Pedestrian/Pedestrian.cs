using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Pedestrian : Character, Killable
{
    #region Constructor
    public Pedestrian() : base(CharacterControllerType.AI) { }
    #endregion

    #region Properties
    Rigidbody pedestrianRb;
    public Rigidbody PedestrianRb { get { return (pedestrianRb == null) ? pedestrianRb = GetComponent<Rigidbody>() : pedestrianRb; } }
    #endregion

    #region SerializeFields
    [SerializeField] Vector3 [] targetPoints = default;
    #endregion

    #region Private Field
    public Tween moveTween;
    float delay;
    #endregion

    #region Public methods from interfaces
    public void Kill()
    {
        EventManager.OnLevelFail.Invoke();
        moveTween.Kill();
    }
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        PedestrianSpawner.AddList(this);

        delay = Random.Range(5f, 7f);
        EventManager.OnLevelStart.AddListener(() => this.Wait(delay, Movement));
    }

    private void OnDisable()
    {
        PedestrianSpawner.RemoveList(this);

        EventManager.OnLevelStart.RemoveListener(() => this.Wait(delay, Movement));
    }
    void Movement()
    {
        if (IsDead == true)
            return;

        OnCharacterWalk.Invoke();
        // Decide how to character movement (Dotween or use physics)  
        // Goal is reach to determined point

        moveTween = transform.DOPath(targetPoints, 8f, PathType.Linear)
            .OnComplete(() => Character.OnCharacterReach.Invoke());
    }
    #endregion
}
