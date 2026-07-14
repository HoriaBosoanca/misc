import { scene, camera, renderer, settings_setup } from './settings.js'
import { draw_cube } from './draw/draw.js'
import { load_materials } from './draw/textures.js'
import { blocks, Blocks } from './blocks.js'

main()

let cube

async function main() {
    settings_setup()
    
    await load_materials()
    cube = draw_cube([
        blocks.grass_side,
        blocks.grass_side,
        blocks.grass_side,
        blocks.grass_side,
        blocks.grass_top,
        blocks.dirt
    ])

    renderer.setAnimationLoop(update)
}

function update(time) {
    cube.rotation.x = time / 2000;
	cube.rotation.y = time / 1000;

    renderer.render(scene, camera)
}