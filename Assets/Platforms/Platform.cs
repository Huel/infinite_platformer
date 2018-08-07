using UnityEngine;
using UnityEditor;

public class Platform : MonoBehaviour
{
	void Awake()
	{
        this.tag = GameplayConstants.TAG_Ground;    // If you get an error here, create a Tag in Unity called "Ground".
        //See the GameplayConstants.cs file for other required Tags and Layers.
        
        SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer> ();
		if (spriteRenderer != null)
		{
            MatchColliderToSpriteSize(spriteRenderer);
		}
	}

    private void MatchColliderToSpriteSize(SpriteRenderer spriteRenderer)
    {
        BoxCollider2D mainColl = this.GetComponent<BoxCollider2D>();
        BoxCollider2D leftSideColl = this.GetComponent<BoxCollider2D>();
        BoxCollider2D rightSidColl = this.GetComponent<BoxCollider2D>();
        PhysicsMaterial2D platformMaterial =   Resources.Load<PhysicsMaterial2D>("Materials/Platform_Main");
        PhysicsMaterial2D platformSideMaterial =  Resources.Load<PhysicsMaterial2D>("Materials/Platform_Side");

        if (mainColl == null)
        {
            mainColl = this.gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
            mainColl.sharedMaterial = platformMaterial;
        }
          
        if (leftSideColl == null)
        {
            leftSideColl = this.gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
            leftSideColl.sharedMaterial = platformSideMaterial;
        }
          
        if (rightSidColl == null)
        {
            rightSidColl = this.gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
            rightSidColl.sharedMaterial = platformSideMaterial;
        }

        mainColl.size = spriteRenderer.size;
        mainColl.offset = 0.5f * spriteRenderer.size.y * Vector2.up;

        leftSideColl.size = new Vector2( 0.1f , spriteRenderer.size.y );
        leftSideColl.offset = new Vector2(-0.5f * spriteRenderer.size.x,0.5f * spriteRenderer.size.y);

        rightSidColl.size = new Vector2( 0.1f , spriteRenderer.size.y );
        rightSidColl.offset = new Vector2(0.5f * spriteRenderer.size.x,0.5f * spriteRenderer.size.y);
    }
}
