<template>
  <n-layout-sider
    bordered
    collapse-mode="width"
    :collapsed-width="64"
    :width="240"
    :collapsed="collapsed"
    show-trigger
    @collapse="collapsed = true"
    @expand="collapsed = false"
  >
    <n-menu
      :collapsed="collapsed"
      :collapsed-width="64"
      :collapsed-icon-size="22"
      :options="menuOptions"
    />
  </n-layout-sider>
</template>

<script setup lang="ts">
import { h, ref } from "vue";
import { NLayoutSider, NMenu } from "naive-ui";
import type { MenuOption } from "naive-ui";
import { RouterLink } from "vue-router";

const menuOptions: MenuOption[] = [
  {
    label: "ダッシュボード",
    key: "dashboard",
  },
  {
    label: () =>
      h(
        RouterLink,
        {
          to: {
            name: "orders",
          },
        },
        { default: () => "受注一覧" }
      ),
    key: "orders",
  },
  {
    label: () =>
      h(
        RouterLink,
        {
          to: {
            name: "products",
          },
        },
        { default: () => "製品一覧" }
      ),
    key: "products",
  },
];

// サイドバーの折りたたみ状態
const collapsed = ref(false);
</script>

<style scoped>
.header-content {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0 20px;
  height: 64px;
}

.header-actions {
  display: flex;
  gap: 12px;
  align-items: center;
}

.content-area {
  padding: 20px;
  min-height: calc(100vh - 64px);
}

.action-buttons {
  display: flex;
  gap: 12px;
  margin-bottom: 16px;
}

.action-buttons-cell {
  display: flex;
  gap: 8px;
}
</style>
