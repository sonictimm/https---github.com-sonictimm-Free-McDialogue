using System.Collections;
using System.Collections.Generic;
using System.IO;    //For File operations
using UnityEngine;
using UnityEngine.UI;

public class McDialogueMan : MonoBehaviour {

    public const string seperator = "||seperator||";    //This remains constant

    //Is this build for Wondoze?
    public bool windows;

    //Who takes part in the conversation?
    public string char1Name, char2Name, char3Name, char4Name, char5Name;
    public GameObject char1, char2, char3, char4, char5;
    GameObject speaker; //Which one is talking right now?

    public string nameSwap1, nameReplace1, nameSwap2, nameReplace2;


    public string fileName; //Name of file to load and read from
    //Note: You canNOT use this by setting it in editor, it will be overriden by OutcomeMan event0
                            //In space jelly, they were formatted like so:   Assets/Dialogue/Resources/Prototype1.txt
    List<Line> Lines = new List<Line>();

    int currentLine = 0; //While line in the event are we currently on?

    /// <summary>
    /// Four output:
    /// The text components of these bojects are used to display the text output.
    /// </summary>
    public Text lineOutput;
    public Text speakerOutput;

    //ALL OF THE ATTACHED AUDIO IN ONE LIST
    public AudioSource[] Sounds;    //Tip: make it static to access all audio even if it's only  attached to one person.
        //The way it's set up now, it will try to get audio attached to character first
            //then it will look at what's attached to his gameobject


    //Keep track of whetehr we're on the last line or not
    public bool lastLine;
    public bool oneLine;    //Prevents InputMan from setting lastLine to false when there's only one Line in this Event

    // Use this for initialization
    void Start () {
        speakerOutput.text = "Bro";
        lineOutput.text = "Shalom";
        Sounds = GetComponents<AudioSource>();   //Build list of all attached sounds

        //FOR PROJECT UNLEAVENED:
        //IF the name is supposed to be replaced with PLAYERNAME, then use player's actual name
        if (nameReplace1 == "PLAYERNAME")
        {
            /*
            //also make sure Player Name isn't blank
            if (ScoreKeeper.playerName.Length > 1)
                nameReplace1 = ScoreKeeper.playerName;
                */
        }

    }
	
	// Update is called once per frame
	void Update () {
        /*
         * 
         * 
                                                      _
                                                     //
                           _                        //
                        ,-'_`----,_                //
                       (  _~d~~_/ '~-----,        //
                       (_<_~~~~_,----==='        //
                  __    /  ~~~~=--~~~~          //
                 /  \   |   /~~                //
                 \_ |   \   \                 //
                 (_ |    \   \_              //
                   L|     \_   \_           //
                   ||       \_   \_        //
               _____U         \_   \_     //
              |  __ \           \_   \_  //
              |  \_\_|            \_   \//
              |______|              \_ //_
              |_______\               //  \
               |  |    \             //\   \
               |  |     \-_         //  |   \
               |  '-,_ / / ,-______//   |__  \
               \----  '-/_/ /||||_  ~),-   ~--\
                ~\_      /-/_'~~~/\_)/_/       ~\
           _       \_   /  / /~~/ /-__ `-/_  ,   |
         _/ ),--,    \_/  /  | / //   -,__ `/_ | |
        /   ',-, |,_   \_/  / / //    /   \  \// |
       /      _)    )-~~(   |/ /_Z--_/_   /    `/
      |  /    _~) /~    -`--/ /~ \   \ ~-/      |
      | /    ' ~,,--,  (   / /`\__\_--~~~      |
      \|        /      )  / /~~              _/
        \_            / _/ /          \    _/
          \          | // /            | _/
           `-__/     |// /            /_-
              `--,__/ / /          __--
                 _-' / /       __--
              _-'   / /    __--
           _-'     / / __-- --___
        _-'   ___-/ /--  ~~~---__`--,___
      _/   __/,--/ /,--,--_____ _~`-----'-----,
   ,-~ __,- _//_/ //__/__/_/_/_//~~~~--r-,.\  )
  |   /  _/~,/ / /             ~~~~~~~~`-`) | (
  \_,| ./ ,'  / /                       (~  o  )
  |_,|~|_/   / /                         ) _  /
  (_,|~||   / /                          |/ )/
  (_// /|  / /                           / /
  | | ||  / /                            |/
  / | || / /
 /  | ||/ /      JOUST(TM) Ostrich and Mount
(_ | ,'/ /  by Greg Berigan <gberigan@cse.unl.edu>
( `/ ||\/              August 29, 1995
 \/ | \_
 |  \_  `_
  \ ,-,\,-,`,
   \_\_\\\ \ \
    ~~~~~~~~~~~
         * */
    }

