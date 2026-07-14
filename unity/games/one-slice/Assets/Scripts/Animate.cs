using System;
using System.Collections;
using UnityEngine;

public class Animate : MonoBehaviour
{
    [SerializeField] private float animateCooldown;
    [SerializeField] private string state = "null";
    
    private Coroutine _animateCoroutine = null;

    // if the state changes, stop the previous animation and start the new one
    // if the state is updated to the same state, don't restart the current animation
    public void UpdateState(string updatedState, Sprite[] sprites, bool looping, Action loopEndCallback = null)
    {
        if (state != updatedState)
        {
            StopAnimation();
            _animateCoroutine =  StartCoroutine(StartAnimation(sprites, looping, loopEndCallback));
        }
        state = updatedState;
    }
    
    private IEnumerator StartAnimation(Sprite[] sprites, bool looping, Action loopEndCallback)
    {
        do
        {
            foreach (var s in sprites)
            {
                GetComponent<SpriteRenderer>().sprite = s;
                yield return new WaitForSeconds(animateCooldown);
            }
            loopEndCallback?.Invoke();
        }
        while (looping);
    }

    private void StopAnimation()
    {
        if (_animateCoroutine != null)
        {
            StopCoroutine(_animateCoroutine);
        }
        _animateCoroutine = null;
    }
}
