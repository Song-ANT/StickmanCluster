using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class Splat : MonoBehaviour
{
    private float _time;
    private float _fadeTime = 1f;
    private Color _color;

    private SpriteRenderer _render;
    private Color _renderColor;

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
        _renderColor = _render.color;
    }

    public void SetInit(Color color)
    {
        _time = 0;
        _color = color;
        _renderColor = color;
    }


    void Update()
    {
        if (_time < _fadeTime)
        {
            _render.color = new Color(_color.r, _color.g, _color.b, 1f - _time / _fadeTime);
        }
        else
        {
            _time = 0;
            _color = Color.white;
            _renderColor = Color.white;
            Main.Pool.Push(this.gameObject, true);
        }
        _time += Time.deltaTime;
    }
    
}
