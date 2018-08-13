using UnityEngine;
using UnityEditor;

public class Platform : MonoBehaviour
{
	void Awake()
	{
        this.tag = GameplayConstants.TAG_Ground;    // If you get an error here, create a Tag in Unity called "Ground".
        //See the GameplayConstants.cs file for other required Tags and Layers.
        
        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();

		if (spriteRenderer != null)
		{
            MatchColliderToSpriteSize(spriteRenderer);
		}
	}

    private void MatchColliderToSpriteSize(SpriteRenderer spriteRenderer)
    {
        //Removing old coliders
        BoxCollider2D[] colliders = this.GetComponents<BoxCollider2D>();

        foreach(var collider in colliders)
        {
            Destroy(collider);
        }

        BoxCollider2D mainColl;
        BoxCollider2D leftSideColl;
        BoxCollider2D rightSidColl;

        PhysicsMaterial2D platformMaterial =   Resources.Load<PhysicsMaterial2D>("Materials/Platform_Main");
        PhysicsMaterial2D platformSideMaterial =  Resources.Load<PhysicsMaterial2D>("Materials/Platform_Side");

     
        mainColl = this.gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        leftSideColl = this.gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        rightSidColl = this.gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
       
        mainColl.sharedMaterial = platformMaterial;
        leftSideColl.sharedMaterial = platformSideMaterial;
        rightSidColl.sharedMaterial = platformSideMaterial;

        mainColl.size = spriteRenderer.size;
        mainColl.offset = 0.5f * spriteRenderer.size.y * Vector2.up;

        leftSideColl.size = new Vector2( 0.1f , spriteRenderer.size.y );
        leftSideColl.offset = new Vector2(-0.5f * spriteRenderer.size.x,0.5f * spriteRenderer.size.y);

        rightSidColl.size = new Vector2( 0.1f , spriteRenderer.size.y );
        rightSidColl.offset = new Vector2(0.5f * spriteRenderer.size.x,0.5f * spriteRenderer.size.y);
    }
}
