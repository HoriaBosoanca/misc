import * as THREE from 'three'
import { scene } from '../settings.js'
import { materials } from './textures.js'

export function draw_cube(types) {
    const mesh = new THREE.Mesh(new THREE.BoxGeometry( 1, 1, 1 ), types.map(type => materials[type]))
    scene.add(mesh)
    return mesh
}