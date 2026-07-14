package com.example;

import net.fabricmc.api.ClientModInitializer;
import net.fabricmc.fabric.api.client.event.lifecycle.v1.ClientTickEvents;
import net.fabricmc.fabric.api.client.keybinding.v1.KeyBindingHelper;
import net.minecraft.client.MinecraftClient;
import net.minecraft.client.network.ClientPlayerEntity;
import net.minecraft.client.option.KeyBinding;
import net.minecraft.entity.Entity;
import net.minecraft.entity.player.PlayerEntity;
import org.lwjgl.glfw.GLFW;

public class Killaura implements ClientModInitializer {

    private boolean killAuraIsOn = false;
    private KeyBinding killAuraKey;

    private final float MAX_ATTACK_RANGE = 4.0f;

    private int tickNumber = 0;
    private final int TICK_DELAY = 0;

    @Override
    public void onInitializeClient() {
        killAuraKey = KeyBindingHelper.registerKeyBinding(new KeyBinding("key.killAura.toggle", GLFW.GLFW_KEY_F9, "category.killAura"));

        ClientTickEvents.END_CLIENT_TICK.register(client -> {
            if (killAuraKey.wasPressed()) {
                killAuraIsOn = !killAuraIsOn;
            }
            if (killAuraIsOn && client.player != null && client.world != null) {
                for (Entity entity : client.world.getEntities()) {
                    try {
                        if (isValidEntity(entity, client)) {
                            if (tickNumber == TICK_DELAY) {
                                tickNumber = 0;
                                faceEntity(client.player, entity);
                                client.interactionManager.attackEntity(client.player, entity);
                                client.player.swingHand(client.player.getActiveHand());
                            } else {
                                tickNumber++;
                            }
                        }
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            }
        });
    }

    private boolean isValidEntity(Entity entity, MinecraftClient client) {
        return entity != client.player && entity.isAlive() && entity.isLiving() && client.player.canSee(entity) && entity instanceof PlayerEntity && client.player.distanceTo(entity) <= MAX_ATTACK_RANGE;
    }

    private void faceEntity(ClientPlayerEntity player, Entity target) {
        double dx = target.getX() - player.getX();
        double dy = target.getEyeY() - player.getEyeY();
        double dz = target.getZ() - player.getZ();
        double distance = Math.sqrt(dx * dx + dz * dz);

        float yaw = (float) (Math.atan2(dz, dx) * 180 / Math.PI - 90);
        float pitch = (float) -(Math.atan2(dy, distance) * 180 / Math.PI);

        player.setYaw(yaw);
        player.setPitch(pitch);
    }
}
