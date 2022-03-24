using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SpaceToken.UI
{
    public class SpriteToggle : MonoBehaviour, ISpriteToggle
    {
        private int _state = 1;

        [SerializeField] private Sprite[] switchSprites;

        [SerializeField] private Image targetImage;

        public UnityEvent<int> OnSwitch;
        
        public void Start()
        {
            targetImage.sprite = switchSprites[_state];
        }

        public void Turn()
        {
            _state = 1 - _state;
            targetImage.sprite = switchSprites[_state];
            OnSwitch?.Invoke(_state);
        }
    }
}