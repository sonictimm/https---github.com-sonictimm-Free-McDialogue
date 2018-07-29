using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sonictimm, 2018

public class Animate : MonoBehaviour {  //This is placed ona  gameobject to enable small in-game animations to move it around

    public static bool debug;
    /*
     * 1 - 
     * 2 - 
     * 3 - 
     * 4 - Left and Right Zigzag
     * 5- 
     * */

    int animState;
    int lastAnim;
    float timer;
    static public float animLength = 0.5f;
    float animPower = 1;

    Quaternion initialRot;

    //bool testDone;
    
    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    void Update ()
    {
        /*  For testingL preview an animation after 3 seconds
        if ((Time.time > 3) && (testDone == false))
        {
            testDone = true;
            StartAnim(4);
        }
         //*/

        

        //handle states here:
		if (animState == 0)
        {
            if (lastAnim != 0)
                timer = 0;
        }
        else   //If we'er animating, handle that
        {
            timer += Time.deltaTime;
            //StartCoroutine(Move4(gameObject, timer, animLength));
        }

        //For debug, print animstate
        if (debug)
            Debug.Log("AnimState = " + animState);
        lastAnim = animState;
	}

    //Start animation: This is called by other scripts
    public void StartAnim(int anim, float timeTotal = 0.5f, float power = 1)
    {
        if (anim != animState)
        {
            //If we're nto changing states, don't worry about it.
            animState = anim;
            timer = 0;
            //run the proper animation
            switch (anim)
            {
                case 0:
                    break;
                case 1:
                    StartCoroutine(Move1(gameObject, animLength, power));
                    break;
                case 2:
                    StartCoroutine(Move2(gameObject, animLength, power));
                    break;
                case 3:
                    StartCoroutine(Move3(gameObject, animLength, power));
                    break;
            case 4:
                StartCoroutine(Move4(gameObject, animLength, power));
                break;
            case 5:
                StartCoroutine(Move5(gameObject, animLength, power));
                break;
                /*
            case 6:
                StartCoroutine(Move6(gameObject, animLength, power));
                break;*/
                case 7:
                    StartCoroutine(Move7(gameObject, animLength, power));
                    break;
                case 10:
                    StartCoroutine(Move10(gameObject, animLength, power));
                    break;
                case 11:
                    StartCoroutine(Move11(gameObject, animLength, power));
                    break;
                case 12:
                    StartCoroutine(Move12(gameObject, animLength, power));
                    break;
                case 13:
                    StartCoroutine(Move13(gameObject, animLength, power));
                    break;
                case 14:
                    StartCoroutine(Move14(gameObject, animLength, power));
                    break;
                case 15:
                    StartCoroutine(Move15(gameObject, animLength, power));
                    break;
                case 22:
                    StartCoroutine(Move22(gameObject, animLength, power));
                    break;
                case 23:
                    StartCoroutine(Move23(gameObject, animLength, power));
                    break;
                case 30:
                    StartCoroutine(Move30(gameObject, animLength, power));
                    break;
                case 31:
                    StartCoroutine(Move31(gameObject, animLength, power));
                    break;
                case 32:
                    StartCoroutine(Move32(gameObject, animLength, power));
                    break;
                case 33:
                    StartCoroutine(Move33(gameObject, animLength, power));
                    break;
                case 40:
                    StartCoroutine(Move40(gameObject, animLength, power));
                    break;
                case 41:
                    StartCoroutine(Move41(gameObject, animLength, power));
                    break;
                case 42:
                    StartCoroutine(Move42(gameObject, animLength, power));
                    break;
                case 43:
                    StartCoroutine(Move43(gameObject, animLength, power));
                    break;
                case 44:
                    StartCoroutine(Move44(gameObject, animLength, power));
                    break;
                case 50:
                    StartCoroutine(Move50(gameObject, animLength, power));
                    break;
                case 51:
                    StartCoroutine(Move51(gameObject, animLength, power));
                    break;
                case 52:
                    StartCoroutine(Move52(gameObject, animLength, power));
                    break;
                case 53:
                    StartCoroutine(Move53(gameObject, animLength, power));
                    break;
                case 61:
                    StartCoroutine(Move61(gameObject, animLength, power));
                    break;
                case 63:
                    StartCoroutine(Move63(gameObject, animLength, power));
                    break;

                case 64:
                    StartCoroutine(Move64(gameObject, animLength, power));
                    break;
                case 70:
                    StartCoroutine(Move70(gameObject, animLength, power));
                    break;
                case 71:
                    StartCoroutine(Move71(gameObject, animLength, power));
                    break;

                case 80:
                    StartCoroutine(Move80(gameObject, animLength, power));
                    break;
                    //*/

            }   //end switch
            
        }

    }

