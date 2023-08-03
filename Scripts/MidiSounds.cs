using System.Collections;
using UnityEngine;

namespace VHon
{
    public static class MidiSounds
    {
        //===============================================================================================================================
        // this.PlayMidi(440, 0.12f, 0.4f);
        //===============================================================================================================================
        public static void PlayMidi<T>(this T obj, float frequency, float volume, float duration) where T : Component
        {
            int sampleRate = 44100;
            AudioClip clip = AudioClip.Create("NewSound", sampleRate, 1, sampleRate, false);

            // Set Clip --------------------------------------
            var size = clip.frequency * (int)Mathf.Ceil(clip.length);
            float[] data = new float[size];

            int count = 0;
            while (count < data.Length)
            {
                data[count] = Mathf.Sin(2 * Mathf.PI * frequency * count / sampleRate);
                count++;
            }

            clip.SetData(data, 0);

            // Find or create AudioSource -----------------------
            AudioSource audioSource = obj.GetComponent<AudioSource>() ?? obj.gameObject.AddComponent<AudioSource>();

            // Play Clip ----------------------------------------
            audioSource.volume = 1;
            audioSource.PlayOneShot(clip, volume);
            Mono.Get(obj.gameObject).StartCoroutine(AudioFadeOut(audioSource, duration));
        }

        // ------------------------------------------------------------------------------------------------------------------------------        
        static IEnumerator AudioFadeOut(AudioSource audioSource, float duration)
        {
            float time = 0;
            float initValue = audioSource.volume;

            while (time < duration)
            {                
                audioSource.volume = Mathf.Lerp(initValue, 0, time / duration);
                time += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }

            audioSource.volume = 0;
            audioSource.Stop();
            yield return null;
        }                
        // ------------------------------------------------------------------------------------------------------------------------------
    }
}