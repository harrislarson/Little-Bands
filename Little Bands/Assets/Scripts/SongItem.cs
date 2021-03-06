﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongItem : MonoBehaviour
{
    [Header("Song Information")]
    public Texture albumArt;
    public string title;
    public string artist;
    public string length;

    [Header("Original Audio")]
    public AudioClip original_full_audio;
    public AudioClip original_guitar;
    public AudioClip original_bass;
    public AudioClip original_piano;
    public AudioClip original_drums;
    public AudioClip original_voice;

    [Header ("Instruction Audio")]
    public AudioClip instruction_guitar;
    public AudioClip instruction_bass;
    public AudioClip instruction_piano;
    public AudioClip instruction_drums;
    public AudioClip instruction_voice;
    
    [Header("Recorded Audio")]
    public float[] recorded_guitar;
    public float[] recorded_bass;
    public float[] recorded_piano;
    public float[] recorded_drums;
    public float[] recorded_voice;

    public AudioClip recorded_guitarClip;
    public AudioClip recorded_bassClip;
    public AudioClip recorded_pianoClip;
    public AudioClip recorded_drumsClip;
    public AudioClip recorded_voiceClip;

    [Header("List Item UI Objects")]
    public GameObject albumArt_image;
    public GameObject title_text;
    public GameObject artist_text;
    public GameObject length_text;
    public GameObject badge_guitar;
    public GameObject badge_bass;
    public GameObject badge_piano;
    public GameObject badge_drums;
    public GameObject badge_voice;

    public int guitarToggleCount;
    public int bassToggleCount;
    public int pianoToggleCount;
    public int drumsToggleCount;
    public int voiceToggleCount;
    


    // Start is called before the first frame update
    void Start()
    {
        // Set all song list item UI elements
        title_text.GetComponent<UnityEngine.UI.Text>().text = title;
        artist_text.GetComponent<UnityEngine.UI.Text>().text = artist;
        length_text.GetComponent<UnityEngine.UI.Text>().text = length;
        albumArt_image.GetComponent<UnityEngine.UI.RawImage>().texture = albumArt;

        // preset all audio to teacher tracks
        guitarToggleCount = 0;
        bassToggleCount = 0;
        pianoToggleCount = 0;
        drumsToggleCount = 0;
        voiceToggleCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
