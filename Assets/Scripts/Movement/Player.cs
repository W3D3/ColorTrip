using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Must;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public float jumpHeight = 4;
	public float moveSpeed = 10;
	public float timeToJumpApex = .4f;
	public float dash = 10;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;

	private int currentColor;

	public Vector2 wallLeap;

	public Vector3 checkPoint;

	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;
	private LevelInit level;

    private bool canDash;

	void Start() {
		controller = GetComponent<Controller2D> ();
		level = GetComponent<LevelInit>();
		checkPoint = this.transform.position;

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);

	    canDash = true;
	}

	void Update() {
		Vector2 input = new Vector2 (GamepadInput.HorizontalVal(), 0);
		int wallDirX = (controller.collisions.left) ? -1 : 1;

		float targetVelocityX = input.x * moveSpeed;
	    if (controller.collisions.zeroGravity)
	    {
	        if (Mathf.Abs(velocity.x) < 0.0001f)
	        {
	            velocity.x = 1 * Mathf.Sign(velocity.x) == 0f ? 1 : Mathf.Sign(velocity.x);
	        }
	    }
	    else
	    {
	        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        }

        bool wallSliding = false;

		if (controller.collisions.death)
		{
			GameManager.instance.DeathCounter++;
			GameManager.instance.deathIsEternal();
			this.transform.position = checkPoint;
			this.velocity = Vector3.zero;
			controller.collisions.death = false;
			return;
			
		}
		
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && !controller.collisions.zeroGravity) {
			wallSliding = true;

			if (velocity.y < -wallSlideSpeedMax) {
				velocity.y = -wallSlideSpeedMax;
			}

			if (timeToWallUnstick > 0) {
				velocityXSmoothing = 0;
				velocity.x = 0;

				if (input.x != wallDirX && input.x != 0) {
					timeToWallUnstick -= Time.deltaTime;
				}
				else {
					timeToWallUnstick = wallStickTime;
				}
			}
			else {
				timeToWallUnstick = wallStickTime;
			}

		}

		if ((controller.collisions.above || controller.collisions.below) && !controller.collisions.zeroGravity) {
			velocity.y = 0;
		}

	    if (controller.collisions.below)
	    {
	        canDash = true;
	    }
        
        if (controller.collisions.isCheckpoint)
	    {
	        checkPoint = controller.collisions.checkpoint;
	    }

		if (GamepadInput.ColorMixed())
		{
			if (currentColor != 3)
			{
				currentColor = 3;
				GetComponent<SpriteRenderer>().color = GameManager.instance.currentColorSet.MixedColor;
				level.SetColorOfBlocks(currentColor);
			}
		}
		else if (GamepadInput.Color1())
		{
			if (currentColor != 1)
			{
				currentColor = 1;
				GetComponent<SpriteRenderer>().color = GameManager.instance.currentColorSet.PrimaryColor;
				level.SetColorOfBlocks(currentColor);
			}
		}
		else if (GamepadInput.Color2())
		{
			if (currentColor != 2)
			{
				currentColor = 2;
				GetComponent<SpriteRenderer>().color = GameManager.instance.currentColorSet.SecondaryColor;
				level.SetColorOfBlocks(currentColor);
			}
		}
		else
		{
			if (currentColor != 0)
			{
				currentColor = 0;
				GetComponent<SpriteRenderer>().color = Color.black;
				level.SetColorOfBlocks(currentColor);
			}
		}

		if (GamepadInput.Jump()) {
			if (wallSliding) {
				GameManager.instance.playJumpSound();
				/*if (wallDirX == input.x || input.x == 0) {
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = wallJumpOff.y;
				}
				else {*/
					velocity.x = -wallDirX * wallLeap.x;
					velocity.y = wallLeap.y;
				//}
			}
			if (controller.collisions.below) {
				GameManager.instance.playJumpSound();
				velocity.y = jumpVelocity;
			    Debug.Log("jump");
            }

			
		}

	    if (GamepadInput.Dash() && canDash)
	    {
		    GameManager.instance.playDashSound();
	        velocity.x = input.normalized.x * dash;
	        canDash = false;
        }
        
	    if (!controller.collisions.zeroGravity)
	    {
	        velocity.y += gravity * Time.deltaTime;
	    }

		controller.Move (velocity * Time.deltaTime, input);
	}
	
}
