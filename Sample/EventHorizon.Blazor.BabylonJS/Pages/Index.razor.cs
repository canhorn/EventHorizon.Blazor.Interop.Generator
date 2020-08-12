using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabylonJS;
using EventHorizon.Blazor.BabylonJS.Model;

namespace EventHorizon.Blazor.BabylonJS.Pages
{
    public partial class Index : IDisposable
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
                    2,
                    8
                ),
                scene
            );
            var box1 = await Mesh.CreateBox(
                "b1",
                1.0m,
                scene
            );
            var box2 = await Mesh.CreateBox(
                "b1",
                1.0m,
                scene
            );
            await box2.set_position(await Vector3.NewVector3(
                2m,
                0,
                0
            ));
            var camera = await ArcRotateCamera.NewArcRotateCamera(
                "ArcRotateCamera",
                (decimal)(System.Math.PI / 2),
                (decimal)(System.Math.PI / 4),
                6,
                await Vector3.NewVector3(1, 0, 0),
                scene
            );
            await camera.set_lowerRadiusLimit(2);
            await camera.set_upperRadiusLimit(10);
            await camera.set_wheelDeltaPercentage(0.01m);

            await scene.set_activeCamera(camera);
            await camera.attachControl(
                canvas,
                false
            );
            await engine.runRenderLoop(() => Task.Run(() => scene.render(true, false)));

            _engine = engine;
        }
    }
}
