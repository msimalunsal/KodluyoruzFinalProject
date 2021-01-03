using UnityEngine;
using UnityEngine.Events;

public enum CharacterControllerType { Player, AI }

public class Character : MonoBehaviour
{
    #region Variables
    public CharacterControllerType CharacterControllerType;
    #endregion

    #region Constructor
    public Character(CharacterControllerType controllerType)
    {
        CharacterControllerType = controllerType;
    }
    #endregion

    #region Main Properties
    private Rigidbody rigidbody;
    public Rigidbody Rigidbody { get { return (rigidbody == null) ? rigidbody = GetComponent<Rigidbody>() : rigidbody; } }

    private Collider collider;
    public Collider Collider { get { return (collider == null) ? collider = GetComponent<Collider>() : collider; } }
    #endregion

    #region Properties
    private bool isDead;
    public bool IsDead { get { return (isDead); } set { isDead = value; } }
    #endregion

    #region Character Events
    [HideInInspector]
    public UnityEvent OnCharacterDie = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterWalk = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterJump = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnCharacterSlide = new UnityEvent();
    #endregion

    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        CharacterManager.Instance.AddCharacter(this);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        CharacterManager.Instance.RemoveCharacter(this);
    }
    #endregion
}