    /*
    //This is called by the looop to run the coroutine
    void doAnim(GameObject go, int anim, float elapsed, float timeTotal = 0.5f, float power = 1, float speed = 1)
    {
        //Choose which animation coroutine to actually do
        StartCoroutine(Move4(go, elapsed,timeTotal));

    }
     //* */

    IEnumerator Move1(GameObject character, float animLength = 0.5f, float animPower = 1)    //hop up and down once
    {
        //set power
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            //print("movve 1 triggered");
            if ((timer < (animLength / 2)))
            {
                //Debug.Log("up");
                character.transform.Translate(0, power, 0);
                yield return null;
            }
            else
            {
                if ((timer < animLength) && (timer > 0))
                {
                    character.transform.Translate(0, -power, 0);
                    yield return null;
                }
                else
                {
                    //print("ResetPosition");
                    //ResetPositions();
                    //end this thread
                    notDone = false;
                    AnimStateReset();
                }
            }
        }
    }

    IEnumerator Move2(GameObject character, float animLength = 0.5f, float animPower = 1)  //hop twice
    {

        //set power
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {

            if ((timer < (animLength / 4)))
            {
                character.transform.Translate(0, power, 0);
                yield return null;
            }
            else if ((timer < (animLength / 2)))
            {

                character.transform.Translate(0, -power, 0);
                yield return null;
            }
            else if ((timer < (animLength / 4) * 3))
            {
                character.transform.Translate(0, power, 0);
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                character.transform.Translate(0, -power, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                AnimStateReset();
            }
        }
    }

    IEnumerator Move3(GameObject character, float animLength = 0.5f, float animPower = 1) //hop 4x
    {
        //set power
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength / 4)))
            {
                if (timer < animLength / 8)
                    character.transform.Translate(0, power, 0);
                else
                    character.transform.Translate(0, -power, 0);
                yield return null;
            }
            else if ((timer < (animLength / 2)))
            {
                if (timer < (animLength / 8) * 3)
                    character.transform.Translate(0, power, 0);
                else
                    character.transform.Translate(0, -power, 0);
                yield return null;
            }
            else if ((timer < (animLength / 4) * 3))
            {
                if (timer < (animLength / 8) * 5)
                    character.transform.Translate(0, power, 0);
                else
                    character.transform.Translate(0, -power, 0);
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                if (timer < (animLength / 8) * 7)
                    character.transform.Translate(0, power, 0);
                else
                    character.transform.Translate(0, -power, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                AnimStateReset();
            }
        }

    }

    IEnumerator Move4(GameObject character, float animLength = 0.5f, float animPower = 1) //FALL quickly, then come back up
    {

        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength / 5)))
            {

                character.transform.Translate(0, -5 * power, 0);

                yield return null;
            }
            else if ((timer < (animLength)))
            {
                character.transform.Translate(0, power, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                animState = 0;
                AnimStateReset();

            }
        }
    }//end of move4

    IEnumerator Move5(GameObject character, float animLength = 0.5f, float animPower = 1) //Sink slowly, then return
    {

        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength * 0.5)))
            {

                character.transform.Translate(0, -power, 0);

                yield return null;
            }
            else if ((timer < (animLength * 0.8)))
            {
                character.transform.Translate(0, power, 0);
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                character.transform.Translate(0, 2.5f*power, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                animState = 0;
                AnimStateReset();

            }
        }
    }

    IEnumerator Move7(GameObject character, float animLength = 0.5f, float animPower = 1)    //hop up and down once, SMALLER
    {
        //set power
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            //print("movve 1 triggered");
            if ((timer < (animLength / 2)))
            {
                //Debug.Log("up");
                character.transform.Translate(0, power * 0.4f, 0);
                yield return null;
            }
            else
            {
                if ((timer < animLength) && (timer > 0))
                {
                    character.transform.Translate(0, -power * 0.4f, 0);
                    yield return null;
                }
                else
                {
                    //print("ResetPosition");
                    //ResetPositions();
                    //end this thread
                    notDone = false;
                    AnimStateReset();
                }
            }
        }
    }

    IEnumerator Move10(GameObject character, float animLength = 0.5f, float animPower = 1) //zig zag left and right
    {
        
        float power = animPower * 5 *  Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength / 3)))
            {
                Debug.Log("Stage 1");
                if (timer < (animLength / 6) * 0.5)    //so that it stays centered near original position.  Without this, it would move around a position starting to the RIGHT of origin.
                    character.transform.Translate(power, 0, 0);
                else
                    character.transform.Translate(-power, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength / 3) * 2))
            {
                Debug.Log("Stage 2");
                if (timer < (animLength / 6) * 3)
                    character.transform.Translate(power, 0, 0);
                else
                    character.transform.Translate(-power, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                Debug.Log("Stage 3");
                if (timer < (animLength / 6) * 5.5)
                    character.transform.Translate(power, 0, 0);
                else
                    character.transform.Translate(-power, 0, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                animState = 0;
                Debug.Log("DONE!");
                AnimStateReset();

            }
        }
    }//end of move10


    IEnumerator Move11(GameObject character, float animLength = 0.5f, float animPower = 1) //Move Right, hold, move back
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength / 4)))
            {
                character.transform.Translate(power, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength / 4) * 3))
            {
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                character.transform.Translate(-power, 0, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move12(GameObject character, float animLength = 0.5f, float animPower = 1) //Move left, hold, move back
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength / 4)))
            {
                character.transform.Translate(-power, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength / 4) * 3))
            {
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                character.transform.Translate(power, 0, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move13(GameObject character, float animLength = 0.5f, float animPower = 1) //FAST Right, hold, move back.
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength / 4)))
            {
                character.transform.Translate(power * 2, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength / 2)))
            {
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                character.transform.Translate(-power, 0, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move14(GameObject character, float animLength = 0.5f, float animPower = 1) //FAST Left, hold, move back.
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength / 4)))
            {
                character.transform.Translate(-power * 2, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength / 2)))
            {
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                character.transform.Translate(power, 0, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move15(GameObject character, float animLength = 0.5f, float animPower = 1) //Quick shake R-L-R-L-R-L-back
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {   //Division of time: 1/12, then 3/12, 5/12, 7/12, 9/12, 11/12, and finally back to origin.
            if ((timer < (animLength / 12) ))
            {
                character.transform.Translate(power, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength / 12) * 3))
            {
                character.transform.Translate(-power * 2, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength / 12) * 5))
            {
                character.transform.Translate(power * 2, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength / 12) * 7))
            {
                character.transform.Translate(-power * 2, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength / 12) * 9))
            {
                character.transform.Translate(power * 2, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength / 12) * 11))
            {
                character.transform.Translate(-power * 2, 0, 0);
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                character.transform.Translate(power, 0, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move22(GameObject character, float animLength = 0.5f, float animPower = 1) //Jump Right, then back
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength * 0.15f)))
            {
                character.transform.Translate(power , power, 0);
                yield return null;
            }
            else if ((timer < (animLength * 0.3f)))
            {
                character.transform.Translate(power, -power, 0);

                yield return null;
            }
            else if ((timer < (animLength * 0.7f)))
            {
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                character.transform.Translate(-power, 0, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move23(GameObject character, float animLength = 0.5f, float animPower = 1) //JUMP LEFT, then back
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength * 0.15f)))
            {
                character.transform.Translate(-power, power, 0);
                yield return null;
            }
            else if ((timer < (animLength * 0.3f)))
            {
                character.transform.Translate(-power, -power, 0);

                yield return null;
            }
            else if ((timer < (animLength * 0.7f)))
            {
                yield return null;
            }
            else if ((timer < (animLength)))
            {
                character.transform.Translate(power, 0, 0);
                yield return null;
            }

            else
            {
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move30(GameObject character, float animLength = 0.5f, float animPower = 1) //Rotate object clockwise once
    {
        float power = animPower * 5 * Time.deltaTime;

        //save rotation
        initialRot = new Quaternion(character.transform.rotation.x, character.transform.rotation.y, character.transform.rotation.z, character.transform.rotation.w);

        bool notDone = true;
        while (notDone)
        {
            if ((timer < animLength))
            {
                character.transform.rotation = Quaternion.Euler(character.transform.rotation.eulerAngles.x, character.transform.rotation.eulerAngles.y,     //does not change x or y axes
                    (timer / animLength) * -360 + initialRot.eulerAngles.z);   //sets z axis using %done of animation (timer / animlength) * 360 (for euler) + initial rotation on z axis (so that it starts at its initial rotation and ends at initial + 360

                yield return null;
            }

            else
            {
                //ResetRotation
                character.transform.rotation = initialRot;

                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move31(GameObject character, float animLength = 0.5f, float animPower = 1) //Rotate CCW once
    {

        //save rotation
        initialRot = new Quaternion(character.transform.rotation.x, character.transform.rotation.y, character.transform.rotation.z, character.transform.rotation.w);

        bool notDone = true;
        while (notDone)
        {
            if ((timer < animLength))
            {
                character.transform.rotation = Quaternion.Euler(character.transform.rotation.eulerAngles.x, character.transform.rotation.eulerAngles.y,     //does not change x or y axes
                    (timer / animLength) * 360 + initialRot.eulerAngles.z);   //sets z axis using %done of animation (timer / animlength) * 360 (for euler) + initial rotation on z axis (so that it starts at its initial rotation and ends at initial + 360

                yield return null;
            }

            else
            {
                //ResetRotation
                character.transform.rotation = initialRot;

                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move32(GameObject character, float animLength = 0.5f, float animPower = 1) //Rotate object clockwise x2
    {
        float power = animPower * 5 * Time.deltaTime;

        //save rotation
        initialRot = new Quaternion(character.transform.rotation.x, character.transform.rotation.y, character.transform.rotation.z, character.transform.rotation.w);

        bool notDone = true;
        while (notDone)
        {
            if ((timer < animLength))
            {
                character.transform.rotation = Quaternion.Euler(character.transform.rotation.eulerAngles.x, character.transform.rotation.eulerAngles.y,     //does not change x or y axes
                    (timer / animLength) * -360 * 2 + initialRot.eulerAngles.z);   //sets z axis using %done of animation (timer / animlength) * 360 (for euler) + initial rotation on z axis (so that it starts at its initial rotation and ends at initial + 360

                yield return null;
            }

            else
            {
                //ResetRotation
                character.transform.rotation = initialRot;

                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move33(GameObject character, float animLength = 0.5f, float animPower = 1) //Rotate CCW x2
    {

        //save rotation
        initialRot = new Quaternion(character.transform.rotation.x, character.transform.rotation.y, character.transform.rotation.z, character.transform.rotation.w);

        bool notDone = true;
        while (notDone)
        {
            if ((timer < animLength))
            {
                character.transform.rotation = Quaternion.Euler(character.transform.rotation.eulerAngles.x, character.transform.rotation.eulerAngles.y,     //does not change x or y axes
                    (timer / animLength) * 360  * 2+ initialRot.eulerAngles.z);   //sets z axis using %done of animation (timer / animlength) * 360 (for euler) + initial rotation on z axis (so that it starts at its initial rotation and ends at initial + 360

                yield return null;
            }

            else
            {
                //ResetRotation
                character.transform.rotation = initialRot;

                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move40(GameObject character, float animLength = 0.5f, float animPower = 1) //Blast off UP
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {   //Division of time: 1/12, then 3/12, 5/12, 7/12, 9/12, 11/12, and finally back to origin.
            if ((timer < (animLength )))
            {
                character.transform.Translate( 0, power * timer * 25, 0);
                yield return null;
            }
            
            else
            {
                Destroy(character); //Destroy actor after it's done, since they're gone forever
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move41(GameObject character, float animLength = 0.5f, float animPower = 1) //Blast off DOWN
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {   //Division of time: 1/12, then 3/12, 5/12, 7/12, 9/12, 11/12, and finally back to origin.
            if ((timer < (animLength)))
            {
                character.transform.Translate(0, -power * timer * 25, 0);
                yield return null;
            }

            else
            {
                Destroy(character); //Destroy actor after it's done, since they're gone forever
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move42(GameObject character, float animLength = 0.5f, float animPower = 1) //Blast off LEFT
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {   //Division of time: 1/12, then 3/12, 5/12, 7/12, 9/12, 11/12, and finally back to origin.
            if ((timer < (animLength)))
            {
                character.transform.Translate(power * timer * 25, 0,0);
                yield return null;
            }

            else
            {
                Destroy(character); //Destroy actor after it's done, since they're gone forever
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move43(GameObject character, float animLength = 0.5f, float animPower = 1) //Blast off RIGHT
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {   //Division of time: 1/12, then 3/12, 5/12, 7/12, 9/12, 11/12, and finally back to origin.
            if ((timer < (animLength)))
            {
                character.transform.Translate(-power * timer * 25, 0, 0);
                yield return null;
            }

            else
            {
                Destroy(character); //Destroy actor after it's done, since they're gone forever
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move44(GameObject character, float animLength = 0.5f, float animPower = 1) //Blast off DOWN after jumping UP
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength / 3)))//first go up
            {
                character.transform.Translate(0,power * 0.5f, 0);
                yield return null;
            }
            else if ((timer < (animLength)))    //now go down
            {
                character.transform.Translate(0,-power * (timer - (timer/3)) * 25, 0);
                yield return null;
            }

            else
            {
                Destroy(character); //Destroy actor after it's done, since they're gone forever
                //ResetPositions();
                //end this thread
                AnimStateReset();
                notDone = false;
            }
        }
    }

    IEnumerator Move50(GameObject character, float animLength = 0.5f, float animPower = 1) //Go and STAY to the RIGHT
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength)))
            {
                character.transform.Translate(power,0, 0);
                yield return null;
            }
            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                AnimStateReset();
            }
        }
    }

    IEnumerator Move51(GameObject character, float animLength = 0.5f, float animPower = 1) //Go and STAY to the LEFT
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength)))
            {
                character.transform.Translate(-power, 0, 0);
                yield return null;
            }
            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                AnimStateReset();
            }
        }
    }

    IEnumerator Move52(GameObject character, float animLength = 0.5f, float animPower = 1) //Go and STAY to the UP
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength)))
            {
                character.transform.Translate(0, power, 0);
                yield return null;
            }
            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                AnimStateReset();
            }
        }
    }

    IEnumerator Move53(GameObject character, float animLength = 0.5f, float animPower = 1) //Go and STAY to the DOWN
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength)))
            {
                character.transform.Translate(0, -power, 0);
                yield return null;
            }
            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                AnimStateReset();
            }
        }
    }

    IEnumerator Move61(GameObject character, float animLength = 0.5f, float animPower = 1) //Shake violently
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength)))
            {
                character.transform.Translate(UnityEngine.Random.Range(-power, power), UnityEngine.Random.Range(-power, power), 0);
                yield return null;
            }
            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                AnimStateReset();
            }
        }
    }

    IEnumerator Move63(GameObject character, float animLength = 0.5f, float animPower = 1) //Rotate and shake violently
    {
        float power = animPower * 5 * Time.deltaTime;

        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength)))
            {
                character.transform.Translate(UnityEngine.Random.Range(-power, power), UnityEngine.Random.Range(-power, power), 0);
                character.transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(-60, 60)));
                //yield return new WaitForEndOfFrame();
                yield return null;
                //yield return null;
            }
            else
            {
                //ResetPositions();
                //end this thread
                notDone = false;
                AnimStateReset();

            }
        }
    }

    
    IEnumerator Move64(GameObject character, float animLength = 0.5f, float animPower = 1) //Rotate and shake violently, then return to original orientation
    {
        float power = animPower * 5 * Time.deltaTime;
        initialRot = new Quaternion(character.transform.rotation.x,character.transform.rotation.y, character.transform.rotation.z, character.transform.rotation.w);
         //save initial rotation
        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength)))
            {
                character.transform.Translate(UnityEngine.Random.Range(-power, power), UnityEngine.Random.Range(-power, power), 0);
                character.transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(-60, 60)));
                //yield return new WaitForEndOfFrame();
                yield return null;
                //yield return null;
            }
            else
            {
                //ResetOrientation();
                character.transform.rotation = initialRot;

                //end this thread
                notDone = false;
                AnimStateReset();

            }
        }
    }


    IEnumerator Move70(GameObject character, float animLength = 0.5f, float animPower = 1) //Make it appear, if invisible.
    {
        
        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength * 0.5f)))
            {
                yield return null;
            }
            else
            {
                //enable sprite renderer, if exists
                if (character.GetComponentInChildren<SpriteRenderer>())
                {
                    //handle ALL sprite renderers
                    foreach ( SpriteRenderer n in character.GetComponentsInChildren<SpriteRenderer>())
                    {
                        n.enabled = true;
                    }
                }
                    //character.GetComponent<SpriteRenderer>().enabled = true; //This could only handle one spriterenderer

                //end this thread
                notDone = false;
                AnimStateReset();

            }
        }
    }


    IEnumerator Move71(GameObject character, float animLength = 0.5f, float animPower = 1) //If visible, make disappear
    {
        bool notDone = true;
        while (notDone)
        {
            if ((timer < (animLength * 0.5f)))
            {
                yield return null;
            }
            else
            {
                //enable sprite renderer, if exists
                if (character.GetComponentInChildren<SpriteRenderer>())
                    //handle ALL sprite renderers
                    foreach (SpriteRenderer n in character.GetComponentsInChildren<SpriteRenderer>())
                    {
                        n.enabled = false;
                    }

                //end this thread
                notDone = false;
                AnimStateReset();

            }
        }
    }

    IEnumerator Move80(GameObject character, float animLength = 0.5f, float animPower = 1)    //hop up and down once
    {

        float initialScaleX = character.transform.localScale.x;
        float initialScaleY = character.transform.localScale.y;

        bool notDone = true;
        while (notDone)
        {
        //set power
        float power = animPower * 10 * Time.deltaTime;
            //print("movve 1 triggered");
            if ((timer < (animLength / 2)))
            {
                //Increase Size
                character.transform.localScale = new Vector3 (character.transform.localScale.x + power , character.transform.localScale.y + power, character.transform.localScale.z);
                yield return null;
            }
            else
            {
                if ((timer < animLength) && (timer > 0))
                {
                    //Decrease Size
                    character.transform.localScale = new Vector3(character.transform.localScale.x - power, character.transform.localScale.y - power, character.transform.localScale.z);
                    yield return null;
                }
                else
                {
                    //print("ResetPosition");
                    //ResetPositions();
                    //end this thread
                    notDone = false;
                    AnimStateReset();
                }
            }
        }
    }

    void AnimStateReset()
    {
        animState = 0;
    }
    

}
/*
 *
                              ...,?77??!~~~~!???77?<~.... 
                        ..?7`                           `7!.. 
                    .,=`          ..~7^`   I                  ?1. 
       ........  ..^            ?`  ..?7!1 .               ...??7 
      .        .7`        .,777.. .I.    . .!          .,7! 
      ..     .?         .^      .l   ?i. . .`       .,^ 
       b    .!        .= .?7???7~.     .>r .      .= 
       .,.?4         , .^         1        `     4... 
        J   ^         ,            5       `         ?<. 
       .%.7;         .`     .,     .;                   .=. 
       .+^ .,       .%      MML     F       .,             ?, 
        P   ,,      J      .MMN     F        6               4. 
        l    d,    ,       .MMM!   .t        ..               ,, 
        ,    JMa..`         MMM`   .         .!                .; 
         r   .M#            .M#   .%  .      .~                 ., 
       dMMMNJ..!                 .P7!  .>    .         .         ,, 
       .WMMMMMm  ?^..       ..,?! ..    ..   ,  Z7`        `?^..  ,, 
          ?THB3       ?77?!        .Yr  .   .!   ?,              ?^C 
            ?,                   .,^.` .%  .^      5. 
              7,          .....?7     .^  ,`        ?. 
                `<.                 .= .`'           1 
                ....dn... ... ...,7..J=!7,           ., 
             ..=     G.,7  ..,o..  .?    J.           F 
           .J.  .^ ,,,t  ,^        ?^.  .^  `?~.      F 
          r %J. $    5r J             ,r.1      .=.  .% 
          r .77=?4.    ``,     l ., 1  .. <.       4., 
          .$..    .X..   .n..  ., J. r .`  J.       `' 
        .?`  .5        `` .%   .% .' L.'    t 
        ,. ..1JL          .,   J .$.?`      . 
                1.          .=` ` .J7??7<.. .; 
                 JS..    ..^      L        7.: 
                   `> ..       J.  4. 
                    +   r `t   r ~=..G. 
                    =   $  ,.  J 
                    2   r   t  .; 
              .,7!  r   t`7~..  j.. 
              j   7~L...$=.?7r   r ;?1. 
               8.      .=    j ..,^   .. 
              r        G              . 
            .,7,        j,           .>=. 
         .J??,  `T....... %             .. 
      ..^     <.  ~.    ,.             .D 
    .?`        1   L     .7.........?Ti..l 
   ,`           L  .    .%    .`!       `j, 
 .^             .  ..   .`   .^  .?7!?7+. 1 
.`              .  .`..`7.  .^  ,`      .i.; 
.7<..........~<<3?7!`    4. r  `          G% 
                          J.` .!           % 
                            JiJ           .` 
                              .1.         J 
                                 ?1.     .'         
                                     7<..%

    
     https://www.ascii-code.com/ascii-art/video-games/sonic-the-hedgehog.php
     */
