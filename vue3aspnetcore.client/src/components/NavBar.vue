<template>
  <div class="navbar">
    <div class="logo">
      <h1>在庫・受注管理システム</h1>
    </div>
    <div class="nav-actions">
      <n-space>
        <div class="user-name">{{ currentUser.name }}</div>
        <n-button type="primary" ghost @click="$emit('logout')">ログアウト</n-button>
      </n-space>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { NButton, NSpace } from "naive-ui";

const currentUser = ref({ name: "山田太郎" });
</script>

<style scoped>
.navbar {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0 1rem;
  background-color: #fff;
}

.logo h1 {
  font-size: 1.2rem;
  margin: 0;
}

.nav-actions {
  display: flex;
  align-items: center;
}

.notification-icon {
  cursor: pointer;
  color: #333;
}

.user-name {
  margin-right: 1rem;
  font-weight: bold;
  margin-top: 6px;
}
</style>
