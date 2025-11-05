// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        Bullet[] bullets = new Bullet[100];
        int bulletIndex = 0;

        int ammo = 100;
        public void Setup()
        {
            Window.SetTitle("Bullet Spawning");
            Window.SetSize(800, 600);
            Window.TargetFPS = 240;
        }
        public void Update()
        {
            Window.ClearBackground(Color.White);

            if (Input.IsMouseButtonPressed(MouseInput.Left)) SpawnBullet();

            for (int i = 0; i < bullets.Length; i++)
            // call update on all bullets
            {
                if (bullets[i] != null) bullets[i].Update();
                // skip the bullet if it hasn't been spawned yet
            }

            // if ammo is gone, right click will give me more
            if (Input.IsMouseButtonPressed (MouseInput.Right))
            {
                bullets = new Bullet[100];
            }

            Text.Draw($"Ammo: {ammo}", new Vector2(10, 10));

        }
        void SpawnBullet()
        {
            // don't spawn the bullets if you are out of ammo
            if (bullets[bulletIndex] != null) return;

            // when mouse button is pressed, spawn a bullet!
            Bullet bullet = new Bullet();

            Vector2 centerScreen = Window.Size / 2.0f;

            bullet.position = Window.Size / 2.0f;

            Vector2 centerToMouse = Input.GetMousePosition() - centerScreen;
            bullet.velocity = Vector2.Normalize(centerToMouse);

            bullets[bulletIndex] = bullet;
            bulletIndex++;

            if (bulletIndex >= bullets.Length) bulletIndex = 0;

            ammo -= 1;
        }
    }

}
