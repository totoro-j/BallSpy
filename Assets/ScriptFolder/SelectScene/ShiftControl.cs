using System.Collections.Generic;
using UnityEngine;

namespace Assets.ScriptFolder.SelectScene
{
    public class ShiftControl : MonoBehaviour
    {
        //切换到的大关ID
        public int ShiftId;

        //当前进度
        public int ShiftMaxId;

        // 解锁动画
        public EventDelegate[] UnclockAnimation;

        public List<GameObject> SelectBackGroundList;

        // Use this for initialization
        private void Start()
        {
            //出现默认
            SelectBackGroundList[ShiftId].GetComponent<BackGroundShift>().Appear(0);
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void ToNext()
        {
            //当切换到最新关卡或者最后关卡时
            //直接返回
            if (ShiftId >= ShiftMaxId ||
                ShiftId >= SelectBackGroundList.Count)
            {
                return;
            }

            //播放当前切换消失动画
            SelectBackGroundList[ShiftId].GetComponent<BackGroundShift>().Disappear(-100);

            ShiftId++;

            //播放当前切换出现动画
            SelectBackGroundList[ShiftId].GetComponent<BackGroundShift>().Appear(100);
        }

        public void ToLast()
        {
            //当切换到最前关卡时
            //直接返回
            if (ShiftId <= 0)
            {
                return;
            }

            //播放当前切换消失动画
            SelectBackGroundList[ShiftId].GetComponent<BackGroundShift>().Disappear(100);

            ShiftId--;

            //播放当前切换出现动画
            SelectBackGroundList[ShiftId].GetComponent<BackGroundShift>().Appear(-100);
        }

        //播放解锁动画
        public void PlayUnclockAnimation()
        {
            foreach (EventDelegate anim in UnclockAnimation)
            {
                anim.Execute();
            }
        }
    }
}