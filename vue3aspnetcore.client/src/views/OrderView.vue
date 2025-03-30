<template>
  <div class="content-area">
    <div class="action-buttons">
      <n-button type="primary">新規作成</n-button>
      <n-button type="error">
        <template #icon>
          <n-icon><trash-icon /></n-icon>
        </template>
        削除
      </n-button>
    </div>
    <n-data-table :columns="columns" :data="tableData" />
  </div>
</template>

<script lang="ts" setup>
import { createApiClient } from "@/utils/fetchWrapper";
import { NButton, type DataTableColumns } from "naive-ui";
import { h, onMounted, ref } from "vue";

interface Product {
  id: number;
  name: string;
  price: number;
  stockQuantity: number;
  categoryId?: number;
}

interface Category {
  id: number;
  name: string;
  description?: string;
}

onMounted(async () => {
  console.log("OrderView mounted");
  await fetchOrders();
});

// APIクライアントの作成
const apiClient = createApiClient("/api", {
  timeout: 10000, // 10秒
  credentials: "include",
  headers: {
    "X-App-Version": "1.0.0",
  },
});

const fetchOrders = async () => {
  const response = await apiClient.get<Product[]>("/products");
  console.log(response.data);
};

// テーブル列の定義
const columns: DataTableColumns = [
  {
    title: "商品コード",
    key: "code",
  },
  {
    title: "商品名",
    key: "name",
  },
  {
    title: "在庫数",
    key: "stock",
  },
  {
    title: "単価",
    key: "price",
  },
  {
    title: "カテゴリ",
    key: "category",
  },
  {
    title: "操作",
    key: "actions",
    render(row) {
      return h(
        "div",
        {
          class: "action-buttons-cell",
        },
        [
          h(
            NButton,
            {
              size: "small",
              quaternary: true,
              type: "info",
            },
            { default: () => "編集" }
          ),
          h(
            NButton,
            {
              size: "small",
              quaternary: true,
              type: "error",
            },
            {
              default: () => "削除",
            }
          ),
        ]
      );
    },
  },
];
// サンプルデータ
const tableData = ref([
  {
    id: 1,
    code: "ITM001",
    name: "ノートパソコン",
    stock: 24,
    price: 85000,
    category: "電子機器",
  },
  {
    id: 2,
    code: "ITM002",
    name: "プリンター",
    stock: 12,
    price: 32000,
    category: "電子機器",
  },
  {
    id: 3,
    code: "ITM003",
    name: "スマートフォン",
    stock: 45,
    price: 65000,
    category: "電子機器",
  },
  {
    id: 4,
    code: "ITM004",
    name: "USBメモリ",
    stock: 120,
    price: 2500,
    category: "アクセサリー",
  },
  {
    id: 5,
    code: "ITM005",
    name: "ワイヤレスマウス",
    stock: 35,
    price: 3200,
    category: "アクセサリー",
  },
]);
</script>

<style>
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