    public void NextLine()
    {
        ++currentLine;
        if (currentLine >= Lines.Count - 1) //Make a note on the last line, so that InputMan will know what to do
        {
            Debug.Log("LASTLIME");
            lastLine = true;
        }
        //Assign speaker
        SpeakerAssign(Lines[currentLine]);
        DisplayLine();

        if (speaker != null)    //This stuff all requires a speaker gameobject
        {
            speaker.GetComponent<Animate>().StartAnim(Lines[currentLine].anim);//run animation
            PlaySound(Lines[currentLine].sound);
            SpriteUpdate(Lines[currentLine].sprite);
            //Something to make idle and Speaking versions of these people appear and disappear
            
        }

        if (Lines[currentLine].stop == 1)//If stoptext = 1, then don't stop the text.   0 is default, for DO wait for user input.
        {
            NextLine();
        }

    }

    void SpeakerAssign(Line line)
    {
        if (line.speaker == char1Name)
            speaker = char1;
        else if (line.speaker == char2Name)
            speaker = char2;
        else if (line.speaker == char3Name)
            speaker = char3;
        else if (line.speaker == char4Name)
            speaker = char4;
        else if (line.speaker == char5Name)
            speaker = char5;
        //if it's none of them, then none of them are speaker, so be null.
        else
            speaker = null;
        if (speaker == char1)
        {
            Debug.Log("Char1 Speaking");
            char1.GetComponent<SpriteRenderer>().enabled = true;
            char2.GetComponent<SpriteRenderer>().enabled = false;
            char3.GetComponent<SpriteRenderer>().enabled = false;
            char4.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (speaker == char2)
        {
            Debug.Log("Char2 Speaking");

            char1.GetComponent<SpriteRenderer>().enabled = false;
            char2.GetComponent<SpriteRenderer>().enabled = true;
            char3.GetComponent<SpriteRenderer>().enabled = true;
            char4.GetComponent<SpriteRenderer>().enabled = false;

        }
    }

    void PlaySound(int sound)   //play an attached sound component
    {
        if (sound > 0)
        {
            //If sound is zero, don't play.  If it's one, play the first sound component.
            //so, we subtract 1

            //First, check the gameobject for sounds.
            if (speaker.GetComponents<AudioSource>().Length > 0)
            {
                AudioSource[] localSounds = speaker.GetComponents<AudioSource>();
                localSounds[sound - 1].Play();

            }
            else   //If object has no sounds, then use sounds ttached to this gameobject.  
                Sounds[sound - 1].Play();   //1 = first, 2 = second, etc.
            //If neither, then it should be zero, shouldn't have a sound.
        }
    }

    void SpriteUpdate(int sprite)   //WARNING: DOES NOT WORK - You cannot attach multiple sprite renderers to one gameobject, so this DOES NOT WORK.  It's possible to fix by loading sprites thru code, but I don't need to for Unleavened.
    {
        if (sprite > 0) //if zero, do nothing.
        {
            SpriteRenderer[] sprites = speaker.GetComponents<SpriteRenderer>();
            foreach (SpriteRenderer s in sprites)
            {
                s.enabled = false;  //Clear old sprite
            }
            sprites[sprite - 1].enabled = true;//activate new sprite
        }
    }

    void DisplayLine(int thisOne)   //This overload allows us to jumpt o any line in an event.  idk why we'd want to, but you're creative, so you'll find a way.
    {
        currentLine = thisOne;
        DisplayLine();
    }

    void DisplayLine()
    {


        //set speaker, can be blank
        //replace it if necessary, i.e. for player character
        if (Lines[currentLine].speaker == nameSwap1)
        {
            speakerOutput.text = nameReplace1;
        }
        else if (Lines[currentLine].speaker == nameSwap2)
        {
            speakerOutput.text = nameReplace2;
        }
        else
            speakerOutput.text = Lines[currentLine].speaker;
        //set line text
        lineOutput.text = Lines[currentLine].line;
    }

    //This version can take in a file name
    public void LoadFile(string file)
    {
        fileName = file;
        LoadFile();
    }

    void LoadFile() //set filename before loading
    {
        if (windows)//This only works if we're on Windows
        {

            try
            {
                //string fileName = ChooseFile();
                //Now actually load the file
                if (File.Exists(fileName))
                {

                    string[] textInput = File.ReadAllLines(fileName);//read whole file

                    //Clear the set of lines, so we don't read from the beginning again.
                    Lines.Clear();

                    int caseNum = 0;
                    string status = "working";
                    Line temp = new Line(); //to hold info, before it's added to Lines
                                            //Now slice it into bitty bits!
                    foreach (string lineInput in textInput)
                    {
                        if (status == "working")
                        {
                            switch (caseNum % 5)    //casenum keeps counting up, and we use it mod 5
                            {
                                case 0: //Name of speaker
                                        //If line has 1+ characters (Because saved files tend to have an empty line at end
                                    if (lineInput.Length > 0)
                                    {
                                        temp.speaker = lineInput;
                                        //Also add it to the dropdown list if not already on it
                                        //AddToCharBox(lineInput); //McDialogue Tool Only
                                    }
                                    else
                                        Debug.Log("Blank Name Detected");
                                    //No error for name being blank, in the event of narration or something.
                                    ///Seems like a dumb idea, but I can change it later.  
                                    caseNum++;
                                    break;

                                case 1: //Info line 1:  Anim, sound, sprite
                                    if (lineInput.Length >= 7)
                                    {

                                        //anim
                                        string raw = lineInput.Substring(0, 2);  //Substring: (starting position, count)
                                        temp.anim = System.Convert.ToInt32(raw);   //using System

                                        temp.sound = System.Convert.ToInt32(lineInput.Substring(3, 2));//sound
                                        temp.sprite = System.Convert.ToInt32(lineInput.Substring(6, 2));//sprite

                                        caseNum++;
                                    }
                                    else
                                    {
                                        Debug.Log("Syntax Error on Info Line 1");
                                        status = "FAIL - Syntax Error";
                                    }
                                    break;

                                case 2: //Info line 2 - Size, style, font-face
                                    if (lineInput.Length >= 5)
                                    {
                                        temp.size = System.Convert.ToInt32(lineInput.Substring(0, 3));//Font Size Modifier
                                        temp.fontStyle = System.Convert.ToInt32(lineInput.Substring(4, 1));//Font Style Modifier
                                        if (lineInput.Length >= 6)//prevent substring out of range error
                                            temp.fontFace = lineInput.Substring(6);//Font FACE Modifier - takes a string until end of line.  Can be absent
                                        caseNum++;
                                    }
                                    else
                                    {
                                        Debug.Log("Syntax Error on Info Line 2");
                                        status = "FAIL - Syntax Error";
                                    }
                                    break;

                                case 3: //Final Info line:  Stop and comment
                                    if (lineInput.Length >= 1)
                                    {
                                        temp.stop = System.Convert.ToInt32(lineInput.Substring(0, 1));//Font Style Modifier

                                        /*
                                         * Use something like this to include Comment with the Line class.   
                                         * Currently: Not implemented.
                                        if (lineInput.Length >= 6)//prevent substring out of range error
                                            temp.fontFace = lineInput.Substring(6);//Font FACE Modifier - takes a string until end of line.  Can be absent
                                         */
                                        caseNum++;
                                    }
                                    else
                                    {
                                        Debug.Log("Syntax Error on Info Line 3");
                                        status = "FAIL - Syntax Error";
                                    }
                                    break;

                                case 4: //The text of a line.  Unless we get to seperator, don't add line.
                                        //Keep adding to Details until we get to seperator 
                                    if (lineInput == seperator)  //once we get to seperator, dump detailsTemp into details list and then continue switching
                                    {
                                        //idk, but I don't think this is needed:  lines.Add((linesTemp + "\n"));    //should add a newline between lines in the text file

                                        Lines.Add(temp);    //Add temp to lines

                                        temp = new Line();  //Resets temp

                                        //Does a cool thing while reading
                                        if (Lines.Count % 3 > 0)
                                            Debug.Log("Line read successfully.");
                                        else if (Lines.Count % 3 > 1)
                                            Debug.Log("Line read successfully..");
                                        else
                                            Debug.Log("Line read successfully...");
                                        //Even cooler: TODO Make it so that for each line read, one more dot appears

                                        caseNum++;
                                    }
                                    else
                                    {
                                        temp.line += lineInput;    //adds lines to details temp until we get to seperator
                                        temp.line += "\n";
                                    }

                                    break;
                            }
                        }
                    }

                    //Success
                    Debug.Log("Load complete! " + fileName);
                    Debug.Log("Lines: " + Lines.Count);
                    //ListViewRefresh(); //Only needed in McDialogue PArser
                    //If this contains only one line, set lastline = true
                    if (Lines.Count == 1)
                    {
                        lastLine = true;
                        oneLine = true;    //Prevents InputMan from setting lastLine to false
                    }
                    else
                        oneLine = false;
                    //Now, output first line
                    currentLine = -1;
                    NextLine();

                }
                else
                {
                    Debug.Log("File not found: " + fileName);

                }

            }
            catch (System.Exception ex)
            {
                Debug.Log("Error while loading file.\n" + ex.Message);
            }
        }
///END OF WINDOWS SECTION
///BEGIN NON-WINDOWS SECTION
        else if (Resources.Load(fileName) != null)
        {
            Debug.Log("Trying to load using Resources.Load...");
            var thisFile = Resources.Load(fileName);
            Debug.Log(thisFile.GetType());

            string[] textInput = File.ReadAllLines(thisFile.ToString());//read whole file

            //Clear the set of lines, so we don't read from the beginning again.
            Lines.Clear();

            int caseNum = 0;
            string status = "working";
            Line temp = new Line(); //to hold info, before it's added to Lines
                                    //Now slice it into bitty bits!
            foreach (string lineInput in textInput)
            {
                if (status == "working")
                {
                    switch (caseNum % 5)    //casenum keeps counting up, and we use it mod 5
                    {
                        case 0: //Name of speaker
                                //If line has 1+ characters (Because saved files tend to have an empty line at end
                            if (lineInput.Length > 0)
                            {
                                temp.speaker = lineInput;
                                //Also add it to the dropdown list if not already on it
                                //AddToCharBox(lineInput); //McDialogue Tool Only
                            }
                            else
                                Debug.Log("Blank Name Detected");
                            //No error for name being blank, in the event of narration or something.
                            ///Seems like a dumb idea, but I can change it later.  
                            caseNum++;
                            break;

                        case 1: //Info line 1:  Anim, sound, sprite
                            if (lineInput.Length >= 7)
                            {

                                //anim
                                string raw = lineInput.Substring(0, 2);  //Substring: (starting position, count)
                                temp.anim = System.Convert.ToInt32(raw);   //using System

                                temp.sound = System.Convert.ToInt32(lineInput.Substring(3, 2));//sound
                                temp.sprite = System.Convert.ToInt32(lineInput.Substring(6, 2));//sprite

                                caseNum++;
                            }
                            else
                            {
                                Debug.Log("Syntax Error on Info Line 1");
                                status = "FAIL - Syntax Error";
                            }
                            break;

                        case 2: //Info line 2 - Size, style, font-face
                            if (lineInput.Length >= 5)
                            {
                                temp.size = System.Convert.ToInt32(lineInput.Substring(0, 3));//Font Size Modifier
                                temp.fontStyle = System.Convert.ToInt32(lineInput.Substring(4, 1));//Font Style Modifier
                                if (lineInput.Length >= 6)//prevent substring out of range error
                                    temp.fontFace = lineInput.Substring(6);//Font FACE Modifier - takes a string until end of line.  Can be absent
                                caseNum++;
                            }
                            else
                            {
                                Debug.Log("Syntax Error on Info Line 2");
                                status = "FAIL - Syntax Error";
                            }
                            break;

                        case 3: //Final Info line:  Stop and comment
                            if (lineInput.Length >= 1)
                            {
                                temp.stop = System.Convert.ToInt32(lineInput.Substring(0, 1));//Font Style Modifier

                                /*
                                 * Use something like this to include Comment with the Line class.   
                                 * Currently: Not implemented.
                                if (lineInput.Length >= 6)//prevent substring out of range error
                                    temp.fontFace = lineInput.Substring(6);//Font FACE Modifier - takes a string until end of line.  Can be absent
                                 */
                                caseNum++;
                            }
                            else
                            {
                                Debug.Log("Syntax Error on Info Line 3");
                                status = "FAIL - Syntax Error";
                            }
                            break;

                        case 4: //The text of a line.  Unless we get to seperator, don't add line.
                                //Keep adding to Details until we get to seperator 
                            if (lineInput == seperator)  //once we get to seperator, dump detailsTemp into details list and then continue switching
                            {
                                //idk, but I don't think this is needed:  lines.Add((linesTemp + "\n"));    //should add a newline between lines in the text file

                                Lines.Add(temp);    //Add temp to lines

                                temp = new Line();  //Resets temp

                                //Does a cool thing while reading
                                if (Lines.Count % 3 > 0)
                                    Debug.Log("Line read successfully.");
                                else if (Lines.Count % 3 > 1)
                                    Debug.Log("Line read successfully..");
                                else
                                    Debug.Log("Line read successfully...");
                                //Even cooler: TODO Make it so that for each line read, one more dot appears

                                caseNum++;
                            }
                            else
                            {
                                temp.line += lineInput;    //adds lines to details temp until we get to seperator
                                temp.line += "\n";
                            }

                            break;
                    }
                }
            }

            //Success
            Debug.Log("Load complete! " + fileName);
            Debug.Log("Lines: " + Lines.Count);
            //ListViewRefresh(); //Only needed in McDialogue PArser
            //If this contains only one line, set lastline = true
            if (Lines.Count == 1)
            {
                lastLine = true;
                oneLine = true;    //Prevents InputMan from setting lastLine to false
            }
            else
                oneLine = false;
            //Now, output first line
            currentLine = -1;
            NextLine();
        }
        else
            Debug.Log("Both load methods failed");

    }

}


//LINE CLASS, same as in Free McDialogue

public class Line
{
    public int id { get; set; }//To keep track of line number (Used only at runtime in McDialogue program)

