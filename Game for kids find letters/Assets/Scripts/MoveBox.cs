using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBox : MonoBehaviour {
    public bool Left;
    public bool IsZadanie;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Left)
        {
            transform.Translate(0, -1 * Time.deltaTime, 0);
            if (transform.position.y < -6)
            {
                transform.position = new Vector3(transform.position.x, 6.5f, 0);
            }
        }
        else
        {
            transform.Translate(0, 1 * Time.deltaTime, 0);
            if (transform.position.y > 6)
            {
                transform.position = new Vector3(transform.position.x, -6.5f, 0);
            }
        }
	}

    private void OnMouseDown()
    {
        if (IsZadanie) SceneManager.LoadScene(0);
    }
}
