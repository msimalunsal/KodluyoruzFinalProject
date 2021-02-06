using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianAnimationController : MonoBehaviour
{
    #region Properties
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    Pedestrian pedestrian;
    Pedestrian Pedestrian { get { return (pedestrian == null) ? pedestrian = GetComponentInParent<Pedestrian>() : pedestrian; } }
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFinish.AddListener(() => Animator.Rebind());
        EventManager.OnLevelFail.AddListener(() => Animator.enabled = false);
        //PedestrianManager.OnPedestrianDie.AddListener(() => InvokeTrigger("Death"));
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFinish.RemoveListener(() => Animator.Rebind());
        EventManager.OnLevelFail.RemoveListener(() => Animator.enabled = false);
        // PedestrianManager.OnPedestrianDie.RemoveListener(() => InvokeTrigger("Death"));
    }
    #endregion

    #region Public Methods
    public void InvokeTrigger(string value)
    {
        Animator.SetTrigger(value);
    }
    #endregion
}
