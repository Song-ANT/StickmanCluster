using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager 
{
    // 3D게임이니까 오디오소스가 그 소리를 내는 오브젝트에 달려있어야한다.
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

    public void SfxPlay(AudioClip clip, Transform parent = null, float volume = 1) // 오디오 클립, 소리가나는 부모, 볼륨 (0~1) 
    {
        if (clip == null) return;

        SfxReturnPool audio = Main.Resource.InstantiatePrefab(Define.PrefabName.AudioSource_sfx, null, true).GetComponent<SfxReturnPool>();
        audio.transform.SetParent(parent);
        audio.transform.localPosition = Vector3.zero;

        audio.PlaySfx(clip, volume);

        // 풀로돌아가는건 오디오소스가 직접합니다

    }

    public void BgmMuteChange()
    {
        _isMute = !_isMute;
        if(_isMute) _currentBgm.mute = true;
        else _currentBgm.mute = false;
    }
   
}
