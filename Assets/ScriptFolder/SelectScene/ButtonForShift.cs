using UnityEngine;

namespace Assets.ScriptFolder.SelectScene
{
    public class ButtonForShift : MonoBehaviour
    {
        //当前场景控制对象
        private GameObject _shiftController;

        //
        public int ShiftIdIncrement;

        // Use this for initialization
        private void Start()
        {
            //获得当前切换控制对象
            _shiftController = GameObject.FindGameObjectWithTag("GameController");
        }

        // Update is called once per frame
        private void Update()
        {
            //若超出范围则禁用按钮
            if (_shiftController.GetComponent<ShiftControl>().ShiftId + ShiftIdIncrement < 0 ||
                _shiftController.GetComponent<ShiftControl>().ShiftId + ShiftIdIncrement >
                _shiftController.GetComponent<ShiftControl>().ShiftMaxId)
            {
                GetComponent<UIButton>().isEnabled = false;
            }
            else
            {
                GetComponent<UIButton>().isEnabled = true;
            }
        }
    }
}