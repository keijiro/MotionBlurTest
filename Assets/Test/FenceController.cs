using UnityEngine;
using System.Collections;
using Klak.Motion;

public class FenceController : MonoBehaviour
{
    [SerializeField] Transform _targetOn;
    [SerializeField] Transform _targetOff;
    [SerializeField] float _interval = 18;

    IEnumerator Start()
    {
        var follower = GetComponent<SmoothFollow>();

        yield return null;

        while (true)
        {
            follower.target = _targetOff;
            yield return new WaitForSeconds(_interval);

            follower.target = _targetOn;
            yield return new WaitForSeconds(_interval);
        }
    }
}
