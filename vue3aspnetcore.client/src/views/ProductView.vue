<template>
  <div class="content-area">
    <div class="action-buttons">
      <n-button type="primary" @click="openAddModal">新規作成</n-button>
      <n-button type="error" :disabled="!selectedRows.length" @click="confirmDelete">削除</n-button>
    </div>

    <!-- 製品テーブル -->
    <n-data-table
      :columns="columns"
      :data="products"
      :loading="loading"
      :pagination="pagination"
      :row-key="(row) => row.id"
    />

    <!-- 製品追加/編集モーダル -->
    <n-modal v-model:show="showModal" :mask-closable="false">
      <n-card
        :title="editingProduct ? '製品編集' : '新規製品登録'"
        style="width: 600px"
        :bordered="false"
        size="huge"
        role="dialog"
        aria-modal="true"
      >
        <n-form
          ref="formRef"
          :model="productForm"
          :rules="rules"
          label-placement="left"
          label-width="100"
        >
          <n-form-item path="code" label="商品コード">
            <n-input v-model:value="productForm.code" placeholder="例: PC-001" />
          </n-form-item>

          <n-form-item path="name" label="商品名">
            <n-input v-model:value="productForm.name" placeholder="製品名を入力" />
          </n-form-item>

          <n-form-item path="description" label="説明">
            <n-input
              v-model:value="productForm.description"
              type="textarea"
              placeholder="製品の説明を入力"
            />
          </n-form-item>

          <n-form-item path="price" label="価格">
            <n-input-number
              v-model:value="productForm.price"
              :min="0"
              :precision="0"
              style="width: 100%"
            />
          </n-form-item>

          <n-form-item path="stockQuantity" label="在庫数">
            <n-input-number
              v-model:value="productForm.stockQuantity"
              :min="0"
              :precision="0"
              style="width: 100%"
            />
          </n-form-item>

          <n-form-item path="categoryId" label="カテゴリ">
            <n-select
              v-model:value="productForm.categoryId"
              :options="categoryOptions"
              placeholder="カテゴリを選択"
              clearable
            />
          </n-form-item>
        </n-form>

        <template #footer>
          <div style="display: flex; justify-content: flex-end; gap: 12px">
            <n-button @click="closeModal">キャンセル</n-button>
            <n-button type="primary" @click="saveProduct" :loading="saving">保存</n-button>
          </div>
        </template>
      </n-card>
    </n-modal>

    <!-- 削除確認ダイアログ -->
    <n-modal v-model:show="showDeleteConfirm" preset="dialog">
      <template #header>
        <div>製品の削除</div>
      </template>
      選択した {{ selectedRows.length }} 件の製品を削除しますか？
      <template #action>
        <div style="display: flex; justify-content: flex-end; gap: 12px">
          <n-button @click="showDeleteConfirm = false">キャンセル</n-button>
          <n-button type="error" @click="deleteProducts" :loading="deleting">削除</n-button>
        </div>
      </template>
    </n-modal>
  </div>
</template>

<script lang="ts" setup>
import { ref, computed, onMounted, h } from "vue";
import { createApiClient } from "@/utils/fetchWrapper";
import {
  NButton,
  NDataTable,
  NModal,
  NCard,
  NForm,
  NFormItem,
  NInput,
  NInputNumber,
  NSelect,
  useMessage,
  type FormRules,
  type DataTableColumns,
  type FormInst,
} from "naive-ui";

// インターフェース定義
interface Product {
  id: number;
  code: string;
  name: string;
  description: string;
  price: number;
  stockQuantity: number;
  categoryId?: number;
  category?: {
    id: number;
    name: string;
    description?: string;
  };
  createdAt?: string;
  updatedAt?: string;
}

interface Category {
  id: number;
  name: string;
  description?: string;
}

// 状態管理
const products = ref<Product[]>([]);
const categories = ref<Category[]>([]);
const loading = ref(false);
const saving = ref(false);
const deleting = ref(false);
const showModal = ref(false);
const showDeleteConfirm = ref(false);
const selectedRows = ref<number[]>([]);
const editingProduct = ref<Product | null>(null);
const formRef = ref<FormInst | null>(null);
const message = useMessage();

// ページネーション設定
const pagination = ref({
  page: 1,
  pageSize: 10,
  showSizePicker: true,
  pageSizes: [10, 20, 50],
  onChange: (page: number) => {
    pagination.value.page = page;
  },
  onUpdatePageSize: (pageSize: number) => {
    pagination.value.pageSize = pageSize;
    pagination.value.page = 1;
  },
});

// フォーム初期値
const initialProductForm = {
  id: 0,
  code: "",
  name: "",
  description: "",
  price: 0,
  stockQuantity: 0,
  categoryId: undefined as number | undefined,
};

const productForm = ref({ ...initialProductForm });

// バリデーションルール
const rules: FormRules = {
  code: [
    { required: true, message: "商品コードは必須です", trigger: "blur" },
    { max: 50, message: "50文字以内で入力してください", trigger: "blur" },
  ],
  name: [
    { required: true, message: "商品名は必須です", trigger: "blur" },
    { max: 100, message: "100文字以内で入力してください", trigger: "blur" },
  ],
  price: [
    { required: true, type: "number", message: "価格は必須です", trigger: "blur" },
    { type: "number", min: 0, message: "0以上の値を入力してください", trigger: "blur" },
  ],
  stockQuantity: [
    { required: true, type: "number", message: "在庫数は必須です", trigger: "blur" },
    { type: "number", min: 0, message: "0以上の値を入力してください", trigger: "blur" },
  ],
};

