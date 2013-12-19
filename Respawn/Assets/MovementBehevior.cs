using UnityEngine;
using System.Collections;

public class MovementBehevior : MonoBehaviour {

    // Globaly declared input array... probably bad programming but who gives a... OH GOD IT'S PUBLIC TOO!
    bool keyJump;
    bool keyW;
    bool keyLeft;
    bool keyS;
    bool keyRight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        KeyCaching();

        //Extremely basic jump function.
        //This should be refactored to take advantage of the collision system
        //and should examine the OnCollisionEnter & OnCollisionExit events 
        //(see http://docs.unity3d.com/Documentation/ScriptReference/Collision.html)
        //and determine if a jump is available based on collision, not velocity as it does now.
        if (keyJump && (rigidbody.velocity.y < 0.1 && rigidbody.velocity.y > -0.1))
        {
            constantForce.force = new Vector3(constantForce.force.x, 350, constantForce.force.z);
        }
        else
        {
            constantForce.force = new Vector3(constantForce.force.x, 0, constantForce.force.z);
        }

        //What the fuck is this 'air resistance' you talk about....
        if (keyRight)
        {
            constantForce.force = new Vector3(10, constantForce.force.y, constantForce.force.z);
        }
        else if (keyLeft)
        {
            constantForce.force = new Vector3(-10, constantForce.force.y, constantForce.force.z);
        }
        else
        {
            constantForce.force = new Vector3(0, constantForce.force.y, constantForce.force.z);
        }
	}

    /// <summary>
    /// Caches keypresses.
    /// Needs to be refactored to take in to account keybinding options.
    /// </summary>
    /* Retreving it at the beginning of a frame & storing it in memory
     * is more performance efficent than polling the Input class in every single
     * instance you require the state of a key.
     * 
     * This method of getting the keys may not be most efficent method of
     * getting input values, on a client with a fairly decent framerate this
     * would be a non-issue, however, consider a client with an extremely low FPS 
     * (5 or so), the user would only get 5 chances per second to change his 
     * input as the entire script (on this thread) must run through before it accepts
     * new input.
     * 
     * Also consider a blocking event occuring in the script (f.e. a broken function
     * or a file operation), should this event occur for any length of time the user
     * would be prevented from changing their input in order to react to occuring on-screen
     * information. Considering the reaction time of a pro-gamer is in the region of 0.4s 
     * this becomes a very large issue, one that would ultimately result in people getting VERY
     * pissed off.
     * 
     * One solution would be to simply run the input in another thread, however, this 
     * brings rise to a whole host of other problems I won't even get into.
     * A more elegant solution would be to use events to handle user input although
     * i'm not even sure if unity has events in regards to user input, much less how
     * it works internally and if it would even help.
     */
    private void KeyCaching()
    {
        keyJump = Input.GetKey(KeyCode.Space);
        keyW = Input.GetKey(KeyCode.W);
        keyLeft = Input.GetKey(KeyCode.A);
        keyS = Input.GetKey(KeyCode.S);
        keyRight = Input.GetKey(KeyCode.D);
    }
}

