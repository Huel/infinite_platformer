using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        [SerializeField]
        public GameObject playManager;
        [SerializeField]
        public GameController  gameController;
        [SerializeField]
        public GameObject  playerCharacter;

        private Transform playerTransform;

        private void Start()
        {
            if (!playManager)
                playManager = GameObject.Find("PlayManager");
            
            gameController = playManager.GetComponent(typeof(GameController)) as GameController;

            if (!playerCharacter)
                playerCharacter = GameObject.Find("CharacterRobotBoy");

            playerTransform = playerCharacter.GetComponent<Transform>();

        }

        private void Update() 
        {
            this.gameObject.transform.position = new Vector3(playerTransform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                --gameController.playerLives;

                if (gameController.playerLives <1 )
                {
                     Debug.Log("OUT OF LIVES!");
                }
                else
                    gameController.RespawnPlayer();        
            }
        }
    }
}
