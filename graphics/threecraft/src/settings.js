import * as THREE from 'three';

export const width = window.innerWidth, height = window.innerHeight;
export const camera = new THREE.PerspectiveCamera( 90, width / height, 0.01, 2000 );
export const renderer = new THREE.WebGLRenderer( { antialias: true } );
export const scene = new THREE.Scene();

export function settings_setup() {
    camera.position.z = 10;
    renderer.setSize( width, height );
    document.body.appendChild( renderer.domElement );
}