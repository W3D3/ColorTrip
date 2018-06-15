using Assets.Scripts.Level;
using UnityEngine;

namespace Assets.Scripts.Movement
{
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

        public CheckpointController LastCheckpoint;
        public Vector3 InitialPosition;

        void Start() {
            controller = GetComponent<Controller2D> ();
            level = GetComponent<LevelInit>();
            checkPoint = this.transform.position;

            gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
            jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

            canDash = true;

            InitialPosition = transform.position;
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
                //GameManager.instance.deathIsEternal();
                //this.transform.position = checkPoint;
                //this.velocity = Vector3.zero;
                Respawn();
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
                    //GameManager.instance.playJumpSound();
                    velocity.y = jumpVelocity;
                }

			
            }

            if (GamepadInput.Dash() && canDash && input.normalized.x != 0)
            {
                GameManager.instance.playDashSound();
                velocity.x = input.normalized.x * dash;
                velocity.y = 7; //very importante
                canDash = false;
            }
        
            if (!controller.collisions.zeroGravity)
            {
                velocity.y += gravity * Time.deltaTime;
            }

            controller.Move (velocity * Time.deltaTime, input);
        }

        #region public methods

        /// <summary>
        /// Respawns the player at a checkpoint or it's initial position.
        /// </summary>
        public void Respawn()
        {
            transform.position = LastCheckpoint == null ? InitialPosition : LastCheckpoint.GetRespawnPosition();
            velocity = Vector3.zero;
        }

        #endregion
    }
}