    public string speaker { get; set; }
    public string line { get; set; }

    //Some data validation (size/number limits) on these GET/SETs would be REAL NICE - TODO-MINOR
    //While I'm dreaming, a string for comments would also be nice.  That way, when you load a file, then export, comments wopuld remain.  And a box to put them in using this app would be good too.
    //Comments would have to be included in: Export, Load, ListView, all constructors below
    //Would also be nice to have a box to type a single-line comment into a line
    public int anim { get; set; }
    public int sound { get; set; }
    public int sprite { get; set; }
    public int stop { get; set; }
    public int size { get; set; }

    public string fontFace;
    public int fontStyle;

    //Default constructor: A Blank line that does nothing
    public Line()
    {
        line = speaker = "";
        anim = sound = sprite = stop = 0;
        size = 100;
        fontFace = "";
        fontStyle = 0;
    }

    //ALMOST Full constructor, with all info EXCEPT FONT STUFF included:
    public Line(string spkr, string lineText, int animation, int snd, int stopValue, int sizeValue)
    {
        speaker = spkr;
        line = lineText;
        anim = animation;
        sound = snd;
        stop = stopValue;
        size = sizeValue;
        fontFace = "";
        fontStyle = 0;
    }
    //Full constructor, with all info included:
    public Line(string spkr, string lineText, int animation, int snd, int stopValue, int sizeValue, string face, int style)
    {
        speaker = spkr;
        line = lineText;
        anim = animation;
        sound = snd;
        stop = stopValue;
        size = sizeValue;
        fontFace = face;
        fontStyle = style;
    }

}