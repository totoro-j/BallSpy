using UnityEngine;

namespace Assets.ScriptFolder.SelectScene
{
    public class BackGroundShift : MonoBehaviour
    {
        //本面板的大关CD
        //        public int SetShiftId;

        //子对象 ，为选关面板
        private GameObject _child;

        //
        //        public int ShiftId
        //        {
        //            get { return SetShiftId; }
        //        }

        // Use this for initialization
        private void Awake()
        {
            //获得子对象
            foreach (Transform child in transform)
            {
                _child = child.gameObject;
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }

        /// <summary>
        /// 本背景出现，参数为从X位置开始位移出现
        /// </summary>
        public void Appear(int formX)
        {
            //物体与子物体出现
            GetComponent<TweenAlpha>().PlayReverse();
            //            print(_child);

            _child.GetComponent<TweenPosition>().to = new Vector3(formX, 0f, 0f);
            _child.GetComponent<TweenPosition>().PlayReverse();
        }

        /// <summary>
        /// 本背景消失，参数为消失的位置
        /// </summary>
        public void Disappear(int toX)
        {
            //物体与子物体复位并播放消失动画
            GetComponent<TweenAlpha>().ResetToBeginning();
            GetComponent<TweenAlpha>().PlayForward();

            _child.GetComponent<TweenPosition>().to = new Vector3(toX, 0f, 0f);
            _child.GetComponent<TweenPosition>().ResetToBeginning();
            _child.GetComponent<TweenPosition>().PlayForward();
        }
    }
}