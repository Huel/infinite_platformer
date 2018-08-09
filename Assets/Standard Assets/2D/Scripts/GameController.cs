using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
namespace UnityStandardAssets._2D
{
	public class GameController : MonoBehaviour 
	{
		[SerializeField]
		public GameObject playerCharacter;
		[SerializeField]
		public int playerLives;

		// Use this for initialization
		public void RespawnPlayer()
		{
			playerCharacter.transform.position = new Vector3 (playerCharacter.transform.position.x,GameConstants.PLAYER_RESPAWN_HIGHT,0.0f);
			playerCharacter.gameObject.GetComponent<PlatformerCharacter2D>().Move(0.0f,false,false,true);
		}
		void Start () 
		{
			playerLives = GameConstants.PLAYER_LIVES;
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}
	}
}
