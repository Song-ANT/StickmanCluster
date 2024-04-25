using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxReturnPool : MonoBehaviour
{
    AudioSource audioSource;

    IEnumerator enumerator = null;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySfx(AudioClip clip, float volume)
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();

        if (enumerator == null)
        {
            enumerator = DestroyWhenFinished();
            StartCoroutine(enumerator);

        }
        //  Debug.Log("ȿ�������");

    }

    private IEnumerator DestroyWhenFinished()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        Main.Resource.Destroy(this.gameObject, true);
        enumerator = null;

    }

    private void OnDisable()
    {
        if (enumerator != null)
            StopAllCoroutines();
    }

}
