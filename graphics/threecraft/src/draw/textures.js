import * as THREE from 'three'
import { Blocks } from '../blocks.js'

const textureLoader = new THREE.TextureLoader()

export let materials = new Blocks()

export async function load_materials() {
    for(let block of Object.keys(materials)) {
        materials[block] = await load_material_async(`../../assets/${block}.png`)
    }
}

async function load_material_async(path) {
    const texture = await new Promise((resolve, reject) => {
        textureLoader.load(path, resolve, undefined, reject)
    })
    texture.colorSpace = THREE.SRGBColorSpace
    texture.magFilter = THREE.NearestFilter
    return new THREE.MeshBasicMaterial({ map: texture })
}