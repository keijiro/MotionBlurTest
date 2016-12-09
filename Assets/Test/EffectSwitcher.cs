using UnityEngine;
using Kvant;

public class EffectSwitcher : MonoBehaviour
{
    [SerializeField] float _throttle = 1;

    public float throttle {
        get { return _throttle; }
        set { _throttle = value; }
    }

    [SerializeField] bool _auto = true;

    public bool auto {
        get { return _auto; }
        set { _auto = value; }
    }

    [SerializeField] float _interval = 10;

    SprayMV[] _sprays;

    float autoThrottle {
        get {
            var t = Time.time * Mathf.PI / _interval;
            return Mathf.Clamp01(Mathf.Sin(t) * -2);
        }
    }

    void Start()
    {
        _sprays = GetComponentsInChildren<SprayMV>();
    }

    void Update()
    {
        var th = _auto ? autoThrottle : _throttle;
        foreach (var sp in _sprays) sp.throttle = th;
    }
}
