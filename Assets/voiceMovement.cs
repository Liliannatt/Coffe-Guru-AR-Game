using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class voiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public bool finish_mixing;

    void Start()
    {
        finish_mixing = false;

        actions.Add("finish", FinishMixing);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.Start();
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        //�������ϣ������ֹͣ
        //keywordRecognizer.Stop();
    }

    void Update()
    {
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            // The recognizer is running
            Debug.Log("Voice recognizer is running.");
        }
        else
        {
            keywordRecognizer.Start();
        }
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
        
    }

    private void FinishMixing()
    {
        finish_mixing = true;
    }

    private void OnDisable()
    {
        // ȷ�������������ʱֹͣ������ʶ����
        if (keywordRecognizer != null && keywordRecognizer.IsRunning)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }
    }

    private void OnDestroy()
    {
        // ȷ���ڶ�������ʱֹͣ������ʶ����
        if (keywordRecognizer != null)
        {
            keywordRecognizer.Stop();
            keywordRecognizer.Dispose();
        }
    }
}

