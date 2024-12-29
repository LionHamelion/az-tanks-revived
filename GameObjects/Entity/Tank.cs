using System;
using az_tanks_revived.GameObjects.Static;
using az_tanks_revived.HitboxSystem;
using az_tanks_revived.Interfaces;
using az_tanks_revived.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace az_tanks_revived.GameObjects.Entity;

public class Tank: Entity, ICollidable
{
    private readonly Turret turret;
    private Rectangle textureBounds = new Rectangle((int)-50f, (int)-70f, 100, 140);
    private float boundsWidth = 90;
    private float boundsHeight = 120;
    public RectHitbox Bounds
    {
        get
        {
            return new RectHitbox(
                Transform.Position.X - 45f, // Центруємо хітбокс за X
                Transform.Position.Y - 60f, // Центруємо хітбокс за Y
                boundsWidth,  // Ширина
                boundsHeight  // Висота
            );
        }
    }
    public Tank (Vector2 position, Vector2 velocity, GameScene scene) {
        Transform.Position = position;
        Velocity = velocity;
        turret = new BasicTurret(this);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        Texture2D tankTexture = AssetManager.Instance.GetTexture("tank_grayscale_light");
        Texture2D pixel = AssetManager.Instance.GetPixelTexture();
        tankTexture = AssetManager.Instance.ColorizeTexture(tankTexture, new Color(0, 255, 0));
        spriteBatch.Draw(
            tankTexture,
            new Rectangle(
                (int)(Transform.Position.X + textureBounds.X), 
                (int)(Transform.Position.Y + textureBounds.Y), 
                textureBounds.Width, 
                textureBounds.Height),
            null,
            Color.White,
            Transform.Rotation,
            Vector2.Zero,
            SpriteEffects.None,
            0f
        );
        // spriteBatch.Draw(
        //     pixel,
        //     new Rectangle((int)Transform.Position.X, (int)Transform.Position.Y, 1, 1),
        //     null,
        //     Color.Red,
        //     Transform.Rotation,
        //     Vector2.Zero,
        //     SpriteEffects.None,
        //     0f
        // );
        // spriteBatch.Draw(
        //     pixel,
        //     new Rectangle((int)(Transform.Position.X - boundsWidth/2), (int)(Transform.Position.Y - boundsHeight/2), (int)boundsWidth, (int)boundsHeight),
        //     null,
        //     Color.Red,
        //     Transform.Rotation,
        //     Vector2.Zero,
        //     SpriteEffects.None,
        //     0f
        // );
    }
    public override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.W)) {
            Velocity = new Vector2(0, -4);
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.S)) {
            Velocity = new Vector2(0, 4);
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.A)) {
            Velocity = new Vector2(-4, 0);
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.D)) {
            Velocity = new Vector2(4, 0);
        }
        else {
            Velocity = Vector2.Zero;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
            turret.Shoot();
        }
        base.Update(gameTime);
    }
    public Hitbox GetHitbox() => Bounds;
    public void Destroy() {
        boundsWidth = boundsHeight = 0;
        textureBounds = Rectangle.Empty;
    }

    public void OnCollision(GameObject other)
    {
        switch (other)
        {
            case Tank tank:
                Transform.Position -= Velocity;
                break;
    
            case Wall:
                Transform.Position -= Velocity;
                break;
    
            default:
                break;
        }
    }

    internal void Load(ContentManager contentManager)
    {
        Console.WriteLine("Tank loaded");
    }
}
