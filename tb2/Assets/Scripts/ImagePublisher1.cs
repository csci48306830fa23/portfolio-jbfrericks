using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class ImagePublisher1 : UnityPublisher<MessageTypes.Sensor.Image>
    {
        public Camera ImageCamera;
        public string FrameId = "Camera";
        public int resolutionWidth = 640;
        public int resolutionHeight = 480;

        private MessageTypes.Sensor.Image message;
        private Texture2D texture2D;
        private Rect rect;

        protected override void Start()
        {
            base.Start();
            InitializeGameObject();
            InitializeMessage();
            Camera.onPostRender += UpdateImage;
        }

        private void UpdateImage(Camera _camera)
        {
            if (texture2D != null && _camera == this.ImageCamera)
                UpdateMessage();
        }

        private void InitializeGameObject()
        {
            texture2D = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGB24, false);
            rect = new Rect(0, 0, resolutionWidth, resolutionHeight);
            ImageCamera.targetTexture = new RenderTexture(resolutionWidth, resolutionHeight, 24);
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Sensor.Image();
            message.header.frame_id = FrameId;
            message.height = (uint)resolutionHeight;
            message.width = (uint)resolutionWidth;
            message.encoding = "rgb8";
            message.is_bigendian = 0;
            message.step = (uint)(3 * resolutionWidth); // 3 bytes per pixel for RGB8 encoding
        }

        private void UpdateMessage()
        {
            message.header.Update();
            texture2D.ReadPixels(rect, 0, 0);
            texture2D.Apply();
            message.data = texture2D.GetRawTextureData();
            Publish(message);
        }
    }
}
