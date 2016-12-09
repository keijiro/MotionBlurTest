using UnityEngine;
using System.Collections;
using Klak.Motion;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] Transform[] _targetList;

    [SerializeField] bool _enableRotation;

    public bool enableRotation {
        get { return _enableRotation; }
        set { _enableRotation = value; }
    }

    [SerializeField] bool _auto = true;

    public bool auto {
        get { return _auto; }
        set { _auto = value; }
    }

    [SerializeField] float _interval = 5;

    IEnumerator Start()
    {
        var follower = GetComponent<SmoothFollow>();

        yield return null;

        while (true)
        {
            foreach (var target in _targetList)
            {
                if (_auto)
                {
                    RehashMotion(target);
                    follower.target = target;
                }
                yield return new WaitForSeconds(_interval);
            }

            if (_auto) _enableRotation = !_enableRotation;
        }
    }

    void Update()
    {
        foreach (var target in _targetList)
        {
            target.GetComponentInParent<ConstantMotion>().enabled = _enableRotation;
            target.GetComponentInParent<BrownianMotion>().enabled = !_enableRotation;
        }
    }

    void RehashMotion(Transform root)
    {
        foreach (var motion in root.GetComponentsInChildren<BrownianMotion>())
            motion.Rehash();
    }
}
