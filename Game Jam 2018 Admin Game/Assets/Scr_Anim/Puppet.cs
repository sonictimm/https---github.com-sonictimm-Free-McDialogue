using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puppet : MonoBehaviour {

    public GameObject[] puppets;    //stuff any actor tha moves into this, in any order.

    //public List<Movement> moves;
    //This isn't editable in editor, so , uh....
    //Rats, it's back to the old fashioned way. 
    //public int[] animate;// = 0;
    //public float[] powerMod;// = 1; You can't set defaults for a struct, unfortunately.
    //public int[] sound;// = -1;
    public int[] puppet;  //Out of thelist of puppets, which one is performing this action?
    public Transform[] destination;

    public string nextScene;

    int action;    //Which item on the list of puppets are we on?

    public float timeStop; //how long to wait before letting user input again
    float timer; 

    enum State
    { Wait, Advancing, Input };

    State currentState;

    //Lerp stuff, thanks to https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
    public Transform startMarker;   //set this to an actor at first positoin
    private Transform endMarker;
    public float speed = 1.0f;
    private float startTime;
    private float journeyLength;



    // Use this for initialization
    void Start ()
    {
        currentState = State.Wait;
        action = -1;
        transform.position = startMarker.transform.position;

	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("State: " + currentState.ToString());
        if (currentState == State.Wait) //Once timer meets timeStop, wait for input
        {
            timer += Time.deltaTime;
            if (timer >= timeStop)
            {   //reset timer, change states
                currentState = State.Input;
                timer = 0;
            }
        }
        else if (currentState == State.Input)
        {
            if (Input.GetAxis("DialogueAdvance") > 0)
            {
                //Advance action
                action++;
                currentState = State.Advancing; //Start moving (go to below state)

                if (action > puppet.Length - 1) //Once at the end, GTFO
                {
                    SceneManager.LoadScene(nextScene);
                }

                //set things for lerp to work
                startTime = Time.time;
                if (action > 0)
                    startMarker = destination[action - 1];
                endMarker = destination[action];
                journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
            }
        }
        else if (currentState == State.Advancing)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            puppets[puppet[action]].transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
            //if it's close enough, go to Wait state
            if (puppets[puppet[action]].transform.position == endMarker.position)
            {
                currentState = State.Wait;
            }
        }

    }

}

//doesn't seem to have a use
public struct Movement
{
    int animate { get; set; }   //Which animation should it play?
    int sound { get; set; }     //Which attached sound should it play (if any)
    int puppet { get; set; }    //Which member of Puppet's list of gameobjects should it access?
    Vector3 arrive { get; set; }    //Where should the gameobject go?
    /*
    Movement(int animate, int sound, int pupper, Vector3 arrive)
    {

    }
    //*/
}