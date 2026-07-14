package com.example;

import net.fabricmc.api.ClientModInitializer;
import net.fabricmc.fabric.api.client.event.lifecycle.v1.ClientTickEvents;
import net.fabricmc.fabric.api.client.keybinding.v1.KeyBindingHelper;
import net.minecraft.client.MinecraftClient;
import net.minecraft.client.network.ClientPlayerEntity;
import net.minecraft.client.option.KeyBinding;
import net.minecraft.entity.attribute.EntityAttributes;
import org.lwjgl.glfw.GLFW;

public class MyHack implements ClientModInitializer {

	private KeyBinding speedBoostKey;
	private KeyBinding jumpBoostKey;
	private KeyBinding reachBoostKey;

	private boolean speedIsOn = false;
	private boolean jumpIsOn = false;
	private boolean reachIsOn = false;

	@Override
	public void onInitializeClient() {

		speedBoostKey = KeyBindingHelper.registerKeyBinding(new KeyBinding("key.myHack.speedBoost", GLFW.GLFW_KEY_F6, "category.myHack"));
		jumpBoostKey = KeyBindingHelper.registerKeyBinding(new KeyBinding("key.myHack.jumpBoost", GLFW.GLFW_KEY_F7, "category.myHack"));
		reachBoostKey = KeyBindingHelper.registerKeyBinding(new KeyBinding("key.myHack.reachBoost", GLFW.GLFW_KEY_F8, "category.myHack"));

		ClientTickEvents.START_WORLD_TICK.register(client -> {
			if (MinecraftClient.getInstance().player != null) {
				ClientPlayerEntity player = MinecraftClient.getInstance().player;

				// speed:
				if (speedBoostKey.wasPressed()) {
					speedIsOn = !speedIsOn;
				}
				if (speedIsOn) {
					player.getAttributeInstance(EntityAttributes.MOVEMENT_SPEED).setBaseValue(0.3);
				} else {
					player.getAttributeInstance(EntityAttributes.MOVEMENT_SPEED).setBaseValue(0.1);
				}

				// jump boost:
				if (jumpBoostKey.wasPressed()) {
					if (!jumpIsOn) {
						jumpIsOn = true;
						player.getAttributeInstance(EntityAttributes.JUMP_STRENGTH).setBaseValue(0.7);
					} else {
						jumpIsOn = false;
						player.getAttributeInstance(EntityAttributes.JUMP_STRENGTH).setBaseValue(0.4);
					}
				}

				// reach (Both for attack and blocks by 1 block - which is the max):
				if (reachBoostKey.wasPressed()) {
					if (!reachIsOn) {
						reachIsOn = true;
						player.getAttributeInstance(EntityAttributes.ENTITY_INTERACTION_RANGE).setBaseValue(6);
						player.getAttributeInstance(EntityAttributes.BLOCK_INTERACTION_RANGE).setBaseValue(6);
					} else {
						reachIsOn = false;
						player.getAttributeInstance(EntityAttributes.ENTITY_INTERACTION_RANGE).setBaseValue(3);
						player.getAttributeInstance(EntityAttributes.BLOCK_INTERACTION_RANGE).setBaseValue(4.5);
					}
				}

				// flight:
				player.getAbilities().allowFlying = true;

				// TODO:
				// safeTP
				// killaura
			}
		});
	}
}
