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
import { NLayoutSider, NMenu, NButton } from "naive-ui";
import type { MenuOption, DropdownOption, DataTableColumns } from "naive-ui";

const menuOptions: MenuOption[] = [
  {
    label: "ダッシュボード",
    key: "dashboard",
  },
  {
    label: "在庫管理",
    key: "inventory",
    children: [
      {
        label: "在庫一覧",
        key: "inventory-list",
      },
      {
        label: "在庫入力",
        key: "inventory-input",
      },
      {
        label: "在庫移動",
        key: "inventory-transfer",
      },
      {
        label: "棚卸し",
        key: "inventory-count",
      },
    ],
  },
  {
    label: "受注管理",
    key: "orders",
    children: [
      {
        label: "受注一覧",
        key: "order-list",
      },
      {
        label: "受注登録",
        key: "order-create",
      },
      {
        label: "出荷管理",
        key: "order-shipping",
      },
      {
        label: "返品処理",
        key: "order-returns",
      },
    ],
  },
  {
    label: "顧客管理",
    key: "customers",
    children: [
      {
        label: "顧客一覧",
        key: "customer-list",
      },
      {
        label: "顧客登録",
        key: "customer-create",
      },
    ],
  },
  {
    label: "仕入先管理",
    key: "suppliers",
    children: [
      {
        label: "仕入先一覧",
        key: "supplier-list",
      },
      {
        label: "仕入先登録",
        key: "supplier-create",
      },
      {
        label: "発注管理",
        key: "purchase-orders",
      },
    ],
  },
  {
    label: "レポート",
    key: "reports",
    children: [
      {
        label: "在庫レポート",
        key: "report-inventory",
      },
      {
        label: "売上レポート",
        key: "report-sales",
      },
      {
        label: "商品分析",
        key: "report-product-analysis",
      },
    ],
  },
  {
    label: "システム設定",
    key: "settings",
  },
];

// ドロップダウンメニューのオプション
const userOptions: DropdownOption[] = [
  {
    label: "プロフィール",
    key: "profile",
  },
  {
    label: "アカウント設定",
    key: "account-settings",
  },
  {
    label: "ログアウト",
    key: "logout",
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
