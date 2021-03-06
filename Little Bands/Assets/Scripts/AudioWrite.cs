﻿using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class AudioWrite : MonoBehaviour
{
    public string pathName;
    private AudioSource audioSource;
    public int frequency = 4400;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public AudioClip convertAudio(float[] sound)
    {
        audioSource.Stop();
        int length = sound.Length;
        audioSource.clip = AudioClip.Create("recorded samples", length, 1, frequency, false);
        audioSource.clip.SetData(sound, 0);
        audioSource.loop = true;
        return audioSource.clip;
    }

    static private byte[] SaveAudioClipToWav(AudioClip audioClip, string filename)
    {
        byte[] buffer;
        FileStream fsWrite = File.Open(filename, FileMode.Create);

        BinaryWriter bw = new BinaryWriter(fsWrite);

        Byte[] header = { 82, 73, 70, 70, 22, 10, 4, 0, 87, 65, 86, 69, 102, 109, 116, 32 };
        bw.Write(header);

        Byte[] header2 = { 16, 0, 0, 0, 1, 0, 1, 0, 68, 172, 0, 0, 136, 88, 1, 0 };
        bw.Write(header2);

        Byte[] header3 = { 2, 0, 16, 0, 100, 97, 116, 97, 152, 9, 4, 0 };

        bw.Write(header3);

        float[] samples = new float[audioClip.samples];
        audioClip.GetData(samples, 0);

        int i = 0;

        while (i < audioClip.samples)
        {
            int sampleInt = (int)(32000.0 * samples[i++]);
            int msb = sampleInt / 256;
            int lsb = sampleInt - (msb * 256);
            bw.Write((Byte)lsb);
            bw.Write((Byte)msb);
        }
        long length = fsWrite.Length;
        int lengthInt = Convert.ToInt32(length);
        buffer = new byte[lengthInt];
        fsWrite.Read(buffer, 0, lengthInt);
        return buffer;

        fsWrite.Close();
    }

    public void createMix()
    {
        SaveAudioClipToWav(GameManager.instance.guitarAudioSource.clip, pathName + "guitar.wav");
        SaveAudioClipToWav(GameManager.instance.bassAudioSource.clip, pathName + "bass.wav");
        SaveAudioClipToWav(GameManager.instance.pianoAudioSource.clip, pathName + "piano.wav");
        SaveAudioClipToWav(GameManager.instance.drumsAudioSource.clip, pathName + "drums.wav");
        SaveAudioClipToWav(GameManager.instance.voiceAudioSource.clip, pathName + "voice.wav");
        
    }

    public void playClip(int instrument)
    {

    }
}
