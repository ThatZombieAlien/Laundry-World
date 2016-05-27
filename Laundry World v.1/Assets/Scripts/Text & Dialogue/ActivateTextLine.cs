// Script skrivet av Sanna Gustafsson

using UnityEngine;
using System.Collections;

public class ActivateTextLine : MonoBehaviour 
{
    public TextAsset theText;
    public int startLine;
    public int endLine;

    public TextBoxManager textManager;
    public bool destoryWhenFinished;
    public bool reqireButtonPress;
    private bool waitForPress;
    public bool timeBased;
    public float maxTime;
    public float countDown;
    private bool activated;
    public bool outOfRangeClosing;

    void Start()
    {
        textManager = FindObjectOfType<TextBoxManager>();
        countDown = maxTime;
    }

    void Update()
    {
        if (waitForPress && Input.GetKeyDown(KeyCode.E))
        {
            activated = true;
            textManager.ReloadText(theText);
            textManager.currentLine = startLine;
            textManager.endAtLine = endLine;
            textManager.EnableTextBox();

            if (destoryWhenFinished)
            {
                Destroy(gameObject);
            }
        }

        //if (timeBased && activated)  // ta bort dialog efter viss tid, ej helt fungerande
        //{
        //    countDown -= Time.deltaTime;
        //    if (countDown < 0)
        //    {
        //        textManager.DisableTextBox();
        //        countDown = maxTime;
        //    }
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (reqireButtonPress)
            {
                waitForPress = true;
                return;
            }
            activated = true;
            textManager.ReloadText(theText);
            textManager.currentLine = startLine;
            textManager.endAtLine = endLine;
            textManager.EnableTextBox();

            if (destoryWhenFinished)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            waitForPress = false; // inte kan aktivera textbox utanför zonen
            if (outOfRangeClosing)
            {
                textManager.DisableTextBox();
            }
        }
    }
}