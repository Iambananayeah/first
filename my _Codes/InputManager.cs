using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerInput
{

    public enum InputType
    {
        MouseAndKeyboard,
    }


    public class InputManager: MonoInstance<InputManager>
    {


        public InputType inputType = InputType.MouseAndKeyboard;

        bool m_FixedUpdateHappened;

        private List<Button> buttons = new List<Button>();

        public InputButton test = new InputButton(KeyCode.K);

        public override void init()
        {
            base.init();
            buttons.Add(test);
        }



        void Update()
        {
            GetInputs(m_FixedUpdateHappened || Mathf.Approximately(Time.timeScale, 0));

            m_FixedUpdateHappened = false;
        }

        void FixedUpdate()
        {
            m_FixedUpdateHappened = true;
        }

        protected void GetInputs(bool fixedUpdateHappened)
        {
            foreach (Button b in buttons)
            {
                b.Get(fixedUpdateHappened, inputType);
            }
        }

        public  void GainControls()
        {

        }

        public  void ReleaseControls(bool resetValues = true)
        {

        }


    }

    public interface IButton
    {
        public void Get(bool fixedUpdateHappened, InputType inputType);
        public void Enable();
        public void Disable();
    }
    public class Button : IButton
    {
        public bool NotNeedGainAndReleaseControl;

        public virtual void Get(bool fixedUpdateHappened, InputType inputType) { }


        public virtual void Enable()
        {
        }

        public virtual void Disable()
        {
        }

    }



    [Serializable]
    public class InputButton : Button
    {
        public KeyCode key;
        public bool Down { get; protected set; }
        public bool Held { get; protected set; }
        public bool Up { get; protected set; }
        public bool IsValid { get; protected set; }
        public bool Enabled
        {
            get { return m_Enabled; }
        }
        public bool BufferEnabled
        {
            get { return m_BufferEnabled; }
        }

        [SerializeField]
        protected bool m_Enabled = true;
        protected bool m_BufferEnabled = true;
        protected int m_FrameCount;

        //This is used to change the state of a button (Down, Up) only if at least a FixedUpdate happened between the previous Frame
        //and this one. Since movement are made in FixedUpdate, without that an input could be missed it get press/release between fixedupdate
        bool m_AfterFixedUpdateDown;
        bool m_AfterFixedUpdateHeld;
        bool m_AfterFixedUpdateUp;



        public InputButton(KeyCode key)
        {
            this.key = key;
        }

        public override void Get(bool fixedUpdateHappened, InputType inputType)
        {
            if (!m_Enabled)
            {
                return;
            }

            if (inputType == InputType.MouseAndKeyboard)
            {
                if (fixedUpdateHappened)
                {
                    Down = Input.GetKeyDown(key);
                    Held = Input.GetKey(key);
                    Up = Input.GetKeyUp(key);

                    m_AfterFixedUpdateDown = Down;
                    m_AfterFixedUpdateHeld = Held;
                    m_AfterFixedUpdateUp = Up;
                }
                else//update键入后，在下一个fixedupdate发生前认为一直有键入 目的是为了不丢失输入
                {
                    Down = Input.GetKeyDown(key) || m_AfterFixedUpdateDown;
                    Held = Input.GetKey(key) || m_AfterFixedUpdateHeld;
                    Up = Input.GetKeyUp(key) || m_AfterFixedUpdateUp;

                    m_AfterFixedUpdateDown |= Down;
                    m_AfterFixedUpdateHeld |= Held;
                    m_AfterFixedUpdateUp |= Up;
                }
            }
            IsValidUpdate(Down);

        }
        public void IsValidUpdate(bool conditions)
        {
            if (!m_BufferEnabled)
                return;
            if (conditions)
            {
                m_FrameCount = Constants.BufferFrameTime;
            }

            // 一次按下只触发一次IsValid
            if (m_FrameCount >= Constants.BufferFrameTime)
            {
                IsValid = true;
                --m_FrameCount;
            }
            else
            {
                IsValid = false;
            }
        }

        public override void Enable()//
        {
            m_Enabled = true;
        }

        public override void Disable()//冻结控制
        {
            if (NotNeedGainAndReleaseControl) return;

            m_Enabled = false;
            Down = false;
            Held = false;
            Up = false;
            m_AfterFixedUpdateDown = false;
            m_AfterFixedUpdateHeld = false;
            m_AfterFixedUpdateUp = false;

            m_FrameCount = 0;
            IsValid = false;
        }

    }

    [Serializable]
    public class InputAxis : Button
    {
        public KeyCode positive;
        public KeyCode negative;
        public float Value { get; protected set; }//can only be -1 0 or 1

        public float ValueBuffer;
        private bool m_BufferEnabled = true;
        private int m_FrameCount;
        public bool ReceivingInput { get; protected set; }
        public bool Enabled
        {
            get { return m_Enabled; }
        }

        protected bool m_Enabled = true;


        public InputAxis(KeyCode positive, KeyCode negative)
        {
            this.positive = positive;
            this.negative = negative;
        }

        public override void Get(bool fixedUpdateHappened, InputType inputType)
        {
            if (!m_Enabled)
            {
                return;
            }

            bool positiveHeld = false;
            bool negativeHeld = false;


            if (inputType == InputType.MouseAndKeyboard)
            {
                positiveHeld = Input.GetKey(positive);
                negativeHeld = Input.GetKey(negative);
            }

            if (positiveHeld == negativeHeld)
                Value = 0f;
            else if (positiveHeld)
                Value = 1f;
            else
                Value = -1f;

            ReceivingInput = positiveHeld || negativeHeld;

            IsValidUpdate(ReceivingInput);
        }
        public void IsValidUpdate(bool ReceivingInput)
        {
            if (!m_BufferEnabled)
                return;
            if (ReceivingInput)
            {
                m_FrameCount = Constants.BufferFrameTime;
                ValueBuffer = Value;
                return;
            }


            if (m_FrameCount > 0)
            {
                --m_FrameCount;
            }
            else
            {
                ValueBuffer = 0;
            }
        }
        public override void Enable()
        {
            m_Enabled = true;
        }

        public override void Disable()
        {
            if (NotNeedGainAndReleaseControl) return;

            m_Enabled = false;
            Value = 0f;
        }

    }
}