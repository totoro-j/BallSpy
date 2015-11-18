using UnityEngine;

    public class AnimationForActivate : MonoBehaviour
    {
       	private GameObject _button;

        // Use this for initialization
        public void Start()
        {
            //
            foreach (Transform child in transform)
            {
                //获得挂在子对象的按钮
                _button = child.gameObject;
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }

        /// <summary>
        ///  播放激活动画
        ///  在按钮无效的情况下才会播放
        /// </summary>
        public void ActivateAnimation()
        {
            //
            if (_button.GetComponent<UIButton>().isEnabled == false)
            {
                GetComponent<TweenScale>().PlayForward();

                //                GetComponent<TweenRotation>().ResetToBeginning();
                //                GetComponent<TweenRotation>().PlayForward();
            }
        }

        public void Activate()
        {
			foreach (Transform child in transform)
			{
				//获得挂在子对象的按钮
				_button = child.gameObject;
			}
			if (_button.GetComponent<UIButton>().isEnabled == false)
            {
                _button.GetComponent<UIButton>().isEnabled = true;
                GetComponent<TweenScale>().PlayReverse();
            }
        }
    }