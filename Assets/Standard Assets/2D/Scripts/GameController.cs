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
		private Transform playerCharacterTransform;
		private PlatformerCharacter2D playerController;
		[SerializeField]
		public int playerLives;

		[SerializeField]
		public GameObject mainCamera;

		private Transform mainCameraTransform;
		private Vector3 velocity = Vector3.zero;


		// Use this for initialization
		void Start () 
		{
			if(!playerCharacter)
				playerCharacter = GameObject.Find("CharacterRobotBoy");

			playerCharacterTransform = playerCharacter.GetComponent<Transform>();
			playerController = playerCharacter.GetComponent<PlatformerCharacter2D>();
			
			if(!mainCamera)
				mainCamera = GameObject.Find("MainCamera");

			 mainCameraTransform = mainCamera.GetComponent<Transform>();

			playerLives = GameConstants.PLAYER_LIVES;
		}
		
		// Update is called once per frame
		void Update () 
		{		
			float newPositionX = playerCharacterTransform.position.x;

			if(playerController.GetFacingRight())
			{
				newPositionX += GameConstants.CAMERA_OFFSET;
			}
			else
				newPositionX -=GameConstants.CAMERA_OFFSET;

			Vector3 targetPosition = new Vector3(newPositionX,playerCharacterTransform.position.y,mainCameraTransform.gameObject.transform.position.z);
			mainCameraTransform.position = Vector3.SmoothDamp(mainCameraTransform.position,targetPosition,ref velocity,GameConstants.CAMERA_SMOOTH_TIME);
		}
		public void RespawnPlayer()
		{
			playerCharacter.transform.position = new Vector3 (playerCharacter.transform.position.x,GameConstants.PLAYER_RESPAWN_HIGHT,0.0f);
			playerCharacter.gameObject.GetComponent<PlatformerCharacter2D>().Move(0.0f,false,false,true);
		}
	}
}
