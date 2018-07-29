using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMan : MonoBehaviour {

    //Enumerables make for a more readable state machine
    enum State
    { Begin, Animate, InputContinue, InputChoice, End };

    State currentState;
    //What choice does player choose?
    public int chosen = -1;

    //This function controls McDialogueMan, which outputs the lines
    public McDialogueMan McDialogue;
    //Outcome man knows how many outcomes for each state.  We need that for choice state to work properly.
    public OutcomeMan OMan;

    float timer;

    // Use this for initialization
    void Start ()
    {
        currentState = State.Begin;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (currentState == State.Begin)
        {
            //idk why I included this state, it seemed important at the time.
            currentState = State.Animate;
            timer = 0;
            
        }
        else if (currentState == State.Animate)
        {
            timer += Time.deltaTime;
            if (timer > Animate.animLength)//once time for animating is finished,
            {
                currentState = State.InputContinue;
            }
        }
        else if (currentState == State.InputContinue)
        {
            timer = 0;
            if (McDialogue.lastLine)
            {
                currentState = State.InputChoice;   //Send to choice state if it's the last line
            }
            else if (Input.GetAxis("DialogueAdvance") > 0)  //Look for uder input to progress
            {
                currentState = State.Animate;   //send back to animate for next line
                McDialogue.NextLine();
            }
        }
        else if (currentState == State.InputChoice)     //Choose between events
        {
            if (timer == 0)  //this will fire first tick only
            {
                int numChoices = OMan.outcomes.Count;
                Debug.Log("Choices available: " + numChoices);
                timer = 0;
                //GUI Buttons would appear here, number depeneding on number of choices
                timer = 0.05f;  //So that this will not fire twice
            }
            int input = CheckChoice();
            if (input != 0)
                chosen = input;
            //Can also be accessed thru GUI buttons with Mouse, not yet implemented.
            //They simply must change "chosen" based on which one is clicked, and disappear once one is clicked.

            //once a choice is selected, send it back to outcomeman
            if (chosen != -1)
            {
                if (OMan.ChooseEvent(chosen))
                {
                    chosen = -1;
                    currentState = State.Animate;
                    if (McDialogue.oneLine == false)//If there is only 1 line total, lastLine should not be set to false
                        McDialogue.lastLine = false;
                        //but otherwise, it should be false on the first line.
                }
            }
            
            
        }
        else if (currentState == State.End)
        {

        }


	}
    int CheckChoice()
    {
        if (Input.GetButtonDown("DialogueChoice01"))    //Future: Move this to a function, and make GUI button also activate the function.
        {
            Debug.Log("ONE PRESSED");
            return 1;
        }
        else if (Input.GetButtonDown("DialogueChoice02"))
        {
            Debug.Log("TOO PRESSED");
            return 2;
        }
        else if (Input.GetButtonDown("DialogueChoice03"))
        {
            Debug.Log("THREEEE PRESSED");
            return 3;
        }
        else if (Input.GetButtonDown("DialogueChoice04"))
        {
            Debug.Log("FOOR PRESSED");
            return 4;
        }
        else if (Input.GetButtonDown("DialogueChoice05"))
        {
            Debug.Log("FIVE PRESSED");
            return 5;
        }
        //If there is only one option, choose it.
        else if (Input.GetButtonDown("DialogueAdvance"))
        {
            Debug.Log("SPACE PRESSED");
            return 100;
        }
        else
           return 0;
    }

}
