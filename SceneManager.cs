using System.Collections.Generic;
using az_tanks_revived.Interfaces;

namespace az_tanks_revived;

public class SceneManager {
    private Stack<IScene> sceneStack;

    public SceneManager () {
        sceneStack = new();
    }

    public void AddScene(IScene scene) {
        scene.Load();
        sceneStack.Push(scene);
    }

    public void RemoveScene() {
        GetCurrentScene().Unload();
        sceneStack.Pop();
    }
    
    public IScene GetCurrentScene() {
        return sceneStack.Peek();
    }
}