using UnityEngine;
using Klak.Motion;
using System.Collections;

public class RigController : MonoBehaviour
{
    [SerializeField] float _interval = 3;
    [SerializeField] Transform[] _targets;
    [SerializeField] Transform _particleSystem;

    void Start()
    {
        StartCoroutine(CameraCoroutine());
        StartCoroutine(SprayCoroutine());
    }

    IEnumerator CameraCoroutine()
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

    IEnumerator SprayCoroutine()
    {
        var sprays = _particleSystem.GetComponentsInChildren<Kvant.SprayMV>();

        while (true)
        {
            yield return null;

            var v = Mathf.Clamp01(-2.0f * Mathf.Sin(Time.time * 0.1f));

            foreach (var spray in sprays) spray.throttle = v;
        }
    }

    void RehashPivot(Transform root)
    {
        foreach (var shaker in root.GetComponentsInChildren<BrownianMotion>())
            shaker.Rehash();
    }
}
