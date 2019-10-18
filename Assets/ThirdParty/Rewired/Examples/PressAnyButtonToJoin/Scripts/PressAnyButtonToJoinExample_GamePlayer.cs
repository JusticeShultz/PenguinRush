// Copyright (c) 2017 Augie R. Maddox, Guavaman Enterprises. All rights reserved.

using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Rewired.Demos
{
    [AddComponentMenu("")]
    [RequireComponent(typeof(Rigidbody))]
    public class PressAnyButtonToJoinExample_GamePlayer : MonoBehaviour
    {
        public int playerId = 0;

        public float moveSpeed = 3.0f;
        public Animator animator;
        public Sprite ReadyIcon;
        public UnityEngine.UI.Image PlayerReadyIcon;
        public AudioSource soundEmitter;
        public List<AudioClip> sources;
        private Rigidbody rb;
        private Vector3 moveVector;
        private bool aButton;

        private Rewired.Player player { get { return ReInput.isReady ? ReInput.players.GetPlayer(playerId) : null; } }

        void OnEnable()
        {
            // Get the character controller
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if(!ReInput.isReady) return; // Exit if Rewired isn't ready. This would only happen during a script recompile in the editor.
            if(player == null) return;

            aButton = player.GetButtonDown("Fire");

            if (aButton && !PressAnyButtonToJoinExample_Assigner.GameStarted)
            {
                PlayerReadyIcon.gameObject.name = "Ready";
                PlayerReadyIcon.sprite = ReadyIcon;
            }

            if (PressAnyButtonToJoinExample_Assigner.GameStarted && !WinState.GameWon)
            {
                animator.SetBool("HandsUp", player.GetButton("Fire"));

                GetInput();
                ProcessInput();
            }
        }

        private void GetInput()
        {
            // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
            // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

            moveVector.x = player.GetAxis("Move Horizontal"); // get input by name or action id
            moveVector.y = player.GetAxis("Move Vertical");
        }

        private void ProcessInput()
        {
            animator.SetBool("Moving", moveVector.magnitude > 0.1f);

            rb.AddForce(Vector3.Normalize(new Vector3(moveVector.x, 0, moveVector.y)) * Time.deltaTime * moveSpeed, ForceMode.Acceleration);
            
            if (rb.velocity.magnitude >= 0.3f)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rb.velocity, Vector3.up), 0.1f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.name == "Player 1" || other.transform.name == "Player 2" ||
                other.transform.name == "Player 3" || other.transform.name == "Player 4")
                soundEmitter.PlayOneShot(sources[Random.Range(0, sources.Count)]);
        }
    }
}