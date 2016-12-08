using UnityEngine;
using Klak.Motion;
using System.Collections;

public class RigController : MonoBehaviour
{
    [SerializeField] float _interval = 3;
    [SerializeField] Transform[] _targets;

    IEnumerator Start()
    {
        var follower = GetComponent<SmoothFollow>();

        yield return null;

        for (var i = 0;; i = (i + 1) % _targets.Length)
        {
            RehashPivot(_targets[i]);
            follower.target = _targets[i];
            yield return new WaitForSeconds(_interval);
        }
    }

    void RehashPivot(Transform root)
    {
        foreach (var shaker in root.GetComponentsInChildren<BrownianMotion>())
            shaker.Rehash();
    }
}
