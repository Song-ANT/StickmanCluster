using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager 
{
    // 3D�����̴ϱ� ������ҽ��� �� �Ҹ��� ���� ������Ʈ�� �޷��־���Ѵ�.

    public void BgmPlay(AudioClip clip, float volume = 1)
    {
        if (clip == null) return;

        AudioSource currentBgm = Main.Resource.InstantiatePrefab(Define.PrefabName.AudioSource_bgm).GetComponent<AudioSource>();
        currentBgm.volume = volume;
        currentBgm.clip = clip;
        currentBgm.Play();

    }

    public void SfxPlay(AudioClip clip, Transform parent = null, float volume = 1) // ����� Ŭ��, �Ҹ������� �θ�, ���� (0~1) 
    {
        if (clip == null) return;

        SfxReturnPool audio = Main.Resource.InstantiatePrefab(Define.PrefabName.AudioSource_sfx, null, true).GetComponent<SfxReturnPool>();
        audio.transform.SetParent(parent);
        audio.transform.localPosition = Vector3.zero;

        audio.PlaySfx(clip, volume);

        // Ǯ�ε��ư��°� ������ҽ��� �����մϴ�

    }

    public void BtnSound()
    {
        SfxPlay(Main.Resource.Load<AudioClip>("switch37"));
    }
}
