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

	private int currentColor = 0;

	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;

	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;
	private LevelInit level;
	private GamepadInput input;

	void Start() {
		controller = GetComponent<Controller2D> ();
		level = GetComponent<LevelInit>();
		input = GetComponent<GamepadInput>();

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
	}

	void Update() {
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		int wallDirX = (controller.collisions.left) ? -1 : 1;

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

		bool wallSliding = false;
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below) {
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

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		if (this.input.ColorMixed())
		{
			Debug.Log("Color MIXED pressed.");
			if (currentColor != 3)
			{
				currentColor = 3;
				GetComponent<SpriteRenderer>().color = GameManager.instance.currentColorSet.MixedColor;
				level.SetColorOfBlocks(currentColor);
			}
		}
		else if (this.input.Color1())
		{
			Debug.Log("Color 1 pressed.");
			if (currentColor != 1)
			{
				currentColor = 1;
				GetComponent<SpriteRenderer>().color = GameManager.instance.currentColorSet.PrimaryColor;
				level.SetColorOfBlocks(currentColor);
			}
		}
		else if (this.input.Color2())
		{
			Debug.Log("Color 2 pressed.");
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

		if (this.input.Jump()) {
			if (wallSliding) {
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
				velocity.y = jumpVelocity;
			}

			if (controller.isAirborne())
			{
				velocity = input.normalized;
				velocity.Scale(new Vector3(dash, 30, 0));
			}
		}

	
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}
