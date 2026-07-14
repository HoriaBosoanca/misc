using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Components.Visuals {
    public class Animator : MonoBehaviour {
        private SpriteRenderer _rend;
        private Sprite _prev;
        
        private float _interval;
        private Sprite[] _sprites;
        private int _index;

        private bool _stopped;
        private bool _playing;
        private void Awake() {
            _rend = GetComponent<SpriteRenderer>();
        }
        public void Play(Sprite[] sprites, float interval) {
            if (_playing) return;
            
            _prev = _rend.sprite;
            _interval = interval;
            _sprites = sprites;
            _index = 0;
            _stopped = false;
            _playing = true;
            
            StartCoroutine(Next());
        }
        public void Stop() {
            _stopped = true;
            _playing = false;
            _rend.sprite = _prev;
        }
        private IEnumerator Next() {
            yield return new WaitForSeconds(_interval);
            if (_index < _sprites.Length && !_stopped) {
                _rend.sprite = _sprites[_index++];
                StartCoroutine(Next());
            } else {
                _playing = false;
                _rend.sprite = _prev;
            }
        }
    }
}