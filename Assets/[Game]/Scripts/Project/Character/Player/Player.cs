using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : Character
{
    #region Constructor
    public Player() : base(CharacterControllerType.Player){ }
	#endregion

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
        //duration: 0.2 seconds
        //start: Vector3 (90f, 0f, 0f)
        //loop: -1 (infinite)
        rotatingCircle
            .DORotate(new Vector3(90f, 0f, -90f), .2f)
            .SetEase(Ease.Linear)
            .From(new Vector3(90f, 0f, 0f))
            .SetLoops(-1, LoopType.Incremental);
    }

	void Update()
	{
		//Mouse
#if UNITY_EDITOR
		//isMoving=true whenever mouse is clicked 
		//isMoving=falseever mouse is released

		if (Input.GetMouseButton(0))
		{
			//Move hole center
			MoveHole();
			//Update hole vertices
			HoleManager.Instance.UpdateHoleVerticesPosition(holeCenter);
		}


		//Touch
#else
		//TouchPhase.Moved to prevent hole from jumping at first touch

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved;) {
		//Move hole center
		MoveHole ();
		//Update hole vertices
		HoleManager.Instance.UpdateHoleVerticesPosition(holeCenter);
		}
#endif


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
