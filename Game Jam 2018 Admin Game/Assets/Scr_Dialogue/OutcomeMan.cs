using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutcomeMan : MonoBehaviour {

    public McDialogueMan dMan;  //What dialogue manager will we use to read the text files and output the lines?

    //List of possible events.  This string holds text files for the location of these events.
    public string event0, event1, event2, event3, event4, event5, event6, event7, event8, event9, event10, event11, event12, event13, event14, event15 ;
    string currentEvent;
    ///Outcomes for each event.
    ///Example: 2|5|
    ///Outcomes are strings made up of ints seperated by |pipelines.   Event has the number of pipelines in its output 
    ///Once an event is read to the end, the player gets choices as to what to do.
    ///If the outcome CHOSEN is 0-15, that number event will be 
    public string outcomes0, outcomes1, outcomes2, outcomes3, outcomes4, outcomes5, outcomes6, outcomes7, outcomes8, outcomes9, outcomes10, outcomes11, outcomes12, outcomes13, outcomes14, outcomes15;
    public List<int> outcomes;

    public string level101, level102, level103, level104, level105;

    //which set of event/outcome are we on?
    int thisEvent = 0;

    // Use this for initialization
    void Start ()
    {
        //Load first event, event0
        SetEvent(0);
        dMan.LoadFile(event0);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //Select next event, based on input from InputMan
    public bool ChooseEvent(int e)
    {
        Debug.Log("Event picked: " + e);
        if (outcomes.Count > (e - 1))    //If that's a valid option
        {
            thisEvent = outcomes[e - 1];    //since we start from 0
            SetEvent(thisEvent);
            dMan.LoadFile(currentEvent);
            return true;
        }
        else if (e == 100)  //handle advancing with space if there is only one option
        {
            if (outcomes.Count == 1)    //Only if there is only one option
            {
                thisEvent = outcomes[0];    //since we start from 0
                SetEvent(thisEvent);
                dMan.LoadFile(currentEvent);
                return true;
            }
            else
            {
                Debug.Log("You must choose a choice when there is more than one option");
                return false;
            }
        }
        else
        {
            Debug.Log("That's not an option, soldier!  See OutcomeMan ChooseEvent");//If it's not a valid option
            return false;
        }

        
    }

    //when we change event number, set event and outcomes appropriately
    void SetEvent(int i)
    {
        switch (i)
        {
            case 0:
                currentEvent = event0;
                setOutcomes(outcomes0);
                break;
            case 1:
                currentEvent = event1;
                setOutcomes(outcomes1);
                break;
            case 2:
                currentEvent = event2;
                setOutcomes(outcomes2);
                break;
            case 3:
                currentEvent = event3;
                setOutcomes(outcomes3);
                break;
            case 4:
                currentEvent = event4;
                setOutcomes(outcomes4);
                break;
            case 5:
                currentEvent = event5;
                setOutcomes(outcomes5);
                break;
            case 6:
                currentEvent = event6;
                setOutcomes(outcomes6);
                break;
            case 7:
                currentEvent = event7;
                setOutcomes(outcomes7);
                break;
            case 8:
                currentEvent = event8;
                setOutcomes(outcomes8);
                break;
            case 9:
                currentEvent = event9;
                setOutcomes(outcomes9);
                break;
            case 10:
                currentEvent = event10;
                setOutcomes(outcomes10);
                break;
            case 11:
                currentEvent = event11;
                setOutcomes(outcomes11);
                break;
            case 12:
                currentEvent = event12;
                setOutcomes(outcomes12);
                break;
            case 13:
                currentEvent = event13;
                setOutcomes(outcomes13);
                break;
            case 14:
                currentEvent = event14;
                setOutcomes(outcomes14);
                break;
            case 15:
                currentEvent = event15;
                setOutcomes(outcomes15);
                break;
           //Load LEvels, dictated by strings
            case 101:
                PlayerPrefs.SetInt("DialogueOutcome", 101);
                SceneManager.LoadScene(level101);
                break;
            case 102:
                PlayerPrefs.SetInt("DialogueOutcome", 102);
                SceneManager.LoadScene(level102);
                break;
            case 103:
                PlayerPrefs.SetInt("DialogueOutcome", 103);
                SceneManager.LoadScene(level103);
                break;
            case 104:
                PlayerPrefs.SetInt("DialogueOutcome", 104);
                SceneManager.LoadScene(level104);
                break;
            case 105:
                PlayerPrefs.SetInt("DialogueOutcome", 105);
                SceneManager.LoadScene(level105);
                break;
        }
    }

    void setOutcomes(string source)
    {
        //clear previous outcomes
        outcomes.Clear();
        //read first char, add it to a string
        string thisOutcome = "";
        foreach (char c in source)
        {
            if (c == '|')
            //keep reading chars until you hit a pipeline
            //after hitting pipe, convert that string to an int and add it to a list
                //repeat above until another pipeline or end of string source
            {
                outcomes.Add(Convert.ToInt32(thisOutcome)); //String to number, add  to list, clear string
                thisOutcome = "";
                Debug.Log("Outcome list item added");
            }
            else
            {
                thisOutcome += c; //add character to string
            }

        }
        //at end of string source, done.

    }
}
