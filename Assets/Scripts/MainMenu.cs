/* Add script to main menu gameobject
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //variables
    public GameObject Title;
    public GameObject StartButton;
    public GameObject QuitButton;
    public GameObject cameraTransition;
    public bool gameHasStarted;

    void Start()
    {
        //display main menu title & options
        Title.SetActive(true);
        StartButton.SetActive(true);
        QuitButton.SetActive(true);

        //game has not started
        gameHasStarted = false;
    }

    /* Starts Game & fades out menu screen while moving camera closer to game scene */
    public void StartGame()
    {
        //play a fade out animation
        Title.SetActive(false);
        StartButton.SetActive(false);
        QuitButton.SetActive(false);

        //move camera to position

        //game has started
        gameHasStarted = true;
    }

    /* Quit Game */
    public void QuitGame()
    {
        Application.Quit();
    }
}
