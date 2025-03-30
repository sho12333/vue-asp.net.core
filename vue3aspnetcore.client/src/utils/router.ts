import HomeView from "@/views/HomeView.vue";
import OrderView from "@/views/OrderView.vue";
import ProductView from "@/views/ProductView.vue";
import { createRouter, createWebHistory } from "vue-router";

// ルートの定義
const routes = [
  {
    path: "/",
    name: "dashboard",
    component: HomeView,
  },
  {
    path: "/orders",
    name: "orders",
    component: OrderView,
  },
  {
    path: "/products",
    name: "products",
    component: ProductView,
  },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

// ナビゲーションガード
// router.beforeEach((to, from, next) => {
//   document.title = `${to.meta.title || "在庫・受注管理システム"}`;

//   // 認証のチェック
//   const isAuthenticated = localStorage.getItem("token") !== null;

//   if (to.meta.requiresAuth && !isAuthenticated) {
//     next({ name: "login", query: { redirect: to.fullPath } });
//   } else {
//     next();
//   }
// });

export default router;
