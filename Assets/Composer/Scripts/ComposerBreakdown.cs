using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ComposerBreakdown : MonoBehaviour
{
    public AudioSource a4, a4Sharp, b4, c4, c4Sharp, d4, d4Sharp, e4, f4, f4Sharp, g4, g4Sharp;
    public List<AudioSource> notesInComposition = new List<AudioSource>();

    public TextMeshProUGUI displaySequence;

    private IEnumerator PlaySong()
    {
        for (int i = 0; i < notesInComposition.Count; i++)
        {
          notesInComposition[i].Play();
            while (notesInComposition[i].isPlaying == true)
            {
                yield return null;
            }
        }

        notesInComposition.Clear();
        displaySequence.text = "Sequence: ";
    }

    public void PlayButton()
    {
        StartCoroutine(PlaySong());
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            notesInComposition.Add(c4);
            displaySequence.text = displaySequence.text + "C ";
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            notesInComposition.Add(c4Sharp);
            displaySequence.text = displaySequence.text + "C# ";
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            notesInComposition.Add(d4);
            displaySequence.text = displaySequence.text + "D ";
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            notesInComposition.Add(d4Sharp);
            displaySequence.text = displaySequence.text + "D# ";
        }
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            notesInComposition.Add(e4);
            displaySequence.text = displaySequence.text + "E ";
        }
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            notesInComposition.Add(f4);
            displaySequence.text = displaySequence.text + "F ";
        }
        if (Keyboard.current.uKey.wasPressedThisFrame)
        {
            notesInComposition.Add(f4Sharp);
            displaySequence.text = displaySequence.text + "F# ";
        }
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            notesInComposition.Add(g4);
            displaySequence.text = displaySequence.text + "G ";
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            notesInComposition.Add(g4Sharp);
            displaySequence.text = displaySequence.text + "G# ";
        }
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            notesInComposition.Add(a4);
            displaySequence.text = displaySequence.text + "A ";
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            notesInComposition.Add(a4Sharp);
            displaySequence.text = displaySequence.text + "A# ";
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            notesInComposition.Add(b4);
            displaySequence.text = displaySequence.text + "B ";
        }
        if (Keyboard.current.backspaceKey.wasPressedThisFrame) //remove the last note that was input into the sequence
        {
            notesInComposition.RemoveAt(notesInComposition.Count - 1);
            displaySequence.text = displaySequence.text.Substring(0, displaySequence.text.Length - 3);
        }
    }
}
