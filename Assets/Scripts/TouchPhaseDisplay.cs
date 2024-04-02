using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchPhaseDisplay : MonoBehaviour
{
    public TMP_Text phaseDisplayText;
    public GameObject targetObject;
    private Touch theTouch;
   

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            //phaseDisplayText.text = theTouch.phase.ToString();

            if (theTouch.phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(theTouch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Book1"))
                    {
                        //the martin
                        // Load another scene
                        SceneManager.LoadScene("TheMartian");
                        
                    }
                    else if (hit.collider.gameObject.CompareTag("Book2"))
                    {
                        //arabic
                        Application.OpenURL("https://www.jarir.com/sa-en/arabic-books-443269.html");
                        // Load another scene
                        //SceneManager.LoadScene(1);

                    }

                    if (hit.collider.gameObject.CompareTag("Book3"))
                    {
                        //such fun age
                        Application.OpenURL("https://www.jarir.com/sa-en/penguin-english-books-569853.html");
                        // Load another scene
                        //SceneManager.LoadScene(1);

                    }
                }

            }
        }
        
    }
}
