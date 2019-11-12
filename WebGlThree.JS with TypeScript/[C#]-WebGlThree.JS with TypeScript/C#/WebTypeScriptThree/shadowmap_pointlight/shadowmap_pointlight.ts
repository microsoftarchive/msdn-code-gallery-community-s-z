// Please see JavaScript project https://threejs.org/examples/#webgl_shadowmap_pointlight
// JavaScript project located here https://github.com/mrdoob/three.js/blob/master/examples/webgl_shadowmap_pointlight.html

namespace smpl {

    export class ShadowMapPointlight {

        private camera: THREE.PerspectiveCamera;
        private scene: THREE.Scene;
        private renderer: THREE.WebGLRenderer;
        private pointLight: THREE.PointLight;
        private pointLight2: THREE.PointLight;
        private controls: THREE.OrbitControls;

        /**
         *  Animate ShadowMapPointlight
         * */
        public animate(): void {
            this.render();
        }

        /**
          * Resizes the canvas to fit the window.
          * */
        public onWindowResize(): void {

            this.camera.aspect = window.innerWidth / window.innerHeight;
            this.camera.updateProjectionMatrix();

            this.renderer.setSize(window.innerWidth, window.innerHeight);
        }

        /**
         * Create ShadowMapPointlight object/scene
         * */
        public constructor() {
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


        private rend(): THREE.WebGLRenderer {
            let rend = new THREE.WebGLRenderer({ antialias: true });

            rend.setPixelRatio(window.devicePixelRatio);
            rend.setSize(window.innerWidth, window.innerHeight);
            rend.shadowMap.enabled = true;

            rend.shadowMap.type = THREE.BasicShadowMap;
            return rend;
        }


        private generateTexture(): HTMLCanvasElement {

            let canv = document.createElement('canvas');
            canv.width = 2;
            canv.height = 2;

            let context = canv.getContext('2d');
            context.fillStyle = 'white';
            context.fillRect(0, 1, 2, 1);
            return canv;

        }


        private createLight(color: number) {

            let intensity = 1.5;
            let plight = new THREE.PointLight(color, intensity, 20);
            plight.castShadow = true;
            plight.shadow.camera.near = 1;
            plight.shadow.camera.far = 60;
            plight.shadow.bias = - 0.005; // reduces self-shadowing on double-sided objects 


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
                    						alphaMap:  material2.alphaMap,
                    						alphaTest: material2.alphaTest 
            });

            sphere.customDistanceMaterial = distanceMaterial;
            return plight;
        }

        private mesh(): THREE.Mesh {
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


        private render(): void {

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
}
