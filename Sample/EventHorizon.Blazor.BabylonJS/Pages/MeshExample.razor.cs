using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabylonJS;
using EventHorizon.Blazor.BabylonJS.Model;

namespace EventHorizon.Blazor.BabylonJS.Pages
{
    public partial class MeshExample : IDisposable
    {
        private Engine _engine;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await CreateScene();
            }
        }

        public void Dispose()
        {
            _engine?.dispose();
        }

        public async ValueTask CreateScene()
        {
            var canvas = await Canvas.GetElementById(
                "game-window"
            );
            var engine = await Engine.NewEngine(
                canvas,
                true
            );
            var scene = await Scene.NewScene(
                engine
            );
            var light0 = await PointLight.NewPointLight(
                "Omni",
                await Vector3.NewVector3(
                    0,
                    100,
                    8
                ),
                scene
            );
            var light1 = await HemisphericLight.NewHemisphericLight(
                "HemisphericLight",
                await Vector3.NewVector3(
                    0,
                    100,
                    8
                ),
                scene
            );
            var house = await SceneLoader.ImportMesh(
                null,
                "assets/",
                "House.gltf",
                scene
            );
            var freeCamera = await FreeCamera.NewFreeCamera(
                "FreeCamera",
                await Vector3.NewVector3(
                    0,
                    0,
                    -100
                ),
                scene
            );
            await freeCamera.set_rotation(await Vector3.NewVector3(
                0,
                0,
                0
            ));
            await scene.set_activeCamera(freeCamera);
            await freeCamera.attachControl(
                canvas,
                false
            );
            await engine.runRenderLoop(() => Task.Run(() => scene.render(true, false)));

            _engine = engine;
        }
    }
}
