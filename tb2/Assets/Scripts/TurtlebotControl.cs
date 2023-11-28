using RosSharp.RosBridgeClient.MessageTypes.Sensor;
using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VelUtils;

namespace RosSharp.RosBridgeClient
{
    public class TurtlebotControl : UnityPublisher<MessageTypes.Sensor.Joy>
    {
        [SerializeField]
        private Rig rig;
        private Joy message;
        private float speed;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
            speed = 1.0f;
        }

        private void InitializeMessage()
        {
            message = new Joy
            {
                
                axes = new float[] { 0.0f, 0.0f, 0.0f, 0.0f }, // Initialize axes
                buttons = new int[] { 0, 0, 0, 0 } // Initialize buttons
            };
            message.header.frame_id = "joystick";
        }

        private void Update()
        {
            //float horizontal = InputMan.ThumbstickX(Side.Left);
            //float vertical = InputMan.ThumbstickY(Side.Left);

            //bool useForce = false;
            //Vector3 forward = -rig.head.forward;
            //forward.y = 0;
            //forward.Normalize();

            //Vector3 right = new Vector3(-forward.z, 0, forward.x);


            //if (useForce)
            //{
            //Vector3 forwardForce = Time.deltaTime * vertical * forward * 1000f;
            //if (Mathf.Abs(Vector3.Dot(rig.rb.velocity, rig.head.forward)) < slidingSpeed)
            //{
            //    rig.rb.AddForce(forwardForce);
            //}

            //Vector3 rightForce = Time.deltaTime * horizontal * right * 1000f;
            //if (Mathf.Abs(Vector3.Dot(rig.rb.velocity, rig.head.right)) < slidingSpeed)
            //{
            //    rig.rb.AddForce(rightForce);
            //}
            //}
            //else
            //{
            //    Vector3 currentSpeed = rig.rb.velocity;
            //    Vector3 forwardSpeed = vertical * forward;
            //    Vector3 rightSpeed = horizontal * right;
            //    Vector3 speed = forwardSpeed + rightSpeed;
            //    //rig.rb.velocity = slidingSpeed * speed + (currentSpeed.y * rig.rb.transform.up);
            //}
            // Update the message based on input
            //message.axes[0] = /* get axis value */;
            //message.axes[1] = /* get axis value */;
            // ... set other axes and button values

            //float horizontal = Input.GetAxis("Horizontal"); // Assuming "Horizontal" is the name of the joystick's horizontal axis
            //float vertical = Input.GetAxis("Vertical"); // Assuming "Vertical" is the name of the joystick's vertical axis
            if (InputMan.Button1Down(Side.Right))
            {
                speed += 1;
            }
            else if (InputMan.Button2Down(Side.Right))
            {
                speed -= 1;
            }
            
            float horizontal = InputMan.ThumbstickX(Side.Right) * speed;
            float vertical = InputMan.ThumbstickY(Side.Right) * speed;
            Debug.Log(horizontal);
            // Update the axes array with the joystick's current position
            // The axes array might need to be adjusted depending on the joystick's layout and how many axes it has
            message.axes[0] = horizontal;
            Debug.Log(vertical);
            message.axes[1] = vertical;
            //Debug.Log(speed);
            // Publish the message
            Publish(message);
        }
    }
}
