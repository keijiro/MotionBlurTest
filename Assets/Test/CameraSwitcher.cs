using UnityEngine;
using System.Collections;
using Klak.Motion;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] Transform[] _targetList;
    [SerializeField] float _interval = 5;

    public void SetFocus(int index)
    {
        RehashMotion(_targetList[index]);
        GetComponent<SmoothFollow>().target = _targetList[index];
    }

    IEnumerator Start()
    {
        var follower = GetComponent<SmoothFollow>();

        yield return null;

        while (true)
        {
            foreach (var target in _targetList)
            {
                RehashMotion(target);
                follower.target = target;
                yield return new WaitForSeconds(_interval);
            }
        }
    }

    void RehashMotion(Transform root)
    {
        foreach (var motion in root.GetComponentsInChildren<BrownianMotion>())
            motion.Rehash();
    }
}
