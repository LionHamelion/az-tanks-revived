using System;
using az_tanks_revived.Interfaces;

namespace az_tanks_revived;

public static class DependencyFactory
{
    private static SceneManager sceneManager;

    public static void RegisterSceneManager(SceneManager manager)
    {
        sceneManager = manager;
    }

    public static IScene GetCurrentScene()
    {
        if (sceneManager == null)
            throw new InvalidOperationException("SceneManager is not registered in the DependencyFactory.");

        return sceneManager.GetCurrentScene();
    }
}
