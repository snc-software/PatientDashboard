import React from "react";
import { styled } from "@mui/material";
import { BaseCSSProperties } from "@mui/material/styles/createMixins";
import Header from "./Header";

interface LayoutProps {
  children: React.ReactNode;
}

const Page = styled("div")(({ theme }) => ({
  backgroundColor: "#f9f9f9",
  width: "100%",
  padding: theme.spacing(3),
}));

const Root = styled("div")({
  display: "flex",
  height:"100%",
});

export const ToolbarOffest = styled("div")(({ theme }) => ({
  ...(theme.mixins.toolbar as BaseCSSProperties),
}));

export default function Layout({ children }: LayoutProps) {
  return (
    <Root>
      <Header data-testid="header"/>

        <Page>
          <ToolbarOffest />
          {children}
        </Page>
    </Root>
  );
}