using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    GamePlayUIController GamePlayUIController;

    private void Start()
    {

    }
    public void Update()
    {
        //if player lose all the hp, game over
        if (GamePlayUIController.Instance.health.GetComponent<Slider>().value == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
        
    
    }
    private void OnTriggerEnter(Collider collision)
    {
        //if player reach the door, go to the next level
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
