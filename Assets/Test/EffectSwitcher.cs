using UnityEngine;
using Kvant;

public class EffectSwitcher : MonoBehaviour
{
    [SerializeField] float _interval = 10;

    SprayMV[] _sprays;

    void Start()
    {
        _sprays = GetComponentsInChildren<SprayMV>();
    }

    void Update()
    {
        var t = Time.time * Mathf.PI / _interval;
        var v = Mathf.Clamp01(Mathf.Sin(t) * -2);
        foreach (var sp in _sprays) sp.throttle = v;
    }
}
