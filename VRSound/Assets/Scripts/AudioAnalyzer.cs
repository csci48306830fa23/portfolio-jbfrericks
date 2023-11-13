using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using VelUtils.VRInteraction;

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

    private Quaternion initialRotation;
    private Vector3 initialPosition;
    public float maxRotation = 360.0f;
    //public AudioSource audioSource;
    public VRDial volumeDial;
    public VRDial bassDial;
    public VRDial midDial;
    public VRDial trebleDial;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        clipSampleData = new float[sampleDataLength];
        audioSource.clip = audioClips[currentClipIndex];
        initialRotation = transform.localRotation;
        initialPosition = transform.localPosition;
        

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
        if(volumeDial.GrabbedBy!=null)
        {
            Vector3 localEulerAnglesVolume = volumeDial.transform.localEulerAngles;
            float volAngle = localEulerAnglesVolume.y;

            Debug.Log(volAngle);

            UpdateVolume(volAngle);
        }
        if (bassDial.GrabbedBy != null)
        {
            float bassLevel = GetDialLevel(bassDial);
            float bass = ConvertLevelToDecibels(bassLevel);
            Debug.Log(bassLevel);
            audioMixer.SetFloat("BassGain", bass);
        }
        if (midDial.GrabbedBy != null)
        {
            float midLevel = GetDialLevel(midDial);
            audioMixer.SetFloat("MidGain", ConvertLevelToDecibels(midLevel));
            //audioMixer.SetFloat("MidHigh", ConvertLevelToDecibels(midLevel));
        }
        if (trebleDial.GrabbedBy != null)
        {
            float trebleLevel = GetDialLevel(trebleDial);
            audioMixer.SetFloat("TrebleGain", ConvertLevelToDecibels(trebleLevel));
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

    void UpdateVolume(float angle)
    {
        float volume = angle / maxRotation;
        Debug.Log(volume);
        audioSource.volume = volume;
    }
    float GetDialLevel(VRDial dial)
    {
        // Get the angle of the dial and convert it to a 0-1 range for level
        Vector3 localEulerAngles = dial.transform.localEulerAngles;
        float angle = localEulerAngles.y; // Assuming y is the axis of rotation for the dials
        return angle / maxRotation; // This converts the angle to a level between 0 and 1
    }
    float ConvertLevelToDecibels(float level)
    {
        // Convert the linear volume level to decibels.
        // -80dB is silence, 0dB is full volume.
        return (level * 6.0f) - 3.0f;
    }
}

