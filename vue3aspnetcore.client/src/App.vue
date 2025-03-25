<template>
  <n-layout position="absolute">
    <n-layout-header style="height: 64px; padding: 12px" bordered>
      <NavBar />
    </n-layout-header>
    <n-layout has-sider class="main-content" position="absolute" style="top: 64px; bottom: 64px">
      <SideBar />
      <n-layout>
        <RouterView />
      </n-layout>
    </n-layout>
  </n-layout>
</template>

<script setup lang="ts">
import SideBar from "@/components/SideBar.vue";
import NavBar from "./components/NavBar.vue";
</script>

<style>
.app-container {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.main-content {
  height: 100vh;
}
</style>
