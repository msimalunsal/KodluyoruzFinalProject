using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    #region Properties
    private Animator animator;
    public Animator Animator { get { return (animator == null) ? animator = GetComponent<Animator>() : animator; } }

    Character character;
    Character Character { get { return (character == null) ? character = GetComponentInParent<Character>() : character; } }
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFinish.AddListener(() => Animator.Rebind());
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFinish.RemoveListener(() => Animator.Rebind());
    }
    #endregion

    #region Public Methods
    public void InvokeTrigger(string value)
    {
        Animator.SetTrigger(value);
    }
    #endregion
}
