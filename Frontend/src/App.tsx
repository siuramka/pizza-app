import { Navigate, Route, Routes } from "react-router-dom";
import "./App.css";
import { CssBaseline } from "@mui/material";
import OrderPage from "./components/OrderPage/OrderPage";
import OrdersPage from "./components/OrdersPage.tsx/OrdersPage";
import Layout from "./components/Layout/Layout";

function App() {
  return (
    <>
      <CssBaseline />
      <Layout>
        <Routes>
          <Route path="*" element={<Navigate to="/order" replace />} />
          <Route path="/order" element={<OrderPage />}></Route>
          <Route path="/orders" element={<OrdersPage />}></Route>
        </Routes>
      </Layout>
    </>
  );
}

export default App;
