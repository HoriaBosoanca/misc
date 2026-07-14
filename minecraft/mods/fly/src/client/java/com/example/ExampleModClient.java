package com.example;

import net.fabricmc.api.ClientModInitializer;
import net.fabricmc.fabric.api.client.event.lifecycle.v1.ClientTickEvents;
import net.fabricmc.fabric.api.client.keybinding.v1.KeyBindingHelper;
import net.minecraft.client.Minecraft;
import net.minecraft.client.KeyMapping;
import org.lwjgl.glfw.GLFW;

public class ExampleModClient implements ClientModInitializer {
	private static final KeyMapping fly_key = KeyBindingHelper.registerKeyBinding(new KeyMapping(
			"key.exampleMod.fly",
			GLFW.GLFW_KEY_C,
			KeyMapping.Category.MOVEMENT
	));
	@Override
	public void onInitializeClient() {
		ClientTickEvents.END_WORLD_TICK.register(client -> {
			var player = Minecraft.getInstance().player;
			if (player != null) {
				if (fly_key.consumeClick()) {
					player.getAbilities().flying = !player.getAbilities().flying;
				}
			}
		});
	}
}