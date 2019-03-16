using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class SpeechRecognizer : MonoBehaviour
{
    KeywordRecognizer KeywordRecognizerObj ;
     public string[] keyword_array;
     private Animator anim;
    public AudioSource[] sound;
    
    void Start()
    {
        KeywordRecognizerObj = new KeywordRecognizer(keyword_array);
        KeywordRecognizerObj.OnPhraseRecognized += OnkeywordsRecognized;
        KeywordRecognizerObj.Start();

        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource[]>();

    }

    void OnkeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword : " + args.text + "- Confidence : " + args.confidence);
        ActionPerformer(args.text);
 
    }
    
    //delay of 1 second = 1100Hz 
    //Play() takes value in Hz
    void ActionPerformer (string command)
    {
       if(command.Contains("jump"))
       {
           anim.Play("jump", -1, 0);
           sound[0].Play(0);
       } 
       if(command.Contains("rage"))
       {
          anim.Play("rage" , -1 , 0);
          sound[1].Play(0);
       }
        if(command.Contains("walk"))
       {
           anim.Play("walk", -1, 0);
           //sound[2].Play(0);
       }
        if(command.Contains("sleep"))
       {
           anim.Play("sleep" , -1 , 0);
           //sound[3].Play(0);
       }
        if(command.Contains("hit"))
       {
           anim.Play("hit" , -1, 0);
           //sound[4].Play(0);
       }
    }
    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
