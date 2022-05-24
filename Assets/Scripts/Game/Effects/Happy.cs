using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happy : MonoBehaviour
{
    [SerializeField] Star[] stars;
    bool playing = false;
    float timer = 0.0f;
    [SerializeField] float timeSpan = 0.3f; // Time between spawing effect
    [SerializeField] float limitAxis = 0.5f; // Limit for X and Y axis (minus and positive)

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            timer += Time.deltaTime;

            if (timer >= timeSpan)
            {
                AddEffects();
            }
        }
    }

    void AddEffects()
    {
        timer = 0.0f;// Reset timer

        foreach (Star star in stars)
        {
            if (!star.IsPlaying() && Random.Range(0, 2) == 1) // Free effect and only hald of them at a  time
            {
                star.Play(new Vector3(Random.Range(limitAxis * -1.0f, limitAxis), Random.Range(limitAxis * -1.0f, limitAxis), 0.0f), Vector3.one * Random.Range(0.1f, 0.3f));
            }
        }
    }

    public void Play(Vector3 spawnPosition)
    {
        if (playing) return; // Already playing
        transform.position = spawnPosition;
        AddEffects();
        playing = true;
    }

    public void Stop()
    {
        playing = false;
    }
}
