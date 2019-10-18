// Copyright (c) 2017 Augie R. Maddox, Guavaman Enterprises. All rights reserved.

/* Disable Joystick Auto-Assignment in the Rewired Input Manager
 * so no joysticks are assigned to any Players at the start of the game.
 * Once assignment is complete, enable joystick auto-assignment
 */

namespace Rewired.Demos {

    using UnityEngine;
    using System.Collections.Generic;
    using Rewired;
    using UnityEngine.SceneManagement;

    [AddComponentMenu("")]
    public class PressAnyButtonToJoinExample_Assigner : MonoBehaviour
    {
        public static bool GameStarted = false;
        public GameObject p1;
        public GameObject p2;
        public GameObject p3;
        public GameObject p4;
        public GameObject MenuScreen;
        public GameObject GameScreen;
        public UnityEngine.UI.Text countdownText;
        public Sprite readySprite;

        private float Countdown = 5;

        private void Start()
        {
            Countdown = 5;
            GameStarted = false;
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        }

        private void Update()
        {
            if (p1.transform.name == "Ready" && p2.transform.name == "Ready" && p3.transform.name == "Ready" && p4.transform.name == "Ready")
            {
                if (Countdown <= -1)
                {
                    GameStarted = true;
                    MenuScreen.SetActive(false);
                    GameScreen.SetActive(true);
                    enabled = false;
                }
                else
                {
                    Countdown -= Time.deltaTime;
                    countdownText.text = "Starting in " + Mathf.CeilToInt(Countdown);
                }
            }

            if(!ReInput.isReady) return;
            AssignJoysticksToPlayers();
        }

        private void AssignJoysticksToPlayers()
        {
            // Check all joysticks for a button press and assign it tp
            // the first Player foudn without a joystick
            IList<Joystick> joysticks = ReInput.controllers.Joysticks;
            for(int i = 0; i < joysticks.Count; i++) {

                Joystick joystick = joysticks[i];
                if(ReInput.controllers.IsControllerAssigned(joystick.type, joystick.id)) continue; // joystick is already assigned to a Player

                // Chec if a button was pressed on the joystick
                if(joystick.GetAnyButtonDown()) {

                    // Find the next Player without a Joystick
                    Player player = FindPlayerWithoutJoystick();
                    if(player == null) return; // no free joysticks

                    // Assign the joystick to this Player
                    player.controllers.AddController(joystick, false);
                }
            }

            // If all players have joysticks, enable joystick auto-assignment
            // so controllers are re-assigned correctly when a joystick is disconnected
            // and re-connected and disable this script
            if(DoAllPlayersHaveJoysticks()) {
                ReInput.configuration.autoAssignJoysticks = true;
            }
        }

        // Searches all Players to find the next Player without a Joystick assigned
        private Player FindPlayerWithoutJoystick() {
            IList<Player> players = ReInput.players.Players;
            for(int i = 0; i < players.Count; i++) {
                if(players[i].controllers.joystickCount > 0) continue;
                return players[i];
            }
            return null;
        }

        private bool DoAllPlayersHaveJoysticks() {
            return FindPlayerWithoutJoystick() == null;
        }
    }
}