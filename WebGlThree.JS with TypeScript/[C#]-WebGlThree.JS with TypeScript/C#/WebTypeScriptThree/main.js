var sl;
window.onload = () => {
    sl = new smpl.ShadowMapPointlight();
    sl.animate();
};
window.onresize = function () {
    sl.onWindowResize();
};
// !!!
// Below another example, comment out above and uncomment below.
//class Game {
//    private _scene: THREE.Scene;
//    //private _canvas: HTMLCanvasElement;
//    private _camera: THREE.PerspectiveCamera;
//    private _renderer: THREE.WebGLRenderer;
//    private _axis: THREE.AxesHelper;
//    private _light: THREE.DirectionalLight;
//    private _light2: THREE.DirectionalLight;
//    private _material: THREE.MeshBasicMaterial;
//    private _box: THREE.Mesh;
//    public constructor() {
//        //this._canvas = <HTMLCanvasElement>document.getElementById(canvasElement);
//        this._scene = new THREE.Scene(); // create the scene
//        // create the camera
//        this._camera = new THREE.PerspectiveCamera( 75, window.innerWidth / window.innerHeight, 0.1, 1000 );
//        this._renderer = new THREE.WebGLRenderer();
//        this._axis = new THREE.AxesHelper( 10 ); // add axis to the scene
//        this._light = new THREE.DirectionalLight( 0xffffff, 1.0 ); // add light1
//        this._light2 = new THREE.DirectionalLight( 0xffffff, 1.0 ); // add light2
//        this._material = new THREE.MeshBasicMaterial( {
//            color: 0xaaaaaa,
//            wireframe: true
//        } );
//        // create a box and add it to the scene
//        this._box = new THREE.Mesh( new THREE.BoxGeometry( 1, 1, 1 ), this._material );
//    }
//    public createScene(): void {
//        // set size
//        this._renderer.setSize( window.innerWidth, window.innerHeight );
//        document.body.appendChild( this._renderer.domElement ); // add canvas to dom
//        this._scene.add( this._axis );
//        this._light.position.set( 100, 100, 100 );
//        this._scene.add( this._light );
//        this._light2.position.set( -100, 100, -100 )
//        this._scene.add( this._light2 );
//        this._scene.add( this._box )
//        this._box.position.x = 0.5;
//        this._box.rotation.y = 0.5;
//        this._camera.position.x = 5;
//        this._camera.position.y = 5;
//        this._camera.position.z = 5;
//        this._camera.lookAt( this._scene.position );
//    }
//    public animate(): void {
//        requestAnimationFrame( this.animate.bind( this ) );
//        this._render();
//    }
//    private _render(): void {
//        let timer = 0.002 * Date.now();
//        this._box.position.y = 0.5 + 0.5 * Math.sin( timer );
//        this._box.rotation.x += 0.1;
//        this._renderer.render( this._scene, this._camera );
//    }
//}
//window.onload = () => {
//    let game = new Game();
//    game.createScene();
//    game.animate();
//}
// Please see JavaScript project https://threejs.org/examples/#webgl_shadowmap_pointlight
// JavaScript project located here https://github.com/mrdoob/three.js/blob/master/examples/webgl_shadowmap_pointlight.html
var smpl;
(function (smpl) {
    class ShadowMapPointlight {
        /**
         * Create ShadowMapPointlight object/scene
         * */
        constructor() {
            this.camera = new THREE.PerspectiveCamera(45, window.innerWidth / window.innerHeight, 1, 1000);
            this.camera.position.set(0, 10, 40);
            this.scene = new THREE.Scene();
            this.scene.add(new THREE.AmbientLight(0x111122));
            this.pointLight = this.createLight(0x0088ff);
            this.scene.add(this.pointLight);
            this.pointLight2 = this.createLight(0xff8888);
            this.scene.add(this.pointLight2);
            this.scene.add(this.mesh());
            this.renderer = this.rend();
            document.body.appendChild(this.renderer.domElement);
            this.controls = new THREE.OrbitControls(this.camera, this.renderer.domElement);
            this.controls.target.set(0, 10, 0);
            this.controls.update();
        }
        /**
         *  Animate ShadowMapPointlight
         * */
        animate() {
            this.render();
        }
        /**
          * Resizes the canvas to fit the window.
          * */
        onWindowResize() {
            this.camera.aspect = window.innerWidth / window.innerHeight;
            this.camera.updateProjectionMatrix();
            this.renderer.setSize(window.innerWidth, window.innerHeight);
        }
        rend() {
            let rend = new THREE.WebGLRenderer({ antialias: true });
            rend.setPixelRatio(window.devicePixelRatio);
            rend.setSize(window.innerWidth, window.innerHeight);
            rend.shadowMap.enabled = true;
            rend.shadowMap.type = THREE.BasicShadowMap;
            return rend;
        }
        generateTexture() {
            let canv = document.createElement('canvas');
            canv.width = 2;
            canv.height = 2;
            let context = canv.getContext('2d');
            context.fillStyle = 'white';
            context.fillRect(0, 1, 2, 1);
            return canv;
        }
        createLight(color) {
            let intensity = 1.5;
            let plight = new THREE.PointLight(color, intensity, 20);
            plight.castShadow = true;
            plight.shadow.camera.near = 1;
            plight.shadow.camera.far = 60;
            plight.shadow.bias = -0.005; // reduces self-shadowing on double-sided objects 
            let geometry1 = new THREE.SphereBufferGeometry(0.3, 12, 6);
            let material1 = new THREE.MeshBasicMaterial({ color: color });
            material1.color.multiplyScalar(intensity);
            let sphere = new THREE.Mesh(geometry1, material1);
            plight.add(sphere);
            let texture = new THREE.CanvasTexture(this.generateTexture());
            texture.magFilter = THREE.NearestFilter;
            texture.wrapT = THREE.RepeatWrapping;
            texture.wrapS = THREE.RepeatWrapping;
            texture.repeat.set(1, 3.5);
            let geometry2 = new THREE.SphereBufferGeometry(2, 32, 8);
            let material2 = new THREE.MeshPhongMaterial({
                side: THREE.DoubleSide,
                alphaMap: texture,
                alphaTest: 0.5
            });
            sphere = new THREE.Mesh(geometry2, material2);
            sphere.castShadow = true;
            sphere.receiveShadow = true;
            plight.add(sphere);
            //// custom distance material - was added manually to thtree.d.ts
            let distanceMaterial = new THREE.MeshDistanceMaterial({
                alphaMap: material2.alphaMap,
                alphaTest: material2.alphaTest
            });
            sphere.customDistanceMaterial = distanceMaterial;
            return plight;
        }
        mesh() {
            let geometry = new THREE.BoxBufferGeometry(30, 30, 30);
            let material = new THREE.MeshPhongMaterial({
                color: 0xa0adaf,
                shininess: 10,
                specular: 0x111111,
                side: THREE.BackSide
            });
            let mesh = new THREE.Mesh(geometry, material);
            mesh.position.y = 10;
            mesh.receiveShadow = true;
            return mesh;
        }
        render() {
            let time = performance.now() * 0.001;
            this.pointLight.position.x = Math.sin(time * 0.6) * 9;
            this.pointLight.position.y = Math.sin(time * 0.7) * 9 + 5;
            this.pointLight.position.z = Math.sin(time * 0.8) * 9;
            this.pointLight.rotation.x = time;
            this.pointLight.rotation.z = time;
            time += 10000;
            this.pointLight2.position.x = Math.sin(time * 0.6) * 9;
            this.pointLight2.position.y = Math.sin(time * 0.7) * 9 + 5;
            this.pointLight2.position.z = Math.sin(time * 0.8) * 9;
            this.pointLight2.rotation.x = time;
            this.pointLight2.rotation.z = time;
            this.renderer.render(this.scene, this.camera);
            this.controls.update();
            requestAnimationFrame(this.animate.bind(this));
        }
    }
    smpl.ShadowMapPointlight = ShadowMapPointlight;
})(smpl || (smpl = {}));
//# sourceMappingURL=main.js.map