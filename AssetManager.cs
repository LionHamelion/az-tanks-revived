using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace az_tanks_revived;

public class AssetManager
{
    private static AssetManager _instance;
    public static AssetManager Instance => _instance ??= new AssetManager();

    private ContentManager _contentManager;
    private GraphicsDevice _graphicsDevice;
    private Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();
    private bool _isInitialized = false;

    private AssetManager() { }

    public void Initialize(ContentManager contentManager, GraphicsDevice graphicsDevice)
    {
        _contentManager = contentManager;
        _graphicsDevice = graphicsDevice;
        _isInitialized = true;
    }

    private void EnsureInitialized()
    {
        if (!_isInitialized)
        {
            throw new InvalidOperationException("AssetManager has not been initialized.");
        }
    }

    public Texture2D GetTexture(string assetName)
    {
        EnsureInitialized();
        if (!_textures.ContainsKey(assetName))
        {
            _textures[assetName] = _contentManager.Load<Texture2D>(assetName);
        }
        return _textures[assetName];
    }

    public Texture2D GetPixelTexture()
    {
        const string pixelKey = "pixel";
        if (!_textures.ContainsKey(pixelKey))
        {
            Texture2D pixel = new Texture2D(_graphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
            _textures[pixelKey] = pixel;
        }
        return _textures[pixelKey];
    }

    public Texture2D GetCircleTexture(int radius, Color color, bool filled = true)
    {
        EnsureInitialized();
        string key = $"circle_{radius}_{color.PackedValue}_{filled}";
        if (!_textures.ContainsKey(key))
        {
            Texture2D texture = new Texture2D(_graphicsDevice, radius * 2, radius * 2);
            Color[] data = new Color[texture.Width * texture.Height];

            float diam = radius * 2;
            float diamsq = diam * diam;

            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    int index = x * texture.Width + y;
                    Vector2 pos = new Vector2(x - radius, y - radius);
                    float distanceSquared = pos.LengthSquared();
                    if (filled)
                    {
                        if (distanceSquared <= diamsq / 4)
                        {
                            data[index] = color;
                        }
                        else
                        {
                            data[index] = Color.Transparent;
                        }
                    }
                    else
                    {
                        float outerRadius = radius;
                        float innerRadius = radius - 1;
                        if (distanceSquared <= outerRadius * outerRadius && distanceSquared >= innerRadius * innerRadius)
                        {
                            data[index] = color;
                        }
                        else
                        {
                            data[index] = Color.Transparent;
                        }
                    }
                }
            }

            texture.SetData(data);
            _textures[key] = texture;
        }
        return _textures[key];
    }
    public Texture2D ColorizeTexture(Texture2D grayscale, Color color)
    {
        // Отримуємо розміри текстури
        int width = grayscale.Width;
        int height = grayscale.Height;

        // Створюємо масив для збереження пікселів
        Color[] data = new Color[width * height];
        grayscale.GetData(data);

        // Проходимося по кожному пікселю та змінюємо його колір
        for (int i = 0; i < data.Length; i++)
        {
            // Використовуємо червоний канал як грейскейл значення
            float grayscaleValue = data[i].R / 255f;

            // Застосовуємо бажаний колір з врахуванням грейскейл
            data[i] = new Color(
                (int)(color.R * grayscaleValue),
                (int)(color.G * grayscaleValue),
                (int)(color.B * grayscaleValue),
                data[i].A // Зберігаємо альфа-канал
            );
        }

        // Створюємо нову текстуру та встановлюємо нові дані
        Texture2D coloredTexture = new Texture2D(grayscale.GraphicsDevice, width, height);
        coloredTexture.SetData(data);
        return coloredTexture;
    }
    public void UnloadTexture(string assetName)
    {
        if (_textures.ContainsKey(assetName))
        {
            _textures[assetName].Dispose();
            _textures.Remove(assetName);
        }
    }

    public void UnloadAll()
    {
        foreach (var texture in _textures.Values)
        {
            texture.Dispose();
        }
        _textures.Clear();
    }
}