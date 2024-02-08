using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUpItem : MonoBehaviour
{
    public int banana;
    public int watermelon;
    public int cherry;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundController.instance.Play("Item");
            //if the game object name is banana
            if (this.gameObject.name == "Banana")
            {
                InventoryController.Instance.bananaCount++;
                //sent to datakeeper, then show on inventory (stage 3)
            }
            //if the game object name is watermelon
            if (this.gameObject.name == "Watermelon")
            {
                InventoryController.Instance.watermelonCount++;
                //sent to datakeeper, then show on inventory (stage 3)
            }
            //if the game object name is cherry 
            if (this.gameObject.name == "Cherry")
            {
                InventoryController.Instance.cherryCount++;
                //sent to datakeeper, then show on inventory (stage 3)
            }
            
            
            Destroy(this.gameObject);
        }
    }
}
