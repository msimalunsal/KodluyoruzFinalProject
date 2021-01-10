public class PedestrianAnimationController : CharacterAnimationController
{
    #region Private Methods
    private void OnEnable()
    {
        Character.OnCharacterWalk.AddListener(() => InvokeTrigger("isWalking"));
        Character.OnCharacterReach.AddListener(() => InvokeTrigger("isWaving"));
    }

    private void OnDisable()
    {
        Character.OnCharacterWalk.RemoveListener(() => InvokeTrigger("isWalking"));
        Character.OnCharacterReach.RemoveListener(() => InvokeTrigger("isWaving"));
    }
    #endregion
}
