/*
 * Script attached to Interactables GameObject (with buttons)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObjects : MonoBehaviour
{
    //variables
    public Transform player;
    public MainMenu mainMenuScript;
    public Animation playerAnim;
    public Animator setAnim;

    //gameobjects
    public GameObject sceneGO;
    public GameObject orangeBG;
    public GameObject cityBG;
    public GameObject credits;

    //audio clips
    public AudioSource sound;
    public AudioSource music;
    public AudioClip drinking;
    public AudioClip eating;
    public AudioClip playing;
    public AudioClip litter;
    public AudioClip mouse;

    private void Start()
    {
        //get player animation component to play animationClips
        playerAnim = GetComponent<Animation>();

        //get audioSources
        sound = GetComponent<AudioSource>();
        music = GetComponent<AudioSource>();
        music.volume = 0.04f;

        //set backgrounds
        orangeBG.SetActive(true);
        cityBG.SetActive(false);
        credits.SetActive(false);
    }

    /* if player clicks on bed, place player on bed & play licking animation */
    public void Bed()
    {
        if (mainMenuScript.gameHasStarted == true)
        {
            //stops previous audio
            sound.Stop();

            //place player position on bed
            player.position = new Vector3(0f, 0f, 0f);

            //play licking animation
            setAnim.SetBool("Licking", true);

            //set everything else false
            setAnim.SetBool("Drinking", false);
            setAnim.SetBool("Eating", false);
            setAnim.SetBool("Playing", false);
            setAnim.SetBool("Litter", false);
            setAnim.SetBool("End", false);
        }
    }

    /* if player clicks on water bowl, place player in front of water bowl & play drinking animation */
    public void Water()
    {
        if (mainMenuScript.gameHasStarted == true)
        {
            //stops previous audio
            sound.Stop();

            //set player in front of water bowl
            //player.position = new Vector3(-3.77f, -3.2f, 0f);
            player.position = new Vector3(0f, 0f, 0f);

            //play drinking water animation
            setAnim.SetBool("Drinking", true);

            //set everything else false
            setAnim.SetBool("Licking", false);
            setAnim.SetBool("Eating", false);
            setAnim.SetBool("Playing", false);
            setAnim.SetBool("Litter", false);
            setAnim.SetBool("End", false);

            //play drinking sound
            sound.clip = drinking;
            sound.volume = 1f;
            sound.Play();

        }
    }

    /* if player clicks on food bowl, place player in front of food bowl & play eating animation */
    public void Food()
    {
        if (mainMenuScript.gameHasStarted == true)
        {
            //stops previous audio
            sound.Stop();

            //place player position in front of food bowl
            player.position = new Vector3(0f, 0f, 0f);

            //play eating animation
            setAnim.SetBool("Eating", true);

            //set everything else false
            setAnim.SetBool("Licking", false);
            setAnim.SetBool("Drinking", false);
            setAnim.SetBool("Playing", false);
            setAnim.SetBool("Litter", false);
            setAnim.SetBool("End", false);

            //play eating sound
            sound.clip = eating;
            sound.volume = 1f;
            sound.Play();
        }
    }

    /* if player clicks on toy, place player in front of toy & play playing animation */
    public void Toy()
    {
        if (mainMenuScript.gameHasStarted == true)
        {
            //stops previous audio
            sound.Stop();

            //place player position in front of toy
            player.position = new Vector3(0f, 0f, 0f);

            //play playing animation
            setAnim.SetBool("Playing", true);

            //set everything else false
            setAnim.SetBool("Licking", false);
            setAnim.SetBool("Eating", false);
            setAnim.SetBool("Drinking", false);
            setAnim.SetBool("Litter", false);
            setAnim.SetBool("End", false);

            //play playing sound
            sound.clip = playing;
            sound.volume = 1f;
            sound.Play();
        }
    }

    /* if player clicks on litter box, place player on top of litter box & play bathroom animation */
    public void Litter()
    {
        if (mainMenuScript.gameHasStarted == true)
        {
            //stops previous audio
            sound.Stop();

            //place player position on top of litter box
            player.position = new Vector3(0f, 0f, 0f);

            //play bathroom animation
            setAnim.SetBool("Litter", true);

            //set everything else false
            setAnim.SetBool("Licking", false);
            setAnim.SetBool("Eating", false);
            setAnim.SetBool("Playing", false);
            setAnim.SetBool("Drinking", false);
            setAnim.SetBool("End", false);

            //play litter sound
            sound.clip = litter;
            sound.volume = 1f;
            sound.Play();
        }
    }

    /* if player clicks on litter box, play ending animation - END OF GAME */
    public void Hole()
    {
        if (mainMenuScript.gameHasStarted == true)
        {
            //stops previous audio
            sound.Stop();

            //place player position next to mouse hole
            player.position = new Vector3(0f, 0f, 0f);

            //play ending animation
            setAnim.SetBool("End", true);

            //set everything else false
            setAnim.SetBool("Licking", false);
            setAnim.SetBool("Eating", false);
            setAnim.SetBool("Drinking", false);
            setAnim.SetBool("Playing", false);
            setAnim.SetBool("Litter", false);

            //play mouse sound
            sound.clip = mouse;
            sound.volume = 0.5f;
            sound.Play();

            //delete scene after a couple of seconds to match with ending animation
            StartCoroutine(deleteSceneGO());
        }
    }

    /* Deletes old home .png to make room for animation background, sets orange background to false & city background to true
     * Includes credits
     */
    public IEnumerator deleteSceneGO()
    {
        yield return new WaitForSeconds(1.57f);

        //delete old home .png since animation will have new home tearing down walls
        Destroy(sceneGO);

        //set orange background to false & city background to true
        orangeBG.SetActive(false);
        cityBG.SetActive(true);

        //include outro
        yield return new WaitForSeconds(4f);
        credits.SetActive(true);

    }
}
