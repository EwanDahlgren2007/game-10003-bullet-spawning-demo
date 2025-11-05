using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Bullet
    {
        public Vector2 position;
        public Vector2 velocity;

        float speed = 1000.0f;
        public void Setup()
        {

        }

        public void Update()
        {
            ProcessPhysics();
            DrawBullet();
        }

        void ProcessPhysics()
        {
            position += speed * velocity * Time.DeltaTime;
        }

        void DrawBullet()
        {
            Draw.LineSize = 2;
            Draw.FillColor = Color.Red;
            Draw.LineColor = new Color("#FFA500");
            Draw.Circle(position, 7);
        }
    }
}
