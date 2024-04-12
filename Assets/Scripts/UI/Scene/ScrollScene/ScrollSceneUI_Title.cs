using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrollSceneUI_Title : MonoBehaviour
{
    public Button startBtn;

    public void OnStartBtn()
    {
        SceneManager.LoadScene(Define.SceneName.Game);
    }
}
