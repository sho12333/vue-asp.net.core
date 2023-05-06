import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    proxy: {
      "/api": {
        target: "https://localhost:7108",
        changeOrigin: true,
        ws: true,
      },
    },
    build: {
      rollupOptions: {
        external: ["axios"],
      },
    },
    optimizeDeps: {
      include: ["axios"],
    },
  },
});
