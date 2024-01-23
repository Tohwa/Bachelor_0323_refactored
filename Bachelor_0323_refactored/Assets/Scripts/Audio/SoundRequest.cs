using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRequest
{
    public AudioData Sound { get; }

    public bool Is2D { get; }
    public Vector3 Position { get; }

    public string Group {  get; }

    private SoundRequest(bool _is2D, Vector3 _position, AudioData _sound, string _group)
    {
        Sound = _sound;
        Is2D = _is2D;
        Position = _position;
        Group = _group;
    }

    public static SoundRequest Request(bool _is2D, Vector3 _position, AudioData _sound, string _group)
    {
        return new SoundRequest( _is2D, _position, _sound, _group);
    }
}
