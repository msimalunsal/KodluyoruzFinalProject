using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
	#region Serialize Field
	[SerializeField] Transform holeCenter;

    //rotating circle arround hole (animation)
    [SerializeField] Transform rotatingCircle;

	[Header("Hole vertices radius")]
	[SerializeField] Vector2 moveLimits;

	[Space]
    [SerializeField] float moveSpeed;
    #endregion

    #region Private Variables
    float x, y;
    Vector3 touch, targetPos;
    #endregion

    #region Private Methods

    private void OnEnable()
    {
		RotateCircleAnim();    
    }

    void RotateCircleAnim()
    {
        //rotate circle arround Y axis by -90°
        //duration: 0.5 seconds
        //start: Vector3 (90f, 0f, 0f)
        //loop: -1 (infinite)
			rotatingCircle.DORotate(new Vector3(90f, 0f, -90f), .5f)
			.SetEase(Ease.Linear)
			.From(new Vector3(90f, 0f, 0f))
			.SetLoops(-1, LoopType.Incremental);
    }

	void Update()
	{
		//Mouse
		//isMoving=true whenever mouse is clicked 
		//isMoving=falseever mouse is released
		GameData.IsCanMove = Input.GetMouseButton(0);
		if (GameData.IsCanMove && LevelManager.Instance.IsLevelStarted)
		{
			//Move hole center
			MoveHole();
			//Update hole vertices
			HoleManager.Instance.UpdateHoleVerticesPosition(holeCenter);
		}


		//Touch

		//TouchPhase.Moved to prevent hole from jumping at first touch

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
		//Move hole center
		MoveHole ();
		//Update hole vertices
		HoleManager.Instance.UpdateHoleVerticesPosition(holeCenter);
		}



	}

 
    void MoveHole()
	{
		x = Input.GetAxis("Mouse X");
		y = Input.GetAxis("Mouse Y");
		//lerp (smooth) movement
		touch = Vector3.Lerp(
			holeCenter.localPosition,
			holeCenter.localPosition + new Vector3(x, 0f, y), //move hole on x & z 
			moveSpeed * Time.deltaTime
		);

		targetPos = new Vector3(
			//Clamp: to prevent hole from going outside of the ground
			Mathf.Clamp(touch.x, -moveLimits.x, moveLimits.x),//limit X
			touch.y,
			Mathf.Clamp(touch.z, -moveLimits.y, moveLimits.y)//limit Z
		);

		holeCenter.localPosition = targetPos;
	}
    #endregion
}
