﻿using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class CheckpointController : MonoBehaviour
    {
        public Vector3 RespawnPosition;
        public int Number;
        public Color32 ColorActivated;
        public bool ColorSet;

        private void Start()
        {
            ColorActivated = ColorFactory.LimeGreen;
            ColorSet = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = ColorFactory.Red;
            const float size = 0.2f;
            var actualPosition = GetRespawnPosition();
            Gizmos.DrawLine(actualPosition + Vector3.up * size, actualPosition + Vector3.down * size);
            Gizmos.DrawLine(actualPosition + Vector3.right * size, actualPosition + Vector3.left * size);
        }
    
        private void OnTriggerEnter2D(Component c)
        {
            if (c.tag != "Player") return;

            var player = c.GetComponent<Player>();
            if (player.LastCheckpoint == null)
            {
                player.LastCheckpoint = this;
            }
            else if (player.LastCheckpoint.Number < Number)
            {
                player.LastCheckpoint = this;
            }

            if (!ColorSet)
            {
                GetComponent<SpriteRenderer>().color = ColorActivated;
                ColorSet = true;
            }
        }

        public Vector3 GetRespawnPosition()
        {
            return RespawnPosition + transform.position;
        }
    }
}