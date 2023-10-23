using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalyzer : MonoBehaviour
{
    public float updateStep = 0.01f;
    public int sampleDataLength = 1024;

    private AudioSource audioSource;
    private float currentUpdateTime = 0f;

    public float clipLoudness;
    private float[] clipSampleData;

    public AudioClip[] audioClips;
    private int currentClipIndex = 0;

    public GameObject bassObject, midObject, trebleObject;
    private float[] frequencyBands = new float[3];

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clipSampleData = new float[sampleDataLength];
        audioSource.clip = audioClips[currentClipIndex];
    }

    // Update is called once per frame
    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength;

            transform.localScale = new Vector3(0.3f, 1, 0.3f) + new Vector3(clipLoudness, clipLoudness, clipLoudness);

            AnalyzeSound();
            bassObject.transform.localScale = new Vector3(0.3f, 1, 0.3f) + new Vector3(0.3f, 1, 0.3f) * frequencyBands[0];
            midObject.transform.localScale = new Vector3(0.3f, 1, 0.3f) + new Vector3(0.3f, 1, 0.3f) * frequencyBands[1];
            trebleObject.transform.localScale = new Vector3(0.3f, 1, 0.3f) + new Vector3(0.3f, 1, 0.3f) * frequencyBands[2];

        }
    }
    private void AnalyzeSound()
    {
        float[] spectrum = new float[1024];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float bass = 0f;
        float mid = 0f;
        float treble = 0f;
        int bassLimit = 20;
        int midLimit = 60;

        for (int i = 0; i < 1024; ++i)
        {
            if (i < bassLimit)
            {
                bass += spectrum[i];
            }
            else if (i < midLimit)
            {
                mid += spectrum[i];
            }
            else
            {
                treble += spectrum[i];
            }
        }

        frequencyBands[0] = bass;
        frequencyBands[1] = mid;
        frequencyBands[2] = treble;
    }
    public void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.Play();
        }
    }

    public void PauseAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
    public void ChangeAudioClip()
    {
        if (audioClips.Length > 0)
        {
            currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
            audioSource.clip = audioClips[currentClipIndex];
            PlayAudio();
        }
    }
}

