using UnityEngine;
using System.Collections;
using Klak.Motion;

public class FenceController : MonoBehaviour
{
    [SerializeField] Transform _targetOn;
    [SerializeField] Transform _targetOff;

    [SerializeField] bool _isOn;

    public bool isOn {
        get { return _isOn; }
        set { _isOn = value; }
    }

    [SerializeField] bool _auto = true;

    public bool auto {
        get { return _auto; }
        set { _auto = value; }
    }

    [SerializeField] float _interval = 18;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(_interval);
            if (_auto) _isOn = !_isOn;
        }
    }

    void Update()
    {
        GetComponent<SmoothFollow>().target = _isOn ? _targetOn : _targetOff;
    }
}
