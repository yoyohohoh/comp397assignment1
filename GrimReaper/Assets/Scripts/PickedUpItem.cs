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
            //if the game object name is banana
            if (this.gameObject.name == "Banana")
            {
                banana++;
                Debug.Log("Banana: " + banana);
                //sent to datakeeper, then show on inventory (stage 3)
            }
            //if the game object name is watermelon
            if (this.gameObject.name == "Watermelon")
            {
                watermelon++;
                Debug.Log("Watermelon: " + watermelon);
                //sent to datakeeper, then show on inventory (stage 3)
            }
            //if the game object name is cherry 
            if (this.gameObject.name == "Cherry")
            {
                cherry++;
                Debug.Log("Cherry: " + cherry);
                //sent to datakeeper, then show on inventory (stage 3)
            }
            
            
            Destroy(this.gameObject);
        }
    }
}
