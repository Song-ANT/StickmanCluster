using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager 
{
    // 3D�����̴ϱ� ������ҽ��� �� �Ҹ��� ���� ������Ʈ�� �޷��־���Ѵ�.
    private bool _isMute;
    private AudioSource _currentBgm;


    public bool IsMute => _isMute;

    public void BgmPlay(AudioClip clip, float volume = 1)
    {
        if (clip == null) return;

        AudioSource currentBgm = Main.Resource.InstantiatePrefab(Define.PrefabName.AudioSource_bgm).GetComponent<AudioSource>();
        currentBgm.volume = volume;
        currentBgm.clip = clip;
        if(_isMute) currentBgm.mute = true;
        _currentBgm = currentBgm;
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

    public void BgmMuteChange()
    {
        _isMute = !_isMute;
        if(_isMute) _currentBgm.mute = true;
        else _currentBgm.mute = false;
    }
   
}
