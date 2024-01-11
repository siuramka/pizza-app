import { ReactNode } from "react";
import PizzaAppBar from "../AppBar/PizzaAppBar";
import { Container } from "@mui/material";

type LayoutProps = {
  children: ReactNode;
};

const Layout = ({ children }: LayoutProps) => {
  return (
    <>
      <div style={{ marginTop: "80px" }}>
        <PizzaAppBar />
      </div>
      <Container maxWidth="lg">{children}</Container>
    </>
  );
};

export default Layout;