// カテゴリオプションの計算プロパティ
const categoryOptions = computed(() => {
  return categories.value.map((category) => ({
    label: category.name,
    value: category.id,
  }));
});

// APIクライアントの作成
const apiClient = createApiClient("/api", {
  timeout: 10000,
  credentials: "include",
});

// 製品の取得
const fetchProducts = async () => {
  loading.value = true;
  try {
    const response = await apiClient.get<any>("/products");

    if (response.error) {
      message.error(response.error || "製品の取得に失敗しました");
      return;
    }

    // System.Text.Json形式のレスポンスに対応
    if (response.data && response.data.$values) {
      products.value = response.data.$values;
    } else if (Array.isArray(response.data)) {
      products.value = response.data;
    } else {
      products.value = [];
      message.error("データの形式が正しくありません");
    }
  } catch (error) {
    message.error("製品の取得中にエラーが発生しました");
  } finally {
    loading.value = false;
  }
};

// カテゴリの取得
const fetchCategories = async () => {
  try {
    const response = await apiClient.get<any>("/products/categories");

    if (response.error) {
      message.error(response.error || "カテゴリの取得に失敗しました");
      return;
    }

    // System.Text.Json形式のレスポンスに対応
    if (response.data && response.data.$values) {
      categories.value = response.data.$values;
    } else if (Array.isArray(response.data)) {
      categories.value = response.data;
    } else {
      categories.value = [];
    }
  } catch (error) {
    message.error("カテゴリの取得中にエラーが発生しました");
  }
};

// モーダルを開く
const openAddModal = () => {
  editingProduct.value = null;
  productForm.value = { ...initialProductForm };
  showModal.value = true;
};

// 編集モーダルを開く
const openEditModal = (product: Product) => {
  editingProduct.value = product;
  productForm.value = {
    id: product.id,
    code: product.code,
    name: product.name,
    description: product.description || "",
    price: product.price,
    stockQuantity: product.stockQuantity,
    categoryId: product.categoryId,
  };
  showModal.value = true;
};

// モーダルを閉じる
const closeModal = () => {
  showModal.value = false;
  editingProduct.value = null;
};

// 製品の保存（新規/更新）
const saveProduct = () => {
  if (!formRef.value) return;

  formRef.value.validate(async (errors) => {
    if (errors) {
      return;
    }

    saving.value = true;
    try {
      let response;
      if (editingProduct.value) {
        // 更新
        response = await apiClient.put<Product>(
          `/products/${productForm.value.id}`,
          productForm.value
        );
      } else {
        // 新規作成
        response = await apiClient.post<Product>("/products", productForm.value);
      }

      if (response.error) {
        message.error(response.error || "保存中にエラーが発生しました");
        return;
      }

      message.success(editingProduct.value ? "製品を更新しました" : "製品を登録しました");
      showModal.value = false;
      await fetchProducts();
    } catch (error) {
      message.error("製品の保存中にエラーが発生しました");
    } finally {
      saving.value = false;
    }
  });
};

// 削除確認ダイアログを表示
const confirmDelete = () => {
  if (!selectedRows.value.length) return;
  showDeleteConfirm.value = true;
};

// チェックボックス選択時のハンドラー
const handleCheck = (rowKeys: number[]) => {
  selectedRows.value = rowKeys;
};

// 製品の削除
const deleteProducts = async () => {
  if (!selectedRows.value.length) return;

  deleting.value = true;
  try {
    for (const id of selectedRows.value) {
      const response = await apiClient.delete<void>(`/products/${id}`);
      if (response.error) {
        message.error(`ID ${id} の製品の削除に失敗しました`);
      }
    }

    message.success("選択した製品を削除しました");
    showDeleteConfirm.value = false;
    selectedRows.value = [];
    await fetchProducts();
  } catch (error) {
    message.error("製品の削除中にエラーが発生しました");
  } finally {
    deleting.value = false;
  }
};

// テーブル列の定義
const columns: DataTableColumns<Product> = [
  {
    type: "selection",
    width: 50,
    fixed: "left",
  },
  {
    title: "ID",
    key: "id",
    width: 80,
  },
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
    key: "stockQuantity",
  },
  {
    title: "単価",
    key: "price",
    render(row) {
      return `¥${row.price?.toLocaleString() || "0"}`;
    },
  },
  {
    title: "カテゴリ",
    key: "category",
    render(row) {
      return row.category ? row.category.name : "-";
    },
  },
  {
    title: "操作",
    key: "actions",
    width: 120,
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
              onClick: () => openEditModal(row),
            },
            {
              default: () => "編集",
            }
          ),
          h(
            NButton,
            {
              size: "small",
              quaternary: true,
              type: "error",
              onClick: () => {
                selectedRows.value = [row.id];
                confirmDelete();
              },
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

// コンポーネントマウント時の処理
onMounted(async () => {
  await Promise.all([fetchProducts(), fetchCategories()]);
});
</script>

<style>
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
