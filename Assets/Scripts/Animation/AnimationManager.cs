using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimationSetup> animatorSetups;

    public enum AnimationType
    {
        RUN,
        IDLE,
        DEATH
    }

    public void Play(AnimationType type)
    {
        animatorSetups.ForEach(i =>
        {
            if (i.type == type)
            {
                animator.SetTrigger(i.trigger);
            }
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(AnimationType.RUN);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(AnimationType.IDLE);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(AnimationType.DEATH);
        }
    }
}

[System.Serializable]
public class AnimationSetup
{
    public AnimationManager.AnimationType type;
    public string trigger;
}
