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

        private void Start()
        {
            if (!playManager)
                playManager = GameObject.Find("PlayManager");
            
            gameController = playManager.GetComponent(typeof(GameController)) as GameController;
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
